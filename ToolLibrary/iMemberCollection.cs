using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    //The specification of MemberCollection ADT, which is used to store and manipulate a collection of members
    
    interface iMemberCollection
    {
        int Number // get the number of members in the community library
        {
            get;
        }

        void add(Member member); //add a new member to this member collection, make sure there are no duplicates in the member collection

        void delete(Member member); //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool

        Boolean search(Member member); //search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise.

        Member[] toArray(); //output the memebers in this collection to an array of iMember
    }
}
