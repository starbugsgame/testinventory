using UnityEngine;
using UnityEngine.UI;


namespace Assets.DynamicListUI.Scripts
{
    public class ListItemViewModel : MonoBehaviour
    {
        public int Id { get; set; }

        public Sprite Sprite;

        public Button Button { get; set; }

        public Color Color = Color.white;


    }
}
