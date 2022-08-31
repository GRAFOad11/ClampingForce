using System;

namespace MouldingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var force = new ForceMemory("Any");
            var forceSave = new ForceSave("Any");
            UserInterface(force, forceSave); 
        }

        private static void UserInterface(IMould force, IMould forceSave)
        {
            while (true)
            {   
                Console.WriteLine();
                Console.WriteLine("Witam w programie do obliczania siły zwarcia. Jeżeli chcesz zakończyć wpisz q lub Ctrl+c");
                Console.WriteLine();
                Console.WriteLine("Czy chcesz aby program zapisał wynik do pliku tekstowego? tak(Y) nie(N)");
                var input = Console.ReadLine();

                if (input == "Y" || input == "y")
                {
                    force = forceSave;
                }

                else if (input == "q")
                {
                    break;
                }

                try
                {
                    Console.WriteLine("Podaj nazwę formy");
                    input = Console.ReadLine();
                    force.SetMouldID(input);
                    Console.WriteLine("Czy detal jest okrągły? tak(Y) nie(N)");
                    input = Console.ReadLine();
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
                    Console.WriteLine($"Podaj ilość gnazd w formie");
                    input = Console.ReadLine();
                    force.SetNumberOfCavites(double.Parse(input));
                    Console.WriteLine($"Podaj pole powierzchni wlewka (cm2) jeżeli brak wpisz 0");
                    input = Console.ReadLine();
                    force.SetRunnerProjectedArea(double.Parse(input));
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
                
                Console.WriteLine("Czy otworzyć chcesz całą historię obliczeń? tak(Y) nie(N)");
                input = Console.ReadLine();

                if (input == "Y" || input == "y")
                {
                    forceSave.GetStatiscics();
                }
            }
        }
    }
}
