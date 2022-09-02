using System;
using System.IO;

namespace MouldingApp
{
    public class ForceBase : EventMessages, IMould
    {
        public const string fileName = "Wyniki Obliczeń";
        public const string fileNameAudit = "audit";
        public virtual event AddedDelegate Added;
        public ForceBase(string mould)
        {
            this.Mould = mould;
            Added += OnAdded;
        }

        public string Mould { get; set; }
        public double Width { get; set; }
        public double Hight { get; set; }
        public double MeltLenth { get; set; }
        public double Thickness { get; set; }
        public bool Shape { get; set; }
        public double Diameter { get; set; }
        public double CavityPressure { get; set; }
        public double NumberOfCavites { get; set; }
        public double RunnerProjectedArea { get; set; }
        public string Material { get; set; }
        public double Pressure { get; set; }
        public double Ratio { get; set; }
        public double Force { get; set; }
        public double ForceSafety { get; set; }
        public double Area { get; set; }
        public double AreaAll { get; set; }

        public virtual void WidthSet(string width)
        {
            if (double.TryParse(width, out double result))
            {
                this.Width = result;
            }
        }

        public virtual void HightSet(string hight)
        {
            if (double.TryParse(hight, out double result))
            {
                this.Hight = result;
            }
        }

        public virtual void LongestMeltSet(string melt)
        {
            if (double.TryParse(melt, out double result))
            {
                this.MeltLenth = result;
            }
        }

        public virtual void ThicknessSet(string thickness)
        {
            if (double.TryParse(thickness, out double result) && result > 0 && result <= 2)
            {
                this.Thickness = result;
            }
        }

        public virtual void ShapeSet(string shape)
        {
            if (shape == "Y" || shape == "y")
            {
                this.Shape = true;
            }

            else
            {
                this.Shape = false;
            }
        }

        public virtual void DiameterSet(string diameter)
        {
            if (double.TryParse(diameter, out double result))
            {
                this.Diameter = result;
                if (Added != null)
                {
                    Added(this, new EventArgs(), diameter);
                }
            }
        }

        public virtual string MaterialViscosity(string material)
        {
            switch (material.ToUpper())
            {
                case "GPPS" or "HIPS" or "TPS" or "PE" or "PP": material = "1"; break;
                case "PA6" or "PA66" or "PA11" or "PA12" or "PBT" or "PETP": material = "1,35"; break;
                case "CA" or "CAB" or "CAP" or "CP" or "EVA" or "PEEL" or "PUR" or "TPU" or "PPVC": material = "1,45"; break;
                case "ABS" or "AAS/ASA" or "SAN" or "MBS" or "PPS" or "PPO" or "BDS" or "POM": material = "1,55"; break;
                case "PMMA" or "PC/ABS" or "PC/PBT": material = "2,6"; break;
                case "PC" or "PES" or "PSU" or "PEI" or "PEEK" or "UPVC": material = "5,2"; break;
                // PP TPE   1
                // PE-LD TPE-S   1,2
                // PS TPE-O TPE-V   1,3
                // PS-HI    1,4
                // PA66    1,5
                // PP-KS LCP   1,6
                // PA6 PA6-GF PA66-GF PP-T   1,7
                // PP-FSC  1,8
                // PE-HD PPE-PA SAN  1,9
                // PET-GF 2,0
                // PMMA TPE-A  2,2
                // ABS  2,3
                // POM 2,5
                // TPE-E 2,8
                // PSU 2,9
                

            }
            this.Material = material;
            return this.Material;
        }

        public virtual void CountPressure()
        {
            this.Ratio = this.MeltLenth / this.Thickness;

            switch (this.Ratio)
            {
                case var r when r <= 75:
                    this.Pressure = -6.6219 * Math.Pow(this.Thickness, 3) + 95.524 * Math.Pow(this.Thickness, 2) - 339.2 * this.Thickness + 430.84;
                    break;
                case var r when r > 75 && r <= 125:
                    this.Pressure = -34.873 * Math.Pow(this.Thickness, 3) + 223.77 * Math.Pow(this.Thickness, 2) - 516.54 * this.Thickness + 574.47;
                    break;
                case var r when r > 125 && r <= 175:
                    this.Pressure = -57.62 * Math.Pow(this.Thickness, 3) + 334.49 * Math.Pow(this.Thickness, 2) - 762.92 * this.Thickness + 832.9;
                    break;
                case var r when r > 175 && r <= 225:
                    this.Pressure = -82.774 * Math.Pow(this.Thickness, 3) + 453.82 * Math.Pow(this.Thickness, 2) - 982.75 * this.Thickness + 1049.7;
                    break;
                case var r when r > 225 && r <= 262:
                    this.Pressure = -186.17 * Math.Pow(this.Thickness, 3) + 914.62 * Math.Pow(this.Thickness, 2) - 1695.3 * this.Thickness + 1509.2;
                    break;
                case var r when r > 262 && r <= 287:
                    this.Pressure = -297.97 * Math.Pow(this.Thickness, 3) + 1487.4 * Math.Pow(this.Thickness, 2) - 2690.5 * this.Thickness + 2165.4;
                    break;
                case var r when r > 287:
                    this.Pressure = -760.81 * Math.Pow(this.Thickness, 3) + 3815.7 * Math.Pow(this.Thickness, 2) - 6593.9 * this.Thickness + 4429.1;
                    break;
            }
            this.CavityPressure = this.Pressure * double.Parse(this.Material);
        }

        public virtual void CountForce()
        {
            if (this.Shape == true)
            {
                this.Area = (3.14 * (this.Diameter * this.Diameter)) / 4;
            }

            else
            {
                this.Area = this.Width * this.Hight;
            }

            this.AreaAll = (this.Area * this.NumberOfCavites) + this.RunnerProjectedArea;
            this.Force = (this.AreaAll * this.CavityPressure) / 1000;
            this.ForceSafety = this.Force * 1.1;
        }

        public virtual void SetMouldID(string mould)
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

        public virtual void PrintList()
        {
            string[] materialList = new string[]
            {
                "AAS/ASA", "ABS", "BDS", "CA", "CAB", "CAP", "CP", "EVA", "GPPS", "HIPS", 
                "MBS", "PA11", "PA12", "PA6", "PA66", "PBT", "PC", "PC/ABS", "PC/PBT", 
                "PE", "PEEK", "PEEL", "PEI", "PES", "PETP", "PMMA", "POM", "PP", "PPO", 
                "PPS", "PPVC", "PSU", "PUR/TPU", "SAN", "TPS", "UPVC"
            };

            foreach (string list in materialList)
            {
                Console.WriteLine($"{list}");
            }
        }

        public virtual double SetNumberOfCavites(double numberOfCavites)
        {
            this.NumberOfCavites = numberOfCavites;
            return this.NumberOfCavites;
        }
        public virtual double SetRunnerProjectedArea(double runnerProjectedArea)
        {
            this.RunnerProjectedArea = runnerProjectedArea;
            return this.RunnerProjectedArea;
        }

        public virtual Statiscics GetStatiscics()
        {
            var result = new Statiscics();
            using (var reader = File.OpenText($"{fileName}.txt"))
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