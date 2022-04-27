using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 印出注視位置
/// </summary>
public class GazePoint : MonoBehaviour
{
    Camera cam;
    RectTransform rectTransform; // not required, if true, set anchorPos directly (Need to be on unscaled canvas)


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Vector3 gazePoint3D = GazeManager.Instance.GazePoint;
        if(rectTransform)
        {
            rectTransform.anchoredPosition = gazePoint3D;
        }
        else
        {
            gazePoint3D.z = 10; // FIXME cam to obj distance
            transform.position = cam.ScreenToWorldPoint(gazePoint3D);
        }
        
    }
}