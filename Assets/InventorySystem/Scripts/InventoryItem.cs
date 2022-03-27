using System;
using System.Collections.Generic;
using UnityEngine;

namespace CubeS.Toolbox
{
    [Serializable]
    public class InventoryItem
    {
        public ItemData itemData;
        public int stackSize;

        public InventoryItem(ItemData item)
        {
            itemData = item;
            AddToStack();
        }

        public void AddToStack()
        {
            stackSize++;
        }

        public void RemoveFromStack()
        {
            stackSize--;
        }
    }
}
