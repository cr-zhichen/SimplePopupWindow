/*****************************************

    文件：Test.cs
    日期：#CreateTime#
    功能：Nothing

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private new List<PopupWindowControl.CC_Button> _ccButtonList = new List<PopupWindowControl.CC_Button>();

    public InputField TitleColorStr;
    public InputField TitleTextColorStr;
    public InputField TitleText;
    
    public InputField BodyColorStr;
    public InputField BodyTextColorStr;
    public InputField BodyText;

    public Dropdown ButtonDropdwon;

    public InputField ButtonColorStr;
    public InputField ButtonTextColorStr;
    public InputField ButtonText;

    private void Start()
    {
        TitleColorStr.text = "#FF8080";
        TitleTextColorStr.text = "#FFFFFF";
        TitleText.text = "标题示例";
        
        BodyColorStr.text = "#FF8080";
        BodyTextColorStr.text = "#FFFFFF";
        BodyText.text = "内容示例";
        
        ButtonColorStr.text = "#FF8080";
        ButtonTextColorStr.text = "#FFFFFF";
        ButtonText.text = "OK";
    }

    private int Num = 0;
    public void NumberButtons(int i)
    {
        Num = i;
    }
    

    public void Demo()
    {
        Color _titleColor;
        ColorUtility.TryParseHtmlString(TitleColorStr.text, out _titleColor);
        Color _titleTextColor;
        ColorUtility.TryParseHtmlString(TitleTextColorStr.text, out _titleTextColor);
        
        Color _bodyColor;
        ColorUtility.TryParseHtmlString(BodyColorStr.text, out _bodyColor);
        Color _bodyTextColor;
        ColorUtility.TryParseHtmlString(BodyTextColorStr.text, out _bodyTextColor);
        
        Color _ButtonColor;
        ColorUtility.TryParseHtmlString(ButtonColorStr.text, out _ButtonColor);
        Color _ButtonTextColor;
        ColorUtility.TryParseHtmlString(ButtonTextColorStr.text, out _ButtonTextColor);

        switch (Num)
        {
            case 0:
            {
                _ccButtonList = new List<PopupWindowControl.CC_Button>()
                {
                    new PopupWindowControl.CC_Button()
                    {
                        ButtonColor = _ButtonColor,
                        ButtonText = ButtonText.text,
                        ButtonTextColor = _ButtonTextColor
                    }
                };
            }
                break;
            case 1:
            {
                _ccButtonList = new List<PopupWindowControl.CC_Button>()
                {
                    new PopupWindowControl.CC_Button()
                    {
                        ButtonColor = _ButtonColor,
                        ButtonText = ButtonText.text,
                        ButtonTextColor = _ButtonTextColor
                    },new PopupWindowControl.CC_Button()
                    {
                        ButtonColor = _ButtonColor,
                        ButtonText = ButtonText.text,
                        ButtonTextColor = _ButtonTextColor
                    }
                };
            }
                break;
            case 2:
            {
                _ccButtonList = new List<PopupWindowControl.CC_Button>()
                {
                    new PopupWindowControl.CC_Button()
                    {
                        ButtonColor = _ButtonColor,
                        ButtonText = ButtonText.text,
                        ButtonTextColor = _ButtonTextColor
                    },new PopupWindowControl.CC_Button()
                    {
                        ButtonColor = _ButtonColor,
                        ButtonText = ButtonText.text,
                        ButtonTextColor = _ButtonTextColor
                    },new PopupWindowControl.CC_Button()
                    {
                        ButtonColor = _ButtonColor,
                        ButtonText = ButtonText.text,
                        ButtonTextColor = _ButtonTextColor
                    }
                };
            }
                break;
        }


        PopupWindowControl.Instance.AccordingToPopupWindow(new PopupWindowControl.CC_PopupWindow()
        {
            Title = new PopupWindowControl.CC_Title()
            {
                TitleColor = _titleColor,
                TitleText = TitleText.text,
                TitleTextColor = _titleTextColor
            },
            Body = new PopupWindowControl.CC_Body()
            {
                BodyColor = _bodyColor,
                BodyText = BodyText.text,
                BodyTextColor = _bodyTextColor
            },
            Buttons = _ccButtonList
        });
    }
}
