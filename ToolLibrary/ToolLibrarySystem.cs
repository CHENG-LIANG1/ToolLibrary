using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class ToolLibrarySystem : iToolLibrarySystem
    {

        private Tool aTool;
        private ToolCollection toolCollection;

        private Member aMember;

        private MemberCollection members;

        public ToolLibrarySystem(ToolCollection toolCollection, MemberCollection memberCollection) {
            this.toolCollection = toolCollection;
            this.members = memberCollection;
        }

        public void add(Tool tool)
        {
            toolCollection.add(tool);
            tool.Quantity++;
        }

        public void add(Tool tool, int quantity)
        {
            toolCollection.add(tool);
            tool.Quantity += quantity;
        }

        public void add(Member member)
        {
            members.add(member);
        }

        public void borrowTool(Member member, Tool tool)
        {
            if (tool.AvailableQuantity > 0)
            {
                member.addTool(tool);
                tool.addBorrower(member);
            }
            else {
                Console.WriteLine("Tool unavailable, please come back later");
            }
        }

        public void delete(Tool tool)
        {
            toolCollection.delete(tool);
        }

        public void delete(Tool tool, int quantity)
        {
            tool.AvailableQuantity -= quantity;
            if (tool.AvailableQuantity < 0) {
                tool.AvailableQuantity += quantity;
                Console.WriteLine("Cannot delete " + quantity + " pieces of tool");
            }
        }

        public void delete(Member member)
        {
            members.delete(member);
        }

        public void display(string phoneNum)
        {
            Member[] memberArray = members.toArray();
            string[] toolArray = null; 

            for (int i = 0; i < memberArray.Length; i++) {
                if (memberArray[i].ContactNumber == phoneNum) {
                    toolArray = memberArray[i].Tools;
                    Console.WriteLine(memberArray[i].ToString());
                    break;
                }
            }

            for (int i = 0; i < toolArray.Length; i++) {
                if (toolArray != null && toolArray[i] != null) {
                    Console.WriteLine(toolArray[i]);
                }
                
            }

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
