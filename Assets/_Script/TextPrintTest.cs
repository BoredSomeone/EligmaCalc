using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextPrintTest : MonoBehaviour
{
    public TMP_Text t;
    void Start()
    {
        t.text = "";
        List<char> allChar = new();

        foreach(var s in lc.StringDic)
        {
            var v = s.Value;
            for (int i = 0; i < v.Length; ++i)
            {
                for (int j = 0; j < v[i].Length; ++j)
                {
                    allChar.Add(v[i][j]);
                }
            }
        }

        allChar = allChar.Distinct().ToList();
        allChar.Sort();
        foreach (var c in allChar)
        {
            t.text += c;
        }
        Debug.Log(t.text);
    }
}
