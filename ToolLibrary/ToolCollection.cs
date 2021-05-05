﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    // Author: Cheng Liang
    // N10346911
    class ToolCollection : iToolCollection
    {

        // private fields
        private int number;
        private Tool[] toolCollection;
        private string name;

        // properties
        public int Number { get { return number; } }
        public string Name { get { return name; } }

        // constructor
        public ToolCollection(string name) {
            toolCollection = new Tool[number];
            this.name = name;
        }

        // private method to check if two tools have the same name,
        // return the index of the tool in the array if found the tool
        // return -1 if not found
        private int hasSameName(Tool tool) {

            for (int i = 0; i < toolCollection.Length; i++) {
                if (toolCollection[i] != null && toolCollection[i].Name == tool.Name)
                {
                    return i;
                }
            }
            return -1;
        }


        // private method to resize the array after addition and deletion
        private Tool[] resizeArray(Tool[] toolArray) {
            Tool[] array = new Tool[number];

            for (int i = 0; i < toolArray.Length; i++) {
                if (toolArray[i] != null) {
                    array[i] = toolArray[i];
                }
            }

            return array;
        }

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

        public void delete(Tool tool)
        {
            number--;
            tool.Quantity = 0;
            int index = hasSameName(tool);
            if (index >=0) {
                toolCollection[index] = null;
                toolCollection = resizeArray(toolCollection);

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
