using Microsoft.Win32.SafeHandles;
using System.Numerics;

namespace DungeonGame;

// Player Class
public class Player
{
    public bool fastMode { get; set; }
    public GameData gameData { get; set; }

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
    public Player(GameData Data)
    {
        gameData = Data;
        
    }

    // Move method
    public void Move(string direction)
    {
        if (gameData.CurrentRoom.Exits.ContainsKey(direction))
        {
            gameData.CurrentRoom = gameData.CurrentRoom.Exits[direction];
            Graphics.Type(fastMode, $"You moved to: {gameData.CurrentRoom.Name}");
        }
        else
        {
            Graphics.Type(fastMode, "You can't go that way!");
        }
    }

    // Character class selection method
    public void ClassChoice()
    {
        Graphics.Type(fastMode, "\nChoose a Class! This determines your stats and abilities. Choose wisely.");
        Graphics.Type(fastMode, "1: Knight: Heavy Armor & Heavy Weapons.");
        Graphics.Type(fastMode, "2: Rogue: Light Armor & Small Weapons.");
        Graphics.Type(fastMode, "3: Wizard: Staffs & Damaging Magic/Spells.");
        Graphics.Type(fastMode, "4: Cleric: Healing Spells & Blunt Weapons.");

        int classChoice;
        while (true)
        {
            Console.Write("\nPlease select a class!\n> ");
            if (int.TryParse(Console.ReadLine(), out classChoice) && classChoice >= 1 && classChoice <= 4)
            {
                switch (classChoice)
                {
                    case 1:
                        gameData.PlayerClass = "Knight";
                        Graphics.Type(fastMode, "Knight");
                        gameData.Health = (100, 100f);
                        gameData.Strength = (10, 10f);
                        gameData.Defense = (20, 20f);
                        gameData.Agility = (5, 5f);
                        break;
                    case 2:
                        gameData.PlayerClass = "Rogue";
                        Graphics.Type(fastMode, "Rogue");
                        gameData.Health = (100, 100f);
                        gameData.Strength = (8, 8f);
                        gameData.Defense = (10, 10f);
                        gameData.Agility = (20, 20f);
                        break;
                    case 3:
                        gameData.PlayerClass = "Wizard";
                        Graphics.Type(fastMode, "Wizard");
                        gameData.Health = (100, 100f);
                        gameData.Strength = (2, 2f);
                        gameData.Defense = (5, 5f);
                        gameData.Agility = (8, 8f);
                        break;
                    case 4:
                        gameData.PlayerClass = "Cleric";
                        Graphics.Type(fastMode, "Cleric");
                        gameData.Health = (100, 100f);
                        gameData.Strength = (5, 5);
                        gameData.Defense = (10, 10f);
                        gameData.Agility = (10, 10f);
                        break;
                }
                Graphics.Type(fastMode, $"\nYou chose {gameData.PlayerClass}! \n{gameData.Health.original} Health\n{gameData.Strength.original} Strength\n{gameData.Defense.original} Defense\n{gameData.Agility.original} Agility");
                Graphics.Type(fastMode, "\nPress any key to continue.\n> ");
                Console.ReadKey();
                break;
            }
            else
            {
                Graphics.Type(fastMode, "*Incorrect Buzzer Sound* Try again. This time enter a number between 1 and 4.");
            }
        }
    }

