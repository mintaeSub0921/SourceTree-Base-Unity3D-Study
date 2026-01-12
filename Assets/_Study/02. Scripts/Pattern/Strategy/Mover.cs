using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool isRun, isFly, isSwim;

    private void Update()
    {
        if (isRun)
        {
            Debug.Log("달리기");
        }

        if (isFly)
        {
            Debug.Log("날기");
        }

        if (isSwim)
        {
            Debug.Log("헤엄치기");
        }
    }
}
