using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TelText : MonoBehaviour
{
    TMP_Text tmP_Text;
    //private string label01 = "<size=60%>���ѽ</size><sprite=0>��<mark>������������</mark><sprite=1><u>�ٺ�ʮ�ּ��ѵ�<sup>3</sup></u><sprite=2><sprite=3><sprite=4><sprite=5>" +
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
        //ǿ��ˢ��
        tmP_Text.ForceMeshUpdate();

        int characterSumCount = tmP_Text.textInfo.characterCount;
        Debug.Log("char = " + characterSumCount);
        int counter = 0;
        int visibleCount = 0;

        while (true) {
            //������31���ַ�����31ģһ�¾�Ϊ��0�ˣ�����31���ַ�ֻ��ģ30�£������ģ����Ҫ��Ӹ�1����Ϊ0��31����ģ��ͬһ��ֵ
            visibleCount = counter % (characterSumCount+1);
            tmP_Text.maxVisibleCharacters = visibleCount;

            counter += 1;

            yield return new WaitForSeconds(0.25f);
        }
    }
}