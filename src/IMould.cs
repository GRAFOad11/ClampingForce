using static MouldingApp.EventMessages;

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
        string MaterialViscosity(string material);
        void CountPressure();
        void CountForce();
        void SetMouldID(string mould);
        void PrintList();
        void SetNumberOfCavites(string numberOfCavites);
        void SetRunnerProjectedArea(string runnerProjectedArea);
        void VoidArea(string voidArea);
        Statiscics GetStatiscics();
        event AddedDelegate Added;
    }
}