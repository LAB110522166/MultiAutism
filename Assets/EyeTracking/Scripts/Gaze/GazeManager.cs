using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine.UI;

/// <summary>
/// Gaze Manager, 包裝 TobiiAPI
/// </summary>
[System.Serializable]
public class GazeManager : MonoSingleton<GazeManager>
{

    /// <summary>
    /// 這些值是否可用 (是否過期？)
    /// </summary>
    /// <value></value>
    public bool IsValid { get; private set; }

    /// <summary>
    /// 是否在注視螢幕？
    /// </summary>
    public bool IsGazing => GazePoint.x <= Screen.width && GazePoint.y <= Screen.height && GazePoint.x >= 0 && GazePoint.y >= 0;

    /// <summary>
    /// 注視點 (螢幕座標)
    /// </summary>
    /// <value></value>
    public Vector2 GazePoint { get; private set; }

    /// <summary>
    /// 是否注視帶有 Gaze Trigger 的有效物件
    /// </summary>
    /// <value></value>
    public bool IsFocusing { get; private set; }

    /// <summary>
    /// 使用者頭部位置
    /// </summary>
    /// <value></value>
    public Vector3 HeadPosition { get; private set; }

    /// <summary>
    /// 使用者頭部旋轉
    /// </summary>
    /// <value></value>
    public Quaternion HeadRotation { get; private set; }



    /* -------------------------------------------------------------------------- */



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instantiate(Resources.Load("Tobii Initializer"));
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // gaze
        var gaze = TobiiAPI.GetGazePoint();
        IsValid = gaze.IsRecent();
        GazePoint = IsValid ? gaze.Screen : Vector2.negativeInfinity;

        // focus
        var focusObj = TobiiAPI.GetFocusedObject()?.GetComponent<FocusTrigger>();
        if (focusObj)
        {
            focusObj.SetFocus();
            IsFocusing = true;
        }
        else
        {
            IsFocusing = false;
        }

        // head pose
        var head = TobiiAPI.GetHeadPose();
        HeadPosition = head.Position;
        HeadRotation = head.Rotation;        
    }
}