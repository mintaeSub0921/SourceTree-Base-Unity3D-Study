using System;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    public Func<int, int, int> myFunc;
    public Func<string, string, bool> myFunc2;

    private void Start()
    {
        myFunc = AddMethod;

        int result = myFunc(5, 2);
        Debug.Log(result);

        myFunc2 = CompareText;
        bool result2 = myFunc2("Hello", "Unity");
        Debug.Log(result2);
    }

    public int AddMethod(int a, int b)
    {
        return a + b;
    }

    public bool CompareText(string a, string b)
    {
        if (a == b)
            return true;

        return false;
    }

}
