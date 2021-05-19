using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class ToolCollection : iToolCollection
    {
        // private fields
        private int number;
        private Tool[] toolCollection;
        private string name; // for identifying tool types

        // properties
        public int Number { get { return number; } }
        public string Name { get { return name; } }

        // constructor
        public ToolCollection(string name) {
            toolCollection = new Tool[number];
            this.name = name;
        }

        /// <summary>
        /// private method to find the index of a tool in the collection
        /// </summary>
        /// <param name="tool"> tool to find </param>
        /// <returns> index of the tool if found, -1 otherwise </returns>
        private int findToolIndex(Tool tool) {
            for (int i = 0; i < toolCollection.Length; i++) {
                if (toolCollection[i] != null && toolCollection[i].Name == tool.Name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// private method to resize a tool array
        /// </summary>
        /// <param name="toolArray"> the tool array to resize</param>
        /// <returns> a resized tool array </returns>
        private Tool[] resizeArray(Tool[] toolArray) {
            Tool[] array = new Tool[number];
            List<Tool> temp = new List<Tool>();

            if (number > toolArray.Length) // Add a tool
            {
                for (int i = 0; i < toolArray.Length; i++)
                {
                    array[i] = toolArray[i];

                }
            }
            else { // delete a tool
                foreach (Tool tool in toolArray) {
                    if (tool != null) {
                        temp.Add(tool);
                    }
                }
                array = temp.ToArray();
            }
            return array;
        }

        /// <summary>
        /// add a tool to the tool collection
        /// </summary>
        /// <param name="tool"> tool to add </param>
        public void add(Tool tool)
        {
            number++;
            toolCollection = resizeArray(toolCollection);
            for (int i = 0; i < toolCollection.Length; i++)
            {
                if (toolCollection[i] == null)
                {
                    toolCollection[i] = tool;
                    break;
                }
            }
        }

        /// <summary>
        /// delete a tool from the tool collection
        /// </summary>
        /// <param name="tool"> tool to delete </param>
        public void delete(Tool tool)
        {
            int index = findToolIndex(tool);
            if (index >=0) {
                toolCollection[index] = null;
                number--;
                toolCollection = resizeArray(toolCollection);
            }
        }

        /// <summary>
        /// search for a tool in the tool collection
        /// </summary>
        /// <param name="tool"> tool to search </param>
        /// <returns> true if found, false otherwise </returns>
        public bool search(Tool tool) 
        {
            if (findToolIndex(tool) >= 0) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// return the tool array
        /// </summary>
        /// <returns> the tool array </returns>
        public Tool[] toArray()
        {
            return toolCollection;
        }
    }
}
