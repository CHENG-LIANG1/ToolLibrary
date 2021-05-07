using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    interface iToolLibrarySystem
    {
        void add(Tool aTool, string aToolType); // add a new tool to the system

        void add(Tool aTool, int quantity); //add new pieces of an existing tool to the system

        void delete(Tool aTool); //delte a given tool from the system

        void delete(Tool aTool, int quantity); //remove some pieces of a tool from the system

        void add(Member aMember); //add a new memeber to the system

        void delete(Member aMember); //delete a member from the system

        void displayBorrowingTools(Member aMember); //given a member, display all the tools that the member are currently renting


        Tool[] displayTools(string aToolType); // display all the tools of a tool type selected by a member

        void borrowTool(Member aMember, Tool aTool); //a member borrows a tool from the tool library

        void returnTool(Member aMember, Tool aTool); //a member return a tool to the tool library

        string[] listTools(Member aMember); //get a list of tools that are currently held by a given member

        void displayTopThree(); //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.

    }
}
