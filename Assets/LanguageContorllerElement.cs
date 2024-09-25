using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageContorllerElement : MonoBehaviour
{
    public string ID;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<Calc>().changeEvent.AddListener(TextChange);
        TextChange();
    }

    public void TextChange()
    {
        gameObject.GetComponent<Text>().text = lc.Text(ID);
    }
}
