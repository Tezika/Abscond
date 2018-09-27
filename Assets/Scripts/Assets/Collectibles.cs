using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abs.Inventory.Assets
{
    [CreateAssetMenu(fileName = "Collectibles",menuName = "Abs/Inventory/Collectibles")]
    public class Collectibles : ScriptableObject
    {
        public List<Collectible> collectibles = new List<Collectible>();
    }
}

