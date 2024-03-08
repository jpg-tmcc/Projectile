using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile
{
     internal class Bullet:Projectile
    {
        public enum CaliberChoices { US22, US45, M9mm, M765, M556 }

    public static int BulletCount { get; private set; }

        private static Random rng = new Random();

        public double PassThroughChance { get; private set; }
        public CaliberChoices BulletCaliber {  get; private set; }


        /**
         * The static constructor is called only once, and before any instance constructor 
         */
        static Bullet()
        {
            BulletCount = 0;
        }

        public Bullet()
        {
            BulletCount++;

            int caliberChoice = rng.Next() % 5;
            BulletCaliber = (CaliberChoices)caliberChoice;

            this.Name = "GenericBullet" + Bullet.BulletCount.ToString();
            this.Description = "Generic Bullet #" + Bullet.BulletCount.ToString();
            this.PassThroughChance = rng.NextDouble();
        }

        public Bullet (CaliberChoices caliber):this() // :this invokes the base constructor
        {
            BulletCaliber = caliber;
        }

        public override string ToString()
        {
            return $"{Description}, pass through chance:{PassThroughChance:0.00} caliber {BulletCaliber}";
        }

        private void RemoveFromActionQueue()
        {
            Console.WriteLine($"Removed {Name} from the action queue. I'm down!");
        }
        public override bool Impact(object target)
        {
            double passThrough = rng.NextDouble();
            if (passThrough > PassThroughChance)
            {
                Console.WriteLine($"{this.ToString()} passed through {target.ToString()}");
                return false;
            }
            else
            {
                RemoveFromActionQueue();
                return true;
            }
        }
    }
}
