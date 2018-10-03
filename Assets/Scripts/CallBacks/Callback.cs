using Abs.Item;
using UnityEngine;

namespace Abs.Callbacks
{
    [RequireComponent(typeof(TriggerObject))]
    public class Callback : MonoBehaviour
    {
        public virtual void Invoke()
        {
        }
    }

}
