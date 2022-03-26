/*****************************************

    文件：Test.cs
    日期：#CreateTime#
    功能：Nothing

******************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var a = PopupWindowControl.Instance.AccordingToPopupWindow(new PopupWindowControl.CC_PopupWindow()
        {
            Title = new PopupWindowControl.CC_Title()
            {
                TitleText = "测试标题"
            },
            Body = new PopupWindowControl.CC_Body()
            {
                BodyText = "测试内容"
            },
            Buttons = new List<PopupWindowControl.CC_Button>()
            {
                new PopupWindowControl.CC_Button()
                {
                    ButtonText = "确定",
                    CallBack = ((g) =>
                    {
                        Debug.Log("按下确定按钮");
                        PopupWindowControl.Instance.ClosePopupWindow(g);
                    })
                },
                new PopupWindowControl.CC_Button()
                {
                    ButtonColor = Color.gray,
                    ButtonText = "取消",
                    CallBack = ((g) =>
                    {
                        Debug.Log("按下取消按钮");
                        PopupWindowControl.Instance.ClosePopupWindow(g);
                    })
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
