using UnityEngine;

public class ExternalClassPattern : MonoBehaviour
{
    private void Start()
    {
        //SimpleSingleton.Instance.level = 1;
        //SimpleSingleton.Instance.playerName = "Player";
        //SimpleSingleton.Instance.LevelUp();

        BasicClass.Instance.LevelUp();

        BasicClass.Instance.level = 10;

    }
}
