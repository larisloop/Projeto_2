using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaViagem.Models;

namespace AgenciaViagem.Controllers
{
    public class PassageirosController : Controller
    {
        private readonly BancoDeDados _context;

        public PassageirosController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: Passageiros
        public async Task<IActionResult> Index()
        {
            var bancoDeDados = _context.Passageiros.Include(p => p.Destino).Include(p => p.Hotel);
            return View(await bancoDeDados.ToListAsync());
        }

        // GET: Passageiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros
                .Include(p => p.Destino)
                .Include(p => p.Hotel)
                .FirstOrDefaultAsync(m => m.CodigoCliente == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // GET: Passageiros/Create
        public IActionResult Create()
        {
            ViewData["DestinoIdDestino"] = new SelectList(_context.Destinos, "IdDestino", "LocalDestino");
            ViewData["HotelIdHotel"] = new SelectList(_context.Hoteis, "IdHotel", "Nome");
            return View();
        }

        // POST: Passageiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCliente,Nome,Identidade,Idade,Email,DestinoIdDestino,HotelIdHotel")] Passageiro passageiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passageiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoIdDestino"] = new SelectList(_context.Destinos, "IdDestino", "LocalDestino", passageiro.DestinoIdDestino);
            ViewData["HotelIdHotel"] = new SelectList(_context.Hoteis, "IdHotel", "Nome", passageiro.HotelIdHotel);
            return View(passageiro);
        }

        // GET: Passageiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros.FindAsync(id);
            if (passageiro == null)
            {
                return NotFound();
            }
            ViewData["DestinoIdDestino"] = new SelectList(_context.Destinos, "IdDestino", "LocalDestino", passageiro.DestinoIdDestino);
            ViewData["HotelIdHotel"] = new SelectList(_context.Hoteis, "IdHotel", "Nome", passageiro.HotelIdHotel);
            return View(passageiro);
        }

        // POST: Passageiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCliente,Nome,Identidade,Idade,Email,DestinoIdDestino,HotelIdHotel")] Passageiro passageiro)
        {
            if (id != passageiro.CodigoCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passageiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassageiroExists(passageiro.CodigoCliente))
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
            ViewData["DestinoIdDestino"] = new SelectList(_context.Destinos, "IdDestino", "LocalDestino", passageiro.DestinoIdDestino);
            ViewData["HotelIdHotel"] = new SelectList(_context.Hoteis, "IdHotel", "Nome", passageiro.HotelIdHotel);
            return View(passageiro);
        }

        // GET: Passageiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros
                .Include(p => p.Destino)
                .Include(p => p.Hotel)
                .FirstOrDefaultAsync(m => m.CodigoCliente == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // POST: Passageiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passageiro = await _context.Passageiros.FindAsync(id);
            _context.Passageiros.Remove(passageiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassageiroExists(int id)
        {
            return _context.Passageiros.Any(e => e.CodigoCliente == id);
        }
    }
}
