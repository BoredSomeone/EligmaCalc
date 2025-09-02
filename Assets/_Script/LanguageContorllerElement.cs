using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageContorllerElement : MonoBehaviour
{
    public string ID;

    TMP_Text text;
    LanguageManager lm;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
        lm = GameObject.Find("GameManager").GetComponent<LanguageManager>();
        lm.changeEvent.AddListener(TextChange);
        TextChange();
    }

    public void TextChange()
    {
        text.text = lc.Text(ID).Replace(' ', '\u00A0');
        text.font = lm.GetFont();
    }
}
