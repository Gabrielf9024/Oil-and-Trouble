using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotStatus : MonoBehaviour
{
    [Header("HealthUI")]
    [SerializeField] float maxHealth;
    [SerializeField] float health;
    private Slider slider;

    void Awake()
    {
        health = maxHealth;
        slider = GameObject.Find("HealthBar").GetComponent<Slider>();
    }
    void Start()
    {
        UpdateHealthBar();
    }
    void Update()
    {
        if (health <= 0) //game over
            Time.timeScale = 0;

        if (Input.GetKey("o"))
            DamageSelf(1);
    }

    private void UpdateHealthBar()
    {
        slider.value = health;
    }

    public void DamageSelf(float damage)
    {
        health -= damage;
        UpdateHealthBar();
    }

    public void HealSelf(float healing)
    {
        health += healing;
        if (health > maxHealth)
            health = maxHealth;
        UpdateHealthBar();
    }
}
