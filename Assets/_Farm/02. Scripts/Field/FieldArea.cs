using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FieldArea : MonoBehaviour, ITriggerEvent
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Vector2Int fieldSize = new Vector2Int(10, 10);

    private float tileSize = 2f;

    private Camera mainCamera;
    private GameObject[,] tileArray;

    private IField field;
    private FieldSeed seed;
    private FieldHarvest harvest;

    [SerializeField] private GameObject[] cropPrefabs;

    [SerializeField] private GameObject fieldUI;
    [SerializeField] private GameObject actionUI; // 어떤 행동을 할지 선택하는 UI
    [SerializeField] private GameObject cropUI; // 심을 작물 선택하는 UI

    [SerializeField] private Button seedButton; //
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] selectCropButtons;
    [SerializeField] private Button exitButton;

    private bool isInteraction;

    void Start()
    {
        Init();
        CreateField();
    }

    void Init()
    {

        tileArray = new GameObject[fieldSize.x, fieldSize.y];

        seed = new FieldSeed();
        harvest = new FieldHarvest();

        seedButton.onClick.AddListener(() =>
        {
            field = seed; // 현재 행동을 작물 심기로 설정
            actionUI.SetActive(false); // 행동 UI 끄기
            cropUI.SetActive(true); // 작물 선택 UI 켜기
        });

        harvestButton.onClick.AddListener(() =>
        {
            field = harvest;

        });


        for (int i = 0; i < selectCropButtons.Length; i++)
        {
            int j = i;
            selectCropButtons[i].onClick.AddListener(() => seed.selectCrop = cropPrefabs[j]);
        }

        exitButton.onClick.AddListener(() =>
        {
            actionUI.SetActive(true);
            cropUI.SetActive(false);
            seed.selectCrop = null;

        });

        

    }

    public void InteractionEnter()
    {
        isInteraction = true;
        CameraManager.OnChangedCamera("Player", "Field");

        fieldUI.SetActive(true);

        StartCoroutine(FiledRoutine());
    }


    public void InteractionExit()
    {
        isInteraction = false;
        fieldUI.SetActive(false);
        CameraManager.OnChangedCamera("Field", "Player");
    }

    void CreateField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2f;
        float offsetY = (fieldSize.y - 1) * tileSize / 2f;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float PosZ = transform.position.z + j * tileSize - offsetY;

                GameObject tileObj = Instantiate(tilePrefab, transform); // transform 스케일 1

                tileObj.layer = 15; // field Layer를 15로 설정, 레이캐스트로 쏘기 위함

                tileObj.name = $"Tile_{i}_{j}";
                tileObj.transform.position = new Vector3(posX, 0, PosZ);
                tileArray[i, j] = tileObj;

                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j);

            }
        }

    }

    IEnumerator FiledRoutine()
    {
        while (isInteraction)
        {
            field?.FieldAction();

            yield return null;
        }
    }

}