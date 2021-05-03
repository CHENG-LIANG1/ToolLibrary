using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class Tool : iTool
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int NoBorrowings { get; set; }
        public MemberCollection GetBorrowers
        {
            get
            {
                return toolBorrowers.InOrderTraverse();
            }
        }

        public Tool(string name) {
            this.Name = name;
        }

        private MemberCollection toolBorrowers = new MemberCollection();


        public void addBorrower(Member member)
        {
            toolBorrowers.add(member);
            NoBorrowings++;
            AvailableQuantity--;

        }

        public void deleteBorrower(Member member)
        {
            toolBorrowers.delete(member);
            NoBorrowings--;
            AvailableQuantity++;
        }
    }
}
