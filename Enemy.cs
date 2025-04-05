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
        public virtual void Attack(Player player)
        {
            Console.WriteLine($"{Name} attacks {player.Name}!");
            player.TakeDamage(10); // Example damage value
        }

        // Special poison attack: applies a poison status to the player
        public void PoisonAttack(Player player)
        {
            Console.WriteLine($"{Name} uses Poison Attack on {player.Name}!");
            player.Debuff("poison", 3, 1f);
        }

        // Enemy chooses what action to take during its turn
        public virtual void EnemyTurn(Player player)
        {
            Console.WriteLine($"{Name} is taking its turn.");
            // Default enemy behavior
        }

        public void TakeDamage(float damage, bool fastMode)
        {
            // Apply Damage
            Health = (Health.original, Health.current - damage);
            Graphics.Type(fastMode, $"{Name} took {damage} points of damage!");
        }

    }
    // Specific enemy: Acid Worm subclass that inherits from Enemy
    public class AcidWorm : Enemy
    {
        // Constructor uses base class values
        public AcidWorm(string name, int health) : base("Acid Worm", 50, 50) { }

        // Overrides the TakeTurn behavior to include unique text
        public override void Attack(Player player)
        {
            Graphics.Type(player.fastMode, $"{Name} spits acid at {player.Name}!", "red");
            player.TakeDamage(15); // Example acid damage
        }
    }
}