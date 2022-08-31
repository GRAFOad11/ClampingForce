using System.Collections.Generic;

namespace MouldingApp
{
    public abstract class ForceBase : EventMessages, IMould
    {
        public List<double> dimensions = new List<double>();
        public List<int> pressure = new List<int>();
        public const string fileName = "Wyniki Obliczeń.txt";
        public const string fileNameAudit = "audit.txt";
        public string[] materialList = new string[] 
        {
            "GPPS", "HIPS", "TPS", "PE", "PP", "PA6", "PA66",
            "PA11", "PA12", "PBT", "PETP", "CA", "CAB", "CAP",
            "CP","EVA", "PEEL", "PUR/TPU", "PPVC", "ABS", "AAS/ASA",
            "SAN", "MBS", "PPS", "PPO", "BDS", "POM", "PMMA", "PC/ABS",
            "PC/PBT", "PC", "PES", "PSU", "PEI", "PEEK", "UPVC"
        };
        public abstract event AddedDelegate Added;
        public ForceBase(string mould)
        {
           this.Mould = mould;
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
        public string Material 
        { 
            get {return this.material;} 
            set
            { 
                if(!string.IsNullOrEmpty(value))
                {
                    this.material = value;
                }
            }
        }
        private double width;
        private double hight;
        private double meltLenth;
        private double thickness;
        private bool shape;
        private double diameter;
        private string material;
        private double cavityPressure;
        private double numberOfCavites;
        private double runnerProjectedArea;

        public abstract void WidthSet(string width);
        public abstract void HightSet(string hight);
        public abstract void LongestMeltSet(string melt);
        public abstract void ThicknessSet(string thickness);
        public abstract void ShapeSet(string shape);
        public abstract void DiameterSet(string diameter);
        public abstract void CavityPressureSet(string cavityPressure);
        public abstract string MaterialViscosity(string material);
        public abstract void CountPressure();
        public abstract void CountForce();
        public abstract void SetMouldID(string mould);
        public abstract void AddDimension(double width, double hight);
        public abstract void PrintList();
        public abstract double SetNumberOfCavites(double numberOfCavites);
        public abstract double SetRunnerProjectedArea(double runnerProjectedArea);
        public abstract Statiscics GetStatiscics();
    }
}