using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class Member : iMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }

        public Member(string firstName, string lastName, string phoneNum) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactNumber = phoneNum;
        }


        public string[] Tools => throw new NotImplementedException();

        public void addTool(iTool tool)
        {
            throw new NotImplementedException();
        }

        public void deleteTool(iTool tool)
        {
            throw new NotImplementedException();
        }

        public string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
