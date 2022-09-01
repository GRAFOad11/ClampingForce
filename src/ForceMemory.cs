using System;
using System.IO;

namespace MouldingApp
{
    public class ForceMemory : ForceBase
    {
        public ForceMemory(string mould) : base(mould) { }

        public override void CountForce()
        {
            base.CountForce();

            if (this.Shape == true)
            {
                Console.WriteLine($"Średnica detalu {this.Diameter.ToString()} cm");
            }

            else
            {
                Console.WriteLine($"Długość Detalu {this.Width.ToString()} cm");
                Console.WriteLine($"Szerokość Detalu {this.Hight.ToString()} cm");
            }

            Console.WriteLine($"Powierzchnia detalu {this.Area:N3}cm2");
            Console.WriteLine($"Powierzchnia wlewka {this.RunnerProjectedArea.ToString()} cm2");
            Console.WriteLine($"Ilość gniazd {this.NumberOfCavites.ToString()} szt.");
            Console.WriteLine($"Powierzchnia wtrysku {this.AreaAll:N3}cm2");
            Console.WriteLine($"Min Siła Zwarcia {this.Force:N0} TON");
            Console.WriteLine($"Optymalna Siła Zwarcia {this.ForceSafety:N0} TON\n\n");
        }

        public override void CountPressure()
        {
            base.CountPressure();

            Console.WriteLine($"Stosunek drogi płynięcia do grubości detalu {this.Ratio.ToString("N0")}:1");
            Console.WriteLine($"Ciśnienie z wykresu {this.Pressure.ToString("N0")}bar");
            Console.WriteLine($"Ciśnienie w gnieżdzie {this.CavityPressure.ToString("N0")}bar");
        }

        public override void DiameterSet(string diameter)
        {
            base.DiameterSet(diameter);

            if (double.TryParse(diameter, out double result))
            {
                Console.WriteLine($"OK {result}");
            }

            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {diameter}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(diameter)}");
            }
        }

        public override void HightSet(string hight)
        {
            base.HightSet(hight);

            if (double.TryParse(hight, out double result))
            {
                Console.WriteLine($"OK mam to {result}");
            }

            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {hight}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(hight)}");
            }
        }

        public override void LongestMeltSet(string melt)
        {
            base.LongestMeltSet(melt);

            if (double.TryParse(melt, out double result))
            {
                Console.WriteLine($"OK {result}");
            }

            else
            {
                Console.WriteLine($"Błąd! nieprawidłowa liczba {melt}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(melt)}");
            }
        }

        public override string MaterialViscosity(string material)
        {
            base.MaterialViscosity(material);

            if (double.TryParse(this.Material, out double result))
            {
                Console.WriteLine($"\nPrzyjmuję viscosity o wartości {this.Material}");
            }
            else
            {
                Console.WriteLine($"Błąd brak materiału na liście {this.Material}");
                Console.WriteLine("lub");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(material)}");
            }
            return base.MaterialViscosity(material);
        }

        public override void ThicknessSet(string thickness)
        {
            base.ThicknessSet(thickness);

            if (double.TryParse(thickness, out double result) && result > 0 && result <= 2)
            {
                Console.WriteLine($"OK {result}");
            }

            else
            {
                Console.WriteLine($"Błąd! liczba poza zakresem {thickness}");
                Console.WriteLine("lub");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(thickness)}");
            }
        }

        public override void WidthSet(string width)
        {
            base.WidthSet(width);

            if (double.TryParse(width, out double result))
            {
                Console.WriteLine($"OK {result}");
            }

            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {width}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(width)}");
            }
        }
    }
}