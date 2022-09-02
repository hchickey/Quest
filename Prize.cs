using System;

namespace Quest
{
    public class Prize
    {
        private string _text;

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                for (int i = 0; i < adventurer.Awesomeness; i++)
                {
                    Console.WriteLine(_text);
                }
            }
            //write the _text field to the console the same number of times
            // as the value of the Awesomeness property.
            else
            {
                Console.WriteLine("No prize for you. Better luck next time.");
            }
        }
    }
}