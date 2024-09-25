using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class lc
{
    public enum Language
    {
        Korean,
        Japanese,
    }

    public static Language nowLanguage;
    public static Dictionary<string, string[]> StringDic = new()
    {
        {
            "t0",
            new string[]
            {
                "시작 ☆ (고유무기 2 = 6, 고유무기 3 = 7)",
                "既存 ☆ (固有武器 2 = 6, 固有武器 3 = 7)"
            }
        },
        {
            "t1",
            new string[]
            {
                "목표 ☆ (고유무기 2 = 6, 고유무기 3 = 7)",
                "目標 ☆ (固有武器 2 = 6, 固有武器 3 = 7)"
            }
        },
        {
            "t2",
            new string[]
            {
                "현재 보유 중인 엘레프",
                "現在持っている新名文字"
            }
        },
        {
            "t3",
            new string[]
            {
                "현재 엘레프의 가격",
                "現在の新名文字の値段"
            }
        },
        {
            "t4",
            new string[]
            {
                "현재 가격의 구매량",
                "現在の値段の購買量"
            }
        }
        ,
        {
            "시성확",
            new string[]
            {
                "시작 ☆을 확인해주세요.",
                "既存 ☆の確認をお願いします。"
            }
        },
        {
            "목성확",
            new string[]
            {
                "목표 ☆을 확인해주세요.",
                "目標 ☆の確認をお願いします。"
            }
        },
        {
            "현가확",
            new string[]
            {
                "현재 가격을 확인해 주세요.",
                "現在値段の確認をお願いします。"
            }
        },
        {
            "현구확",
            new string[]
            {
                "현재 가격에 구매한 엘레프 수를 확인해주세요.",
                "現在の値段に購入した新名文字の量の確認をお願いします。"
            }
        },
        {
            "정값임?",
            new string[]
            {
                "정확한 값을 입력해주세요.",
                "正しい数字の入力をお願いします。"
            }
        },
        {
            "필요엘레프",
            new string[]
            {
                "필요한 엘레프: ",
                "必要な新名文字の量："
            }
        },
        {
            "필요엘리그마",
            new string[]
            {
                "필요 엘리그마: ",
                "必要な新名のカケラ："
            }
        }

    };

    public static string Text(string id)
    {
        return StringDic[id][(int)nowLanguage];
    }
}
