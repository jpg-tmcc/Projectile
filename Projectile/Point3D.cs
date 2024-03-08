using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile
{
    internal class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point3D add(Point3D p)
        {
           Point3D point3D = new Point3D();
            point3D.X = this.X + p.X;
            point3D.Y = this.Y + p.Y;
            point3D.Z = this.Z + p.Z;
            return point3D;
        }
    }
}
