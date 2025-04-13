using Microsoft.Win32.SafeHandles;

namespace DungeonGame;

// Player Class
public class Player
{
    public string Name { get; private set; }
    public Room CurrentRoom { get; set; }
    public Inventory Inventory { get; private set; }
    public bool fastMode { get; set; }
    public bool EndingUnlocked = false;


    // Player stats, use .original for normal character stats + equipment bonuses, or use .current for interactions and temporary effects
    string PlayerClass = "Unset";
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
    private (int duration, float damage) Poison { get; set; } // Takes from current health each round
    private (int duration, float percentage) Weaken { get; set; } // Reduces current strength
    private (int duration, float percentage) Confusion { get; set; } // Reduces current agility
    private (int duration, float percentage) Vulnerability { get; set; } // Reduces current armor

    // Player constructor
    public Player(string name, Room startingRoom)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CurrentRoom = startingRoom ?? throw new ArgumentNullException(nameof(startingRoom));
        Inventory = new Inventory();
    }

    // Move method
    public void Move(string direction)
    {
        if (CurrentRoom.Exits.ContainsKey(direction))
        {
            CurrentRoom = CurrentRoom.Exits[direction];
            Console.WriteLine($"You moved to: {CurrentRoom.Name}");
        }
        else
        {
            Console.WriteLine("You can't go that way!");
        }
    }

    // Character class selection method
    public void ClassChoice()
    {
        Console.WriteLine("\nChoose a Class! This determines your stats and abilities. Choose wisely.");
        Console.WriteLine("1: Knight: Heavy Armor & Heavy Weapons. Health = 20");
        Console.WriteLine("2: Rogue: Light Armor & Small Weapons. Health = 12");
        Console.WriteLine("3: Wizard: Staffs & Damaging Magic/Spells. Health = 10");
        Console.WriteLine("4: Cleric: Healing Spells & Blunt Weapons. Health = 15");

        int classChoice;
        while (true)
        {
            Console.Write("\nPlease select a class!\n> ");
            if (int.TryParse(Console.ReadLine(), out classChoice) && classChoice >= 1 && classChoice <= 4)
            {
                switch (classChoice)
                {
                    case 1:
                        PlayerClass = "Knight";
                        Console.WriteLine("Knight");
                        Health = (20, 20f);
                        Strength = (10, 10f);
                        Defense = (20, 20f);
                        Agility = (5, 5f);
                        break;
                    case 2:
                        PlayerClass = "Rogue";
                        Console.WriteLine("Rogue");
                        Health = (12, 12f);
                        Strength = (8, 8f);
                        Defense = (10, 10f);
                        Agility = (20, 20f);
                        break;
                    case 3:
                        PlayerClass = "Wizard";
                        Console.WriteLine("Wizard");
                        Health = (10, 10f);
                        Strength = (2, 2f);
                        Defense = (5, 5f);
                        Agility = (8, 8f);
                        break;
                    case 4:
                        PlayerClass = "Cleric";
                        Console.WriteLine("Cleric");
                        Health = (15, 15f);
                        Strength = (5, 5);
                        Defense = (10, 10f);
                        Agility = (10, 10f);
                        break;
                }
                Console.WriteLine($"\nYou chose {PlayerClass}! \n{Health.original} Health, \n{Strength.original} Strength\n{Defense.original} Defense\n{Agility.original} Agility");
                System.Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please enter a number between 1 and 4.");
            }
        }
    }

    // Buff method
    public void Buff(string status, int duration, float effect)
    {
        switch (status)
        {
            case "heal": // Adds health, use null or 0 for duration
                Health = (Health.original, Health.current + effect);
                Console.WriteLine($"You heal for {effect} health!");
                break;

            case "regeneration":
                Regeneration = (duration, effect);
                Console.WriteLine($"You regenerate for {effect} health for {duration} round(s)!");
                break;

            case "rage":
                Strength = (Strength.original, Strength.current - Strength.original * Rage.percentage);
                Rage = (duration, effect);
                Strength = (Strength.original, Strength.current + Strength.original * effect);
                Console.WriteLine($"You rage for +{effect * 100}% strength for {duration} round(s)!");
                break;

            case "focus":
                Agility = (Agility.original, Agility.current - Agility.original * Focus.percentage);
                Focus = (duration, effect);
                Agility = (Agility.original, Agility.current + Agility.original * effect);
                Console.WriteLine($"You focus for +{effect * 100}% agility for {duration} round(s)!");
                break;

            case "fortify":
                Defense = (Defense.original, Defense.current - Defense.original * Focus.percentage);
                Fortify = (duration, effect);
                Defense = (Defense.original, Defense.current + Defense.original * effect);
                Console.WriteLine($"You fortify for +{effect * 100}% defense for {duration} round(s)!");
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
                Console.WriteLine($"You are stunned for {duration} round(s)!");
                break;

            case "poison":
                Poison = (duration, effect);
                Console.WriteLine($"You are poisoned by {effect} damage for {duration} round(s)!");
                break;

            case "weaken":
                Strength = (Strength.original, Strength.current + Strength.original * Weaken.percentage);
                Weaken = (duration, effect);
                Strength = (Strength.original, Strength.current - Strength.original * effect);
                Console.WriteLine($"You are weakened by {(effect) * 100}% for {duration} round(s)!");
                break;

            case "confusion":
                Agility = (Agility.original, Agility.current + Agility.original * Confusion.percentage);
                Confusion = (duration, effect);
                Agility = (Agility.original, Agility.current - Agility.original * effect);
                Console.WriteLine($"You are confused by {(effect) * 100}% for {duration} round(s)!");
                break;

            case "vulnerability":
                Defense = (Defense.original, Defense.current + Defense.original * Vulnerability.percentage);
                Vulnerability = (duration, effect);
                Defense = (Defense.original, Defense.current - Defense.original * effect);
                Console.WriteLine($"You are weakened by {(effect) * 100}% for {duration} round(s)!");
                break;
        }
    }

    // Update method
    public void TakeDamage(float damage)
    {
        // Add attack damage
        damage -= Math.Max(0, (damage * ((float)Math.Sqrt(Defense.current) * 0.01f))); // Reduce attack damage by defense

        /* Progress Buffs */
        if (Regeneration.duration > 0 && Health.current < Health.original) // Regeneration effect
        {
            Health = (Health.original, Math.Min(Health.original, Health.current + Regeneration.health));
        }
        if (Rage.duration <= 0) // Rage reset
        {
            Strength = (Strength.original, Strength.current - Strength.original * Rage.percentage);
            Rage = (0, 0);
        }
        if (Focus.duration <= 0) // Focus reset
        {
            Agility = (Agility.original, Agility.current - Agility.original * Focus.percentage);
            Focus = (0, 0);
        }
        if (Fortify.duration <= 0) // Fortify reset
        {
            Defense = (Defense.original, Defense.current - Defense.original * Focus.percentage);
            Fortify = (0, 0);
        }

        /* Progress Debuffs */
        if (Poison.duration > 0) // Poison effect
        {
            damage += Poison.damage;
        }
        if (Weaken.duration <= 0) // Weaken reset
        {
            Strength = (Strength.original, Strength.current + Strength.original * Weaken.percentage);
            Weaken = (0, 0);
        }
        if (Confusion.duration <= 0) // Confusion reset
        {
            Agility = (Agility.original, Agility.current + Agility.original * Confusion.percentage);
            Confusion = (0, 0);
        }
        if (Vulnerability.duration <= 0) // Vulnerability reset
        {
            Defense = (Defense.original, Defense.current + Defense.original * Vulnerability.percentage);
            Vulnerability = (0, 0);
        }   

        // Apply Damage
        Health = (Health.original, Health.current - damage);
        Graphics.Type(fastMode, $"You took {damage} points of damage! Your Health is now {Health.current}/{Health.original}.");

        // Check for Death
        if (Health.current <= 0)
        {
            DeathScene();
        }
    }

    public void PlayerHealthCheck()
    {
        Console.WriteLine($"Your health is: {Health.current}");
    }

    static void DeathScene()
    {
        Console.WriteLine("You have perished. Game over.");
        // Add any additional logic for handling player death, such as restarting or exiting the game.
    }

    public virtual void Attack(Enemy enemy)
    {
       Console.WriteLine($"{Name} attacks {enemy.Name}!");
        enemy.TakeDamage(10, this.fastMode); // Example damage value
    }
}