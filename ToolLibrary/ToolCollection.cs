using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class ToolCollection : iToolCollection
    {

        const int NUMBER_OF_TYPES = 49;
        public int Number { get { return NUMBER_OF_TYPES; } }

        private Tool[] toolCollection = new Tool[0];

        public ToolCollection() {
            toolCollection = new Tool[200];
        }

        private int hasSameName(Tool tool) {

            for (int i = 0; i < toolCollection.Length; i++) {
                if (toolCollection[i] != null && toolCollection[i].Name == tool.Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public void add(Tool tool)
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

        public void delete(Tool tool)
        {
            int index = hasSameName(tool);
            if (index >=0) {
                toolCollection[index] = null;

            }
        }

        public bool search(Tool tool) 
        {
            if (hasSameName(tool) >= 0) {
                return true;
            }

            return false;
        }

        public Tool[] toArray()
        {
            return toolCollection;
        }
    }
}
