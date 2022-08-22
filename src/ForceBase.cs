namespace MouldingApp
{
    public abstract class FoceBase : FoceObject, Foce.IForce
    {
        public FoceBase(string mould) : base(mould)
        {
        }
        public FoceBase(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure) 
        : base(mould, width, meltLenth,  thickness,  shape,  diameter,  material,  cavityPressure) 
        {
        }
        public virtual event Foce.AddedDelegate Added;
        public abstract void WidthSet(string width);
        public virtual Statiscics GetStatiscics()
        {
            throw new System.NotImplementedException();
        }

        
    }
}