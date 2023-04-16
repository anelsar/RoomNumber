using RoomNumberTask.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomNumberTask
{
    public class App
    {
        private readonly IRoomNumber _roomNumber;

        public App(IRoomNumber roomNumber)
        {
            _roomNumber = roomNumber;
        }

        public void Run(string[] args) 
        {
            Console.WriteLine("Enter your room number (between 1 and 1,000,000): ");

            int numberOfTheRoom;

            while (true)
            {
                var userInput = Console.ReadLine();
                if(int.TryParse(userInput, out numberOfTheRoom))
                {
                    if (numberOfTheRoom == -1)
                        return;

                    var numberOfSets = _roomNumber.numberOfSets(numberOfTheRoom);

                    Console.WriteLine("Number of sets required is {0}: ", numberOfSets);

                    Console.WriteLine("Enter the next room number (-1 to exit): ");

                }
                else
                {
                    Console.WriteLine("Wrong input, integer value expected");
                        
                }
                
            }
            
        }
    }
}
