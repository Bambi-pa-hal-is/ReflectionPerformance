using ReflectionPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService.Simple
{
    public class SimpleCloneService : ICloneService
    {
        public Report? Clone(Report report)
        {
            if(report == null) return null;

            return new Report()
            {
                Age = report.Age,
                CreationDate = report.CreationDate,
                Description = report.Description,
                Email = report.Email,
                IsDeleted = report.IsDeleted,
                Title = report.Title,
                UpdateDate = report.UpdateDate,
            };
        }

        public T Clone<T>(T clone)
        {
            throw new NotImplementedException();
        }

        public void Map<T>()
        {
            throw new NotImplementedException();
        }
    }
}
