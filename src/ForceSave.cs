using System;
using System.IO;

namespace MouldingApp
{
    public class ForceSave : ForceBase
    {
        public ForceSave(string mould) : base(mould) { }

        public override void CountForce()
        {
            base.CountForce();

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Powierzchnia detalu {this.Area:N3}cm2");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Powierzchnia detalu {this.Area:N3}cm2");
            }

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Powierzchnia wlewka {this.RunnerProjectedArea.ToString()}cm2");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Powierzchnia wlewka {this.RunnerProjectedArea.ToString()}cm2");
            }

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Powierzchnia wtrysku {this.AreaAll:N3}cm2");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Powierzchnia wtrysku {this.AreaAll:N3}cm2");
            }

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Ilość gniazd {this.NumberOfCavites.ToString()}szt.");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Ilość gniazd {this.NumberOfCavites.ToString()}szt.");
            }

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Min Siła Zwarcia {this.Force:N0} TON");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Min Siła Zwarcia {this.Force:N0} TON");
            }

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Optymalna Siła Zwarcia {this.ForceSafety:N0} TON\n\n");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Optymalna Siła Zwarcia {this.ForceSafety:N0} TON\n\n");
            }
        }

        public override void CountPressure()
        {
            base.CountPressure();

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Stosunek drogi płynięcia do grubości detalu {this.Ratio.ToString("N0")}:1");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Stosunek drogi płynięcia do grubości detalu {this.Ratio.ToString("N0")}:1");
            }

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Ciśnienie z wykresu {this.Pressure.ToString("N0")}bar");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Ciśnienie z wykresu {this.Pressure.ToString("N0")}bar");
            }

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Ciśnienie w gnieżdzie {this.CavityPressure.ToString("N0")}bar");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Ciśnienie w gnieżdzie {this.CavityPressure.ToString("N0")}bar");
            }
            CountForce();
        }

        public override void DiameterSet(string diameter)
        {
            base.DiameterSet(diameter);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Średnica {diameter}cm");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Średnica {diameter}cm");
            }
        }

        public override void HightSet(string hight)
        {
            base.HightSet(hight);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Szerokość {hight}cm");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Szerokość {hight}cm");
            }
        }

        public override void LongestMeltSet(string melt)
        {
            base.LongestMeltSet(melt);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Droga płynięcia {melt}mm");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Droga płynięcia {melt}mm");
            }
        }

        public override string MaterialViscosity(string material)
        {
            base.MaterialViscosity(material);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Viscosity {this.Material}");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Viscosity {this.Material}");
            }
            return base.MaterialViscosity(material);
        }
        public override void SetMouldID(string mould)
        {
            base.SetMouldID(mould);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"{this.Mould}\n");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   {this.Mould}\n");
            }
        }

        public override void ShapeSet(string shape)
        {
            base.ShapeSet(shape);
            string s = "Prostokątna";

            if (this.Shape == true)
            {
                s = "Okrągła";
                using (var writer = File.AppendText($"{fileName}"))
                {
                    writer.WriteLine($"Bryła {s}");
                }

                using (var writer = File.AppendText($"{fileNameAudit}"))
                {
                    writer.WriteLine($"{DateTime.Now}   Bryła {s}");
                }
            }

            else
            {
                using (var writer = File.AppendText($"{fileName}"))
                {
                    writer.WriteLine($"Bryła {s}");
                }

                using (var writer = File.AppendText($"{fileNameAudit}"))
                {
                    writer.WriteLine($"{DateTime.Now}   Bryła {s}");
                }
            }
        }

        public override void ThicknessSet(string thickness)
        {
            base.ThicknessSet(thickness);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Grubość ścianki {thickness}mm");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Grubość ścianki {thickness}mm");
            }
        }

        public override void WidthSet(string width)
        {
            base.WidthSet(width);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Długość {width}cm");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Długość {width}cm");
            }
        }

        public override void VoidArea(string voidArea)
        {
            base.VoidArea(voidArea);

            using (var writer = File.AppendText($"{fileName}"))
            {
                writer.WriteLine($"Pole odliczanej powierzchni {voidArea}cm2");
            }

            using (var writer = File.AppendText($"{fileNameAudit}"))
            {
                writer.WriteLine($"{DateTime.Now}   Pole odliczanej powierzchni {voidArea}cm2");
            }
        }

        public override Statiscics GetStatiscics()
        {
            var result = new Statiscics();
            using (var reader = File.OpenText($"{fileName}"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(line);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}