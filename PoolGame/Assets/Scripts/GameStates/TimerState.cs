using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerState : MonoBehaviour
{
    // 게임오버 메세지 객체 //
    public GameObject messageCanv;
    // 현재 타이머의 시간을 담기 위한 변수 // 
    public Text text;
    public int time = 180;
    public int hour = 0;
    public int minute = 0;
    public int seconds = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(startTimer());

        // 만약 게임오버 메세지 프리펩이 널값이 아니라면 // 
        if (messageCanv != null)
        {
            // 게임오버 메세지를 비활성화 함 //
            messageCanv.gameObject.SetActive(false);
            messageCanv.gameObject.GetComponent<Canvas>().enabled = false;
        }
    }

    // 코틀린 가동 => 시간을 1초 마다 줄이기 //
    IEnumerator startTimer()
    {
        // 타이머 시간이 0이 될때까지 반복
        while (time >= 0)
        {
            // 숫자 시간에서 분 추출 알고리즘 // 
            minute = time / 60;
            // 숫자 시간에서 초 추출 알고리즘 // 
            seconds = time % 60;
            // 시간값 감소 // 
            time -= 1;
            // 텍스트 UI에 시간 서식 표현 // 
            text.text = minute + ":" + string.Format("{0:D2}", seconds);
            // 별 관리 루틴 //
            if( minute < 2)
            {
                GameManager.instance.stars[2].sprite = GameManager.instance.greyedStar; 
            }
            if( minute < 1)
            {
                GameManager.instance.stars[1].sprite = GameManager.instance.greyedStar;
            }
            if( minute == 0 && seconds < 30)
            {
                GameManager.instance.stars[0].sprite = GameManager.instance.greyedStar;
            }
            // 1초 딜레이 거는 코드 //
            yield return new WaitForSeconds(1);
        }
        // 만약 게임오버 메세지 프리펩이 널값이 아니라면 // 
        if (messageCanv != null)
        {
            // 게임오버 메세지를 활성화 함 //
            messageCanv.gameObject.SetActive(true);
            messageCanv.gameObject.GetComponent<Canvas>().enabled = true;
            // 게임 정지 //
            Time.timeScale = 0;
        }
    }
}