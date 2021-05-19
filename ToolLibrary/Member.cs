using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class Member : iMember, IComparable<Member>
    {
        // privat fields
        private string firstName;
        private string lastName;
        private string contactNumber;
        private string pin;
        private int numOfBorrowingTools;
        private ToolCollection borrowedTools;
        private string[] toolNames;

        // properties
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string ContactNumber { get { return contactNumber; } set { contactNumber = value; } }
        public string PIN { get { return pin; } set { pin = value; } }
        public string[] Tools { get {
                toolNames = new string[numOfBorrowingTools];
                for (int i = 0; i < borrowedTools.toArray().Length; i++) {
                    if (borrowedTools.toArray()[i] != null)
                    {
                        toolNames[i] = borrowedTools.toArray()[i].Name;
                    }
                }
                return toolNames;
            }
            
        }
        


        // constructor
        public Member(string firstName, string lastName, string phoneNum, string pin) {
            borrowedTools = new ToolCollection("Borrowed Tools");
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactNumber = phoneNum;
            this.PIN = pin;
         
        }

     

        /// <summary>
        /// private method to resize an array
        /// </summary>
        /// <param name="toolNamesArray"> a string array </param>
        /// <returns></returns>
        private string[] resizeArray(string[] toolNamesArray)
        {
            string[] resultArray = new string[numOfBorrowingTools];

            if (numOfBorrowingTools > toolNamesArray.Length)
            {
                for (int i = 0; i < toolNamesArray.Length; i++)
                {
                    toolNames[i] = toolNamesArray[i];
                }
            }
            else {
                resultArray = resultArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            }
            return resultArray;
        }


        /// <summary>
        /// Add a tool to the member's borrowing tool collection
        /// </summary>
        /// <param name="aTool"> a Tool object</param>
        public void addTool(Tool aTool)
        {
            numOfBorrowingTools++;
            toolNames = resizeArray(toolNames);
            borrowedTools.add(aTool);
        }

        /// <summary>
        /// Delete a tool from member's boroowing tool collection
        /// </summary>
        /// <param name="aTool"> a Tool object</param>
        public void deleteTool(Tool aTool)
        {
            numOfBorrowingTools--;
            toolNames = resizeArray(toolNames);
            borrowedTools.delete(aTool);
        }

        /// <summary>
        /// format the output of a Member object
        /// </summary>
        /// <returns> the formatted output </returns>
        override public string ToString()
        {
            return String.Format("{0, -15}{1, -15} {2, -15}", firstName, lastName, contactNumber);
        }


        /// <summary>
        /// Compare 
        /// </summary>
        /// <param name="other"> another Member</param>
        /// <returns> integer of order </returns>
        public int CompareTo(Member other)
        {
            if (this.LastName.CompareTo(other.LastName) < 0)
            {
                return -1;
            }
            else if (this.LastName.CompareTo(other.LastName) == 0 &&
                        this.FirstName.CompareTo(other.FirstName) == 0)
            {
                return 0;
            }
            else if (this.LastName.CompareTo(other.LastName) == 0 &&
                        this.FirstName.CompareTo(other.FirstName) < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

    }
}
