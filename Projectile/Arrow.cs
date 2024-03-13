using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile
{
    internal class Arrow:Projectile
    {
        public static int ArrowCount { get; private set; }
        public double KnockdownChance { get; private set; }

        public double Sharpness {  get; private set; }

        private static Random rng = new Random();
        /**
         * The static constructor is called only once, and before any instance constructor 
         */
        static Arrow()
        {
            ArrowCount = 0;
        }

        public Arrow() 
        {
            ArrowCount++;

            this.Name = "GenericArrow" + Arrow.Count.ToString();
            this.Description = "Generic Arrow #" + Arrow.Count.ToString();
            this.KnockdownChance = rng.NextDouble();
        }

        public void RemoveFromActionQueue()
        {
            Console.WriteLine($"Removed {Name} from the action queue. I'm dead!");
        }

        public override bool Impact(object target)
        {
            double knockDown = rng.NextDouble();
            if(knockDown > KnockdownChance) 
            {
                Console.WriteLine($"{this.ToString()} knocked down {target.ToString()}");

            }
            RemoveFromActionQueue();
            return true; // remove from target list
        }

        public override string ToString()
        {
            return $"{Description}!";
        }

    }
}
