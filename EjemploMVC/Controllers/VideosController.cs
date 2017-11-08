using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EjemploMVC.Models;

namespace EjemploMVC.Controllers
{
    public class VideosController : Controller
    {
        private readonly EjemploMVCContext _context;

        public VideosController(EjemploMVCContext context)
        {
            _context = context;
        }

        // GET: Videos
        public async Task<IActionResult> Index(string vGenero, string vBusqueda)
        {
            IQueryable<string> busquedaGenero = from m in _context.Videos
                                                orderby m.Genero
                                                select m.Genero;

            var Videos = from m in _context.Videos select m;
            if (!String.IsNullOrEmpty(vBusqueda))
            {
                Videos = Videos.Where(s => s.Titulo.Contains(vBusqueda));
                  }

            if (!String.IsNullOrEmpty(vGenero))
            {
                Videos = Videos.Where(s => s.Genero == vGenero);
            }
            var VistageneroMV = new VistaGenero();
            VistageneroMV.Generos = new SelectList(await busquedaGenero.Distinct().ToListAsync() );
            VistageneroMV.L_Videos = await Videos.ToListAsync();


            return View(VistageneroMV);
        }
        public async Task<IActionResult> Lista(string vGenero, string vBusqueda)
        {
            IQueryable<string> busquedaGenero = from m in _context.Videos
                                                orderby m.Genero
                                                select m.Genero;

            var Videos = from m in _context.Videos select m;
            if (!String.IsNullOrEmpty(vBusqueda))
            {
                Videos = Videos.Where(s => s.Titulo.Contains(vBusqueda));
            }

            if (!String.IsNullOrEmpty(vGenero))
            {
                Videos = Videos.Where(s => s.Genero == vGenero);
            }
            var VistageneroMV = new VistaGenero();
            VistageneroMV.Generos = new SelectList(await busquedaGenero.Distinct().ToListAsync());
            VistageneroMV.L_Videos = await Videos.ToListAsync();


            return View(VistageneroMV);
        }
        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,FechaEstreno,Genero,Precio,Stock,Rating")] Videos videos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videos);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos.SingleOrDefaultAsync(m => m.ID == id);
            if (videos == null)
            {
                return NotFound();
            }
            return View(videos);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,FechaEstreno,Genero,Precio,Stock,Rating")] Videos videos)
        {
            if (id != videos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideosExists(videos.ID))
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
            return View(videos);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videos = await _context.Videos.SingleOrDefaultAsync(m => m.ID == id);
            _context.Videos.Remove(videos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideosExists(int id)
        {
            return _context.Videos.Any(e => e.ID == id);
        }
    }
}
