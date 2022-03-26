/*****************************************

    文件：Button.cs
    日期：#CreateTime#
    功能：按钮控制

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public Image image;
    public Text text;

    public bool isDown = false;
    
    public delegate void Down();
    
    private void Start()
    {
        button.onClick.AddListener (() =>
        {
            isDown = true;
        });
    }

    public IEnumerator A(Down down)
    {
        while (true)
        {
            while (!isDown)
            {
                yield return null;
            }
            isDown = false;
            down();
            yield return null;
        }
    }
}
