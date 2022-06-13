using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatControllerMy : MonoBehaviour
{
    public TMP_InputField tMP_InputField;
    public TMP_Text tMP_OutPutField;
    public Scrollbar scrollbar;

    private void OnEnable()
    {
        tMP_InputField.onSubmit.AddListener(AddToOutPutField);
    }

    private void OnDisable()
    {
        tMP_InputField.onSubmit.RemoveListener(AddToOutPutField);
    }

    public void AddToOutPutField(string newText) {
        tMP_InputField.text = string.Empty;

        var nowTime = System.DateTime.Now;
        string formatedText = "[<#FFFF80>"+ nowTime.Hour.ToString("d2") +":"+nowTime.Minute.ToString("d2")+":"+nowTime.Second.ToString("d2")+ "</color>] " + newText;

        if (tMP_OutPutField != null) {
            if (tMP_OutPutField.text == string.Empty)
            {
                tMP_OutPutField.text = formatedText;
            }
            else {
                tMP_OutPutField.text += "\n" + formatedText;
            }
        }

        //每次enter后inputfield被设置成未激活状态，不能输入，这句可以重新激活，enter后可以直接输入
        tMP_InputField.ActivateInputField();
        
        //滑动按钮滑倒最底下，因为新消息在最底下
        scrollbar.value = 0;
    }
}
