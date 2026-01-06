using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    public UnityEvent uEvent;


    private void Start()
    {
        //uEvent += MethodA;

        uEvent.AddListener(MethodA);
        uEvent.RemoveListener(MethodA);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            uEvent?.Invoke();
        }
    }

    void MethodA()
    {

    }
}

