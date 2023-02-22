using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WEATHERSTATE
{
    SUNNY,
    SNOW
}

public class WeatherSystem : MonoBehaviour
{
    // snow effect object
    [SerializeField]
    GameObject snowParticle;   
    
    // global 2d light
    private UnityEngine.Rendering.Universal.Light2D sunLight;

    void Start()
    {
        sunLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        // sun change timer
        SunState();
        // weather change timer
        WeatherCheck();

        // whather change
        if (GameManager.Instance.weatherState == WEATHERSTATE.SUNNY)
        {
            snowParticle.SetActive(false);
        }
        else
        {
            snowParticle.SetActive(true);
        }
    }

    private static void WeatherCheck()
    {
        GameManager.Instance.weatherTime += Time.deltaTime;

        if (GameManager.Instance.weatherTime > GameManager.Instance.maxWeatherTime)
        {
            if (GameManager.Instance.weatherState == WEATHERSTATE.SUNNY)
            {
                GameManager.Instance.weatherState = WEATHERSTATE.SNOW;
                GameManager.Instance.weatherTime = 0;
                GameManager.Instance.maxWeatherTime = Random.Range(10, 20);
            }
            else
            {
                GameManager.Instance.weatherState = WEATHERSTATE.SUNNY;
                GameManager.Instance.weatherTime = 0;
                GameManager.Instance.maxWeatherTime = Random.Range(10, 20);
            }
        }
    }

    private void SunState()
    {
        if (GameManager.Instance.isSunrise)
            GameManager.Instance.dayTimer += Time.deltaTime / 10;
        else
            GameManager.Instance.dayTimer -= Time.deltaTime / 10;

        if (GameManager.Instance.dayTimer >= 1.0f)
            GameManager.Instance.isSunrise = false;
        if (GameManager.Instance.dayTimer < 0.3f)
            GameManager.Instance.isSunrise = true;

        sunLight.intensity = GameManager.Instance.dayTimer;
    }
}
