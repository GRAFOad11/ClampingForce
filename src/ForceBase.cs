namespace MouldingApp
{
    public abstract class FORCEbase : FORCEobject, FORCE.IForce
    {
        public FORCEbase(string mould) : base(mould)
        {
        }
        public FORCEbase(string mould,double width, double meltLenth, double thickness, bool shape, double diameter, string material, double cavityPressure) 
        : base(mould, width, meltLenth,  thickness,  shape,  diameter,  material,  cavityPressure) 
        {
        }
        public virtual event FORCE.AddedDelegate Added;
        public abstract void WidthSet(string width);
        public virtual Statiscics GetStatiscics()
        {
            throw new System.NotImplementedException();
        }

        
    }
}