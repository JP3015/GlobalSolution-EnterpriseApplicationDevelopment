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
    public class CarrosController : Controller
    {
        private readonly Contexto _context;

        public CarrosController(Contexto context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
              return View(await _context.Carro.ToListAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Modelo,EstacionamentoId")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Modelo,EstacionamentoId")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
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
            return View(carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carro == null)
            {
                return Problem("Entity set 'Contexto.Carro'  is null.");
            }
            var carro = await _context.Carro.FindAsync(id);
            if (carro != null)
            {
                _context.Carro.Remove(carro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
          return _context.Carro.Any(e => e.Id == id);
        }
    }
}
