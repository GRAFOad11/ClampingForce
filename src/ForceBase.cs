
namespace MouldingApp
{
    public abstract class ForceBase : ForceObject, IMould
    {
        public ForceBase(string mould) : base(mould){}
        public ForceBase(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure) 
        : base(mould, width, meltLenth,  thickness,  shape,  diameter,  material,  cavityPressure) {}
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