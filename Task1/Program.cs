using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tasks.Contracts;

namespace Tasks
{
    /*Random moving furniture
Topics: Inheritance, polymorphism, generic, collections, 
Implement a simple C# console application. Idea is to have a collection of furniture,
    which can be moved. Each object should have an appropriate method (public interface)
    for moving. Note that some objects can have additional methods,
    for a TV it will be turn on/turn off etc. Create a collection of objects and move
    them in a random position in a foreach. 

Additional notes:
1. It should be easy to add a new object without changing too much code.
2. There should a check that we can add only an object that has the X, Y properties and the Move method.
3. Consider using a loop to move all the objects.
4. The UI must be as simple as possible.A console application with text output is the best solution
5. Add a few additional rooms.Each room must have a name. Consider storing rooms in a 
    dictionary with the name as a key and the room as a value.
6. The TV needs to be turned off before it can be moved. */
    class Program
    {
        public static Dictionary<string, IRoom> Items = new Dictionary<string, IRoom>();

        static void Main(string[] args)
        {
            ICollection<Furniture> myFurniture = new Collection<Furniture>();
            IRoom bedroom = new Bedroom();
            IRoom kitchen = new Kitchen();
            IRoom livingroom = new Livingroom();
            Items.Add("Bedroom", bedroom);
            Items.Add("Kitchen", kitchen);
            Items.Add("Livingroom", livingroom);
            Console.WriteLine("Choose items (Bed, Couch) for moving.\n\rWrite End if finished. ");
            
            string item = Console.ReadLine();
            while(item!="End".ToLower())
            {
                switch(item.ToLower())
                {
                    case "bed":
                        Bed mybed = new Bed();
                        myFurniture.Add(mybed);
                        break;
                    case "couch":
                        Couch mycouch = new Couch();
                        myFurniture.Add(mycouch);
                        break;
                    case "tv":
                        TV myTv = new TV();
                        myFurniture.Add(myTv);
                        break;
                    case "chair":
                        Chair myChair = new Chair();
                        break;
                    default:
                        Console.WriteLine("Please enter one of the items.");
                        break;


                }
                Console.WriteLine("Choose items (Bed, Couch, TV) for moving.\n\rWrite End if finished. ");
                item = Console.ReadLine();
                if (item.ToLower() == "end")
                {
                    break;
                }
            }

            foreach(var item1 in myFurniture)
            {
                if (item1.Name == "TV")
                {
                    item1.Move();
                    Console.WriteLine($"{item1.Name} is moved to the Livingroom.");
                    Console.WriteLine();
                }
                if (item1.Name == "Couch")
                {
                    item1.Move();
                    Console.WriteLine($"{item1.Name} is moved to the Livingroom.");
                    Console.WriteLine();
                }
                if (item1.Name == "Bed")
                {
                    item1.Move();
                    Console.WriteLine($"{item1.Name} is moved to the Bedroom.");
                    Console.WriteLine();
                }
                if (item1.Name == "Chair")
                {
                    item1.Move();
                    Console.WriteLine($"{item1.Name} is moved to the ----.");
                    Console.WriteLine();
                }

            }

            Console.ReadLine();
        }
    }
}
