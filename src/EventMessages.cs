using System;

namespace MouldingApp
{
    public class EventMessages
    {
        public delegate void AddedDelegate(object sender, EventArgs args, string diameter);
        public virtual void OnAdded(object sender, EventArgs args, string diameter)
        {
            if (double.TryParse(diameter, out double result) && result < 3)
            {
                Console.WriteLine($"Małe to kółeczko");
            }
        }
    } 
}