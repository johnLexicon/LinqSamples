
using System;

namespace LinqSamples {

    public class Manufacturer {

        public string Name { get; set; }
        public string Headquarters { get; set; }
        public int Year { get; set; }

        public override string ToString(){
            return $"{this.Name} {this.Headquarters} {this.Year}";
        }
        
        internal static Manufacturer ParseFromCsv(string line)
        {
            var cols = line.Split(',');
            return new Manufacturer {
                Name = cols[0],
                Headquarters = cols[1],
                Year = int.Parse(cols[2])
            };
        }
    }

}