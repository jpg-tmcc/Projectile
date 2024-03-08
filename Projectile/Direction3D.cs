using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile
{
    internal class Direction3D
    {
        private double theta = 0; // the rotation from 0 radians in the x-y plane
        private double phi = 0;   // the inclination/declination from the x-y plane in radians

        public Direction3D()
        {
            theta = 0;
            phi = 0;
        }

        public Direction3D (double theta, double phi)
        {
            this.theta = theta;
            this.phi = phi;
        }

    }
}
