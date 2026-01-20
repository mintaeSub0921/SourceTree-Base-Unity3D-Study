using Farm;
using UnityEngine;

public class GameManager : SingletonCore<GameManager>
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform spawnPoint;

    //[SerializeField] private PoolManager poolManager;
    //[SerializeField] private GameObject canvas;
    //[SerializeField] private UIManager ui;
    
    protected override void Awake()
    {
        base.Awake();

        int index = DataManager.Instance.SelectCharacterIndex;

        GameObject character = Instantiate(characterPrefabs[index], spawnPoint.position, Quaternion.identity);

        DataManager.Instance.Player = character;
    }

    private void Start()
    {
        
        CameraManager.onSetProperty?.Invoke(DataManager.Instance.Player.transform);
    }
}