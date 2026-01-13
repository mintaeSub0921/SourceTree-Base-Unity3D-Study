using UnityEngine;

public class Bullet : MonoBehaviour
{
    public UnityPoolManager poolManager;

    private void Awake()
    {
        poolManager = FindFirstObjectByType<UnityPoolManager>();
    }

    private void OnEnable()
    {
        Invoke("ReturnPool", 10f);

    }

    void ReturnPool()
    {
        poolManager.pool.Release(gameObject);
    }
}
