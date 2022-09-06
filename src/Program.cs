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
                bool memory;

                Console.WriteLine("\n****** Witam w programie do obliczania siły zwarcia. Jeżeli chcesz zakończyć wpisz q lub Ctrl+c ******\n");

                Console.WriteLine("Czy chcesz aby program zapisał wynik do pliku tekstowego? TAK [Y] NIE [N]");
                var input = Console.ReadLine();

                if (input == "Y" || input == "y" || input == "T" || input == "t" || input == "tak" || input == "TAK")
                {
                    force = new ForceSave("Any");
                    memory = true;
                }

                else if (input == "Q" || input == "q")
                {
                    break;
                }

                else
                {
                    force = new ForceMemory("Any");
                    memory = false;
                }

                try
                {
                    Console.WriteLine("Podaj nazwę formy");
                    input = Console.ReadLine();
                    force.SetMouldID(input);

                    Console.WriteLine("Czy detal jest okrągły? TAK [Y] NIE [N]");
                    input = Console.ReadLine();
                    force.ShapeSet(input);

                    if (input == "Y" || input == "y" || input == "T" || input == "t" || input == "tak" || input == "TAK")
                    {
                        Console.WriteLine($"Podaj ŚREDNICĘ detalu (milimetry)");
                        input = Console.ReadLine();
                        force.DiameterSet(input);
                    }

                    else
                    {
                        Console.WriteLine($"Podaj DŁUGOŚĆ detalu (milimetry)");
                        input = Console.ReadLine();
                        force.WidthSet(input);

                        Console.WriteLine($"Podaj SZEROKOŚĆ detalu (milimetry)");
                        input = Console.ReadLine();
                        force.HightSet(input);
                    }

                    Console.WriteLine($"Podaj POLE obszaru detalu do odliczenia, jeżeli brak wpisz [0] (cm2)");
                    input = Console.ReadLine();
                    force.VoidArea(input);

                    Console.WriteLine($"Podaj ILOŚĆ GNIAZD w formie");
                    input = Console.ReadLine();
                    force.SetNumberOfCavites(input);

                    Console.WriteLine($"Podaj POLE powierzchni WLEWKA np. 3,5 (cm2) jeżeli brak wpisz 0");
                    input = Console.ReadLine();
                    force.SetRunnerProjectedArea(input);

                    Console.WriteLine($"Podaj GRUBOŚĆ ŚCIANKI, max 2 np. 1,9 (milimetry)");
                    input = Console.ReadLine();
                    force.ThicknessSet(input);

                    Console.WriteLine($"Podaj najdłuższy ODCINEK PŁYNIĘCIA materiału (milimetry)");
                    input = Console.ReadLine();
                    force.LongestMeltSet(input);

                    Console.WriteLine("Wprowadz NAZWĘ TWORZYWA (np PA6, aby wyświetlić pełną listę wpisz (L))");
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

                if (memory == true)
                {
                    Console.WriteLine("Chcesz otworzyć całą historię obliczeń? TAK [Y] NIE [N]");
                    input = Console.ReadLine();

                    if (input == "Y" || input == "y" || input == "T" || input == "t" || input == "tak" || input == "TAK")
                    {
                        forceSave.GetStatiscics();
                    }
                }
            }
        }
    }
}
