﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal1.Data;
using ProyectoFinal1.Models;

namespace ProyectoFinal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tbl_detalle_viajeEntityController : ControllerBase
    {
        private readonly ProyectoFinal1Context _context;

        public tbl_detalle_viajeEntityController(ProyectoFinal1Context context)
        {
            _context = context;
        }

        // GET: api/tbl_detalle_viajeEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_detalle_viaje>>> Gettbl_detalle_viaje()
        {
            return await _context.tbl_detalle_viaje.ToListAsync();
        }

        // GET: api/tbl_detalle_viajeEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_detalle_viaje>> Gettbl_detalle_viaje(int id)
        {
            var tbl_detalle_viaje = await _context.tbl_detalle_viaje.FindAsync(id);

            if (tbl_detalle_viaje == null)
            {
                return NotFound();
            }

            return tbl_detalle_viaje;
        }

        // PUT: api/tbl_detalle_viajeEntity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_detalle_viaje(int id, tbl_detalle_viaje tbl_detalle_viaje)
        {
            if (id != tbl_detalle_viaje.id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_detalle_viaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_detalle_viajeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/tbl_detalle_viajeEntity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_detalle_viaje>> Posttbl_detalle_viaje(tbl_detalle_viaje tbl_detalle_viaje)
        {
            _context.tbl_detalle_viaje.Add(tbl_detalle_viaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_detalle_viaje", new { id = tbl_detalle_viaje.id }, tbl_detalle_viaje);
        }

        // DELETE: api/tbl_detalle_viajeEntity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_detalle_viaje(int id)
        {
            var tbl_detalle_viaje = await _context.tbl_detalle_viaje.FindAsync(id);
            if (tbl_detalle_viaje == null)
            {
                return NotFound();
            }

            _context.tbl_detalle_viaje.Remove(tbl_detalle_viaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_detalle_viajeExists(int id)
        {
            return _context.tbl_detalle_viaje.Any(e => e.id == id);
        }
    }
}
