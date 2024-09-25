using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Calc : MonoBehaviour
{
    public Dropdown ddlanguage;
    public InputField ifStartStar;   //시작 성급
    public InputField ifEndStar;     //목표 성급

    public InputField ifStartNum;    //지금 몇개나 있음?

    public InputField ifStartPrice;  //시작 구매 가격
    public InputField ifStartPriceNum;//현재 가격으로 몇개나 삼?

    public Text resultText;

    int[] UpTable = { 0, 30, 80, 100, 120, 120, 180 };
    public int needNum = 0;

    public int startStar;
    public int startNum;
    public int endStar;
    public int startPrice;
    public int startPriceNum;

    public UnityEvent changeEvent;


    private void Start()
    {

    }

    public void SetInt()
    {
        try
        {
            startStar = int.Parse(ifStartStar.text);
            endStar = int.Parse(ifEndStar.text);
            startNum = int.Parse(ifStartNum.text);
            startPrice = int.Parse(ifStartPrice.text);
            startPriceNum = int.Parse(ifStartPriceNum.text);

            string t = "";
            if (startStar < 1 || startStar > 7)
            {
                t += lc.Text("시성확") + " (1 ~ 7)\n";
            }
            if (endStar < startStar || startStar > 7)
            {
                t += lc.Text("시성확") + " (" + startNum + " ~ 7)\n";
            }
            if(startPrice > 20)
            {
                t += lc.Text("현가확") + "\n";
            }
            if(startPriceNum < 0 || startPriceNum > 20)
            {
                t += lc.Text("현구확") + "\n";
            }

            if (string.IsNullOrEmpty(t))
                StartCalc();
            else
            {
                if (t[^1] == '\n')
                    t = t.TrimEnd();
                resultText.text = t;
            }
        }
        catch (System.Exception e)
        {
            resultText.text = lc.Text("정값임?");
            Debug.Log(e);
        }
    }

    void StartCalc()
    {
        Debug.Log("StartCalc");
        needNum = 0;
        NeedCalc();
        resultText.text = lc.Text("필요엘레프") + needNum + "\n" + lc.Text("필요엘리그마") + CalcEligma();
    }

    void NeedCalc()
    {
        for (int i = startStar; i < endStar; ++i)
        {
            needNum += UpTable[i];
        }
        needNum -= startNum;

        if(needNum < 0)
            needNum = 0;
    }

    int CalcEligma()
    {
        int result = 0;

        if (startPriceNum > 0)
        {
            if (needNum > startPriceNum)
            {
                needNum -= startPriceNum;
            }
            else
            {
                return result += startPrice * needNum;
            }
        }

        for (int price = startPrice; price < 5; ++price)
        {
            if (needNum  > 19)
            {
                result += price * 20;
                needNum -= 20;
            }
            else
            {
                result += price * needNum;
                needNum = 0;
                break;
            }
        }

        if (needNum > 0)
        {
            result += needNum * 5;
        }

        return result;
    }

    public void ChangeLanguage()
    {
        lc.nowLanguage = (lc.Language)ddlanguage.value;
        SetInt();
        changeEvent.Invoke();
    }
}