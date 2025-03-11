using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public Dropdown ddlanguage;
    public UnityEvent changeEvent;

    public Calc calc;
    public void Start()
    {
        SetStartLanguage();
    }

    void SetStartLanguage()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
            ddlanguage.value = 0;
        else if (Application.systemLanguage == SystemLanguage.Japanese)
            ddlanguage.value = 1;
    }
    public void ChangeLanguage()
    {
        lc.nowLanguage = (lc.Language)ddlanguage.value;
        calc.SetInt();
        changeEvent.Invoke();
    }
}
