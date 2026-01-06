using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudyUnityAction : MonoBehaviour
{
    public Button button;

    public static event UnityAction buttonAction;

    private void Start()
    {
        buttonAction += MethodA;
        buttonAction += ClearScore;
        buttonAction += ResetPlayerPosition;

        button.onClick.AddListener(buttonAction);

    }

    void MethodA()
    {
        Debug.Log("Method A");

    }
    
    void ClearScore()
    {
        Debug.Log("점수 초기화");

    }

    void ResetPlayerPosition()
    {
        Debug.Log("플레이어 위치 초기화");
    }

}


