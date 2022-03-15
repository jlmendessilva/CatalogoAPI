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
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _context.Produto.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produto.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;


        }

        [HttpPost]
        public ActionResult Post([FromBody]Produto p)
        {
            _context.Produto.Add(p);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = p.Id }, p);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Produto p)
        {
            if (id != p.Id)
                return NotFound();

            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produto.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound();

            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return produto;
        }
        
    }
}
