using Abs.Utils;
using UnityEngine;

namespace Abs.Triggerable
{
    public class Draggable : MonoBehaviour
    {
        public bool beingDragged { get; private set; };

        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            this.beingDragged = false;
            _boxCollider2D = this.GetComponent<BoxCollider2D>();
        }

        // Use this for initialization
        void Start()
        {

        }

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

