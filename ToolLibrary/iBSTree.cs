using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    interface iBSTree
    {


		// pre: true
		// post: item is added to the binary search tree
		void add(Member item);

		// pre: true
		// post: an occurrence of item is removed from the binary search tree 
		//		 if item is in the binary search tree
		void delete(Member item);

		// pre: true
		// post: return true if item is in the binary search true;
		//	     otherwise, return false.
		bool search(Member item);
        MemberCollection InOrderTraverse();
    }
}
