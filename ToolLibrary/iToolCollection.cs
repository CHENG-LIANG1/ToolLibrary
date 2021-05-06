using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    //The specification of ToolCollection ADT, which is used to store and manipulate a collection of tools
    interface iToolCollection
    {
        int Number // get the number of the types of tools in the community library
        {
            get;
        }
        void add(Tool aTool); //add a given tool to this tool collection
        void delete(Tool aTool); //delete a given tool from this tool collection
        Boolean search(Tool aTool); //search a given tool in this tool collection. Return true if this tool is in the tool collection; return false otherwise
        Tool[] toArray(); // output the tools in this tool collection to an array of iTool
    }
}
