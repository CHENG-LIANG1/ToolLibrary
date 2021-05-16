﻿using System;
using System.Collections.Generic;


namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class ToolLibrarySystem : iToolLibrarySystem
    {

        // private fields
        private MemberCollection members;
        private ToolCollection[] toolCollections;
        private List<Tool> allTools;


        // constructor
        public ToolLibrarySystem() {
            toolCollections = Program.GetToolCollections();
            members = UserInterface.GetMemberCollection();                                               
        }

        public void add(Tool aTool)
        {
            for (int i = 0; i < toolCollections.Length; i++) {
                if (toolCollections[i].Name == UserInterface.GetCurrentlySelectedToolType()) {
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
                if (aMember.Tools == null || aMember.Tools.Length < 3)
                {
                    aMember.addTool(aTool);
                    aTool.addBorrower(aMember);
                    return true;
                }
                else {
                    Console.WriteLine("\nYou have borrowed 3 tools, please return some of them before borrowing.");
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
            for (int i = 0; i < toolCollections.Length; i++) {
                for (int j = 0; j < toolCollections[i].toArray().Length; j++) {
                    if (aTool.Name == toolCollections[i].toArray()[j].Name) {
                        toolCollections[i].delete(aTool);
                    }
                }
            }
        }

        public void delete(Tool aTool, int quantity) // the situation 'quantity > available quantity' has been handled in UserInterface class
                                                     // so the avaiable quantity is always greater than the quantity to delete in this block of code
        {
             aTool.AvailableQuantity -= quantity; 
             aTool.Quantity -= quantity;
        }

        public void delete(Member member)
        {
            if (member.Tools != null && member.Tools.Length > 0)
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

        public void displayTools(string aToolType)
        {
            string header = "===============================" + aToolType + "==============================";
            Console.WriteLine(header);
            Console.WriteLine("   {0, -25}{1, -14}{2, -10}{3, -10}", "Name", "Available", "Total", "Total Borrowings");
            for (int i = 0; i < toolCollections.Length; i++) {
                if (toolCollections[i].Name == aToolType) {
                    for (int j = 0; j < toolCollections[i].Number; j++) {
                        Tool tool = toolCollections[i].toArray()[j];
                        Console.WriteLine(j + 1 +  ". " + tool.ToString());
                    }
                    break;
                }
            }

            for (int i = 0; i < header.Length; i++) {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        // private method to put all tools in an array
        private void putAllToolsInToList()
        {
            for (int i = 0; i < toolCollections.Length; i++)
            {
                for (int j = 0; j < toolCollections[i].toArray().Length; j++)
                {
                    allTools.Add(toolCollections[i].toArray()[j]);
                }
            }
        }


        public void displayTopThree()
        {
            putAllToolsInToList();

            for (int i = 0; i < 3; i++) {

                int numOfBoroowings = 0;
                Tool topBorrowedTool = null;

                for (int j = 0; j < allTools.Count; j++)
                {
                    if (allTools[i] != null && allTools[i].NoBorrowings > numOfBoroowings)
                    {
                        numOfBoroowings = allTools[i].NoBorrowings;
                        topBorrowedTool = allTools[i];
                    }
                }
                allTools.Remove(topBorrowedTool);


                if (topBorrowedTool != null)
                {
                    Console.WriteLine(i + 1  + ". {0, -25}  Total Borrowings: {1, -20}", topBorrowedTool.Name, topBorrowedTool.NoBorrowings);
                }       
            }

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
            Console.WriteLine("===============Borrowed Tools===============");
            for (int i = 0; i < aMember.Tools.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + aMember.Tools[i]);
            }
            Console.WriteLine("============================================");
        }
    }
}
