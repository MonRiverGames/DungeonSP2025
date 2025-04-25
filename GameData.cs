using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DungeonGame
{
    public class GameData
    {
        static string FilePath = "game_save.json";
        public bool IsResuming = false;

        public string PlayerName { get; set; }
        public Room CurrentRoom { get; set; }
        public Inventory PlayerInventory { get; set; }
        public bool EndingUnlocked = false;

        // Player stats, use .original for normal character stats + equipment bonuses, or use .current for interactions and temporary effects
        public string PlayerClass = "Unset";
        public (int original, float current) Health { get; set; }
        public (int original, float current) Strength { get; set; }
        public (int original, float current) Defense { get; set; }
        public (int original, float current) Agility { get; set; }

        public GameData()
        {
            PlayerInventory = new Inventory();
        }

        // Main Load method, takes the 'startRoom.Exits[North]' parameter which equals livingRoom
        public static GameData LoadGame(List<Room> rooms)
        {
            GameData gameData = File.Exists(FilePath) ? JsonConvert.DeserializeObject<GameData>(File.ReadAllText(FilePath)) : new GameData();
            if (File.Exists(FilePath))
            {
                Graphics.Type(false, $"Hello there {gameData.PlayerName}, would you like to resume your game? (Y/N)");
                while (true)
                {
                    Thread.Sleep(50);
                    Console.Write("\n> ");
                    string response = Console.ReadLine().ToLower();
                    if (response.Contains("y"))
                    {
                        gameData.CurrentRoom = rooms.Find(room => room.Name == gameData.CurrentRoom.Name);
                        gameData.IsResuming = true;
                        break;
                    }
                    else if (response.Contains("n"))
                    {
                        gameData.IsResuming = false;
                        ResetGame();
                        gameData.CurrentRoom = rooms.Find(room => room.Name == "Foyer");
                        break;
                    }
                    Graphics.Type(false, "It's a simple question...\nWould you like to resume your game? (Y/N)");
                }
            }
            else
            {
                gameData.CurrentRoom = rooms.Find(room => room.Name == "Foyer");
            }

                return gameData;
        }

        // Save method, pass in current gameData reference
        public static void SaveGame(GameData gameData)
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(gameData, Formatting.Indented));
        }

        // Reset Save file
        public static void ResetGame()
        {
            if (File.Exists(FilePath)) File.Delete(FilePath);

            // Reset in-memory GameData fields
            GameData gameData = new GameData
            {
                PlayerName = string.Empty,
                CurrentRoom = null,
                PlayerInventory = new Inventory(), // Create a new inventory object
                EndingUnlocked = false,
                PlayerClass = "Unset",
                Health = (100, 100),
                Strength = (10, 10),
                Defense = (10, 10),
                Agility = (10, 10)
            };

            // Explicitly clear the inventory
            gameData.PlayerInventory.Items.Clear();
        }
    }
}
