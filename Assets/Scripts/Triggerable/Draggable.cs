using UnityEngine;

namespace Abs.Triggerable
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Draggable : MonoBehaviour
    {
        public bool beingDragged { get; private set; }

        private void Awake()
        {
            this.beingDragged = false;
        }

        // Use this for initialization

        void Update()
        {
            if (this.beingDragged)
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.gameObject.transform.position = new Vector3(point.x, point.y, 0);
            }
        }

        private void OnMouseDown()
        {
            this.beingDragged = true;
        }

        private void OnMouseUp()
        {
            this.beingDragged = false;
        }
    }
}

