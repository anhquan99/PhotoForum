using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.ModelService
{
    interface IService<T>
    {
        bool create(T t);
        T findById(String id);
        List<T> findAll();
        bool update(T t);
        bool deleteById(String id);
    }
}
