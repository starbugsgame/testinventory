using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Adorner : MonoBehaviour
{
    SpriteRenderer _renderer;

    void Start()
    {
        transform.SetParent(null);
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetImage(Image image)
    {
        Rect rect = new Rect(0, 0, image.mainTexture.width, image.mainTexture.height);
        _renderer.sprite = Sprite.Create((Texture2D)image.mainTexture, rect, new Vector2(0.5f, 0.5f));
    }

    public void ResetImage()
    {
        _renderer.sprite = null;
    }
}
