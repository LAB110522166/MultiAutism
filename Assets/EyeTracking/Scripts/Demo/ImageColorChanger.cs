using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
public class ImageColorChanger : MonoBehaviour
{
    public Color[] colors;

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
        image.color = colors[order];
    }
}