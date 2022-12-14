using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge twoSquared = new Challenge("What is 2 squared?", 4, 4);
            Challenge sqrtFour = new Challenge("What is the sqrt of 4?", 2, 2);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            Robe adventurersRobe = new Robe();
            adventurersRobe.Length = 12;
            adventurersRobe.Colors.Add("blue");
            adventurersRobe.Colors.Add("green");

            Hat hat = new Hat();
            hat.ShininessLevel = 12;

            Prize prizeWinner = new Prize("Buried Treasure");

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(name, adventurersRobe, hat);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                twoSquared,
                sqrtFour
            };
            // put this loop through the while loop
            // Loop through all the challenges and subject the Adventurer to them



            string playAgain;
            int numCorrect;
            do
            {
                numCorrect = 0;
                Console.WriteLine($"Initial Awesomeness = {theAdventurer.Awesomeness}");

                Console.WriteLine(theAdventurer.GetDescription());
                Console.WriteLine("---------------------------------");

                // Creates a list of ints 0 to the last index of challenges
                List<int> possibleNums = new List<int>();
                for (int i = 0; i < challenges.Count; i++)
                {
                    possibleNums.Add(i);
                }

                // Loop thorugh all the challenges and subject the Adventurer to them
                for (int i = 0; i < 5; i++)
                {
                    int index = possibleNums[new Random().Next(0, possibleNums.Count)];
                    possibleNums.Remove(index);

                    numCorrect += challenges[index].RunChallenge(theAdventurer);
                }


                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                Console.WriteLine("------------------------------");
                prizeWinner.ShowPrize(theAdventurer);

                Console.WriteLine("------------------------------");
                Console.WriteLine("Would you like to repeat the Quest (type \"yes\" to repeat)?");
                playAgain = Console.ReadLine().ToLower();
                theAdventurer.Awesomeness += numCorrect * 10;

            } while (playAgain == "yes");
        }

    }
}
