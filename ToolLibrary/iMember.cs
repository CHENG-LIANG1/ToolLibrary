using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    //The specification of Member ADT
    interface iMember
    {
        
        string FirstName  //get and set the first name of this member
        {
            get;
            set;
        }
        string LastName //get and set the last name of this member
        {
            get;
            set;
        }

        string ContactNumber //get and set the contact number of this member
        {
            get;
            set;
        }

        string PIN //get and set the password of this member
        {
            get;
            set;
        }

        string[] Tools //get a list of tools that this memebr is currently holding
        {
            get;
        }

        void addTool(Tool aTool); //add a given tool to the list of tools that this member is currently holding

        void deleteTool(Tool aTool); //delete a given tool from the list of tools that this member is currently holding

        string ToString(); //return a string containing the first name, lastname, and contact phone number of this memeber
    }
}
