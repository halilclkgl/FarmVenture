using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCotroller : MonoBehaviour
{
    public Transform sunTransform;
    public Light sunLight;
    public float dayLength = 60f;
    public TMP_Text timeText;

    private float[] rotationTimes = {
        6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 17f, 18f, 19f,
        20f, 21f, 22f, 23f, 0f, 1f, 2f, 3f, 4f, 5f
    };

    private float[] rotationValues = {
        40f, 45f, 50f, 55f, 60f, 65f, 70f, 75f, 80f, 95f, 100f, 105f,
        110f, 115f, 190f, 190f, 195f, 200f, 210f, 215f, 220f, 225f, 230f, 235f
    };

    private int currentRotationIndex = 0;
    public float currentTime = 6f;
    public float currentMinute = 0f;
    void Start()
    {
        // Ýlk ýþýk rotasyonunu ayarla
        UpdateLightRotation();
    }

    void Update()
    {
        // Zamaný güncelle
        currentMinute += Time.deltaTime;

        // Bir f süresi geçtiðinde saat ve dakikayý güncelle
        if (currentMinute >= 1f)
        {
            currentMinute = 0f;

            // Dakikayý ve saati güncelle
            currentTime += 1f / dayLength;
            if (currentTime >= 24f)
            {
                currentTime = 0f;
            }

            // Saati ve ýþýk rotasyonunu güncelle
            UpdateTime();
            UpdateLightRotation();
        }
    }
    public void SetTime(int hour, int minute)
    {
        // Saat ve dakikayý güncelle
        currentTime = hour + (minute / 60f);

        // Iþýk rotasyonunu güncelle
        currentRotationIndex = hour - 6;
        if (currentRotationIndex < 0)
        {
            currentRotationIndex += rotationTimes.Length;
        }

        // Saat metnini güncelle
        timeText.text = hour.ToString("00") + ":" + minute.ToString("00");
    }

    void UpdateLightRotation()
    {
        // Iþýk rotasyonunu güncelle
        float rotationValue = rotationValues[currentRotationIndex];
        sunLight.transform.rotation = Quaternion.Euler(rotationValue, 0f, 0f);
    }

    void UpdateTime()
    {
        // Saati ve dakikayý güncelle
        int hour = Mathf.FloorToInt(currentTime);
        int minute = Mathf.FloorToInt((currentTime - hour) * 60f);

        // Saat metnini güncelle
        timeText.text = hour.ToString("00") + ":" + minute.ToString("00");

        // Iþýk rotasyonunu güncelle
        currentRotationIndex = hour - 6;
        if (currentRotationIndex < 0)
        {
            currentRotationIndex += rotationTimes.Length;
        }
    }
}
