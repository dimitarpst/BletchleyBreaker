using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class GuessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guesses.ToListAsync());
        }

        // GET: Guesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guess = await _context.Guesses
                .FirstOrDefaultAsync(m => m.GuessId == id);
            if (guess == null)
            {
                return NotFound();
            }

            return View(guess);
        }

        // GET: Guesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuessId,GameSessionId,PlayerId,GuessedCoordinates,CorrectNumbers,CorrectPositions")] Guess guess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guess);
        }

        // GET: Guesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guess = await _context.Guesses.FindAsync(id);
            if (guess == null)
            {
                return NotFound();
            }
            return View(guess);
        }

        // POST: Guesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuessId,GameSessionId,PlayerId,GuessedCoordinates,CorrectNumbers,CorrectPositions")] Guess guess)
        {
            if (id != guess.GuessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuessExists(guess.GuessId))
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
            return View(guess);
        }

        // GET: Guesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guess = await _context.Guesses
                .FirstOrDefaultAsync(m => m.GuessId == id);
            if (guess == null)
            {
                return NotFound();
            }

            return View(guess);
        }

        // POST: Guesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guess = await _context.Guesses.FindAsync(id);
            if (guess != null)
            {
                _context.Guesses.Remove(guess);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuessExists(int id)
        {
            return _context.Guesses.Any(e => e.GuessId == id);
        }
    }
}
