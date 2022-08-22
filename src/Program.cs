using System;
using System.Linq;
using System.Collections.Generic;

namespace MouldingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var force = new Force("Any");
            force.Added += OnAdded;

            Terminal(force);

            void OnAdded(object sender, EventArgs args, string diameter)
            {
                if (double.TryParse(diameter, out double result) && result < 3)
                {
                    Console.WriteLine($"Małe to kółeczko");
                }
            }
        }

        private static void Terminal(Force force)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Witam w programie do obliczania bezpiecznej siły zwarcia. Jeżeli chcesz zakończyć wpisz q lub Ctrl+c");
                Console.WriteLine();
                Console.WriteLine("Czy detal jest okrągły? tak(Y) nie(N)");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    force.ShapeSet(input);
                    if (input == "Y" || input == "y")
                    {
                        Console.WriteLine($"Podaj średnicę detalu (centymetry)");
                        input = Console.ReadLine();
                        force.DiameterSet(input);
                    }
                    else
                    {
                        Console.WriteLine($"Podaj długość detalu (centymetry)");
                        input = Console.ReadLine();
                        force.WidthSet(input);
                        Console.WriteLine($"Podaj szerokość detalu (centymetry)");
                        input = Console.ReadLine();
                        force.HightSet(input);
                    }

                    Console.WriteLine($"Podaj grubość ścianki, max 2 (milimetry)");
                    input = Console.ReadLine();
                    force.ThicknessSet(input);
                    Console.WriteLine($"Podaj najdłóższy odcinek płynięcia materiału (milimetry)");
                    input = Console.ReadLine();
                    force.LongestMeltSet(input);
                    Console.WriteLine("Wprowadz nazwę tworzywa (np PA6, aby wyświetlić pełną listę wpisz (L))");
                    input = Console.ReadLine();
                    if (input == "L" || input == "l")
                    {
                        Console.WriteLine();
                        force.PrintList();
                        Console.WriteLine($"Wprowadz nazwę tworzywa");
                        input = Console.ReadLine();
                        force.MaterialViscosity(input);
                    }
                    else
                    {
                        force.MaterialViscosity(input);
                    }
                    force.CountPressure();

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { }

            }
        }
    }
}
