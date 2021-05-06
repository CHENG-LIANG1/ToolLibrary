﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class ToolLibrarySystem : iToolLibrarySystem
    {


        private ToolCollection aToolCollection;
        private MemberCollection members;
        private ToolCollection[] toolCollections;
     

        public ToolCollection ToolCollection { get { return aToolCollection; } set { aToolCollection = value; } }
        public ToolCollection[] ToolCollections { get { return toolCollections; } set { toolCollections = value; } }
        
       
        public ToolLibrarySystem()
        {
        }


        public void add(Tool aTool, string aToolType)
        {
            for (int i = 0; i < toolCollections.Length; i++) {
                if (toolCollections[i].Name == aToolType) {
                    toolCollections[i].add(aTool);
                    aTool.Quantity++;
                }
            }

        }

        public void add(Tool aTool, int quantity)
        {
            aTool.Quantity += quantity;
        }

        public void add(Member aMember)
        {
            members.add(aMember);
        }

        public void borrowTool(Member aMember, Tool aTool)
        {
            if (aTool.AvailableQuantity > 0)
            {
                aMember.addTool(aTool);
                aTool.addBorrower(aMember);
            }
            else
            {
                Console.WriteLine("Tool unavailable, please come back later");
            }
        }

        public void delete(Tool aTool)
        {
            aToolCollection.delete(aTool);
        }

        public void delete(Tool aTool, int quantity)
        {


            if (aTool.AvailableQuantity > quantity)
            {
                aTool.AvailableQuantity -= quantity;
            }
            else {
                Console.WriteLine("Cannot delete " + quantity + " pieces of tool");
            }
        }

        public void delete(Member member)
        {
            members.delete(member);
        }


        public void displayTools(string aToolType)
        {
            for (int i = 0; i < toolCollections.Length; i++) {
                if (toolCollections[i].Name == aToolType) {
                    for (int j = 0; j < toolCollections[i].toArray().Length; i++) {
                        if (toolCollections[i].toArray()[j] != null) {
                            Console.WriteLine(toolCollections[i].toArray()[j].Name);
                        }
                    }
                    break;
                }
            }
        }


        private Tool findMaxBorrowing(List<Tool> tools) {

            int numOfBoroowings = 0;
            Tool topTool = null;
            for (int i = 0; i < tools.Count; i++)
            {
                if (tools[i].NoBorrowings > numOfBoroowings) {
                    numOfBoroowings = tools[i].NoBorrowings;
                    topTool = tools[i];
                    tools.RemoveAt(i); // remove the top borrowing tool
                }
            }
            return topTool;
        }

        public void displayTopThree()
        {
            List<Tool> allTools = new List<Tool>();
            for (int i = 0; i < toolCollections.Length; i++) {
                for (int j = 0; j < toolCollections[i].toArray().Length; j++) {
                    allTools.Add(toolCollections[i].toArray()[j]);
                }
            }

            Tool top = null;
            for (int i = 0; i < 3; i++) {
                top = findMaxBorrowing(allTools);
                Console.WriteLine(top.Name);
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
            string[] borrowingTools = aMember.Tools;
            for (int i = 0; i < borrowingTools.Length; i++) {
                if (borrowingTools[i] != null) {
                    Console.WriteLine(borrowingTools[i]);
                }
            }
        }
    }
}
