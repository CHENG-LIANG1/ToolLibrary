﻿using System;
using System.Collections.Generic;
using System.Text;

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
        private ToolCollection borrowedTools = new ToolCollection("Borrowed Tools");
        private string[] toolNames;

        // properties
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string ContactNumber { get { return contactNumber; } set { contactNumber = value; } }
        public string PIN { get { return pin; } set { pin = value; } }
        public string[] Tools { get {

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
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactNumber = phoneNum;
            this.PIN = pin;
        }


        // private method to resize the array after addition and deletion
        private void resizeArray()
        {
            toolNames= new string[numOfBorrowingTools];
        }

        public void addTool(Tool aTool)
        {
            borrowedTools.add(aTool);
            numOfBorrowingTools++;
            resizeArray();
        }

        public void deleteTool(Tool aTool)
        {
            borrowedTools.delete(aTool);
            numOfBorrowingTools--;
            resizeArray();
        }

        override public string ToString()
        {
            return String.Format("{0, -15}{1, -15} {2, -15}", firstName, lastName, contactNumber);
        }

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
