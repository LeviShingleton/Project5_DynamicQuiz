///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 5 - Dynamic Quiz
// Description: QuizNode<T> is used as a generic value node within BinTree.
//              
//
///////////////////////////////////////////////////////////////////////////////

namespace Project5_DynamicQuiz
{
    internal class QuizNode<T> where T : IComparable<T>
    {
        public T data = default(T);
        public QuizNode<T> leftChild, rightChild;

        public QuizNode(T initData)
        {
            data = initData;
        }

        /// <summary>
        /// Adds a new node as the leftChild of this QuizNode
        /// </summary>
        /// <param name="addData">The value to be stored in the new left child node</param>
        public void AddLeftNode(T addData)
        {
            if (leftChild == null || leftChild.data == null)
            {
                leftChild = new QuizNode<T>(addData);
            }
            else
            {
                leftChild.data = addData;
            }
        }

        /// <summary>
        /// Adds a new node as the rightChild of this QuizNode
        /// </summary>
        /// <param name="addData">The value to be stored in the new right child node</param>
        public void AddRightNode(T addData)
        {
            if (rightChild == null || rightChild.data == null)
            {
                rightChild = new QuizNode<T>(addData);
            }
            else
            {
                rightChild.data = addData;
            }
        }
    }
}
