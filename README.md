# 简单的Unity全局弹窗方式

Unity版本2020.3.27f  

[WebGL示例](https://cr-zhichen.github.io/SimplePopupWindow/)

## 资源使用方式

1. 直接克隆该项目
2. 导入[unitypackage包](https://github.com/cr-zhichen/SimplePopupWindow/releases)

## 使用方法

### 显示弹窗

``` c#

PopupWindowControl.Instance.AccordingToPopupWindow(new PopupWindowControl.CC_PopupWindow()
        {
            Title = new PopupWindowControl.CC_Title()
            {
                TitleColor = new Color(1.0f,0.5f,0.5f,1.0f),
                TitleText = "示例标题",
                TitleTextColor = Color.white
            },
            Body = new PopupWindowControl.CC_Body()
            {
                BodyColor = new Color(1.0f,0.5f,0.5f,1.0f),
                BodyText = "示例内容",
                BodyTextColor = Color.white
            },
            Buttons = new List<PopupWindowControl.CC_Button>()
            {
                new PopupWindowControl.CC_Button()
                {
                    ButtonColor =new Color(1.0f,0.5f,0.5f,1.0f),
                    ButtonText = "确定",
                    ButtonTextColor = Color.white,
                    CallBack = (g =>
                    {
                        Debug.Log("按下按钮");
                        PopupWindowControl.Instance.ClosePopupWindow(g);
                    })
                },
                new PopupWindowControl.CC_Button()
                {
                    ButtonColor = Color.gray,
                    ButtonText = "取消",
                    ButtonTextColor = Color.white,
                    CallBack = (g =>
                    {
                        Debug.Log("按下按钮");
                        PopupWindowControl.Instance.ClosePopupWindow(g);
                    })
                }
            }
        });
        
```

### 关闭弹窗

```c#

PopupWindowControl.Instance.ClosePopupWindow(g);

```

## 演示视频

<video src="https://kai.chengrui.xyz/Video/20220327_111353.mp4" width=auto height="600px" controls="controls"></video>