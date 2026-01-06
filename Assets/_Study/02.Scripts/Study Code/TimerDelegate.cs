using System.Collections;
using UnityEngine;

public class TimerDelegate : MonoBehaviour
{
    public delegate void TimerStart();
    public TimerStart onTimerStart; // 타이머 시작 이벤트

    public delegate void TimerEnd();
    public TimerEnd onTimerEnd; // 타이머 종료 이벤트

    public delegate void TimerStop();
    public TimerStop onTimerStop; // 타이머 멈춤 이벤트

    public KeyCode keyCode = KeyCode.Space; // 타이머 멈추는 키

    public float timer = 5f;
    public bool isTimer = true;

    private void Awake()
    {
        onTimerStart += StartEvent;
        onTimerStop += StopEvent;
        onTimerEnd += EndEvent;
    }

    private void Start()
    {
        onTimerStart?.Invoke();

        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (isTimer)
        {
            Debug.Log($"현재 {timer}초 남았습니다.");
            yield return new WaitForSeconds(1f);
            timer--;

            if (timer <= 0f)
            {
                isTimer = false;
                onTimerEnd?.Invoke(); // 타이머 종료

            }
        }
    }

    private void StartEvent()
    {
        Debug.Log("폭탄이 설치되었습니다.");
    }

    private void StopEvent()
    {
        isTimer = false;
        StopAllCoroutines();
        Debug.Log("폭탄이 멈췄습니다.");
    }

    private void EndEvent()
    {
        Debug.Log("폭탄이 터졌습니다.");

    }


}
