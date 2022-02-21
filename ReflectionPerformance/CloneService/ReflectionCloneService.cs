using ReflectionPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService
{
    public class ReflectionCloneService : ICloneService
    {
        public Report Clone(Report report)
        {
            return Clone<Report>(report);
        }

        public T Clone<T>(T clone)
        {
            var newClone = Activator.CreateInstance<T>();
            if (newClone == null) throw new ArgumentNullException("Generictype is null");
            var fields = newClone.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var value = field.GetValue(clone);
                field.SetValue(newClone, value);
            }
            return newClone;
        }

        public void Map<T>()
        {
            throw new NotImplementedException();
        }
    }
}
