using ReflectionPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService
{
    public interface ICloneService
    {
        public Report Clone(Report report);
        public T Clone<T>(T clone);
        public void Map<T>();
    }
}
