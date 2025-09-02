using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioGroup : MonoBehaviour
{
    [SerializeField]
    int _radioInt;

    public Calc calc;
    public int radioInt
    {
        get { return _radioInt; }
    }

    public void ButtonPush(int value)
    {
        _radioInt = value;
        calc.SetInt();
    }
}
