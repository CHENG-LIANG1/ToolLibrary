using System;

namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class Tool : iTool
    {
        // private fields
        private string name;
        private int quantity;
        private int availableQuantity;
        private int noBorrowings;
        private MemberCollection toolBorrowers;

        // properties
        public string Name { get { return name; } set { name = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int AvailableQuantity { get { return availableQuantity; } set { availableQuantity = value; } }
        public int NoBorrowings { get { return noBorrowings; } set { noBorrowings = value; } }
        public MemberCollection GetBorrowers {get{ return toolBorrowers; } }

        // constructor
        public Tool(string name) {
            toolBorrowers = new MemberCollection();
            this.name = name;
        }

        public void addBorrower(Member member)
        {
            if (availableQuantity > 0)
            {
                toolBorrowers.add(member);
                noBorrowings++;
                availableQuantity--;
            }
        }

        public void deleteBorrower(Member member)
        {
            toolBorrowers.delete(member);
            availableQuantity++;
        }

        public override string ToString()
        {
            return String.Format("{0, -25}{1, -14}{2, -10}{3, -10}", name, availableQuantity, quantity, noBorrowings);
        }
    }
}
