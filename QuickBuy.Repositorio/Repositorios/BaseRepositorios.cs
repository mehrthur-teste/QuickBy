using Quickbuy.Dominio.Contratos;
using QuickBuy.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Repositorio.Repositorios
{
    public class BaseRepositorios<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
       protected readonly QuickBuyContexto QuickBuyContexto;

       public  BaseRepositorios(QuickBuyContexto quickBuyContexto) 
        {
            QuickBuyContexto = quickBuyContexto;

        }

        public void Adicionar(TEntity entity)
        {
            // throw new NotImplementedException();
            QuickBuyContexto.Set<TEntity>().Add(entity);
            QuickBuyContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            //throw new NotImplementedException();
            QuickBuyContexto.Set<TEntity>().Update(entity);
            QuickBuyContexto.SaveChanges();
        }

        
        public TEntity ObterPorId(int id)
        {
            //throw new NotImplementedException();
            return QuickBuyContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {


            //throw new NotImplementedException();
            return QuickBuyContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            //throw new NotImplementedException();
            QuickBuyContexto.Remove(entity);
            QuickBuyContexto.SaveChanges();

        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            QuickBuyContexto.Dispose();
        }

    }
}
