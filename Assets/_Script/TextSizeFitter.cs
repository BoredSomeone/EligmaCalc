using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextSizeFitter : MonoBehaviour
{
    public TMP_Text[] Texts;

    int preScreenWidth, preScreenHeight;

    private void Start()
    {
        FontSizeFit();
        preScreenWidth = Screen.width;
        preScreenHeight = Screen.height;
    }

    private void Update()
    {
        if (preScreenWidth != Screen.width || preScreenHeight != Screen.height)
        {
            StartCoroutine(FontSizeFitter());
            preScreenWidth = Screen.width;
            preScreenHeight = Screen.height;
        }
    }

    void FontSizeFit()
    {
        for (int i = 0; i < Texts.Length; i++)
        {
            Texts[i].enableAutoSizing = true;
        }

        float minSize = Texts.Min(t => t.fontSize);

        for (int i = 0; i < Texts.Length; i++)
        {
            Texts[i].enableAutoSizing = false;
            Texts[i].fontSize = minSize;
        }
    }

    IEnumerator FontSizeFitter()
    {
        for (int i = 0; i < Texts.Length; i++)
        {
            Texts[i].enableAutoSizing = true;
        }

        yield return new WaitForEndOfFrame();
        float minSize = Texts.Min(t => t.fontSize);

        for (int i = 0; i < Texts.Length; i++)
        {
            Texts[i].enableAutoSizing = false;
            Texts[i].fontSize = minSize;
        }
    }
}
