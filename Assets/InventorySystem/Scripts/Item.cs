using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeS.Toolbox
{
    public class Item : MonoBehaviour, ICollectible
    {
        public static event HandleGemCollected OnGemCollected; 
        public delegate void HandleGemCollected(ItemData itemData);
        public ItemData itemData;

        public void Collect()
        {
            Destroy(gameObject);
            OnGemCollected?.Invoke(itemData);
        }
    }
}
