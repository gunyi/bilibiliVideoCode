using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TelText : MonoBehaviour
{
    TMP_Text tmP_Text;
    //private string label01 = "<size=60%>你好呀</size><sprite=0>，<mark>哈哈哈哈哈哈</mark><sprite=1><u>嘿嘿十分艰难的<sup>3</sup></u><sprite=2><sprite=3><sprite=4><sprite=5>" +
        //"<sprite=6><sprite=7><sprite index=8><sprite=9><link>666</link>";

    private void Awake()
    {
        tmP_Text = this.GetComponent<TMP_Text>();
        //tmP_Text.text = label01;
        if (tmP_Text == null) {
            Debug.Log("null");
        }
    }

    IEnumerator Start()
    {
        //强制刷新
        tmP_Text.ForceMeshUpdate();

        int characterSumCount = tmP_Text.textInfo.characterCount;
        Debug.Log("char = " + characterSumCount);
        int counter = 0;
        int visibleCount = 0;

        while (true) {
            //比如有31个字符，到31模一下就为了0了，所以31个字符只能模30下，如果想模够就要多加个1，因为0和31都是模的同一个值
            visibleCount = counter % (characterSumCount+1);
            tmP_Text.maxVisibleCharacters = visibleCount;

            counter += 1;

            yield return new WaitForSeconds(0.25f);
        }
    }
}