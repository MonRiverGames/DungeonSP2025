using System;

namespace DungeonGame
{
    public class Enemy
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public virtual void TakeTurn(Player player)
        {
            Console.WriteLine($"{Name} is taking its turn.");
            // Default enemy behavior
        }

        public void PoisonAttack(Player player)
        {
            Console.WriteLine($"{Name} uses Poison Attack on {player.Name}!");
            // Implement poison attack logic
        }
    }

    public class AcidWorm : Enemy
    {
        public AcidWorm(string name, int health) : base(name, health) { }

        public override void TakeTurn(Player player)
        {
            Console.WriteLine($"{Name} spits acid at {player.Name}!");
            // Implement AcidWorm-specific behavior
        }
    }
}