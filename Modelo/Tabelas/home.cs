using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class home
    {
        public IQueryable<Produto> listaProdutoLancamento;
        public IQueryable<Produto> listaProdutoDestaque;
    }
}
