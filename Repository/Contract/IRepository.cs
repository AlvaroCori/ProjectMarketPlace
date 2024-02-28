//using ProjectMarketPlace.Service.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ProjectMarketPlace.Repository.Contract
{
    public interface IRepository<ENTITY, DTO> where ENTITY : class where DTO : class
    {
        protected DbContext Context { get; }

        async Task<DTO> FindById(int id)
        {
            var item = await Context.Set<ENTITY>().FindAsync(id);
            if (item == null)
            {
                throw new Exception("Elemento no encontrado");
            }
            return null;

        }
    }
}
