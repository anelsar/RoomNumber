using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomNumberTask.BusinessLogic
{
    public class RoomNumber : IRoomNumber 
    {
         /// <summary>
        /// Gets the number of sets needed to make the number which will be sticking on your door.
        /// </summary>
        /// <param name="roomNumber">The number that will be sticking on your door.</param>
        /// <returns>An integer value containing the number of sets.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the room number is less than 1 or greater than 1,000,000</exception>
        public int numberOfSets(int roomNumber)
        {
            if (roomNumber < 1 || roomNumber > 1000000) // if roomNumber is less than 1 or great than 1,000,000 throw an out of range exception
                throw new ArgumentOutOfRangeException();


            var arrayOfDigits = getNumberOfDigits(roomNumber);

            int numberOfSetsRequired = arrayOfDigits.Max(); // Gets the maximum number in the array

            int indexOfTheMaxNumber = Array.IndexOf(arrayOfDigits, numberOfSetsRequired); // Gets the index number of the maximum number in the array

            if (indexOfTheMaxNumber == 6) // Checks whether the index is 6 (6 and 9 gets stored in the same index) 
                numberOfSetsRequired = (int) Math.Ceiling(1.0 * numberOfSetsRequired / 2); // Divide by 2 and round up to the nearest greater value

            return numberOfSetsRequired;


        }

        private int[] getNumberOfDigits(int number)
        {
            int[] arrayOfDigits = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // Initializing an array to store the number of digits that are contained in the room number
                                                                 // We are storing the digit 6 and digit 9 in the same index number
            while (number > 0)
            {
                int currentDigit = number % 10; 

                if (currentDigit == 6 || currentDigit == 9)
                    arrayOfDigits[6]++;

                else
                    arrayOfDigits[currentDigit]++;

                number /= 10;
            }

            return arrayOfDigits;
        }
    }
}
