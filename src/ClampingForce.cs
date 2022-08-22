using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouldingApp
{
    public class FORCE : FORCEbase
    { 
        public FORCE(string mould) : base(mould){}
        public FORCE(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure) 
                        : base(mould, width, meltLenth,  thickness,  shape,  diameter,  material,  cavityPressure) {}
        public delegate void AddedDelegate(object sender, EventArgs args, string diameter);
        public override event AddedDelegate Added;

        public string[] materialList = new string[] {"GPPS", "HIPS", "TPS", "PE", "PP", "PA6", "PA66", "PA11", "PA12", "PBT", "PETP", "CA", "CAB", "CAP", "CP", "EVA", "PEEL", "PUR/TPU", "PPVC",
                                                      "ABS", "AAS/ASA", "SAN", "MBS", "PPS", "PPO", "BDS", "POM", "PMMA", "PC/ABS", "PC/PBT", "PC", "PES", "PSU", "PEI", "PEEK", "UPVC"};
        private List<double> dimensions = new List<double>();
        private List<int> pressure = new List<int>();

        public interface IForce
        {
            public void WidthSet(string width);
            Statiscics GetStatiscics();
            string Mould{get;}            
            event AddedDelegate Added;
        }
        
        public override void WidthSet(string width)
        {
            if (double.TryParse(width, out double result))
            {
                Console.WriteLine($"OK {result}");
                this.Width = result;
            } 
            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {width}");
            }
        }
        public void HightSet(string hight)
        {
            if (double.TryParse(hight, out double result))
            {
                Console.WriteLine($"OK mam to {result}");
                this.Hight = result;
            } 
            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {hight}");
            }
        }
        public void LongestMeltSet(string melt)
        {
            if (double.TryParse(melt, out double result))
            {
                Console.WriteLine($"OK {result}");
                this.MeltLenth = result;
            } 
            else
            {
                Console.WriteLine($"Błąd! nieprawidłowa liczba {melt}");
            }
        }
        public void ThicknessSet(string thickness)
        {
            if (double.TryParse(thickness, out double result) && result > 0 && result <= 2)
            {
                Console.WriteLine($"OK {result}");
                this.Thickness = result;
            } 
            else
            {
                Console.WriteLine($"Błąd! liczba poza zakresem {thickness}");
            }
        }
        public void ShapeSet(string shape)
        {
            if(shape == "Y" || shape == "y")
            {
                this.Shape = true;
            }
            else
            {
                this.Shape = false;
                //throw new ArgumentException($"Niewłaściwa składnia {nameof(shape)}");
            }
        }
        public void DiameterSet(string diameter)
        {
            if (double.TryParse(diameter, out double result))
            {
                Console.WriteLine($"OK {result}");
                this.Diameter = result;
                if (Added != null)
                {
                    Added(this, new EventArgs(), diameter);
                }
            } 
            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {diameter}");
            }
        }
        public void CavityPressureSet(string cavityPressure)
        {
            if (int.TryParse(cavityPressure, out int result))
            {
                Console.WriteLine($"OK mam to {result}");
                this.CavityPressure = result;
            } 
            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {cavityPressure}");
            }
        }
        public string MaterialViscosity(string material)
        {
            
            switch(material.ToUpper()) 
            {
                case "GPPS": material = "1"; break; case "HIPS": material = "1"; break; case "TPS": material = "1"; break; case "PE": material = "1"; break; case "PP": material = "1"; break;
                case "PA6": material = "1,35"; break; case "PA66": material = "1,35"; break; case "PA11": material = "1,35"; break; case "PA12": material = "1,35"; break; 
                case "PBT": material  = "1,35"; break; case "PETP": material = "1,35"; break;
                case "CA": material = "1,45";break; case "CAB": material = "1,45"; break; case "CAP": material = "1,45"; break; case "CP": material = "1,45"; break; 
                case "EVA": material = "1,45"; break; case "PEEL": material = "1,45"; break; case "PUR": material = "1,45"; break; case "TPU": material = "1,45"; break; case "PPVC": material = "1,45"; break; 
                case "ABS": material = "1,55"; break; case "AAS/ASA": material = "1,55"; break; case "SAN": material = "1,55"; break; case "": material = "1,55"; break; 
                case "MBS": material = "1,55"; break; case "PPS": material = "1,55"; break; case "PPO": material = "1,55"; break; case "BDS": material = "1,55"; break; case "POM": material = "1,55"; break; 
                case "PMMA": material = "1,7"; break; case "PC/ABS": material = "1,7"; break; case "PC/PBT": material = "1,7"; break; 
                case "PC": material = "1,9"; break; case "PES": material = "1,9"; break; case "PSU": material = "1,9"; break; case "PEI": material = "1,9"; break; case "PEEK": material = "1,9"; break; 
                case "UPVC": material = "1,9"; break; 
            }
            Console.WriteLine($"Przyjmuję viscosity o wartości {material}");
            return this.Material;
        }

        public void CountPressure()
        {
            double pressure = 0.0;
            double ratio = 0.0;
            ratio = this.MeltLenth / this.Thickness;
            Console.WriteLine($"Stosunek drogi płynięcia do grubości detalu {ratio.ToString("N0")}:1");
            Console.WriteLine();
    
            switch(ratio) 
            {
                case var r when r <= 75: pressure = -6.6219 * Math.Pow(this.Thickness, 3) + 95.524 * Math.Pow(this.Thickness, 2) - 339.2 * this.Thickness + 430.84; 
                break;
                case var r when r > 75 && r <= 125 : pressure = -34.873 * Math.Pow(this.Thickness, 3) + 223.77 * Math.Pow(this.Thickness, 2) - 516.54 * this.Thickness + 574.47; 
                break;
                case var r when r > 125 && r <= 175 : pressure = -57.62 * Math.Pow(this.Thickness, 3) + 334.49 * Math.Pow(this.Thickness, 2) - 762.92 * this.Thickness + 832.9;
                break;
                case var r when r > 175 && r <= 225 : pressure = -82.774 * Math.Pow(this.Thickness, 3) + 453.82 * Math.Pow(this.Thickness, 2) - 982.75 * this.Thickness + 1049.7;
                break;
                case var r when r > 225 && r <= 262 : pressure = -186.17 * Math.Pow(this.Thickness, 3) + 914.62 * Math.Pow(this.Thickness, 2) - 1695.3 * this.Thickness + 1509.2;
                break;
                case var r when r > 262 && r <= 287 : pressure = -297.97 * Math.Pow(this.Thickness, 3) + 1487.4 * Math.Pow(this.Thickness, 2) - 2690.5 * this.Thickness + 2165.4;
                break;
                case var r when r > 287 && r <= 320 : pressure = -760.81 * Math.Pow(this.Thickness, 3) + 3815.7 * Math.Pow(this.Thickness, 2) - 6593.9 * this.Thickness + 4429.1;
                break;
            }
            Console.WriteLine($"Ciśnienie z wykresu {pressure.ToString("N0")}bar");
            pressure = pressure * this.Thickness;
            Console.WriteLine($"Ciśnienie w gnieżdzie {pressure.ToString("N0")}bar");
            this.CavityPressure = pressure;
            CountForce();
        }

        public void CountForce()
        { 
            double force;
            double forceSafety;
            double area;

            if (this.Shape == true)
            {
                area = 3.14* this.Diameter * this.Diameter / 4;
                force = area * this.CavityPressure /1000;
                forceSafety = force * 1.2;
                Console.WriteLine($"Średnica detalu {this.Diameter.ToString()} cm");
            }
            else
            {
                area = this.Width * this.Hight;
                force = area * this.CavityPressure /1000;
                forceSafety = force * 1.2;
                Console.WriteLine($"Długość Detalu {this.Width.ToString()} cm");
                Console.WriteLine($"Szerokość Detalu {this.Hight.ToString()} cm"); 
            }
            Console.WriteLine($"Powierzchnia wtrysku {area:N3}cm2");
            Console.WriteLine($"Min Siła Zwarcia {force:N0} TON");
            Console.WriteLine($"Optymalna Siła Zwarcia {forceSafety:N0} TON");
        }
        public void ChangeMouldID(string mould)
        {
            bool noDigit = true;
            foreach (char n in mould)
            {   
                if (char.IsDigit(n))
                {
                    Console.WriteLine($"Nowa nazwa formy zawiera cyfrę({n}) Nazwa nie została zmieniona!!!");
                    noDigit = false;
                    break;
                } 
            }
            if (noDigit)
            {
                this.Mould = mould;
                Console.WriteLine($"Nazwa formy została zmieniona na {mould}");
            }
        }
        public void AddDimension(double width, double hight)
        {
            this.dimensions.Add(width);
            this.dimensions.Add(hight);
        }
         public void AddPressure(int pressure)
        {
            this.pressure.Add(pressure);
        }
    
        public void PrintList()
        {
            foreach (string list in this.materialList)
            {
                Console.WriteLine(list);
            }
            Console.WriteLine();
        }
        public Statiscics GetStatistics()
        {
            var result = new Statiscics();
            result.Averidge = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Width = this.Width;
            foreach (var dimension in this.dimensions)
            {
                result.Low = Math.Min(dimension, result.Low);
                result.High = Math.Max(dimension, result.High);
                result.Averidge += dimension;
            }
            result.Averidge /= dimensions.Count;
            Console.WriteLine($" Low {result.Low}");
            Console.WriteLine($" High {result.High}");
            Console.WriteLine($" Averidge {result.Averidge}");
            Console.WriteLine($" Width {result.Width}");
            return result;
        }
    }
}