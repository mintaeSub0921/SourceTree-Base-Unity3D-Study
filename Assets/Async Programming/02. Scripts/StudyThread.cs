using UnityEngine;
using System.Threading;

public class StudyThread : MonoBehaviour
{
    private void Start()
    {
        Thread t = new Thread(SubThread);
        t.IsBackground = true;

        t.Start();

        t.Join(); // Thread가 완료될 때까지 대기 -> 동기

        Debug.Log("Main Thread 종료");
    }

    private void SubThread()
    {
        Debug.Log("서브쓰레드 실행");
        Thread.Sleep(2000); // 2초 멈춤

        Debug.Log("Sub Thread");
    }
}
