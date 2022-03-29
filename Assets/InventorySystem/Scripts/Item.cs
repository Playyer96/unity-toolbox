using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeS.Toolbox
{
    public class Item : MonoBehaviour, ICollectible
    {
        public static event HandleGemCollected OnItemCollected; 
        public delegate void HandleGemCollected(ItemData itemData);
        public ItemData _itemData;

        public void Collect()
        {
            Destroy(gameObject);
            OnItemCollected?.Invoke(_itemData);
        }
    }
}
