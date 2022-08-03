using System;
using System.Linq;
using System.Threading.Tasks;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EstoqueWebContext _context;

        public EnderecoController(EstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index(int? cid)
        {
            if (cid.HasValue)
            {
                var cliente = await _context.Clientes.FindAsync(cid);
                if (cliente != null)
                {
                    _context.Entry(cliente).Collection(c => c.Enderecos).Load();
                    ViewBag.Cliente = cliente;
                    return View(cliente.Enderecos);
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Cliente não encontrado.", TipoMensagem.Erro);
                    return RedirectToAction("Index", "Cliente");
                }
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Só é possível mostrar endereços de um cliente específico.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? cid, int? eid)
        {
            if (cid.HasValue)
            {
                var cliente = await _context.Clientes.FindAsync(cid);
                if (cliente != null)
                {
                    ViewBag.Cliente = cliente;
                    if (eid.HasValue)
                    {
                        _context.Entry(cliente).Collection(c => c.Enderecos).Load();
                        var endereco = cliente.Enderecos.FirstOrDefault(e => e.IdEndereco == eid);
                        if (endereco != null)
                        {
                            return View(endereco);
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Endereço não encontrado.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        return View(new EnderecoModel());
                    }
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Cliente não encontrado.", TipoMensagem.Erro);
                }
                return RedirectToAction("Index");
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Nenhum proprietário de endereços foi informado.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }
        }

        private bool EnderecoExiste(int cid, int eid)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdUsuario == cid)
                .Enderecos.Any(e => e.IdEndereco == eid);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] int? idUsuario,
            [FromForm] EnderecoModel endereco)
        {
            if (idUsuario.HasValue)
            {
                var cliente = await _context.Clientes.FindAsync(idUsuario);
                ViewBag.Cliente = cliente;

                if (ModelState.IsValid)
                {
                    if (cliente.Enderecos.Count() == 0) endereco.Selecionado = true;
                    endereco.CEP = ObterCepNormalizado(endereco.CEP);
                    if (endereco.IdEndereco > 0)
                    {
                        if (endereco.Selecionado)
                            cliente.Enderecos.ToList().ForEach(e => e.Selecionado = false);

                        if (EnderecoExiste(idUsuario.Value, endereco.IdEndereco))
                        {
                            var enderecoAtual = cliente.Enderecos
                                .FirstOrDefault(e => e.IdEndereco == endereco.IdEndereco);
                            _context.Entry(enderecoAtual).CurrentValues.SetValues(endereco);
                            if (_context.Entry(enderecoAtual).State == EntityState.Unchanged)
                            {
                                TempData["mensagem"] = MensagemModel.Serializar("Nenhum dado do endereço foi alterado.");
                            }
                            else
                            {
                                if (await _context.SaveChangesAsync() > 0)
                                {
                                    TempData["mensagem"] = MensagemModel.Serializar("Endereço alterado com sucesso.");
                                }
                                else
                                {
                                    TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar endereço.");
                                }
                            }
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Endereço não encontrado.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        var idEndereco = cliente.Enderecos.Count() > 0 ? cliente.Enderecos.Max(e => e.IdEndereco) + 1 : 1;
                        endereco.IdEndereco = idEndereco;
                        _context.Clientes.FirstOrDefault(c => c.IdUsuario == idUsuario).Enderecos.Add(endereco);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Endereço cadastrado com sucesso.");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar endereço.");
                        }
                    }
                    return RedirectToAction("Index", "Endereco", new { cid = idUsuario });
                }
                else
                {
                    return View(endereco);
                }
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Nenhum proprietário de endereços foi informado.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }
        }

        private string ObterCepNormalizado(string cep)
        {
            string cepNormalizado = cep.Replace("-", "").Replace(".", "").Trim();
            return cepNormalizado.Insert(5, "-");
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? cid, int? eid)
        {
            if (!cid.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Cliente não informado.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }

            if (!eid.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Endereço não informado.", TipoMensagem.Erro);
                return RedirectToAction("Index", new { cid = cid });
            }

            var cliente = await _context.Clientes.FindAsync(cid);
            var endereco = cliente.Enderecos.FirstOrDefault(e => e.IdEndereco == eid);
            if (endereco == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Endereço não encontrado.", TipoMensagem.Erro);
                return RedirectToAction("Index", new { cid = cid });
            }

            ViewBag.Cliente = cliente;
            return View(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int idUsuario, int idEndereco)
        {
            var cliente = await _context.Clientes.FindAsync(idUsuario);
            var endereco = cliente.Enderecos.FirstOrDefault(e => e.IdEndereco == idEndereco);
            if (endereco != null)
            {
                cliente.Enderecos.Remove(endereco);
                if (await _context.SaveChangesAsync() > 0)
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Endereço excluído com sucesso.");
                    if (endereco.Selecionado && cliente.Enderecos.Count() > 0)
                    {
                        cliente.Enderecos.FirstOrDefault().Selecionado = true;
                        await _context.SaveChangesAsync();
                    }
                }
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir o endereço.", TipoMensagem.Erro);                
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Endereço não encontrado.", TipoMensagem.Erro);                
            }
            return RedirectToAction("Index", new { cid = idUsuario });
        }
    }
}