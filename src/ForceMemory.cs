using System;

namespace MouldingApp
{
    public class ForceMemory : ForceBase
    { 
        public ForceMemory(string mould) : base(mould){}
        public ForceMemory(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure) 
                        : base(mould, width, meltLenth,  thickness,  shape,  diameter,  material,  cavityPressure) {}
        public delegate void AddedDelegate(object sender, EventArgs args, string diameter);
        public event AddedDelegate Added;

        
        
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
                throw new ArgumentException($"Niewłaściwa składnia {nameof(width)}");
            }
        }
        public override void HightSet(string hight)
        {
            if (double.TryParse(hight, out double result))
            {
                Console.WriteLine($"OK mam to {result}");
                this.Hight = result;
            } 
            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {hight}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(hight)}");
            }
        }
        public override void LongestMeltSet(string melt)
        {
            if (double.TryParse(melt, out double result))
            {
                Console.WriteLine($"OK {result}");
                this.MeltLenth = result;
            } 
            else
            {
                Console.WriteLine($"Błąd! nieprawidłowa liczba {melt}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(melt)}");
            }
        }
        public override void ThicknessSet(string thickness)
        {
            if (double.TryParse(thickness, out double result) && result > 0 && result <= 2)
            {
                Console.WriteLine($"OK {result}");
                this.Thickness = result;
            } 
            else
            {
                Console.WriteLine($"Błąd! liczba poza zakresem {thickness}");
                Console.WriteLine("lub");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(thickness)}");
            }
        }
        public override void ShapeSet(string shape)
        {
            if(shape == "Y" || shape == "y")
            {
                this.Shape = true;
            }
            else
            {
                this.Shape = false;
            }
        }
        public override void DiameterSet(string diameter)
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
                throw new ArgumentException($"Niewłaściwa składnia {nameof(diameter)}");
            }
        }
        public override void CavityPressureSet(string cavityPressure)
        {
            if (int.TryParse(cavityPressure, out int result))
            {
                Console.WriteLine($"OK mam to {result}");
                this.CavityPressure = result;
            } 
            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {cavityPressure}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(cavityPressure)}");
            }
        }
        public override string MaterialViscosity(string material)
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
            if (double.TryParse(material, out double result))
            {
                Console.WriteLine();
                Console.WriteLine($"Przyjmuję viscosity o wartości {material}");
            }
            else
            {
                Console.WriteLine($"Błąd brak materiału na liście {material}");
                Console.WriteLine("lub");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(material)}");
            }
            return this.Material;
        }

        public override void CountPressure()
        {
            double pressure = 0.0;
            double ratio = 0.0;
            ratio = this.MeltLenth / this.Thickness;
            Console.WriteLine($"Stosunek drogi płynięcia do grubości detalu {ratio.ToString("N0")}:1");
    
            switch(ratio) 
            {
                case var r when r <= 75 : pressure = -6.6219 * Math.Pow(this.Thickness, 3) + 95.524 * Math.Pow(this.Thickness, 2) - 339.2 * this.Thickness + 430.84; 
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
                case var r when r > 287 : pressure = -760.81 * Math.Pow(this.Thickness, 3) + 3815.7 * Math.Pow(this.Thickness, 2) - 6593.9 * this.Thickness + 4429.1;
                break;
            }
            Console.WriteLine($"Ciśnienie z wykresu {pressure.ToString("N0")}bar");
            pressure = pressure * this.Thickness;
            Console.WriteLine($"Ciśnienie w gnieżdzie {pressure.ToString("N0")}bar");
            this.CavityPressure = pressure;
            CountForce();
        }

        public override void CountForce()
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
                forceSafety = force * 1.1;
                Console.WriteLine($"Długość Detalu {this.Width.ToString()} cm");
                Console.WriteLine($"Szerokość Detalu {this.Hight.ToString()} cm"); 
            }
            Console.WriteLine($"Powierzchnia wtrysku {area:N3}cm2");
            Console.WriteLine($"Min Siła Zwarcia {force:N0} TON");
            Console.WriteLine($"Optymalna Siła Zwarcia {forceSafety:N0} TON");
            Console.WriteLine();
            Console.WriteLine();
        }
        public override void SetMouldID(string mould)
        {
            bool noDigit = true;
            foreach (char n in mould)
            {   
                if (char.IsDigit(n))
                {
                    Console.WriteLine($"Nowa nazwa formy zawiera cyfrę({n}) Nazwa nie została zapisana!!!");
                    noDigit = false;
                    break;
                } 
            }
            if (noDigit)
            {
                this.Mould = mould;
                Console.WriteLine($"Nazwa formy {mould}");
            }
        }
        public override void AddDimension(double width, double hight)
        {
            this.dimensions.Add(width);
            this.dimensions.Add(hight);
        }
         public void AddPressure(int pressure)
        {
            this.pressure.Add(pressure);
        }
    
        public override void PrintList()
        {
            foreach (string list in this.materialList)
            {
                Console.WriteLine(list);
            }
            Console.WriteLine();
        }
       
        public override Statiscics GetStatiscics()
        {
            var result = new Statiscics();
            /*result.Averadge = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Width = this.Width;
            foreach (var dimension in this.dimensions)
            {
                result.Low = Math.Min(dimension, result.Low);
                result.High = Math.Max(dimension, result.High);
                result.Averadge += dimension;
            }
            result.Averadge /= dimensions.Count;
            Console.WriteLine($" Low {result.Low}");
            Console.WriteLine($" High {result.High}");
            Console.WriteLine($" Averidge {result.Averadge}");
            Console.WriteLine($" Width {result.Width}");*/
            return result;
        }
    }
}