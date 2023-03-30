///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 5 - Dynamic Quiz
// Description: BinTree is used as the primary data structure for a tree.
//              
//
///////////////////////////////////////////////////////////////////////////////

namespace Project5_DynamicQuiz
{
    internal class BinTree<T> where T : IComparable<T>
    {
        public QuizNode<T> root { get; private set; }
        public BinTree(T rootData) 
        {
            root = new QuizNode<T>(rootData);
        }

        /// <summary>
        /// Adds a node by using a binary string to designate the destination of the inData value node.
        /// </summary>
        /// <param name="inData">The value to be stored by the new node in the BinTree</param>
        /// <param name="MapString">The binary string to use as a destination map within the BinTree.</param>
        public void AddNode(T inData, string MapString)
        {
            // Root null case
            if (root == null)
            {
                root = new QuizNode<T>(inData);
            }

            int jumpCount = MapString.Length;
            
            if (MapString.Length == 0)
            {
                root.data = inData;
            }
            // Insertion
            else
            {
                int currentJump = -1;
                QuizNode<T> currentNode = root;
                while (++currentJump < MapString.Length)
                {
                    // Force the character within the MapString to ANOTHER string, so int.Parse works nicely with it.
                    // Convert.ToInt32 will convert char to ASCII value - could easily work, but I wanted to keep 0 and 1 values (48/49).
                    string charStr = "" + MapString[currentJump];
                    int direction = int.Parse(charStr);
                    // Left
                    if (direction == 0)
                    {
                        if (currentNode.leftChild == null)
                        {
                            currentNode.AddLeftNode(inData);
                        }
                        else
                        {
                            currentNode = currentNode.leftChild;
                        }
                    }
                    // Right
                    else if (direction == 1)
                    {
                        if (currentNode.rightChild == null)
                        {
                            currentNode.AddRightNode(inData);
                        }
                        else
                        {
                            currentNode = currentNode.rightChild;
                        }
                    }
                    // Bad input
                    else
                    {
                        Console.WriteLine($"Tree traversal unsuccessful. Invalid direction indicator \'{MapString[currentJump]}\'" +
                            $"in input string \"{MapString}\".");
                    }
                }
            }
        }
    }
}
