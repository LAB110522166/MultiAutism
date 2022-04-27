using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Tobii.Gaming.GazeAware))]
public class FocusTrigger : MonoBehaviour
{
    [Header("當【此物件被注視】(Focus) (該物件需要有 Collider、Gaze Aware)")]
    public UnityEvent OnFocusEnter;
    public UnityEvent OnFocusExit;

    private bool isFocus = false;
    private bool isFocusExitInvoked = false;

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        if(!isFocus && !isFocusExitInvoked)
        {
            OnFocusExit?.Invoke();
            isFocusExitInvoked = true;
        }
        isFocus = false;
    }

    /// <summary>
    /// GazeManager 先輩！看我看我
    /// 希望我打這行不會被發現XDDDD
    /// </summary>
    public void SetFocus()
    {
        if(!isFocus)
            OnFocusEnter?.Invoke();
        isFocus = true;
        isFocusExitInvoked = false;
        // print("y");
    }
}