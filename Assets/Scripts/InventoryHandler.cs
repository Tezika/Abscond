using System.Collections;
using System.Collections.Generic;
using Abs.Inventory.Assets;
using Abs.Utils;
using UnityEngine;

namespace Abs.Inventory
{
    public class InventoryHandler : MonoBehaviour
    {

        public Collectibles collectibleAsset;

        private void Awake()
        {
            if (this.collectibleAsset == null)
            {
                Debugger.Exception("Please assign the collectible asset to inventory");
            }
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
