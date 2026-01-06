using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate myDelegate;

    public delegate void MyDelegate2(string s);
    public MyDelegate2 myDelegate2;

    public Button buttonUI;

    public List<int> intList = new List<int>();

    private void Start()
    {
        #region Button
        buttonUI.onClick.AddListener(ButtonEvent);

        buttonUI.onClick.AddListener(delegate
        {
            ButtonEvent();
            ButtonEvent2(10);
            
        });

        buttonUI.onClick.AddListener(() => ButtonEvent());
        #endregion

        #region Lambda
        myDelegate = () => Debug.Log("Hello Unity");
        myDelegate?.Invoke();

        //myDelegate += () =>
        //{
        //    Debug.Log("Hello Unity");
        //    Debug.Log("Hello C#");
        //};

        myDelegate2 = (s) => Debug.Log(s);
        myDelegate2("Hello C#");
        #endregion

        #region List
        for (int i = 0; i < 10; i++)
        {
            intList.RemoveAll(n => n % 2 != 0);
        }

        #endregion
    }

    public void ButtonEvent()
    {

    }

    public void ButtonEvent2(int number)
    {

    }

    
}
