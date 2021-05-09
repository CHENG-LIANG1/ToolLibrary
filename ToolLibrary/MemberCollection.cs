using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToolLibrary
{
	// Author:    Cheng Liang
	// Studen ID: N10346911
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



		Member[] memberArray = new Member[500]; // initialise an array with a resonable community size of 500 people
		int index = 0;
		public Member[] toArray()
		{
			memberArray = new Member[500]; // reset the array for a new BST traversal
			index = 0;                     // reset the index as well
			InOrderTraverse(root);
			return memberArray;
		}


		private Member[] InOrderTraverse(BTreeNode root)
		{

			if (root != null)
			{
				InOrderTraverse(root.LChild);
			    memberArray[index++] = root.Member;
				InOrderTraverse(root.RChild);
			}

			return memberArray;
		}






	}
}
