namespace Projectile
{
    /*
        Projectile Class

    Our zombie dinosaur hunter game currently uses a generic projectile as a placeholder, which has no methods and very rudimetary structure.
    Your assignment is to create a class hierarchy to replace that temporary class.
    The game works by placing active items (NPCs, players, projectiles) in an Action queue. The Action queue is activated every game cycle
    (usually 60 times per second). 

    You are to develop a class hierarchy for the various projectiles we have in this game: arrows (long and short), crossbow bolts (light and heavy), bullets (pistol: .45 caliber, 9mm, and .22 caliber), rifle (7.62 and 5.56)), and shells (cannonballs, mortar, and howitzer). 

    Each type of projectile will have the following (declared as double):
        a damage minimum and maximum (to prevent RNG anomalies creating strange effects like one-shot .22 kills on a T-Rex)
        a speed minimum and maximum (also to prevent anomalies making the game even more unrealistic than our premise provides)
        a range maximum (no infinite head-shots)
        a projectile drop value (to further limit range and accuracy, and to provide some skill requirements for the game)

    Your classes must have:
        Move() method that changes the projectile's coordinates according to its speed and direction. This method has no arguments and returns a Point3D.
        MoveTo() method that "magically" sets the projectile at the new location.This method takes a Point3D argument but returns no values.
        IsInProximityTo() method that returns true if the projectile is within the proximity value of the target, and false otherwise.This method takes a Point3D argument for the target and a double argument for the range or distance from the target.
        WhereAmI() method which returns the projectile's current location as a Point3D
        Fire() method that initializes the projectile's location, speed, and direction (ostensibly from the location of the weapon firing the projectile)
            This method uses a RNG to set the speed and takes two arguments: the location (a Point3D) and a direction (a double)
        Impact() method. This method will change behavior depending on the type of projectile:
            bullets have a chance of penetrating (passing through) targets with a diminishing chance after each target, but never change direction
            arrows will never pass through a target but may knock them down; long arrows have a higher probability of this
            bolts may pass through the first target but never more than one; they never change direction, and may knock the target down
            shells explode on contact with a variable damage circumference based on the damage max
            cannon balls will pass through all targets in their path within its range maximum and have a moderate chance of changing direction slightly
            
            Notes: A Projectile that stops in a target or reaches its max range will be removed from the Action queue
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            List<Projectile> projectiles = new List<Projectile>();

            Arrow arrow = new Arrow();
            projectiles.Add(arrow);

            Object target = new Object();
           
            for(int i = 0; i < 40; i++) 
            {
                if (rng.Next() % 2 == 0)
                {
                    arrow = new Arrow();
                    projectiles.Add(arrow);
                }
                else 
                {
                    Bullet bullet = new Bullet();
                    projectiles.Add(bullet);
                }
            }

            List<Projectile> deadProjectiles = new List<Projectile>();
            while(projectiles.Count > 0)
            {
                foreach (Projectile item in projectiles)
                {
                    Console.WriteLine($"I am {item.ToString()}");
                    if (item.Impact(target))
                    {
                        deadProjectiles.Add(item);
                    }
                }

                foreach(Projectile item in deadProjectiles)
                {
                    projectiles.Remove(item);
                }
            }
            Console.WriteLine("All projectiles have stopped, dropped, and or rolled.");
        }
    }
}
