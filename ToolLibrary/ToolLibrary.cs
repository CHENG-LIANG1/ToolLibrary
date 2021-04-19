using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class ToolLibrary : iToolLibrarySystem
    {
        public void add(iTool tool)
        {
            throw new NotImplementedException();
        }

        public void add(iTool tool, int quantity)
        {
            throw new NotImplementedException();
        }

        public void add(iMember member)
        {
            throw new NotImplementedException();
        }

        public void borrowTool(iMember member, iTool tool)
        {
            throw new NotImplementedException();
        }

        public void delete(iTool tool)
        {
            throw new NotImplementedException();
        }

        public void delete(iTool tool, int quantity)
        {
            throw new NotImplementedException();
        }

        public void delete(iMember member)
        {
            throw new NotImplementedException();
        }

        public void display(string phoneNum)
        {
            throw new NotImplementedException();
        }

        public void displayTools(string toolType)
        {
            throw new NotImplementedException();
        }

        public void displayTopTHree()
        {
            throw new NotImplementedException();
        }

        public string[] listTools(iMember member)
        {
            throw new NotImplementedException();
        }

        public void returnTool(iMember member, iTool tool)
        {
            throw new NotImplementedException();
        }
    }
}
