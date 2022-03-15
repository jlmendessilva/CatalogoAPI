using CatalogoAPI.Context;
using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categoria.AsNoTracking().Include(p => p.Produto).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categoria.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var cat = _context.Categoria.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (cat == null)
                return NotFound();

            return cat;
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria c)
        {
            _context.Categoria.Add(c);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = c.Id }, c);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Categoria c)
        {
            if (id == c.Id)
                return NotFound();

            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var cat = _context.Categoria.FirstOrDefault(c => c.Id == id);

            if (cat == null)
                return NotFound();

            _context.Categoria.Remove(cat);
            _context.SaveChanges();

            return cat;
        }
    }
}
