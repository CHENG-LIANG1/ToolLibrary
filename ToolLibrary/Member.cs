using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class Member : iMember
    {
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PIN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
