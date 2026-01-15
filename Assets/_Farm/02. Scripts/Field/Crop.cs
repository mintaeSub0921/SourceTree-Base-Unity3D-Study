using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public enum CropState { Level1, Level2, Level3 }
    public CropState cropState;

    private WeatherType currentWeather;

    [SerializeField] private CropData data;

    private float growthTime;
    

    private void Awake()
    {
        growthTime = data.growthTime;

    }

    private void OnEnable()
    {
        
        SetState(CropState.Level1);
        WeatherSystem.weatherChanged += SetGrowth;

        StartCoroutine(GrowthRoutine());

    }

    private void OnDisable()
    {
        WeatherSystem.weatherChanged -= SetGrowth;
    }

    IEnumerator GrowthRoutine()
    {
        yield return new WaitForSeconds(growthTime);
        SetState(CropState.Level2);

        yield return new WaitForSeconds(growthTime);
        SetState(CropState.Level3);

       
    }

    private void SetState(CropState newState)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == (int)newState);

        cropState = newState;
    }

    private void SetGrowth(WeatherType weatherType)
    {
        if (currentWeather != weatherType)
        {

            switch (weatherType)
            {
                case WeatherType.Sun:
                    growthTime *= 1f;
                    break;
                case WeatherType.Rain:
                    growthTime *= 1.3f;
                    break;
                case WeatherType.Snow:
                    growthTime *= 2f;
                    break;
            }

            if (growthTime > 10)
                growthTime = 10;

            currentWeather = weatherType;
            
        }
    }

    public void SetCropData(out GameObject fruit, out int maxCount)
    {
        fruit = data.fruit;
        maxCount = data.maxFruitCount;
    }
}
