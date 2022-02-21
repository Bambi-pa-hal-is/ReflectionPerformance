using ReflectionPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService.FastReflection
{
    public class FastReflectionCloneService : ICloneService
    {
        public FastReflectionMapper FastReflectionMapper { get; set; }

        public FastReflectionCloneService()
        {
            FastReflectionMapper = new FastReflectionMapper();
        }
        public Report Clone(Report report)
        {
            return Clone<Report>(report);
        }

        public T? Clone<T>(T clone)
        {
            if(clone == null) return default;

            var mappedClass = FastReflectionMapper.GetMappedClass<T>();
            var newClone = (T)mappedClass.Constructor();
            foreach(var prop in mappedClass.Properties)
            {
                prop.Setter(newClone, prop.Getter(clone));
            }

            return newClone;
        }

        public void Map<T>()
        {
            FastReflectionMapper.Map<T>();
        }
    }
}
