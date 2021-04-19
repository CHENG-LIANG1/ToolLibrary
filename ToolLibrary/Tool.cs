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
        public string ToolType { get; set; }

        public Tool(string name, string toolType) {
            this.Name = name;
            this.ToolType = toolType;
        }

        public iMemberCollection GetBorrowers => throw new NotImplementedException();

        public void addBorrower(iMember member)
        {
            NoBorrowings++;

        }

        public void deleteBorrower(iMember member)
        {
            throw new NotImplementedException();
        }
    }
}
