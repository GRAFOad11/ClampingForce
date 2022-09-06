using System;
using System.IO;

namespace MouldingApp
{
    public class ForceBase : EventMessages, IMould
    {
        public const string fileName = "Wyniki Obliczeń.txt";
        public const string fileNameAudit = "audit.txt";
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
        public double Voidarea { get; set; }

        public virtual void WidthSet(string width)
        {
            if (double.TryParse(width, out double result))
            {
                this.Width = result / 10;
            }
        }

        public virtual void HightSet(string hight)
        {
            if (double.TryParse(hight, out double result))
            {
                this.Hight = result / 10;
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
            if (shape == "Y" || shape == "y" || shape == "T" || shape == "t" || shape == "tak" || shape == "TAK")
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
                this.Diameter = result / 10;
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
                // Original list of material viscosity does not work werry well !!!!
                /*case "GPPS" or "HIPS" or "TPS" or "PE" or "PP": material = "1"; break;
                case "PA6" or "PA66" or "PA11" or "PA12" or "PBT" or "PETP": material = "1,35"; break;
                case "CA" or "CAB" or "CAP" or "CP" or "EVA" or "PEEL" or "PUR" or "TPU" or "PPVC": material = "1,45"; break;
                case "ABS" or "AAS/ASA" or "SAN" or "MBS" or "PPS" or "PPO" or "BDS" or "POM": material = "1,55"; break;
                case "PMMA" or "PC/ABS" or "PC/PBT": material = "1,7"; break;
                case "PC" or "PES" or "PSU" or "PEI" or "PEEK" or "UPVC": material = "1,9"; break;*/

                case "PP" or "TPE": material = "1"; break;
                case "PE-LD" or "TPE-S": material = "1,2"; break;
                case "PS" or "TPE-O" or "TPE-V ": material = "1,3"; break;
                case "PS-HI": material = "1,4"; break;
                case "PA66": material = "1,5"; break;
                case "PP-KS" or "LCP": material = "1,6"; break;
                case "PA6" or "PA6-GF" or "PA66-GF" or "PP-T": material = "1,7"; break;
                case "PP-FSC": material = "1,8"; break;
                case "PE-HD" or "PPE-PA" or "SAN": material = "1,9"; break;
                case "PET-GF": material = "2"; break;
                case "PMMA" or "TPE-A": material = "2,2"; break;
                case "ABS": material = "2,3"; break;
                case "POM": material = "2,5"; break;
                case "PC/ABS": material = "2,6"; break;
                case "TPE-E": material = "2,8"; break;
                case "PSU": material = "2,9"; break;
                case "PES": material = "3,2"; break;
                case "PPS": material = "3,6"; break;
                case "PBT-GF": material = "3,7"; break;
                case "PC/PBT": material = "3,8"; break;
                case "PBT": material = "3,9"; break;
                case "PC-GF" or "TPE-U": material = "4"; break;
                case "PEI": material = "4,4"; break;
                case "PVC-U": material = "4,5"; break;
                case "PC": material = "5,2"; break;

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
                this.Area = (3.14 * (this.Diameter * this.Diameter)) / 4 - this.Voidarea;
            }

            else
            {
                this.Area = this.Width * this.Hight - this.Voidarea;
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
                Console.WriteLine($"Nazwa formy {mould}\n");
            }
        }

        public virtual void PrintList()
        {
            string[] materialList = new string[]
            {
                /*"AAS/ASA", "ABS", "BDS", "CA", "CAB", "CAP", "CP", "EVA", "GPPS", "HIPS", 
                "MBS", "PA11", "PA12", "PA6", "PA66", "PBT", "PC", "PC/ABS", "PC/PBT", 
                "PE", "PEEK", "PEEL", "PEI", "PES", "PETP", "PMMA", "POM", "PP", "PPO", 
                "PPS", "PPVC", "PSU", "PUR/TPU", "SAN", "TPS", "UPVC"
                */
                "ABS", "LCP", "PA6", "PA66", "PA66-GF", "PA6-GF", "PBT", "PBT-GF", "PC",
                "PC/ABS", "PC/PBT", "PC-GF", "PE-HD", "PEI", "PE-LD", "PES", "PET-GF", 
                "PMMA", "POM", "PP", "PPE-PA", "PP-FSC", "PP-KS", "PPS", "PP-T", "PS", 
                "PS-HI", "PSU", "PVC-U", "SAN", "TPE", "TPE-A", "TPE-E", "TPE-O", "TPE-S",
                "TPE-U", "TPE-V"
            };

            foreach (string list in materialList)
            {
                Console.WriteLine($"{list}");
            }
        }

        public virtual void SetNumberOfCavites(string numberOfCavites)
        {
            if (double.TryParse(numberOfCavites, out double result))
            {
                this.NumberOfCavites = result;
            }
        }

        public virtual void SetRunnerProjectedArea(string runnerProjectedArea)
        {
            if (double.TryParse(runnerProjectedArea, out double result))
            {
                this.RunnerProjectedArea = result;
            }
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

        public virtual void VoidArea(string voidArea)
        {
            if (double.TryParse(voidArea, out double result))
            {
                this.Voidarea = result;
            }
        }
    }
}