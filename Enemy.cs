using System;

namespace DungeonGame
{
    // Enemy Class - Represents an enemy in the dungeon
    public class Enemy
    {
        // Properties: Every enemy has a name and health
        public string Name { get; private set; }
        public (int original, float current) Health { get; set; }

        // Constructor: Called when creating a new enemy object
        public Enemy(string name, int maxHealth, int currentHP)
        {
            Name = name;
            Health = (maxHealth, currentHP);
        }

        // Enemy attacks the player
        public void Attack(Player player)
        {
            Console.WriteLine($"{Name} attacks {player.Name}!");
            player.TakeDamage(10); // Example damage value
        }

        // Special poison attack: applies a poison status to the player
        public void PoisonAttack(Player player)
        {
            Console.WriteLine($"{Name} uses Poison Attack on {player.Name}!");
            player.IsPoisoned = true;
            player.PoisonTurnsRemaining = Math.Max(player.PoisonTurnsRemaining, 3); // Ensure poison duration is extended.
        }

        // Enemy chooses what action to take during its turn
        public virtual void TakeTurn(Player player)
        {
            Console.WriteLine($"{Name} is taking its turn.");
            // Default enemy behavior
        }
    }

    // Specific enemy: Acid Worm subclass that inherits from Enemy
    public class AcidWorm : Enemy
    {
        // Constructor uses base class values
        public AcidWorm(string name, int health) : base("Acid Worm", 50, 50) { }

        // Overrides the TakeTurn behavior to include unique text
        public override void TakeTurn(Player player)
        {
            Console.WriteLine($"{Name} spits acid at {player.Name}!");
            player.TakeDamage(15); // Example acid damage
        }
    }
}