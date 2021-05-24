using System;
using System.Collections.Generic;
using System.Linq;


namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class ToolLibrarySystem : iToolLibrarySystem
    {

        // private fields
        private MemberCollection members;
        private ToolCollection[] toolCollections;
        private List<Tool> borrowedTools; // all the tools that have been borrowed before


        // constructor
        public ToolLibrarySystem()
        {
            toolCollections = UserInterface.GetAllToolCollections();
            members = UserInterface.GetMemberCollection();
            borrowedTools = new List<Tool>();
        }


        /// <summary>
        /// add a tool to the system
        /// </summary>
        /// <param name="aTool"> tool to add </param>
        public void add(Tool aTool)
        {
            for (int i = 0; i < toolCollections.Length; i++)
            {
                if (toolCollections[i].ToString() == UserInterface.GetCurrentlySelectedToolType())
                {
                    toolCollections[i].add(aTool);
                }
            }
        }

        /// <summary>
        /// add some pieces of an existing tool to the sysyem
        /// </summary>
        /// <param name="aTool"> tool to add</param>
        /// <param name="quantity"></param>
        public void add(Tool aTool, int quantity)
        {
            aTool.Quantity += quantity;
            aTool.AvailableQuantity += quantity;
        }

        /// <summary>
        /// add a member to the system
        /// </summary>
        /// <param name="aMember"> member to add </param>
        public void add(Member aMember)
        {
            members.add(aMember);
        }

        /// <summary>
        /// a member borrows a tool from the system
        /// </summary>
        /// <param name="aMember"> member who borrows a tool </param>
        /// <param name="aTool"> tool gets borrowed </param>
        /// <returns></returns>
        public bool borrowTool(Member aMember, Tool aTool)
        {
            if (aTool.AvailableQuantity > 0)
            {
                if (aMember.Tools == null || aMember.Tools.Length < 3)
                {
                    aMember.addTool(aTool);
                    aTool.addBorrower(aMember);
                    borrowedTools.Add(aTool); // add the borrowed tool to the list
                    borrowedTools = borrowedTools.Distinct().ToList(); // remove duplicate tools
     
                    return true;
                }
                else
                {
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

        /// <summary>
        /// delete a tool from the system
        /// </summary>
        /// <param name="aTool"> tool to delete </param>
        public void delete(Tool aTool)
        {
            for (int i = 0; i < toolCollections.Length; i++)
            {
                for (int j = 0; j < toolCollections[i].toArray().Length; j++)
                {
                    if (aTool.Name == toolCollections[i].toArray()[j].Name)
                    {
                        toolCollections[i].delete(aTool);
                    }
                }
            }
        }

        /// <summary>
        /// delete some pieces of an existing tool from the system
        /// </summary>
        /// <param name="aTool"> Tool to remove pieves</param>
        /// <param name="quantity"> quantity of pieces to remove </param>
        public void delete(Tool aTool, int quantity) // the situation 'quantity to delete > available quantity' has been handled in UserInterface class
                                                     // so the avaiable quantity is always greater than the quantity to delete in this block of code
        {
            aTool.AvailableQuantity -= quantity;
            aTool.Quantity -= quantity;
        }

        /// <summary>
        /// delete a member from the system
        /// </summary>
        /// <param name="member"> member to delete </param>
        public void delete(Member member)
        {
            if (member.Tools != null && member.Tools.Length > 0)
            {
                Console.WriteLine("\nCannot delete this member! The member is currently borrowing tools.");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                members.delete(member);
                Console.WriteLine("\n" + member.FirstName + " " + member.LastName + " has been removed. ");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

        }

        /// <summary>
        /// display the tools in a given tool type
        /// </summary>
        /// <param name="aToolType"> a tool type </param>
        public void displayTools(string aToolType)
        {
            string header = "===============================" + aToolType + "==============================";
            Console.WriteLine(header);
            Console.WriteLine("   {0, -25}{1, -14}{2, -10}{3, -10}", "Name", "Available", "Total", "Total Borrowings");
            for (int i = 0; i < toolCollections.Length; i++)
            {
                if (toolCollections[i].ToString() == aToolType)
                {
                    for (int j = 0; j < toolCollections[i].Number; j++)
                    {
                        Tool tool = toolCollections[i].toArray()[j];
                        Console.WriteLine(j + 1 + ". " + tool.ToString());
                    }
                    break;
                }
            }

            for (int i = 0; i < header.Length; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// display the top three borrowed tools
        /// an array containng distinct borrowed tool has been created.
        /// This method will only sort the tools which has been borrowed before
        /// </summary>
        public void displayTopThree()
        {
            // Buble sort the borrowed tools list
            for (int i = 0; i < borrowedTools.Count - 1; i++)
            {
                for (int j = 0; j < borrowedTools.Count - 1 - i; j++)
                {
                    if (borrowedTools[j + 1].NoBorrowings < borrowedTools[j].NoBorrowings)
                    {
                        Tool temp = borrowedTools[j];
                        borrowedTools[j] = borrowedTools[j + 1];
                        borrowedTools[j + 1] = temp;
                    }
                }
            }

            // display the top three tools
            if (borrowedTools[^1].NoBorrowings > 0)
                Console.WriteLine("{0, -25}  Total Borrowings: {1, -20}", borrowedTools[^1].Name, borrowedTools[^1].NoBorrowings);


            if (borrowedTools.Count > 1 && borrowedTools[^2].NoBorrowings > 0)
                Console.WriteLine("{0, -25}  Total Borrowings: {1, -20}", borrowedTools[^2].Name, borrowedTools[^2].NoBorrowings);


            if (borrowedTools.Count > 2 && borrowedTools[^3].NoBorrowings > 0)
                Console.WriteLine("{0, -25}  Total Borrowings: {1, -20}", borrowedTools[^3].Name, borrowedTools[^3].NoBorrowings);

        }


        /// <summary>
        /// get an array of tools a member is currently borrowing
        /// </summary>
        /// <param name="aMember"> a member </param>
        /// <returns> a string array of tool names </returns>
        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }

        /// <summary>
        /// a member returns a tool
        /// </summary>
        /// <param name="aMember"> a member who returns a tool </param>
        /// <param name="aTool"> tool to return </param>
        public void returnTool(Member aMember, Tool aTool)
        {
            aMember.deleteTool(aTool);
            aTool.deleteBorrower(aMember);
        }

        /// <summary>
        /// display the tools a member is currently borrwoing
        /// </summary>
        /// <param name="aMember"> a member </param>
        public void displayBorrowingTools(Member aMember)
        {
            Console.WriteLine("===============Borrowed Tools===============");
            if (aMember.Tools != null)
            {
                for (int i = 0; i < aMember.Tools.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + aMember.Tools[i]);
                }
            }
            Console.WriteLine("============================================");
        }
    }
}
