using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoAPI.Controllers
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Desc { get; set; }
        public decimal Preco { get; set; }
        public string Img { get; set; }
        public float Qtde { get; set; }
        public DateTime Dtcad { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
