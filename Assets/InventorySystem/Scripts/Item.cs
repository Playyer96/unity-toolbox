using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeS.Toolbox
{
    public class Item : MonoBehaviour, ICollectible
    {
        
        public static event HandleItemCollected OnItemCollected; 
        public delegate void HandleItemCollected(ItemData itemData);
        public ItemData itemData;

        public void Collect()
        {
            Destroy(gameObject);
            OnItemCollected?.Invoke(itemData);
        }
    }
}
