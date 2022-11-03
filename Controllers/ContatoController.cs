using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_mvc_net_core.Context;
using Projeto_mvc_net_core.Models;

namespace Projeto_mvc_net_core.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        // construtor recebendo a classe de contexto de banco de dados AgendaContext
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }

        public IActionResult Editar(int id)
        {

            var contato = _context.Contatos.Find(id);

            if (contato.Id == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoNoBanco = _context.Contatos.Find(contato.Id);

            contatoNoBanco.Nome = contato.Nome;
            contatoNoBanco.Telefone = contato.Telefone;
            contatoNoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoNoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato){
            var contatoNoBanco = _context.Contatos.Find(contato.Id);

            _context.Contatos.Remove(contatoNoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}