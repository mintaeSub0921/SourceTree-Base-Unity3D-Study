using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class StudyTask : MonoBehaviour
{
    async void Start()
    {
        Debug.Log("Main Thread 실행");
        await Task.Run(SubThread); // 비동기 방식

        //t.Join();   
        //Task.Wait();  동기 방식

        Debug.Log("Main Thread 종료");
    }

    void SubThread()
    {
        Debug.Log("Sub Thread 실행");
        Thread.Sleep(3000);

        Debug.Log("Sub Thread 종료");
    }
}
