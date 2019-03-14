
namespace LinqSamples {

    public class Car {

        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }

        public override string ToString(){
            return $"{this.Year} {this.Manufacturer} {this.Name} {this.Displacement} {this.Cylinders} {this.City} {this.Highway} {this.Combined}";
        }

        internal static Car ParseFromCsv(string line){
            var cols = line.Split(',');

            return new Car {
                Year = int.Parse(cols[0]),
                Manufacturer = cols[1],
                Name = cols[2],
                Displacement = cols[3],
                Cylinders = int.Parse(cols[4]),
                City = int.Parse(cols[5]),
                Highway = int.Parse(cols[6]),
                Combined = int.Parse(cols[7])
            };

        }
    }
}