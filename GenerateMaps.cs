using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonGame
{
    public class BSPDungeon
    {
        private const int MIN_ROOM_WIDTH = 6;
        private const int MIN_ROOM_HEIGHT = 6;

        private class Node
        {
            public Rectangle Area;
            public Node? Left { get; set; } // Marked as nullable
            public Node? Right { get; set; } // Marked as nullable

            public Node(Rectangle area)
            {
                Area = area;
            }

            public bool IsLeaf => Left == null && Right == null;
        }

        private List<Rectangle> rooms = new List<Rectangle>();
        private Random random = new Random();

        public void GenerateDungeon(int width, int height)
        {
            Node root = new Node(new Rectangle(0, 0, width, height));
            Split(root);
            CreateRooms(root);
        }

        private void Split(Node node)
        {
            if (node.Area.Width < MIN_ROOM_WIDTH * 2 && node.Area.Height < MIN_ROOM_HEIGHT * 2)
                return;

            bool splitVertically = node.Area.Width >= node.Area.Height;

            if (splitVertically)
            {
                if (node.Area.Width < MIN_ROOM_WIDTH * 2) return;

                int splitX = random.Next(MIN_ROOM_WIDTH, node.Area.Width - MIN_ROOM_WIDTH);
                node.Left = new Node(new Rectangle(node.Area.X, node.Area.Y, splitX, node.Area.Height));
                node.Right = new Node(new Rectangle(node.Area.X + splitX, node.Area.Y, node.Area.Width - splitX, node.Area.Height));
            }
            else
            {
                if (node.Area.Height < MIN_ROOM_HEIGHT * 2) return;

                int splitY = random.Next(MIN_ROOM_HEIGHT, node.Area.Height - MIN_ROOM_HEIGHT);
                node.Left = new Node(new Rectangle(node.Area.X, node.Area.Y, node.Area.Width, splitY));
                node.Right = new Node(new Rectangle(node.Area.X, node.Area.Y + splitY, node.Area.Width, node.Area.Height - splitY));
            }

            Split(node.Left);
            Split(node.Right);
        }

        private void CreateRooms(Node node)
        {
            if (node.IsLeaf)
            {
                int roomWidth = random.Next(MIN_ROOM_WIDTH, node.Area.Width);
                int roomHeight = random.Next(MIN_ROOM_HEIGHT, node.Area.Height);
                int roomX = node.Area.X + random.Next(0, node.Area.Width - roomWidth);
                int roomY = node.Area.Y + random.Next(0, node.Area.Height - roomHeight);

                rooms.Add(new Rectangle(roomX, roomY, roomWidth, roomHeight));
            }
            else
            {
                if (node.Left != null) CreateRooms(node.Left);
                if (node.Right != null) CreateRooms(node.Right);
            }
        }

        public void RenderAsciiDungeon(int width, int height)
        {
            char[,] map = new char[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    map[x, y] = ' ';

            foreach (var room in rooms)
            {
                for (int x = room.X; x < room.X + room.Width; x++)
                {
                    for (int y = room.Y; y < room.Y + room.Height; y++)
                    {
                        if (x > 0 && x < width && y > 0 && y < height)
                            map[x, y] = '#';
                    }
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}