using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Projectile
{
    internal class Projectile
    {
        public static int Count { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Point3D Location { get; set; }
        public Direction3D Direction { get; set; }

        public Projectile() 
        {
            this.Location = new Point3D();
            Projectile.Count++;
            this.Name = "GenericProjectile" + Projectile.Count.ToString();
            this.Description = "Generic Projectile #" + Projectile.Count.ToString();
            Location = new Point3D(8, 15, -9);
            this.Direction = new Direction3D(); // initally 0 by 0
        }

        /**
         * The static constructor is called at most once, and before any instance constructor is invoked.
         * You would use this instead of an initilizer if there were external conditions for the value.
         * The runtime calls the static constructor after the initializer but before creating an instance and before referencing any static members 
         */
        static Projectile()
        {
            Count = 0;
        }
       
        /**
         * Value constructor. Note the : this(), which calls the Projectile default constructor
         */
        public Projectile(string name) :this()
        {
            this.Name=name;
        }

        public virtual bool Impact(object target)
        {
            return true;
        }


        public override string ToString()
        {
            return ($"{this.Name} at ({this.Location.X}, {this.Location.Y}, {this.Location.Z})");
        }
         public void Move()
        {

        }

    }
}
