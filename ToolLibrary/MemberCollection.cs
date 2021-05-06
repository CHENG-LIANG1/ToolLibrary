using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
	// Author: Cheng Liang
	// N10346911
	class MemberCollection : iMemberCollection, iBSTree
    {
		// private fields
		private BTreeNode root;
		private int number;

		// properties
		public int Number { get { return number; } set { number = value; } }

		// constructor
        public MemberCollection() {
            root = null;
        }

        public void add(Member member)
        {
			number++;
            if (root == null)
                root = new BTreeNode(member);
            else
                add(member, root);
        }

        private void add(Member aMember, BTreeNode ptr)
        {
            if (aMember.CompareTo(ptr.Member) < 0)
            {
				if (ptr.LChild == null)
					ptr.LChild = new BTreeNode(aMember);
				else
				{
					add(aMember, ptr.LChild);
				}
            }
            else
            {
				if (ptr.RChild == null)
					ptr.RChild = new BTreeNode(aMember);
				else
				{
					add(aMember, ptr.RChild);
				}
            }
        }


        public void delete(Member aMember)
        {
			// search for item and its parent
			BTreeNode ptr = root; // search reference
			BTreeNode parent = null; // parent of ptr
			while ((ptr != null) && (aMember.CompareTo(ptr.Member) != 0))
			{
				parent = ptr;
				if (aMember.CompareTo(ptr.Member) < 0) // move to the left child of ptr
					ptr = ptr.LChild;
				else
					ptr = ptr.RChild;
			}

			if (ptr != null) // if the search was successful
			{
				number--;
				// case 3: item has two children
				if ((ptr.LChild != null) && (ptr.RChild != null))
				{
					// find the right-most node in left subtree of ptr
					if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
					{
						ptr.Member = ptr.LChild.Member;
						ptr.LChild = ptr.LChild.LChild;
					}
					else
					{
						BTreeNode p = ptr.LChild;
						BTreeNode pp = ptr; // parent of p
						while (p.RChild != null)
						{
							pp = p;
							p = p.RChild;
						}
						// copy the item at p to ptr
						ptr.Member = p.Member;
						pp.RChild = p.LChild;
					}
				}
				else // cases 1 & 2: item has no or only one child
				{
					BTreeNode c;
					if (ptr.LChild != null)
						c = ptr.LChild;
					else
						c = ptr.RChild;

					// remove node ptr
					if (ptr == root) //need to change root
						root = c;
					else
					{
						if (ptr == parent.LChild)
							parent.LChild = c;
						else
							parent.RChild = c;
					}
				}

			}
		}

        public bool search(Member aMember)
        {
			return Search(aMember, root);
		}

		private bool Search(Member item, BTreeNode r)
		{
			if (r != null)
			{
				if (item.CompareTo(r.Member) == 0)
					return true;
				else
					if (item.CompareTo(r.Member) < 0)
					return Search(item, r.LChild);
				else
					return Search(item, r.RChild);
			}
			else
				return false;
		}

		public Member[] toArray()
        {
			return InOrderTraverseArray(root);
		}


		public MemberCollection InOrderTraverse()
		{
			return InOrderTraverse(root);
		}

		private MemberCollection InOrderTraverse(BTreeNode root)
		{
			MemberCollection resultCollection = new MemberCollection();
			if (root != null)
			{

				InOrderTraverse(root.LChild);

				resultCollection.add(root.Member);
				InOrderTraverse(root.RChild);
			}

			return resultCollection;
		}


		private Member[] InOrderTraverseArray(BTreeNode root)
		{
			Member[] resultArray = new Member[number];
			int index = 0;
			if (root != null)
			{

				InOrderTraverse(root.LChild);

				resultArray[index] = root.Member;
				index++;
				InOrderTraverse(root.RChild);
			}

			return resultArray;
		}




	}
}
