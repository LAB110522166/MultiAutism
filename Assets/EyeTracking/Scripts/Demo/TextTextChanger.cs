using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextTextChanger : MonoBehaviour
{
    [Multiline]
    public string[] texts;

    Text text;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        text = GetComponent<Text>();
    }

    public void Execute(int order)
    {
        text.text = texts[order];
    }
}