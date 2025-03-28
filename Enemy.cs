namespace DungeonGame;

// Enemy Class
public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }

    public int AttackPwr {get; set; }

    public int Defense {get; set;}

    public Enemy(string name, int health, int attackPwr, int defense)// defines the enemy
    {
        Name = name;
        Health = health;
        AttackPwr = attackPwr;
        Defense = defense;
    }

    public void Attack (Player player) // calculates how much damage the enemy deals
    {
        int damageDealt = AttackPwr - player.Defense;


        damageDealt = Math.Max(1,damageDealt);

        player.TakeDamage(damageDealt);

        Console.WriteLine($"{Name} visciously attacks {player.Name} for {damageDealt} damage");

    }

    public void TakeDamage(int damage) // calculates how much damage the enemy takes
    {
        int actualDamage = damage - Defense;

        actualDamage = Math.Max(1, actualDamage );

        Health -= actualDamage;

        Console.WriteLine($"{Name} has suffered {actualDamage} damage");

        if (!IsAlive())
        {
            Console.WriteLine($"{Name} has been vanquiseh");
        }
    }

    public bool IsAlive()//checks to make sure enemy is still alive
    {
        return Health > 0;
    }

    public void EnemyTurn(Player player, Enemy enemy) //uses random to allow the enemy to have different attacks
    {
        Random random = new Random();
        int decision = random.Next(1,101);

        if (enemy.Health < 10 && decision <= 65)
        {
            Console.WriteLine($"{enemy.Name} attacks normally");
            Attack(player, enemy);
        }
        else if (enemy.Health < 20 && decision <= 78)
        {
            Console.WriteLine($"{enemy.Name} spits posion!!");
            PosionAttack(player,enemy);

        }
    }

    public void PosionAttack(Player player)//allows enemy to have posion attack
    {
       player.IsPoisoned = true;
       player. PoisonTurnsRemaining = 3;
    }

    public class AcidWorm : Enemy //creates enemy class to have posion
    {
        public AcidWorm(): base("Acid Worm", 30, 5, 8) {}

        public override void TakeTurn (Player player)
        {
            Console.WriteLine("The worm emerges from the ground spewing acid!!");
            EnemyTurn(player);
        }
    }


}