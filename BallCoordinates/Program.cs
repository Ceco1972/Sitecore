using BallCoordinates.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BallCoordinates
{
    class Program
    {
        static void Main(string[] args)
        {
           // List<Coord> coordinates = new List<Coord>();
            List<string> allCoor = new List<string>();
            List<string> allCoorFile = new List<string>();

            string filePath = @"C:\Users\User\Desktop\Sitecore\record.txt";

            try
            {
                Random rand = new Random();
                while (true)
                {
                    int x = rand.Next(0, 12);
                    int y = rand.Next(0, 11);
                    //Coord coor = new Coord(x, y);
                    StringBuilder sb = new StringBuilder();

                    if (x <= 0 || x > 9 || y <= 0 || y > 10)
                    {
                        allCoorFile = File.ReadAllLines(filePath).ToList();
                        foreach (var item in allCoorFile)
                        {
                            sb.Append(item);   
                        }
                        throw new CoordException(sb.ToString());
                    }
                    else
                    {
                        Console.WriteLine($"x is {x} and y is {y}");
                        //coordinates.Add(coor);
                        allCoor.Add("(" + x + ", " + y + ")");
                        File.WriteAllLines(filePath, allCoor);
                    }
                }
            }
            catch (CoordException)
            {
                Console.WriteLine("The Ball has hit a wall...");
                Console.WriteLine("Here is the path of the ball: ");
                foreach (var item in allCoorFile)
                {
                    Console.WriteLine(item);
                }

            }
                   }

    }
        //public struct Coord
        //{
        //    public int x;
        //    public int y;
        //    public Coord(int xa, int ya)
        //    {
        //        x = xa;
        //        y = ya;
        //    }
        //}

    }


