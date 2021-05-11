﻿using System;
using System.Collections.Generic;


namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class ToolLibrarySystem : iToolLibrarySystem
    {

        // private fields
        private ToolCollection aToolCollection;
        private MemberCollection members = new MemberCollection();
        private ToolCollection[] toolCollections;
     

        public ToolCollection[] ToolCollections { get { return toolCollections; } set { toolCollections = value; } }
        public MemberCollection Members { get { return members; }  set { members = value; } }
        
       
        public ToolLibrarySystem()
        {
        }


        public void add(Tool aTool, string aToolType)
        {
            for (int i = 0; i < toolCollections.Length; i++) {
                if (toolCollections[i].Name == aToolType) {
                    toolCollections[i].add(aTool);
                }
            }
        }

        public void add(Tool aTool, int quantity)
        {
            aTool.Quantity += quantity;
            aTool.AvailableQuantity += quantity;
        }

        public void add(Member aMember)
        {
            members.add(aMember);
        }

        public bool borrowTool(Member aMember, Tool aTool)
        {
            if (aTool.AvailableQuantity > 0)
            {
                if (aMember.BorrowedTools.Number < 3)
                {
                    aMember.addTool(aTool);
                    aTool.addBorrower(aMember);
                    return true;
                }
                else {
                    Console.WriteLine("You have borrowed 3 tools, please return some of them before borrowing.");
                    Console.WriteLine("Press any key to go back. ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nTool unavailable, please come back later.");
                Console.WriteLine("Press any key to go back. ");
                Console.ReadKey();

            }

            return false;
        }

        public void delete(Tool aTool)
        {
            aToolCollection.delete(aTool);
        }

        public void delete(Tool aTool, int quantity) // the situation 'quantity > available quantity' has been handled in UserInterface class
                                                     // so the avaiable quantity is always greater than the quantity to delete in this block of code
        {
             aTool.AvailableQuantity -= quantity; 
             aTool.Quantity -= quantity;
        }

        public void delete(Member member)
        {
            if (member.BorrowedTools.Number > 0)
            {
                Console.WriteLine("\nCannot delete this member! The member is currently borrowing tools.");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else {
                members.delete(member);
                Console.WriteLine("\n" + member.FirstName + " " + member.LastName + " has been removed. ");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

        }


        public Tool[] displayTools(string aToolType)
        {
            Tool tool = null;
            Tool[] displayedTools = null;
            string header = "===============================" + aToolType + "==============================";
            Console.WriteLine(header);
            Console.WriteLine("   {0, -25}{1, -14}{2, -10}{3, -10}", "Name", "Available", "Total", "Total Borrowings");
            for (int i = 0; i < toolCollections.Length; i++) {
                if (toolCollections[i].Name == aToolType) {
                    displayedTools = new Tool[toolCollections[i].Number]; 
                    for (int j = 0; j < toolCollections[i].Number; j++) {
                        tool = toolCollections[i].toArray()[j];
                        displayedTools[j] = tool;
                        Console.WriteLine(j + 1 +  ". {0, -25}{1, -14}{2, -10}{3, -10}", tool.Name, tool.AvailableQuantity, tool.Quantity, tool.NoBorrowings);
                    }
                    break;
                }
            }

            for (int i = 0; i < header.Length; i++) {
                Console.Write("=");
            }
            Console.WriteLine();

            return displayedTools;
        }

     

        private Tool findMaxBorrowing(Tool[] tools) {

            int numOfBoroowings = -1;
            Tool topTool = null;
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] != null && tools[i].NoBorrowings > numOfBoroowings) {
                    numOfBoroowings = tools[i].NoBorrowings;
                    topTool = tools[i];
                }
            }

            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] != null && tools[i].Name == topTool.Name)
                {
                    tools[i] = null;
                }
            }

            return topTool;
        }

        Tool[] allTools = new Tool[1500]; // Recommended size for each tool type is 30, there are 49 tool types
                                          // 1500 is a resonable size to store all the tools
        int index = 0;

        private void putAllToolsInToArray() {
            for (int i = 0; i < toolCollections.Length; i++)
            {
                for (int j = 0; j < toolCollections[i].toArray().Length; j++)
                {
                    allTools[index++] = toolCollections[i].toArray()[j];
                }
            }
        }

        public void displayTopThree()
        {
            putAllToolsInToArray();
            Console.WriteLine("===============Top 3 Borrowed Tools===============");
            for (int i = 0; i < 3; i++) {
                Tool topBorrowedTool = findMaxBorrowing(allTools);
                if (topBorrowedTool != null)
                {
                    Console.WriteLine(i + 1  + ". {0, -25}  Total Borrowings: {1, -20}", topBorrowedTool.Name, topBorrowedTool.NoBorrowings);
                }       
            }
            Console.WriteLine("==================================================");
        }

        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            aMember.deleteTool(aTool);
            aTool.deleteBorrower(aMember);
        }

        public void displayBorrowingTools(Member aMember)
        {
            string[] borrowedTools = aMember.Tools;


            Console.WriteLine("===============Borrowed Tools===============");
            for (int i = 0; i < borrowedTools.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + borrowedTools[i]);

            }
            Console.WriteLine("============================================");



        }
    }
}
