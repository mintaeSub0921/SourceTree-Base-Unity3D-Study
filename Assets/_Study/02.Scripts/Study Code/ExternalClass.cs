using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    private void Start()
    {
        StudyUnityAction.buttonAction += MethodB;
    }

    void MethodB()
    {
        Debug.Log("Method B");
    }


}
