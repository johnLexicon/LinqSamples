using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqSamples
{
    class Program
    {
        static void ShowFuelEfficiencyQuerySyntax(List<Car> cars, List<Manufacturer> manufacturers){

            var query = 
                from c in cars join m in manufacturers on c.Manufacturer equals m.Name
                orderby c.Combined descending, c.Name ascending
                select new {
                    m.Headquarters,
                    c.Name,
                    c.Combined
                };
            
            foreach(var item in query.Take(10)){
                System.Console.WriteLine($"Headquarters: {item.Headquarters}, Name: {item.Name}, Combined: {item.Combined}");
            }
        }

        static void ShowFuelEfficiencyMehtodSyntax(List<Car> cars, List<Manufacturer> manufacturers){

            //For efficiency you should always use the smallest sequence as the inner sequence in a join.
            //Here is the manufacturers sequence used as an inner sequence:
            var result = cars.Join(manufacturers, 
                        c => c.Manufacturer, 
                        m => m.Name, 
                        (c, m) => new {
                            m.Headquarters,
                            c.Name,
                            c.Combined
                        })
                        .OrderByDescending(item => item.Combined)
                        .ThenBy(item => item.Name);
            
            foreach(var item in result.Take(10)){
                System.Console.WriteLine($"Headquarters: {item.Headquarters}, Name: {item.Name}, Combined: {item.Combined}");
            }
        }

        static void Main(string[] args)
        {
            var cars = ProcessFuelFile("Cars/fuel.csv");
            var manufacturers = ProcessManufaturersFile("Cars/manufacturers.csv");

            ShowFuelEfficiencyQuerySyntax(cars, manufacturers);
            System.Console.WriteLine("-----------------------------------------------------");
            ShowFuelEfficiencyMehtodSyntax(cars, manufacturers);
        }

        private static List<Manufacturer> ProcessManufaturersFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath)
                                .Where(l => l.Length > 1);

            return lines
                .Select(line => Manufacturer.ParseFromCsv(line))
                .ToList();
        }

        private static List<Car> ProcessFuelFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath)
                            .Where(l => l.Length > 1);

            return lines
                .Skip(1)
                .Select(line => Car.ParseFromCsv(line))
                .ToList();
        }
    }
}
