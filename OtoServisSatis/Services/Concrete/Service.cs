using Data;
using Data.Abstract;
using Data.Concrete;
using Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class Service<T> : GenericRepository<T>,IService<T> where T : class, IBaseEntity, new()
    {
        public Service(SectionsContext context) : base(context)
        {
        }
    }
}
