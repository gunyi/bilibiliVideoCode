using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    TMP_Text tmp_Text;
    // Start is called before the first frame update
    void Awake()
    {
        tmp_Text = GetComponent<TMP_Text>();
    }

    IEnumerator Start()
    {
        tmp_Text.ForceMeshUpdate();

        int totalCharacter = tmp_Text.textInfo.characterCount;
        int counter = 0;
        int visiableCount = 0;

        while (true) {
            visiableCount = counter % (totalCharacter + 1);
            tmp_Text.maxVisibleCharacters = visiableCount;

            counter += 1;

            yield return new WaitForSeconds(0.25f);
        }
    }

}
