using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BletchleyBreaker.Web.Data;
using BletchleyBreaker.Web.Models;

namespace BletchleyBreaker.Web.Controllers
{
    public class GameSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameSessions
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameSessions.ToListAsync());
        }

        // GET: GameSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameSession = await _context.GameSessions
                .FirstOrDefaultAsync(m => m.GameSessionId == id);
            if (gameSession == null)
            {
                return NotFound();
            }

            return View(gameSession);
        }

        // GET: GameSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameSessionId,Player1Id,Player2Id,TargetCoordinates,CurrentPlayerId,IsGameOver,AttemptsLeft")] GameSession gameSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameSession);
        }

        // GET: GameSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameSession = await _context.GameSessions.FindAsync(id);
            if (gameSession == null)
            {
                return NotFound();
            }
            return View(gameSession);
        }

        // POST: GameSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameSessionId,Player1Id,Player2Id,TargetCoordinates,CurrentPlayerId,IsGameOver,AttemptsLeft")] GameSession gameSession)
        {
            if (id != gameSession.GameSessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameSessionExists(gameSession.GameSessionId))
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
            return View(gameSession);
        }

        // GET: GameSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameSession = await _context.GameSessions
                .FirstOrDefaultAsync(m => m.GameSessionId == id);
            if (gameSession == null)
            {
                return NotFound();
            }

            return View(gameSession);
        }

        // POST: GameSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameSession = await _context.GameSessions.FindAsync(id);
            if (gameSession != null)
            {
                _context.GameSessions.Remove(gameSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameSessionExists(int id)
        {
            return _context.GameSessions.Any(e => e.GameSessionId == id);
        }
    }
}
