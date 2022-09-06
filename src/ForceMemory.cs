using System;

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
                Console.WriteLine($"Średnica detalu {this.Diameter.ToString()}cm");
            }

            else
            {
                Console.WriteLine($"Długość detalu {this.Width.ToString()}cm");
                Console.WriteLine($"Szerokość detalu {this.Hight.ToString()}cm");
            }

            Console.WriteLine($"Powierzchnia detalu {this.Area:N3}cm2");
            Console.WriteLine($"Powierzchnia wlewka {this.RunnerProjectedArea.ToString()}cm2");
            Console.WriteLine($"Ilość gniazd {this.NumberOfCavites.ToString()}szt.");
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
            CountForce();
        }

        public override void DiameterSet(string diameter)
        {
            base.DiameterSet(diameter);

            if (double.TryParse(diameter, out double result))
            {
                Console.WriteLine($"OK {result}mm\n");
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
                Console.WriteLine($"OK mam to {result}mm\n");
            }

            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {hight}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(hight)}\n");
            }
        }

        public override void LongestMeltSet(string melt)
        {
            base.LongestMeltSet(melt);

            if (double.TryParse(melt, out double result))
            {
                Console.WriteLine($"OK {result}mm\n");
            }

            else
            {
                Console.WriteLine($"Błąd! nieprawidłowa liczba {melt}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(melt)}\n");
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
                throw new ArgumentException($"Niewłaściwa składnia {nameof(material)}\n");
            }
            return base.MaterialViscosity(material);
        }

        public override void SetNumberOfCavites(string numberOfCavites)
        {
            base.SetNumberOfCavites(numberOfCavites);

            if (double.TryParse(numberOfCavites, out double result))
            {
                if (result >= 2 && result <=4)
                {
                    Console.WriteLine($"OK {result} gniazda\n");
                }

                else if(result > 4)
                {
                    Console.WriteLine($"OK {result} gniazd\n");
                }

                else
                {
                    Console.WriteLine("OK jedno gniazdo\n");
                }
                
            }

            else
            {
                Console.WriteLine($"Błąd! nieprawidłowa liczba {numberOfCavites}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(numberOfCavites)}\n");
            }
        }

        public override void SetRunnerProjectedArea(string runnerProjectedArea)
        {
            base.SetRunnerProjectedArea(runnerProjectedArea);

            if (double.TryParse(runnerProjectedArea, out double result))
            {
                Console.WriteLine($"OK {result}cm2\n");
            }

            else
            {
                Console.WriteLine($"Błąd! nieprawidłowa liczba {runnerProjectedArea}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(runnerProjectedArea)}\n");
            }
        }

        public override void ShapeSet(string shape)
        {
            base.ShapeSet(shape);

            if (this.Shape == true)
            {
                Console.WriteLine("OK detal jest okrągły\n");
            }

            else
            {
                Console.WriteLine("OK detal jest prostokątny\n");
            }
        }

        public override void ThicknessSet(string thickness)
        {
            base.ThicknessSet(thickness);

            if (double.TryParse(thickness, out double result) && result > 0 && result <= 2)
            {
                Console.WriteLine($"OK {result}mm\n");
            }

            else
            {
                Console.WriteLine($"Błąd! liczba poza zakresem {thickness}");
                Console.WriteLine("lub");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(thickness)}\n");
            }
        }

        public override void WidthSet(string width)
        {
            base.WidthSet(width);

            if (double.TryParse(width, out double result))
            {
                Console.WriteLine($"OK {result}mm\n");
            }

            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {width}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(width)}\n");
            }
        }

        public override void VoidArea(string voidArea)
        {
            base.VoidArea(voidArea);

            if (double.TryParse(voidArea, out double result))
            {
                Console.WriteLine($"OK {result}cm2\n");
            }

            else
            {
                Console.WriteLine($"Błąd! nieprawidłowa liczba {voidArea}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(voidArea)}\n");
            }
        }
    }
}