// This script should handle the changing of variables for the robot's body
// While Health is in another script, specifics for the player are handled here
// Ammo is kept track here


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotStatus : MonoBehaviour
{
    public AudioClip [] reloadClips;
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
        if (ammo == (ammoLimit-1) && count > 0)
        {
            this.GetComponent<AudioSource>().clip = reloadClips[1];
            this.GetComponent<AudioSource>().pitch = 1.0f;
            this.GetComponent<AudioSource>().Play();
        }
        ammo += count;
        if (count > 0 && ammo < ammoLimit)
        {
            this.GetComponent<AudioSource>().clip = reloadClips[0];
            this.GetComponent<AudioSource>().pitch = 1.0f;
            this.GetComponent<AudioSource>().Play();
        }
        if (ammo < 0)
            ammo = 0;
        if (ammo > ammoLimit)
            ammo = ammoLimit;
        UpdateAmmoCount();
    }
    
}

