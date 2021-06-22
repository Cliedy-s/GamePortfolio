using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text score;
    public float coroutineYieldTime = 0.08f;
    // unity functions
    void Start()
    {
        // score = GetComponent<Text>();
        // 텍스트 변경
        // score.text = "안녕하세요";
        // 일부분 색상 변경
        score.text = "아이템 속성: <color=#0000ff>얼음</color>";
        
        // 코루틴
        StartCoroutine(DisplayOneLetter("코루틴을 시작합니다"));
    }
    void Update()
    {
        
    }
    // custom functions
    IEnumerator DisplayOneLetter(string str){
        char [] array = str.ToCharArray();
        for (int i = 0; i < array.Length; i++)
        {
            yield return new WaitForSeconds(coroutineYieldTime);
            if (array[i] == ' ')
                score.text += array[i++];
            score.text += array[i];
        }

    }
}
