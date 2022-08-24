using System;
using System.IO;

namespace MouldingApp
{
    public class SaveForce : ForceBase
    {
        public SaveForce(string mould) : base(mould){}
        
        public SaveForce(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure) 
        : base(mould, width, meltLenth,  thickness,  shape,  diameter,  material,  cavityPressure) {}



        public override void AddDimension(double width, double hight)
        {
            throw new System.NotImplementedException();
        }

        public override void CavityPressureSet(string cavityPressure)
        {
            throw new System.NotImplementedException();
        }

        public override void CountForce()
        {
            throw new System.NotImplementedException();
        }

        public override void CountPressure()
        {
            throw new System.NotImplementedException();
        }

        public override void DiameterSet(string diameter)
        {
            throw new System.NotImplementedException();
        }

        public override Statiscics GetStatiscics()
        {
            throw new System.NotImplementedException();
        }

        public override void HightSet(string hight)
        {
            throw new System.NotImplementedException();
        }

        public override void LongestMeltSet(string melt)
        {
            throw new System.NotImplementedException();
        }

        public override string MaterialViscosity(string material)
        {
            throw new System.NotImplementedException();
        }

        public override void PrintList()
        {
            throw new System.NotImplementedException();
        }

        public override void SetMouldID(string mould)
        {
            throw new System.NotImplementedException();
        }

        public override void ShapeSet(string shape)
        {
            throw new System.NotImplementedException();
        }

        public override void ThicknessSet(string thickness)
        {
            throw new System.NotImplementedException();
        }

        public override void WidthSet(string width)
        {
            if (double.TryParse(width, out double result))
            {
                using (var writer = File.AppendText($"{Mould}.txt"))
                {
                    writer.WriteLine($"Długość {width}cm");
                }
            } 
            else
            {
                Console.WriteLine($"Błąd źle wpisałeś tą liczbę {width}");
                throw new ArgumentException($"Niewłaściwa składnia {nameof(width)}");
            }
        }
    }
}