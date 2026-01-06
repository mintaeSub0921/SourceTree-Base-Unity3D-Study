using System.Collections;
using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate myDelegate;

    private void Start()
    {
        //myDelegate = new MyDelegate(Method); // 예전 방식

        myDelegate = Method; // 표준방식

        myDelegate(); // 직접 실행 방법

        myDelegate.Invoke(); // 델리게이트를 실행하는 명확한 실행 방식

        myDelegate?.Invoke(); // 안전한 실행 방식

        // if (myDelegate != null) myDelegate가 null이 아니라면
        //     myDelegate.Invoke(); myDelegate를 호출한다
    }


    public void Method()
    {

    }
}
