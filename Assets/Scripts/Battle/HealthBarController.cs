using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthBarController : MonoBehaviour
{
    [Header("Health bar")]
    public Transform bar;
    public Transform entity;

    [SerializeField]
    private int currentValue;
    private int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = GameManager.Instance.playerHP;
        maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (entity != null)
        {
            transform.position = entity.position + Vector3.up * 1.5f;
        }
    }

    public void SetValue(int new_value)
    {
        currentValue = new_value;
        bar.localScale = new Vector3((float)((double)currentValue / (double)maxValue), 1.0f, 1.0f);

        // clamp the scale on the x axis to be zero minimum
        if (bar.localScale.x < 0)
        {
            bar.localScale = new Vector3(0.0f, 1.0f, 1.0f);
        }
    }
}
