using System.Net.Http.Headers;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StepperGroup : MonoBehaviour
{
    public int rangeMin;
    public int rangeMax;

    public Calc calc;

    public TMP_InputField text;
    [SerializeField]
    int _myVal = 0;

    public int value
    {
        get { return _myVal; }
    }

    public void ValueChange(int val)
    {
        var temp = _myVal + val;
        if (temp < rangeMin)
            temp = rangeMin;
        else if (temp > rangeMax)
            temp = rangeMax;
        _myVal = temp;

        ValueChanged();
    }

    public void FieldChange()
    {
        int temp = 0;
        if (string.IsNullOrEmpty(text.text))
            temp = rangeMin;

        if (int.TryParse(text.text, out temp))
            temp = Mathf.Clamp(temp, rangeMin, rangeMax);
        else
            temp = text.text.StartsWith('-') ? rangeMin : rangeMax;
        _myVal = temp;
        text.textComponent.rectTransform.anchoredPosition = Vector2.zero;
        ValueChanged();
    }

    void ValueChanged()
    {
        text.text = value.ToString();
        calc.SetInt();
    }
}
