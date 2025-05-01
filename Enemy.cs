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
            Console.WriteLine($"{Name} attacks {player.gameData.PlayerName}!");
            player.TakeDamage(10); // Example damage value
        }

        // Special poison attack: applies a poison status to the player
        public void PoisonAttack(Player player)
        {
            Console.WriteLine($"{Name} uses Poison Attack on {player.gameData.PlayerName}!");
            player.Debuff("poison", 3, 1f);
        }

        public void FireAttack(Player player)
        {
            Console.WriteLine($"{Name} uses fire breath on {player.gameData.PlayerName}!");
            player.Debuff("fire", 3, 1f);
        }

        // Enemy chooses what action to take during its turn
        public virtual string EnemyTurn(Player player)
        {
         Random rng = new Random();
         string[] actions = { "attack", "defend", "grab" };
         string action = actions[rng.Next(actions.Length)];
         Graphics.Type(player.fastMode, $"{Name} chose to {action}!");
         return action;
        }


        public void TakeDamage(float damage, bool fastMode)
        {
            // Apply Damage
            Health = (Health.original, Health.current - damage);
            Graphics.Type(fastMode, $"{Name} took {damage} points of damage!");
        }

        public static void Battle(Enemy enemy, Player player)
        {
            Graphics.Type(player.fastMode, $"You are now battling {enemy.Name}. You got this!", "none");
            Graphics.Type(player.fastMode, $"[You gotta kill the {enemy.Name} if you want to interact with the room. Either that or you die. Good luck! You're gonna need it.]", "green", 0, 15);

            string playerAction = "none";
            string enemyAction = "none";

            while (true)
            {
                // Check for Death
                if (player.gameData.Health.current <= 0)
                {
                    player.DeathScene();
                }
                else if (enemy.Health.current <= 0)
                {
                    Graphics.Type(player.fastMode, $"You deliver the final blow to the {enemy.Name}. It shrieks in pain. You sigh, and wonder how you ever survived.", "none", 200, 50);
                    Graphics.Type(player.fastMode, "YOU HAVE SLAIN YOUR ENEMY.", "green", 200, 50);
                    break;
                }

                Graphics.Type(player.fastMode, $"\nWhat do you do?", "green");
                Graphics.Type(player.fastMode, $"1. Attack", "green");
                Graphics.Type(player.fastMode, $"2. Defend", "green");
                Graphics.Type(player.fastMode, $"3. Grab", "green");

                while (true) // Determine what the player does
                {
                    Console.Write("\n> ");
                    string input = Console.ReadLine() ?? string.Empty;
                    input = input.ToLower(); // Detects player input

                    if (input == "1" || input == "attack")
                    {
                        playerAction = "attack"; // Set the player action to attack
                        Graphics.Type(player.fastMode, "You chose to attack!");
                        break;
                    }
                    else if (input == "2" || input == "defend")
                    {
                        playerAction = "defend"; // Set the player action to defend
                        Graphics.Type(player.fastMode, "You chose to defend!");
                        break;
                    }
                    else if (input == "3" || input == "grab")
                    {
                        playerAction = "grab"; // Set the action to grab
                        Graphics.Type(player.fastMode, "You chose to grab!");
                        break;
                    }
                    else
                    {
                        Graphics.Type(player.fastMode, "Invalid action");
                    }
                }

                enemyAction = enemy.EnemyTurn(player);  // Now calls the polymorphic version

                if (playerAction == enemyAction)
                {
                    Graphics.Type(player.fastMode, $"\nBoth sides chose to do the same thing! Everything cancels out!");
                }
                else if (playerAction == "attack" && enemyAction == "defend")
                {
                    Graphics.Type(player.fastMode, $"\nYou lunge at {enemy.Name}, but {enemy.Name} defends itself. You leave yourself open to an opportunity attack!\n");
                    enemy.Attack(player);
                }
                else if (playerAction == "attack" && enemyAction == "grab")
                {
                    Graphics.Type(player.fastMode, $"\nYou lunge at {enemy.Name}, and {enemy.Name} tried to grab you! You take this opportunity to attack!\n");
                    player.Attack(enemy);
                }
                else if (playerAction == "defend" && enemyAction == "attack")
                {
                    Graphics.Type(player.fastMode, $"\n{enemy.Name} lunges at you, but you defended yourself! You take this opportunity to attack!\n");
                    player.Attack(enemy);
                }
                else if (playerAction == "defend" && enemyAction == "grab")
                {
                    Graphics.Type(player.fastMode, $"\nYou go to defend yourself, but {enemy.Name} grabs you! Breaking you out of your defense, it gets a chance to attack.\n");
                    enemy.Attack(player);
                }
                else if (playerAction == "grab" && enemyAction == "attack")
                {
                    Graphics.Type(player.fastMode, $"\nYou go to grab your opponent, but {enemy.Name} attacks you! As you lunge towards it, it has a moment of opportunity.\n");
                    enemy.Attack(player);
                }
                else if (playerAction == "grab" && enemyAction == "defend")
                {
                    Graphics.Type(player.fastMode, $"\n{enemy.Name} tried to defend itself, and you take this opportunity to grab it! It gives you a moment of opportunity.\n");
                    player.Attack(enemy);
                }
                else
                {
                    Graphics.Type(player.fastMode, "\nWhat the... You broke something didn't you? You're not supposed to be able to get this text!\n");
                }
            }
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
            Graphics.Type(player.fastMode, $"{Name} spits acid at {player.gameData.PlayerName}!", "red");
            player.TakeDamage(15); // Example acid damage
        }
    }

    public class LichKitty : Enemy
    {
        public LichKitty(string name, int health) : base ("Lich Kitty", 100, 100) {}

        public override void Attack(Player player)
        {
         Graphics.Type(player.fastMode, $"{Name} opens its maw and spits fire from it mouth at {player.gameData.PlayerName}!!", "red");
         player.TakeDamage(20);//Fire damage   
        }
        public override string EnemyTurn(Player player)
        {
         Random rng = new Random();
         int roll = rng.Next(100);

         if (roll < 60)
         {
           Graphics.Type(player.fastMode, $"{Name} prepares a fire spell!", "red");
           return "attack";
         }
           else if (roll < 80)
         {
            Graphics.Type(player.fastMode, $"{Name} raises a bone shield!", "yellow");
            return "defend";
         }
           else
         {
            Graphics.Type(player.fastMode, $"{Name} attempts to grab you with a spectral hand!", "purple");
            return "grab";
         }
        }

    }

    public class Spirit : Enemy
    {
        public Spirit(string name, int health) : base ("Spirit", 25,25) {}
        public override void Attack(Player player)
        {
            Graphics.Type(player.fastMode, $"{Name} leaps through {player.gameData.PlayerName} soul!", "red");
            player.TakeDamage(15); // Example spirit damage
        }
    }

    
}