using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class Member : iMember, IComparable<Member>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }
        public string[] Tools { get {
                string[] toolNames = new string[3];
                for (int i = 0; i < borrowedTools.Length; i++) {
                    toolNames[i] = borrowedTools[i].Name;
                }
                return toolNames;
            } }


        private Tool[] borrowedTools = new Tool[3];



        public Member(string firstName, string lastName, string phoneNum, string pin) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactNumber = phoneNum;
            this.PIN = pin;
        }


        public void addTool(Tool tool)
        {
            for (int i = 0; i < borrowedTools.Length; i++) {
                if (borrowedTools[i] != null) {
                    borrowedTools[i] = tool;
                    break;
                }
            }
        }

        public void deleteTool(Tool tool)
        {
            for (int i = 0; i < borrowedTools.Length; i++)
            {
                if (borrowedTools[i] != null && borrowedTools[i].Name == tool.Name)
                {
                    borrowedTools[i] = null;
                }
            }
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
