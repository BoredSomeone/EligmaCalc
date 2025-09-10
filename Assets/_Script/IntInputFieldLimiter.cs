using TMPro;
using UnityEngine;

public class IntInputFieldLimiter : MonoBehaviour
{
    public Calc calc;

    int _myValue = 0;

    public int value
    {
        get { return _myValue; }
    }
    public void Limit(TMP_InputField field)
    {
        if (int.TryParse(field.text, out _myValue))
            _myValue = Mathf.Clamp(_myValue, 0, int.MaxValue);
        else
            _myValue = field.text.StartsWith(' ') ? 0 : int.MaxValue;

        field.text = value.ToString();
        field.textComponent.rectTransform.anchoredPosition = Vector2.zero;

        calc.SetInt();
    }
}
