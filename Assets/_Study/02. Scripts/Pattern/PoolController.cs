using UnityEngine;

public class PoolController : MonoBehaviour
{
    public UnityPoolManager poolManager;
    public Transform shootPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
         {
            GameObject bullet = poolManager.pool.Get();

            bullet.transform.position = shootPoint.position;
        }
    }
}
