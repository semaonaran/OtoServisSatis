using Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IService<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
    }
}
