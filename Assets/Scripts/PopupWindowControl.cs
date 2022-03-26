/*****************************************

    文件：PopupWindowControl.cs
    日期：#CreateTime#
    功能：控制弹窗

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindowControl : MonoBehaviour
{
    public static PopupWindowControl Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        
        if (canvas != null)
        {
            _canvas = Instantiate(canvas, this.transform);
        }
    }

    public Canvas canvas;
    public GameObject popupWindow;
    public GameObject button;

    public List<CC_PopupWindowData> popupWindowList=new List<CC_PopupWindowData>();

    private Canvas _canvas;

    public delegate void CallBack(GameObject g);

    /// <summary>
    /// 显示通知弹窗
    /// </summary>
    public GameObject AccordingToPopupWindow(CC_PopupWindow ccPopupWindow)
    {
        var _popupWindow = Instantiate(this.popupWindow, _canvas.transform).GetComponent<PopupWindow>();

        CC_PopupWindowData ccPopupWindowData = new CC_PopupWindowData();
        ccPopupWindowData.PopupWindow = _popupWindow.gameObject;
        
        
        

        _popupWindow.Bg.color = ccPopupWindow.BgColor;
        _popupWindow.TitleBg.color = ccPopupWindow.Title.TitleColor;
        _popupWindow.TitleText.text = ccPopupWindow.Title.TitleText;
        _popupWindow.TitleText.color = ccPopupWindow.Title.TitleTextColor;
        _popupWindow.BodyBG.color = ccPopupWindow.Body.BodyColor;
        _popupWindow.BodyText.text = ccPopupWindow.Body.BodyText;
        _popupWindow.BodyText.color = ccPopupWindow.Body.BodyTextColor;

        if (ccPopupWindow.Buttons.Count!=0)
        {
            var index = 0;
            foreach (var CcButton in ccPopupWindow.Buttons)
            {
                var i = index;
                var _button=Instantiate(button, _popupWindow.ButtonGroup.transform).GetComponent<Button>();

                _button.image.color = CcButton.ButtonColor;
                _button.text.text = CcButton.ButtonText;
                _button.text.color = CcButton.ButtonTextColor;
                StartCoroutine(_button.A(() =>
                {
                    CcButton.CallBack(_popupWindow.gameObject);
                }));
                ccPopupWindowData.Button.Add(_button);
                
                index++;
            }
        }
        
        popupWindowList.Add(ccPopupWindowData);

        return _popupWindow.gameObject;

    }

    /// <summary>
    /// 关闭通知弹窗
    /// </summary>
    public void ClosePopupWindow(GameObject g)
    {
        foreach (var PopupWindowData in popupWindowList)
        {
            if (PopupWindowData.PopupWindow==g)
            {
                Destroy(PopupWindowData.PopupWindow);
                popupWindowList.Remove(PopupWindowData);
                return;
            }
        }
    }
    
    /// <summary>
    /// 通知弹窗数据
    /// </summary>
    [System.Serializable]
    public class CC_PopupWindowData
    {
        /// <summary>
        /// 通知
        /// </summary>
        public GameObject PopupWindow;
        /// <summary>
        /// 按钮
        /// </summary>
        public List<Button> Button=new List<Button>();
    }
    
    /// <summary>
    /// 通知弹窗属性
    /// </summary>
    [System.Serializable]
    public class CC_PopupWindow
    {
        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color BgColor=Color.white;
        /// <summary>
        /// 标题
        /// </summary>
        public CC_Title Title=new CC_Title();
        /// <summary>
        /// 内容
        /// </summary>
        public CC_Body Body=new CC_Body();
        /// <summary>
        /// 生成按钮
        /// </summary>
        public List<CC_Button> Buttons=new List<CC_Button>()
        {
            new CC_Button()
            {
                CallBack = (g =>
                {
                    PopupWindowControl.Instance.ClosePopupWindow(g);
                })
            }
        };
    }
    /// <summary>
    /// 标题
    /// </summary>
    [System.Serializable]
    public class CC_Title
    {
        /// <summary>
        /// 标题颜色
        /// </summary>
        public Color TitleColor=new Color(1.0f,0.5f,0.5f,1.0f);
        /// <summary>
        /// 标题文字
        /// </summary>
        public string TitleText= "请输入标题";
        /// <summary>
        /// 标题文字颜色
        /// </summary>
        public Color TitleTextColor= Color.white;
    }
    /// <summary>
    /// 内容
    /// </summary>
    [System.Serializable]
    public class CC_Body
    {
        /// <summary>
        /// 内容背景颜色
        /// </summary>
        public Color BodyColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);

        /// <summary>
        /// 内容文字内容
        /// </summary>
        public string BodyText =
            "这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，这里是正文，";

        /// <summary>
        /// 内容文字颜色
        /// </summary>
        public Color BodyTextColor = Color.white;
    }

    /// <summary>
    /// 按钮
    /// </summary>
    [System.Serializable]
    public class CC_Button
    {
        /// <summary>
        /// 按钮背景颜色
        /// </summary>
        public Color ButtonColor = new Color(1.0f,0.5f,0.5f,1.0f);
        /// <summary>
        /// 按钮文字
        /// </summary>
        public string ButtonText = "确定";
        /// <summary>
        /// 按钮文字颜色
        /// </summary>
        public Color ButtonTextColor = Color.white;
        /// <summary>
        /// 按下回调
        /// </summary>
        public CallBack CallBack=new CallBack((g) =>
        {
            PopupWindowControl.Instance.ClosePopupWindow(g);
        });
    }
    
}
