using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class OutlineOnHover:MonoBehaviour
    {
        private Outline outline;
        private void Awake()
        {
            outline = GetComponent<Outline>();
        }
        void OnMouseOver()
        {
            outline.OutlineWidth = 2;
        }

        void OnMouseExit()
        {
            outline.OutlineWidth = 0;
        }

    }
}
