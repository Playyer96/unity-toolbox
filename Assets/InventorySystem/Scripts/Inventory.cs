using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeS.Toolbox
{
    public class Inventory : MonoBehaviour
    {
        public List<InventoryItem> inventory = new List<InventoryItem>();
        private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

        private void OnEnable()
        {
            Item.OnItemCollected += Add;
        }

        private void OnDisable()
        {
            Item.OnItemCollected -= Add;
        }

        public void Add(ItemData itemData)
        {
            if (itemDictionary.TryGetValue((ItemData)itemData, out InventoryItem item))
            {
                item.AddToStack();
                Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
            }
            else
            {
                InventoryItem newItem = new InventoryItem(itemData);
                inventory.Add(newItem);
                itemDictionary.Add(itemData, newItem); 
                Debug.Log($"Added {item.itemData.displayName} to the inventory for the first time.");
            }
        }

        public void Remove(ItemData itemData)
        {
            if(itemDictionary.TryGetValue((ItemData)itemData, out InventoryItem item))
            {
                item.RemoveFromStack();
                if (item.stackSize == 0)
                {
                    inventory.Remove(item);
                    itemDictionary.Remove(itemData);
                }
            }
        }
    }
}
