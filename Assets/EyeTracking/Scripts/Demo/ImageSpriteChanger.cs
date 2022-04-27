using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
public class ImageSpriteChanger : MonoBehaviour
{
    public Sprite[] sprites;

    Image image;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Execute(int order)
    {
        image.sprite = sprites[order];
    }
}