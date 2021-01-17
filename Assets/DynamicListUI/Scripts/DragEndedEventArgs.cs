using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.DynamicListUI.Scripts
{
    public class DragEndedEventArgs
    {
        public ListItemViewModel Item { get; set; }
        public GameObject Target { get; set; }
    }
}
