using Lean.Touch;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class OutlineOnHover : MonoBehaviour
    {
        private Outline _outline;

        private LeanSelectable _selectable;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
            _selectable = GetComponent<LeanSelectable>();
        }

        private void Update()
        {
            if (_selectable.IsSelected)
            {
                EnableOutline();
                return;
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out RaycastHit hit)) // void OnMouseOver() - not working properly with two cameras
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    EnableOutline();
                }
                else
                {
                    DisableOutline();
                }
            }
        }

        private void EnableOutline()
        {
            _outline.OutlineWidth = 2;
        }
        private void DisableOutline()
        {
            _outline.OutlineWidth = 0;
        }
    }
}
