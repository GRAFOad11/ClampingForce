using System.Collections.Generic;

namespace MouldingApp
{
    public abstract class ForceBase : EventMessages, IMould
    {
        public abstract event AddedDelegate Added;
        public ForceBase(string mould)
        {
           this.Mould = mould;
        }
        public ForceBase(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure)
        {
           this.Mould = mould;
           this.Width = width;
           this.MeltLenth = meltLenth;
           this.Thickness = thickness;
           this.Shape = shape;
           this.Diameter = diameter;
           this.Material = material;
           this.CavityPressure = cavityPressure;
        }
        private double width;
        private double hight;
        private double meltLenth;
        private double thickness;
        private bool shape;
        private double diameter;
        private string material;
        private double cavityPressure;
        public string Mould { get; set; }
        public double Width { get{return this.width;} set{this.width = value;}}
        public double Hight { get{return this.hight;} set{this.hight = value;}}
        public double MeltLenth { get{return this.meltLenth;} set{this.meltLenth = value;}}
        public double Thickness { get{return this.thickness;} set{this.thickness = value;}}
        public bool Shape { get{return this.shape;} set{this.shape = value;}}
        public double Diameter { get{return this.diameter;} set{this.diameter = value;}}
        public string Material { get{return this.material;} set{ if(!string.IsNullOrEmpty(value)){this.material = value;}}}
        public double CavityPressure { get{return this.cavityPressure;} set{this.cavityPressure = value;}}
        public string[] materialList = new string[] {"GPPS", "HIPS", "TPS", "PE", "PP", "PA6", "PA66", "PA11", "PA12", "PBT", "PETP", "CA", "CAB", "CAP", "CP",
        "EVA", "PEEL", "PUR/TPU", "PPVC", "ABS", "AAS/ASA", "SAN", "MBS", "PPS", "PPO", "BDS", "POM", "PMMA", "PC/ABS", "PC/PBT", "PC", "PES", "PSU", "PEI", "PEEK", "UPVC"};
        public List<double> dimensions = new List<double>();
        public List<int> pressure = new List<int>();
        public abstract void WidthSet(string width);
        public abstract Statiscics GetStatiscics();
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
    }
}