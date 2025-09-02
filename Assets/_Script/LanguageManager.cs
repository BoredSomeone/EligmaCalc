using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public List<TMP_FontAsset> fonts;
    public UnityEvent changeEvent;
    public TextSizeFitter tsf;

    public Calc calc;
    public void Start()
    {
        SetStartLanguage();
    }

    void SetStartLanguage()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
            ChangeLanguage(0);
        else if (Application.systemLanguage == SystemLanguage.Japanese)
            ChangeLanguage(1);
    }
    public void ChangeLanguage(int langCode)
    {
        lc.nowLanguage = (lc.Language)langCode;
        calc.SetInt();
        changeEvent.Invoke();
        tsf.DelayedUpdateTextSize();
    }

    public TMP_FontAsset GetFont()
    {
        return fonts[(int)lc.nowLanguage];
    }
}
