using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoAPI.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produto = new Collection<Produto>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Img { get; set; }
        public ICollection<Produto> Produto { get; set; }

    }
}
