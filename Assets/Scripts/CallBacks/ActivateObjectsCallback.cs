using System.Collections.Generic;
using UnityEngine;

namespace Abs.Callbacks
{
    public class ActivateObjectsCallback : Callback
    {
        public List<GameObject> gameObjects = new List<GameObject>();

        public bool active = true;

        public override void Invoke()
        {
            base.Invoke();
            for (int i = 0; i < this.gameObjects.Count; i++)
            {
                this.gameObjects[i].SetActive(active);
            }
        }
    }
}

