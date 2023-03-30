///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 5 - Dynamic Quiz
// Description: This project uses a binary tree to present a dynamic quiz to the
//              user.
//
///////////////////////////////////////////////////////////////////////////////

namespace Project5_DynamicQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinTree<string> quiz = new BinTree<string>("Do you have experience in developing applications?");
            GenerateQuizTree(quiz);
            DoQuiz(quiz.root);
        }

        /// <summary>
        /// Creates a quiz tree with a provided or new string BinTree. Replicates structure of Project5-Instructions.png
        /// </summary>
        /// <param name="tree">Input tree (or new) to transform</param>
        static void GenerateQuizTree(BinTree<string> tree)
        {
            string[] Questions = {"Have you worked as a developer for more than 5 years?",
                                  "Have you completed university?", "Will you find some time during the semester?"};

            string[] Results = {"Apply as a junior developer!", "Apply for our long-time internship program!", "Apply for summer internship programs!",
                                "Apply as a middle developer!", "Apply as a senior developer!"};

            int qIndex = 0;
            int rIndex = 0;
            // B
            tree.AddNode(Questions[qIndex++], "0");
            // E
            tree.AddNode(Questions[qIndex++], "1");
            // G
            tree.AddNode(Questions[qIndex], "11");

            // F
            tree.AddNode(Results[rIndex++], "10");
            // H
            tree.AddNode(Results[rIndex++], "110");
            // I
            tree.AddNode(Results[rIndex++], "111");

            // D
            tree.AddNode(Results[rIndex++], "01");
            // C
            tree.AddNode(Results[rIndex++], "00");
        }

        /// <summary>
        /// Presents the string held by the current QuizNode and prompts the user for a response.
        /// Uses the response to recursively progress through the BinTree.
        /// </summary>
        /// <param name="currentNode">The node that the quiz should progress to. When manually called, should be "root."</param>
        static void DoQuiz(QuizNode<string> currentNode)
        {
            Console.WriteLine($"{currentNode.data}" +
                $"\nPlease enter Y/N.");
            
            if (currentNode.leftChild != null || currentNode.rightChild != null)
            {
                string response = Console.ReadLine().Trim().ToLower();

                bool yes = response.Equals("y") || response.Equals("yes");
                bool no = response.Equals("yes") || response.Equals("no");
                bool isValid = (yes || no);

                while (!isValid)
                {
                    Console.WriteLine("Sorry, but that response could not be understood.\n" +
                        "Please enter Y/N.\n");
                    response = Console.ReadLine().Trim().ToLower();

                    yes = response.Equals("y") || response.Equals("yes");
                    no = response.Equals("n") || response.Equals("no");
                    isValid = (yes || no);
                }

                if (yes)
                {
                    DoQuiz(currentNode.leftChild);
                }
                else if (no)
                {
                    DoQuiz(currentNode.rightChild);
                }
            }
        }
    }
}