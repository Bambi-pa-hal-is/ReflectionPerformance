using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService.FastReflection
{
    public class MappedProperty
    {
        public Action<object, object> Setter { get; private set; }
        public Func<object, object> Getter { get; private set; }

        public MappedProperty(Func<object, object> getter, Action<object, object> setter)
        {
            Setter = setter;
            Getter = getter;
        }
    }
}
