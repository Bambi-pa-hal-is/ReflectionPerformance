using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService.FastReflection
{
    public class MappedClass
    {
        public Func<object> Constructor { get; set; }
        public List<MappedProperty> Properties { get; set; }
        public MappedClass(Func<object> constructor)
        {
            Constructor = constructor;
            Properties = new();
        }
    }
}
