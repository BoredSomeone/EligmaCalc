using System.Collections;
using UnityEngine;

public class ScreenRatioFitter : MonoBehaviour
{
    enum ScreenType
    {
        vertical,
        horizontal
    }

    [SerializeField] private RectTransform left;
    [SerializeField] private RectTransform right;

    private void Start()
    {
        StartCoroutine(RatioWatcher());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }


    private ScreenType getNowScreenType()
    {
        int x, y;

#if UNITY_EDITOR
        System.Type T = System.Type.GetType("UnityEditor.GameView, UnityEditor");
        System.Reflection.MethodInfo getSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        object res = getSizeOfMainGameView.Invoke(null, null);
        Vector2 v_res = (Vector2)res;
        
        x = (int)v_res.x;
        y = (int)v_res.y;
#else
        x = Screen.width;
        y = Screen.height;
#endif

        Debug.Log($"({x}, {y})");

        return x >= y ? ScreenType.horizontal : ScreenType.vertical;
    }

    IEnumerator RatioWatcher()
    {
        ScreenType? nowType = null;
        while (true)
        {
            var checkedType = getNowScreenType();
            if(nowType != checkedType)
            {
                nowType = checkedType;
                UpdateUI((ScreenType)nowType);
            }

            yield return null;
        }
    }

    private void UpdateUI(ScreenType nowType)
    {
        if (nowType == ScreenType.vertical)
        {
            left.anchorMin = new Vector2(0.01f, 0.39f);
            left.anchorMax = new Vector2(0.99f, 1);
            left.sizeDelta = new Vector2(0, 0);
            left.anchoredPosition = new Vector3(0, 10, 0);

            right.anchorMin = new Vector2(0.01f, 0.01f);
            right.anchorMax = new Vector2(0.99f, 0.39f);
            right.sizeDelta = new Vector2(0, 0);
            right.anchoredPosition = new Vector3(0, 0, 0);
        }
        else if (nowType == ScreenType.horizontal)
        {
            left.anchorMin = new Vector2(0.01f, 0.05f);
            left.anchorMax = new Vector2(0.5f, 1);
            left.sizeDelta = new Vector2(5, 0);
            left.anchoredPosition = new Vector3(0, 0, 0);

            right.anchorMin = new Vector2(0.5f, 0.05f);
            right.anchorMax = new Vector2(0.99f, 1);
            right.sizeDelta = new Vector2(0, 0);
            right.anchoredPosition = new Vector3(5, 0, 0);
        }
    }

#if UNITY_EDITOR
    public bool STOP;
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
            return;
        if (STOP)
            return;
        UpdateUI(getNowScreenType());

    }
#endif
}
