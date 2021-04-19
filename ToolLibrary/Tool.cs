using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class Tool : iTool
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AvailableQuantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NoBorrowings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public iMemberCollection GetBorrowers => throw new NotImplementedException();

        public void addBorrower(iMember member)
        {
            throw new NotImplementedException();
        }

        public void deleteBorrower(iMember member)
        {
            throw new NotImplementedException();
        }
    }
}
