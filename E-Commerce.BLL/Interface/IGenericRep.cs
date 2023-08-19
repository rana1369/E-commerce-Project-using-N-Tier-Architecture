using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Interface
{
    public interface IGenericRep<TEntity>
    {
        List<TEntity> Get();
        TEntity GetById(int id);
        TEntity Create(TEntity obj);
        TEntity Edit(TEntity obj);
        void Delete(int id);

    }
}
