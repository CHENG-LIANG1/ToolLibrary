using System;
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

        // properties
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string ContactNumber { get { return contactNumber; } set { contactNumber = value; } }
        public string PIN { get { return pin; } set { pin = value; } }
        public string[] Tools { get {
                string[] toolNames = new string[3];
                for (int i = 0; i < borrowedTools.toArray().Length; i++) {
                    toolNames[i] = borrowedTools.toArray()[i].Name;
                }

                return toolNames;
            } }


        private ToolCollection borrowedTools = new ToolCollection("Borrowed Tools");

        // constructor
        public Member(string firstName, string lastName, string phoneNum, string pin) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactNumber = phoneNum;
            this.PIN = pin;
        }


        public void addTool(Tool aTool)
        {
            borrowedTools.add(aTool);
            borrowedTools.Number++;
     
        }

        public void deleteTool(Tool aTool)
        {

            borrowedTools.delete(aTool);

        }

        override public string ToString()
        {
            return "Name: " + FirstName + " " + LastName + ", Phone Number: " + ContactNumber;
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
