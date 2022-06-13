using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VertexColorCyclerMy : MonoBehaviour
{
    TMP_Text tMP_Text;

    private void Awake()
    {
        tMP_Text = GetComponent<TMP_Text>();            
    }

    private void Start()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor() {
        tMP_Text.ForceMeshUpdate();

        TMP_TextInfo tMP_TextInfo = tMP_Text.textInfo;

        int characterCount = tMP_TextInfo.characterCount;
        int currentCharacter = 0;
        Color32 c0 = tMP_Text.color;

        while (true) {

            if (characterCount == 0)
            {
                yield return new WaitForSeconds(0.25f);
                continue;
            }

            int materialIndex = tMP_TextInfo.characterInfo[currentCharacter].materialReferenceIndex;
            int vertexIndex = tMP_TextInfo.characterInfo[currentCharacter].vertexIndex;
            Color32[] color32s = tMP_TextInfo.meshInfo[materialIndex].colors32;

            if (tMP_TextInfo.characterInfo[currentCharacter].isVisible) {
                c0 = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                
                color32s[vertexIndex + 0] = c0;
                color32s[vertexIndex + 1] = c0;
                color32s[vertexIndex + 2] = c0;
                color32s[vertexIndex + 3] = c0;

                tMP_Text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }

            currentCharacter = (currentCharacter+1) % characterCount;

            yield return new WaitForSeconds(0.05f);

        }

    }
}
