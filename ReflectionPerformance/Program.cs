// See https://aka.ms/new-console-template for more information
using ReflectionPerformance.Benchmarking;
using ReflectionPerformance.CloneService;
using ReflectionPerformance.CloneService.FastReflection;
using ReflectionPerformance.CloneService.Reflection;
using ReflectionPerformance.CloneService.Simple;
using ReflectionPerformance.Models;

ICloneService simpleCloneService = new SimpleCloneService();

ICloneService reflectionCloneService = new ReflectionCloneService();





















ICloneService fastReflectionCloneService = new FastReflectionCloneService();
fastReflectionCloneService.Map<Report>();



var report = new Report()
{
    Title = "kalle",
    Age = 5,
    CreationDate = DateTime.Now,
    Description =  "Description",
    Email = "Arrenator@arre.se",
    IsDeleted = false,
    UpdateDate = DateTime.Now.AddDays(5)
};

var benchmark = new Benchmarker();

benchmark.Execute("Simple",() => simpleCloneService.Clone(report));
benchmark.Execute("Reflection",() => reflectionCloneService.Clone(report));
benchmark.Execute("FastReflection",() => fastReflectionCloneService.Clone(report));
benchmark.PrintResult();

//var test2 = fastReflectionCloneService.FastReflectionMapper.MappedClasses[typeof(Report)].Properties.FirstOrDefault().Value.Getter(test);
//fastReflectionCloneService.FastReflectionMapper.MappedClasses[typeof(Report)].Properties.FirstOrDefault().Value.Setter(test,"hej");
