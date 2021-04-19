using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class ToolCollection : iToolCollection
    {

        const int NUMBER_OF_TYPES = 49;
        public int Number { get { return NUMBER_OF_TYPES; } }

        public iTool[] toolCollection = new iTool[0];

        public ToolCollection() {
            toolCollection = new iTool[200];
        }

        public bool isSameName(iTool tool) {

            for (int i = 0; i < toolCollection.Length; i++) {
                if (toolCollection[i] != null)
                {
                    if (toolCollection[i].Name == tool.Name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void add(iTool tool)
        {
            if (isSameName(tool))
            {
                tool.AvailableQuantity++;
            }
            else
            {
                for (int i = 0; i < toolCollection.Length; i++)
                {
                    if (toolCollection[i] == null)
                    {
                        toolCollection[i] = tool;
                        break;
                    }
                }
            }
        }

        public void delete(iTool tool)
        {
            throw new NotImplementedException();
        }

        public bool search(iTool tool)
        {
            throw new NotImplementedException();
        }

        public iTool[] toArray()
        {
            throw new NotImplementedException();
        }
    }
}
