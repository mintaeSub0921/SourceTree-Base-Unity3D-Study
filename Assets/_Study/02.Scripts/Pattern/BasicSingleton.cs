using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicSingleton : MonoBehaviour
{
    //public static BasicSingleton Instance {  get; private set; }
    private static BasicSingleton instance;
    public static BasicSingleton Instance
    {
        //get => instance;

        get
        {
            if (instance == null)
            {
                var obj = FindFirstObjectByType<BasicSingleton>();

                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject("Basic Singleton");
                    newObj.AddComponent<BasicSingleton>();

                    instance = newObj.GetComponent<BasicSingleton>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this; // 싱글턴 인스턴스로 할당
            DontDestroyOnLoad(gameObject); // 씬 전환 이후에도 파괴되지 않게 하는 기능
        }
        else
            Destroy(gameObject);
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(1);
    }


}
