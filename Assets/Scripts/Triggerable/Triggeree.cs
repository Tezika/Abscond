using UnityEngine;

namespace Abs.Triggerable
{
    public class Triggeree : MonoBehaviour
    {
        public bool destroyed;

        public void Triggered()
        {
            if (this.destroyed)
            {
                Destroy(this.gameObject);
            }
            else
            {
                //....
            }
        }
    }
}

