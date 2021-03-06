using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeS.Toolbox
{
    [CreateAssetMenu(menuName ="CubeS/Item Data")]
    public class ItemData : ScriptableObject
    {
        public string displayName;
        public Sprite icon;
    }
}
