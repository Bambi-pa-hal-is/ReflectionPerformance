using ReflectionPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService.Reflection
{
    public class ReflectionCloneService : ICloneService
    {
        public Report? Clone(Report report)
        {
            return Clone<Report>(report);
        }

        public T? Clone<T>(T clone)
        {
            if(clone == null) return default;

            var newClone = Activator.CreateInstance<T>();
            if (newClone == null) throw new ArgumentNullException("Generictype is null");
            var fields = newClone.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