    // Buff method
    public void Buff(string status, int duration, float effect)
    {
        switch (status)
        {
            case "heal": // Adds health, use null or 0 for duration
                gameData.Health = (gameData.Health.original, gameData.Health.current + effect);
                Graphics.Type(fastMode, $"You heal for {effect} health!");
                break;

            case "regeneration":
                Regeneration = (duration, effect);
                Graphics.Type(fastMode, $"You regenerate for {effect} health for {duration} round(s)!");
                break;

            case "rage":
                gameData.Strength = (gameData.Strength.original, gameData.Strength.current - gameData.Strength.original * Rage.percentage);
                Rage = (duration, effect);
                gameData.Strength = (gameData.Strength.original, gameData.Strength.current + gameData.Strength.original * effect);
                Graphics.Type(fastMode, $"You rage for +{effect * 100}% strength for {duration} round(s)!");
                break;

            case "focus":
                gameData.Agility = (gameData.Agility.original, gameData.Agility.current - gameData.Agility.original * Focus.percentage);
                Focus = (duration, effect);
                gameData.Agility = (gameData.Agility.original, gameData.Agility.current + gameData.Agility.original * effect);
                Graphics.Type(fastMode, $"You focus for +{effect * 100}% agility for {duration} round(s)!");
                break;

            case "fortify":
                gameData.Defense = (gameData.Defense.original, gameData.Defense.current - gameData.Defense.original * Focus.percentage);
                Fortify = (duration, effect);
                gameData.Defense = (gameData.Defense.original, gameData.Defense.current + gameData.Defense.original * effect);
                Graphics.Type(fastMode, $"You fortify for +{effect * 100}% defense for {duration} round(s)!");
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
                Graphics.Type(fastMode, $"You are stunned for {duration} round(s)!");
                break;

            case "poison":
                Poison = (duration, effect);
                Graphics.Type(fastMode, $"You are poisoned by {effect} damage for {duration} round(s)!");
                break;

            case "weaken":
                gameData.Strength = (gameData.Strength.original, gameData.Strength.current + gameData.Strength.original * Weaken.percentage);
                Weaken = (duration, effect);
                gameData.Strength = (gameData.Strength.original, gameData.Strength.current - gameData.Strength.original * effect);
                Graphics.Type(fastMode, $"You are weakened by {(effect) * 100}% for {duration} round(s)!");
                break;

            case "confusion":
                gameData.Agility = (gameData.Agility.original, gameData.Agility.current + gameData.Agility.original * Confusion.percentage);
                Confusion = (duration, effect);
                gameData.Agility = (gameData.Agility.original, gameData.Agility.current - gameData.Agility.original * effect);
                Graphics.Type(fastMode, $"You are confused by {(effect) * 100}% for {duration} round(s)!");
                break;

            case "vulnerability":
                gameData.Defense = (gameData.Defense.original, gameData.Defense.current + gameData.Defense.original * Vulnerability.percentage);
                Vulnerability = (duration, effect);
                gameData.Defense = (gameData.Defense.original, gameData.Defense.current - gameData.Defense.original * effect);
                Graphics.Type(fastMode, $"You are weakened by {(effect) * 100}% for {duration} round(s)!");
                break;
        }
    }

    // Update method
    public void TakeDamage(float damage)
    {
        // Add attack damage
        damage -= Math.Max(0, (damage * ((float)Math.Sqrt(gameData.Defense.current) * 0.01f))); // Reduce attack damage by defense

        /* Progress Buffs */
        if (Regeneration.duration > 0 && gameData.Health.current < gameData.Health.original) // Regeneration effect
        {
            gameData.Health = (gameData.Health.original, Math.Min(gameData.Health.original, gameData.Health.current + Regeneration.health));
        }
        if (Rage.duration <= 0) // Rage reset
        {
            gameData.Strength = (gameData.Strength.original, gameData.Strength.current - gameData.Strength.original * Rage.percentage);
            Rage = (0, 0);
        }
        if (Focus.duration <= 0) // Focus reset
        {
            gameData.Agility = (gameData.Agility.original, gameData.Agility.current - gameData.Agility.original * Focus.percentage);
            Focus = (0, 0);
        }
        if (Fortify.duration <= 0) // Fortify reset
        {
            gameData.Defense = (gameData.Defense.original, gameData.Defense.current - gameData.Defense.original * Focus.percentage);
            Fortify = (0, 0);
        }

        /* Progress Debuffs */
        if (Poison.duration > 0) // Poison effect
        {
            damage += Poison.damage;
        }
        if (Weaken.duration <= 0) // Weaken reset
        {
            gameData.Strength = (gameData.Strength.original, gameData.Strength.current + gameData.Strength.original * Weaken.percentage);
            Weaken = (0, 0);
        }
        if (Confusion.duration <= 0) // Confusion reset
        {
            gameData.Agility = (gameData.Agility.original, gameData.Agility.current + gameData.Agility.original * Confusion.percentage);
            Confusion = (0, 0);
        }
        if (Vulnerability.duration <= 0) // Vulnerability reset
        {
            gameData.Defense = (gameData.Defense.original, gameData.Defense.current + gameData.Defense.original * Vulnerability.percentage);
            Vulnerability = (0, 0);
        }   

        // Apply Damage
        gameData.Health = (gameData.Health.original, gameData.Health.current - damage);
        Graphics.Type(fastMode, $"You took {damage} points of damage! Your Health is now {gameData.Health.current}/{gameData.Health.original}.");
    }

    public void PlayerHealthCheck()
    {
        Graphics.Type(fastMode, $"Your health is: {gameData.Health.current}");
    }

    public void DeathScene()
    {
        Graphics.Type(fastMode, "You start to feel woozy. Your breaths become shallower, and your vision begins to darken. Eventually, you can't see anything. You can't feel anything.", "green", 200, 50);
        Graphics.Type(fastMode, "YOU DIED.\nFrankly, I could have done better. Game over.", "green", 200, 50);
        // Add any additional logic for handling player death, such as restarting or exiting the game.
        GameData.ResetGame(gameData.Rooms, gameData);
        Graphics.Type(fastMode, "Press any key to exit.", "green", 200, 50);
        Environment.Exit(0);
    }

    public virtual void Attack(Enemy enemy)
    {
        Graphics.Type(fastMode, $"{gameData.PlayerName} attacks {enemy.Name}!");
        enemy.TakeDamage(10, fastMode); // Example damage value
    }
}