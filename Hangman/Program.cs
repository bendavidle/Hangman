using System;

namespace Hangman
{
    internal class Program
    {
        /*
         * Få tak i ett random ord fra en array/liste 
         * Vise _ per character i ordet.
         * input fra bruker
         * osv
         */

        public static string guesses = "";
        public static bool GameRunning = true;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] words = new string[]
            {
                "Terje",
                "Joakim",
                "Anita",
                "Therese",
                "Linn",
                "Benjamin",
                "Bjørnar",
                "Edgar",
                "Eskil",
                "Marie",
            };

            string randomOrd = words[rnd.Next(0, words.Length)].ToLower();

            while (GameRunning)
            {
                ShowWord(randomOrd);
                if (GameRunning)
                {
                    Guess();
                    CheckWrongGuesses(randomOrd);
                }

            }

        }

        static void Guess()
        {
            string guess = Console.ReadLine().ToLower();
            guesses += guess;

        }
        //abik - bokstaven !fins i ordet count++ return count - hvor mange bokstaver som ikke fins i order (feil)

        static void CheckWrongGuesses(string ord)
        {
            int count = 0;
            int lives = 6;

            foreach (char bokstav in guesses)
            {
                if (!ord.Contains(bokstav))
                {
                    count++;
                }
            }

            CheckLost(count, lives);
        }

        private static void CheckLost(int count, int lives)
        {
            if (count >= lives)
            {
                GameRunning = false;
                Console.WriteLine("Du tapte!");
            }
            else
            {
                Console.WriteLine($"Du har {lives - count} liv igjen.");
            }
        }

        static void ShowWord(string ord)
        {
            string finalWord = "";
            foreach (char character in ord)
            {
                if (guesses.Contains(character))
                {
                    finalWord += character;
                }
                else
                {
                    finalWord += "_ ";
                }
            }

            CheckWin(ord, finalWord);

        }

        private static void CheckWin(string ord, string finalWord)
        {
            if (finalWord == ord)
            {
                Console.WriteLine("Du har vunnet!");
                GameRunning = false;
            }
            else
            {
                Console.WriteLine(finalWord);
            }
        }
    }
}
