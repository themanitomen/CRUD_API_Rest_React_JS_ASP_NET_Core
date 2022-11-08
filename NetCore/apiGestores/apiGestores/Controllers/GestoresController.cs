using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GestoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _context.gestores_bd.ToListAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}", Name = "GetGestor")]
        public async Task<ActionResult> Get(int Id)
        {
            try
            {
                return Ok(await _context.gestores_bd.Where(p => p.Id == Id).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]GestoresBD gestor)
        {
            try
            {
                _context.gestores_bd.Add(gestor);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetGestor", new { Id = gestor.Id }, gestor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, [FromBody] GestoresBD gestor)
        {
            try
            {
                if (gestor.Id == Id)
                {
                    _context.Entry(gestor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return CreatedAtRoute("GetGestor", new { Id = gestor.Id }, gestor);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                GestoresBD gestor = await _context.gestores_bd.FirstOrDefaultAsync(p => p.Id == Id);
                if (gestor != null)
                {
                    _context.gestores_bd.Remove(gestor);
                    await _context.SaveChangesAsync();
                    return Ok(Id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
