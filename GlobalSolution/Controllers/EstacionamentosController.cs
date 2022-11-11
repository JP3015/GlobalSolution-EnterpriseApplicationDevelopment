using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Models;

namespace GlobalSolution.Controllers
{
    public class EstacionamentosController : Controller
    {
        private readonly Contexto _context;

        public EstacionamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Estacionamentos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Estacionamento.ToListAsync());
        }

        // GET: Estacionamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estacionamento == null)
            {
                return NotFound();
            }

            var estacionamento = await _context.Estacionamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacionamento == null)
            {
                return NotFound();
            }

            return View(estacionamento);
        }

        // GET: Estacionamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estacionamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local")] Estacionamento estacionamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estacionamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamento);
        }

        // GET: Estacionamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estacionamento == null)
            {
                return NotFound();
            }

            var estacionamento = await _context.Estacionamento.FindAsync(id);
            if (estacionamento == null)
            {
                return NotFound();
            }
            return View(estacionamento);
        }

        // POST: Estacionamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Local")] Estacionamento estacionamento)
        {
            if (id != estacionamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacionamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacionamentoExists(estacionamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estacionamento);
        }

        // GET: Estacionamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estacionamento == null)
            {
                return NotFound();
            }

            var estacionamento = await _context.Estacionamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacionamento == null)
            {
                return NotFound();
            }

            return View(estacionamento);
        }

        // POST: Estacionamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estacionamento == null)
            {
                return Problem("Entity set 'Contexto.Estacionamento'  is null.");
            }
            var estacionamento = await _context.Estacionamento.FindAsync(id);
            if (estacionamento != null)
            {
                _context.Estacionamento.Remove(estacionamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstacionamentoExists(int id)
        {
          return _context.Estacionamento.Any(e => e.Id == id);
        }
    }
}
