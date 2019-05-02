// This script should handle the changing of variables for the robot's body
// While Health is in another script, specifics for the player are handled here
// Ammo is kept track here


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotStatus : MonoBehaviour
{
    private Slider slider;
    private float maxHealth, health;
    [SerializeField] int ammo, ammoLimit;

    void Awake()
    {
        maxHealth = this.GetComponent<Health>().getMaxHealth();
        health = this.GetComponent<Health>().getHealth();
        slider = GameObject.Find("HealthBar").GetComponent<Slider>();

        UpdateAmmoCount();

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
    private void UpdateAmmoCount()
    {
        GameObject.Find("AmmoCount").GetComponent<Text>().text = ammo.ToString();
    }

    public int getAmmo()
    {
        return ammo;
    }
    public void addAmmo(int count)
    {
        ammo += count;
        if (ammo < 0)
            ammo = 0;
        if (ammo > ammoLimit)
            ammo = ammoLimit;
        UpdateAmmoCount();
    }
    
}

