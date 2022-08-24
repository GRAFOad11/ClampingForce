namespace MouldingApp
{
    public class ForceObject
    {
        public ForceObject(string mould)
        {
           this.Mould = mould;
        }
        public ForceObject(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure)
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
    }

}