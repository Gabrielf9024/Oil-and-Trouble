using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotStatus : MonoBehaviour
{
    private Slider slider;
    private float maxHealth, health;

    void Awake()
    {
        float maxHealth = this.GetComponent<Health>().getMaxHealth();
        float health = this.GetComponent<Health>().getHealth();
        slider = GameObject.Find("HealthBar").GetComponent<Slider>();
    }
    void Start()
    {
    }
    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        slider.value = this.GetComponent<Health>().getHealth();
    }
}

