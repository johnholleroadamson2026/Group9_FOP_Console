namespace Group9_FOP_StoryTeller
{
    internal class Program
    {
        // Arrays hold details that are reused throughout the story.
        static string[] pigNames = { "Pip", "Percy", "Penny" };
        static string[] houseMaterials = { "straw", "sticks", "bricks" };
        static string[] houseStrength = { "light and cozy", "fairly sturdy", "strong and safe" };

        static string[] firstChoices =
        {
        "Stay inside the straw house and speak through the door.",
        "Go get the other pigs so they can meet the wolf together."
    };

        static string[] secondChoices =
        {
        "Ask the wolf why he is looking for the pigs.",
        "Ask the wolf to wait while the pigs make a safety plan."
    };

        static void Main(string[] args)
        {
            bool playAgain = true;

            // This loop lets the reader restart the story after an ending.
            while (playAgain)
            {
                ShowHeader();
                ShowPigIntroduction();
                TellOpening();

                int firstChoice = AskChoice("What should Pip do?", firstChoices);
                int secondChoice = AskChoice("What should the pigs do next?", secondChoices);

                TellEnding(firstChoice, secondChoice);
                playAgain = AskToPlayAgain();
            }

            ShowGoodbye();
       
       }

        static void ShowHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("+----------------------------------------------+");
            Console.WriteLine("|              THE THREE LITTLE PIGS           |");
            Console.WriteLine("|              A choose-your-own story         |");
            Console.WriteLine("+----------------------------------------------+");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void ShowPigIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEET THE THREE PIGS");
            Console.ResetColor();

            // A for loop visits each pig and prints the matching array details.
            for (int index = 0; index < pigNames.Length; index++)
            {
                Console.WriteLine(
                    "  " + pigNames[index] + " lives in a " + houseMaterials[index] + " house.");
                Console.WriteLine(
                    "  The house is " + houseStrength[index] + ".");
            }

            Console.WriteLine();
        }

        static void TellOpening()
        {
            Console.WriteLine("One windy afternoon, a wolf came to Pip's straw house.");
            Console.WriteLine("He knocked gently and called through the door.");
            Console.WriteLine("\"Hello! I am lost and looking for my family. Can you help me?\"");
            Console.WriteLine("Pip wanted to help, but also wanted everyone to stay safe.");
            Console.WriteLine();
        }
        static int AskChoice(string question, string[] choices)
        {
            int selectedNumber = 0;
            bool validChoice = false;

            // Keep asking until the reader types a number from the menu.
            while (!validChoice)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(question);
                Console.ResetColor();

                // A loop prints every choice stored in the array.
                for (int index = 0; index < choices.Length; index++)
                {
                    Console.WriteLine("  " + (index + 1) + ". " + choices[index]);
                }

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine() ?? "";

                if (int.TryParse(answer, out selectedNumber))
                {
                    if (selectedNumber >= 1)
                    {
                        if (selectedNumber <= choices.Length)
                        {
                            validChoice = true;
                        }
                        else
                        {
                            ShowInvalidChoice();
                        }
                    }
                    else
                    {
                        ShowInvalidChoice();
                    }
                }
                else
                {
                    ShowInvalidChoice();
                }

                Console.WriteLine();
            }

            return selectedNumber;
        }

        static void ShowInvalidChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter one of the numbers shown in the menu.");
            Console.ResetColor();
        }

        static void TellEnding(int firstChoice, int secondChoice)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("STORY CONTINUES");
            Console.ResetColor();
            Console.WriteLine();

            // The first switch selects one of Pip's two possible actions.
            switch (firstChoice)
            {
                case 1:
                    TellStayInsideStory(secondChoice);
                    break;

                case 2:
                    TellGetBrothersStory(secondChoice);
                    break;

                default:
                    Console.WriteLine("The pigs pause and decide to try again.");
                    break;
            }

            Console.WriteLine();
            ShowTheEnd();
        }

        static void TellStayInsideStory(int secondChoice)
        {
            Console.WriteLine("Pip stayed inside the straw house and spoke through the closed door.");
            Console.WriteLine("He asked the wolf to explain why he was looking for the pigs.");

            // This is a nested if: the second check happens inside the first path.
            if (secondChoice == 1)
            {
                Console.WriteLine("The wolf explained that he had lost his way in the woods.");

                if (IsTheWolfPolite())
                {
                    Console.WriteLine("The wolf thanked Pip for listening and waited patiently.");
                    Console.WriteLine("Pip called his brothers, and they showed the wolf a safe path home.");
                }
                else
                {
                    Console.WriteLine("Pip asked the wolf to speak calmly before they continued.");
                    Console.WriteLine("The wolf apologized, and the pigs helped him find his family.");
                }
            }
            else
            {
                Console.WriteLine("Pip asked the wolf to wait while he made a safety plan.");
                Console.WriteLine("He called Percy and Penny before opening the door.");

                if (AreBrothersReady())
                {
                    Console.WriteLine("The brothers arrived quickly and stood together by the window.");
                    Console.WriteLine("They listened to the wolf and helped him find the forest trail.");
                }
                else
                {
                    Console.WriteLine("Penny brought a map while Percy stayed beside Pip.");
                    Console.WriteLine("Together, they gave the wolf directions without leaving the house.");
                }
            }
        }

        static void TellGetBrothersStory(int secondChoice)
        {
            Console.WriteLine("Pip hurried to find Percy and Penny before talking with the wolf.");
            Console.WriteLine("The three pigs returned together and kept a safe distance.");

            // This nested if adds a different detail to the brothers' story path.
            if (secondChoice == 1)
            {
                Console.WriteLine("Percy asked the wolf why he had come to their neighborhood.");

                if (IsTheWolfPolite())
                {
                    Console.WriteLine("The wolf calmly explained that he had lost his family.");
                    Console.WriteLine("Penny recognized the trail on her map and offered to guide him.");
                }
                else
                {
                    Console.WriteLine("Penny asked the wolf to take a breath and explain more slowly.");
                    Console.WriteLine("Once everyone understood, the pigs pointed out the forest path.");
                }
            }
            else
            {
                Console.WriteLine("Penny suggested they make a simple safety plan before helping.");
                Console.WriteLine("They agreed to stay together and keep the front gate closed.");

                if (AreBrothersReady())
                {
                    Console.WriteLine("The brothers found a map and worked out the route as a team.");
                    Console.WriteLine("They gave the wolf clear directions to his family.");
                }
                else
                {
                    Console.WriteLine("Percy gathered a lantern, and Pip found the map.");
                    Console.WriteLine("With the plan ready, they helped the wolf get home safely.");
                }
            }
        }

        static bool IsTheWolfPolite()
        {
            // This small array is checked with a loop to show a second array example.
            string[] kindWords = { "please", "thank you", "help" };

            foreach (string word in kindWords)
            {
                if (word == "thank you")
                {
                    return true;
                }
            }

            return false;
        }

        static bool AreBrothersReady()
        {
            // The house-material array helps decide which supplies are available.
            for (int index = 0; index < houseMaterials.Length; index++)
            {
                if (houseMaterials[index] == "bricks")
                {
                    return true;
                }
            }

            return false;
        }

        static bool AskToPlayAgain()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Would you like to read the story again?");
            Console.ResetColor();
            Console.WriteLine("1. Yes, start over");
            Console.WriteLine("2. No, finish the story");
            Console.Write("Enter your choice: ");

            string answer = Console.ReadLine() ?? "";

            // A switch handles the replay menu choices.
            switch (answer)
            {
                case "1":
                    return true;

                case "2":
                    return false;

                default:
                    Console.WriteLine("I will close the story. You can run it again any time.");
                    return false;
            }
        }

        static void ShowTheEnd()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("+----------------------------------------------+");
            Console.WriteLine("|                  THE END                     |");
            Console.WriteLine("+----------------------------------------------+");
            Console.ResetColor();
        }

        static void ShowGoodbye()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Thanks for reading about Pip, Percy, and Penny!");
            Console.WriteLine("Goodbye!");
            Console.ResetColor();
        }
    }


}

