using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class ToolLibrarySystem : iToolLibrarySystem
    {

        private Tool aTool { get; set; }
        private ToolCollection ToolCollection { get; set; }

        private Member aMember { get; set; }

        private MemberCollection members { get; set; }

        public void add(Tool tool)
        {
            ToolCollection.add(tool);
            tool.Quantity++;
        }

        public void add(Tool tool, int quantity)
        {
            ToolCollection.add(tool);


        }

        public void add(Member member)
        {
            throw new NotImplementedException();
        }

        public void borrowTool(Member member, Tool tool)
        {
            throw new NotImplementedException();
        }

        public void delete(Tool tool)
        {
            throw new NotImplementedException();
        }

        public void delete(Tool tool, int quantity)
        {
            throw new NotImplementedException();
        }

        public void delete(Member member)
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

        public string[] listTools(Member member)
        {
            throw new NotImplementedException();
        }

        public void returnTool(Member member, Tool tool)
        {
            throw new NotImplementedException();
        }
    }
}
