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

        private List<Collectible> _collectibles = new List<Collectible>();

        private void Awake()
        {
            if (this.collectibleAsset == null)
            {
                Debugger.Exception("Please assign the collectible asset to inventory");
            }
        }

        public void AddCollectible(string letter)
        {
            var letterInstance = this.collectibleAsset.collectibles.Find(c => c.letter == letter );
            var newCollectible = Instantiate<Collectible>(letterInstance);
            newCollectible.transform.SetParent(this.transform);
            _collectibles.Add(newCollectible);
        }

        public void RemoveCollectible()
        {

        }

        // Use this for initialization
        private void Start()
        {
            this.AddCollectible("A");
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }

}
