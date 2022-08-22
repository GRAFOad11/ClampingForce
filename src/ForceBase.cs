namespace MouldingApp
{
    public abstract class ForceBase : ForceObject, IMould
    {
        public ForceBase(string mould) : base(mould)
        {
        }
        public ForceBase(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure) 
        : base(mould, width, meltLenth,  thickness,  shape,  diameter,  material,  cavityPressure) 
        {
        }

        public virtual Statiscics GetStatiscics()
        {
            throw new System.NotImplementedException();
        }

        public abstract void WidthSet(string width);
        
    }
}