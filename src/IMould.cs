using System;
//ctrl+k+d
namespace MouldingApp
{
    public interface IMould
    {
        string Mould { get; }
        void WidthSet(string width);
        void HightSet(string hight);
        void LongestMeltSet(string melt);
        void ThicknessSet(string thickness);
        void ShapeSet(string shape);
        void DiameterSet(string diameter);
        void CavityPressureSet(string cavityPressure);
        string MaterialViscosity(string material);
        void CountPressure();
        void CountForce();
        void SetMouldID(string mould);
        void AddDimension(double width, double hight);
        void PrintList();
        Statiscics GetStatiscics();

    }

}