using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GazeDataDebugger : MonoBehaviour
{
    [SerializeField] Text _debugText;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // debugger
        if (_debugText)
        {
            GazeManager gm = GazeManager.Instance;
            _debugText.text =
                // "GazeManager.Instance.\n\n" +
                $"IsValid={gm.IsValid}\nGazePoint={gm.GazePoint}\nIsGazing={gm.IsGazing}\n\n" +
                $"IsFocusing={gm.IsFocusing}\n\n" +
                $"HeadPosition={gm.HeadPosition}\nHeadRotation={gm.HeadRotation}\n\n";
        }
    }
}