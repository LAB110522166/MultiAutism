using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class GazeTrigger : MonoBehaviour
{
    [Header("當使用者【有看螢幕】 (Gaze)")]
    public UnityEvent OnGazeEnter;
    public UnityEvent OnGazeExit;    

    /* -------------------------------------------------------------------------- */

    private bool isGazing = false;
    
    /* -------------------------------------------------------------------------- */

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        bool g = GazeManager.Instance.IsGazing;
        if(g != isGazing)
        {
            if(isGazing)
                OnGazeExit?.Invoke();
            else
                OnGazeEnter?.Invoke();
        }
        isGazing = g;
    }

    
}