using System;
using System.Collections.Generic;

namespace DungeonGame
{
    // Player Class
    public class Player // Changed to public
    {
        public string Name { get; private set; }
        public Room CurrentRoom { get; set; }
        public Inventory Inventory { get; private set; }
        public bool fastMode { get; set; }
        public bool IsPoisoned { get; set; }
        public int PoisonTurnsRemaining { get; set; }

        // Player stats, reference original for overall stats but use current during interactions
        public (int original, float current) Health { get; set; }
        public (int original, float current) Strength { get; set; }
        public (int original, float current) Defense { get; set; }
        public (int original, float current) Agility { get; set; }

        // Buffs
        private (int duration, float health) Regeneration { get; set; } // Adds to current health each round
        private (int duration, float percentage) Rage { get; set; } // Increases current strength
        private (int duration, float percentage) Focus { get; set; } // Increases current agility
        private (int duration, float percentage) Fortify { get; set; } // Increases current armor

        // Debuffs
        private int Stun { get; set; } // Stops player action
        private (int duration, float damage) Poison {  get; set; } // Takes from current health each round
        private (int duration, float percentage) Weaken { get; set; } // Reduces current strength
        private (int duration, float percentage) Confusion { get; set; } // Reduces current agility
        private (int duration, float percentage) Vulnerability {  get; set; } // Reduces current armor

        // Player constructor

        public Player(string name, Room startingRoom)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CurrentRoom = startingRoom ?? throw new ArgumentNullException(nameof(startingRoom));
            Inventory = new Inventory();
            Health = (100, 100f);
            Strength = (10, 10f);
            Defense = (10, 10f);
            Agility = (5, 5f);
        }

        public void Move(string direction, Player player)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                Graphics.TypeEffectColor(player.fastMode, $"You move {direction} to the {CurrentRoom.Name}.", "green");
            }
            else
            {
                Graphics.TypeEffectColor(player.fastMode, "You can't go that way.", "green");
            }
        }

        // Attack method
        public void Attack(int enemyDamage)
        {
            Health = (Health.original, Health.current - (enemyDamage - (enemyDamage * ((float)Math.Sqrt(Defense.current) * 0.01f)))); 
        }
        // Heal method
        public void Heal(int health)
        {
            Health = (Health.original, Health.current + health);
        }
        // Buff method
        public void Buff(string status, int duration, float effect)
        {
            switch (status)
            {
                case "regeneration":
                    Regeneration = (duration, effect);
                    break;

                case "rage":
                    Rage = (duration, effect);
                    Strength = (Strength.original, Strength.current + Strength.current * effect);
                    break;

                case "focus":
                    Focus = (duration, effect);
                    Agility = (Agility.original, Agility.current + Agility.current * effect);
                    break;

                case "fortify":
                    Fortify = (duration, effect);
                    Defense = (Defense.original, Defense.current + Defense.current * effect);
                    break;
            }
        }
        // Debuff method
        public void Debuff(string status, int duration, float effect)
        {
            switch (status)
            {
                case "stun":
                    Stun = duration;
                    break;

                case "poison":
                    Poison = (duration, effect);
                    break;

                case "weaken":
                    Weaken = (duration, effect);
                    Strength = (Strength.original, Strength.current - Strength.current * effect);
                    break;

                case "confusion":
                    Confusion = (duration, effect);
                    Agility = (Agility.original, Agility.current - Agility.current * effect);
                    break;

                case "vulnerability":
                    Vulnerability = (duration, effect);
                    Defense = (Defense.original, Defense.current - Defense.current * effect);
                    break;
            }
        }

        // Update method
        public void TakeDamage(int damage)
        {
            // Poison effect
            if (Poison.duration > 0)
            {
                Health = (Health.original, Health.current - Poison.damage);
            }

            // Weaken reset
            if (Weaken.duration == 0)
            {
                Strength = (Strength.original, Strength.original);
            }

            // Confusion reset
            if (Confusion.duration == 0)
            {
                Agility = (Agility.original, Agility.original);
            }

            // Vulnerability reset
            if (Vulnerability.duration == 0)
            {
                Defense = (Defense.original, Defense.original);
            }

            // Regeneration effect
            if (Regeneration.duration > 0 && Health.current < Health.original)
            {
                Health = (Health.original, Health.current + Regeneration.health);
            }
            if (Health.current > Health.original)
            {
                Health = (Health.original, Health.original);
            }

            // Rage reset
            if (Rage.duration == 0)
            {
                Strength = (Strength.original, Strength.original);
            }

            // Focus reset
            if (Focus.duration == 0)
            {
                Strength = (Strength.original, Strength.original);
            }

            // Calculate effective damage
            int effectiveDamage = Math.Max(0, damage - (int)Defense.current); // Reduce damage by defense
            Health = (Health.original, Health.current - effectiveDamage); // Subtract damage from current health

            Console.WriteLine($"{Name} takes {effectiveDamage} damage! Health is now {Health.current}.");

            // Fortify reset
            if (Fortify.duration == 0)
            {
                Defense = (Defense.original, Defense.original);
            }

            // Check if the player is defeated
            if (Health.current <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!");
                // Handle player death logic here
            }
        }
    }
}