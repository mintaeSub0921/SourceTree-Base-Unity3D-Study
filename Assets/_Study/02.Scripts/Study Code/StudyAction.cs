using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    public event Action myAction;

    public event Action<int> myAction2;

    private void Start()
    {
        myAction += Method;
        myAction += () => Debug.Log("Hello");
        myAction?.Invoke();

        myAction2 += MethodA;
        myAction2 += (n) => Debug.Log($"전달받은 매개변수 값은 {n}입니다.");
        myAction2?.Invoke(10);

    }

    private void Method()
    {

    }

    private void MethodA(int a)
    {

    }

}
