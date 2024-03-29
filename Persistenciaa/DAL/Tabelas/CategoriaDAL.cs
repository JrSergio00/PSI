﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistenciaa.Contexts;
using Modelo.Tabelas;
using System.Data.Entity;

namespace Persistenciaa.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }
        public Categoria ObterCategoriaPorId(long id)
        {
            return context.Categorias.Where(c => c.CategoriaId == id).Include("Produtos.Frabricante").First();
        }
        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == 0)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}