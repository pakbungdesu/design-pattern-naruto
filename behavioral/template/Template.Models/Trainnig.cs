
namespace Trainings
{
   public abstract class JutsuTraining
    {
        public void Train()
        {
            Focus();
            OrganizeBreathing();
            VisualizeChakra();
            ApplyToFeet();
            ApplyToHand();
            ApplyToMouth();
            Release();
            Climb();
            Walk();
            Diffuse();
            Console.WriteLine("--------------\n");
        }

        // Every subclass implements these
        public abstract void Focus();
        public abstract void Release();

        // Same across your classes
        public virtual void OrganizeBreathing() => Console.WriteLine("- Close eyes and concentrate");
        public virtual void VisualizeChakra() => Console.WriteLine("- Visualize own chakra");

        // Optional hook steps
        public virtual void ApplyToFeet() { }
        public virtual void ApplyToHand() { }
        public virtual void ApplyToMouth() { }
        public virtual void Climb() { }
        public virtual void Walk() { }
        public virtual void Diffuse() { }
    }

    public class TreeClimbing : JutsuTraining
    {
        public override void Focus() => Console.WriteLine("- Look at the tree");
        public override void ApplyToFeet() => Console.WriteLine("- Apply to Feet");
        public override void Release() => Console.WriteLine("- Release chakra through feet");
        public override void Climb() => Console.WriteLine("- Climb the tree");
    }

    public class WaterWalking : JutsuTraining
    {
        public override void Focus() => Console.WriteLine("- Look at water surface");
        public override void ApplyToFeet() => Console.WriteLine("- Apply to Feet");
        public override void Release() => Console.WriteLine("- Release chakra through feet");
        public override void Walk() => Console.WriteLine("- Walk on the water surface");
    }

    public class Rasengan : JutsuTraining
    {
        public override void Focus() => Console.WriteLine("- Look at opponent");
        public override void ApplyToHand() => Console.WriteLine("- Apply to both hands");
        public override void Release() => Console.WriteLine("- Release chakra through hands");
        public override void Diffuse() => Console.WriteLine("- Rasengan spinning attacks the opponent");
    }

    public class Fireball : JutsuTraining
    {
        public override void Focus() => Console.WriteLine("- Look at opponent");
        public override void ApplyToHand() => Console.WriteLine("- Apply to one hand");
        public override void ApplyToMouth() => Console.WriteLine("- Apply to mouth");
        public override void Release() => Console.WriteLine("- Release chakra through mouth");
        public override void Diffuse() => Console.WriteLine("- Fireball flowing attacks the opponent");
    }
}