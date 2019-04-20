using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float health;

    void Awake()
    {
        health = maxHealth;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0) //Do some action for this object dying
            Die();

        if (Input.GetKey("o")) //Debug
            DamageSelf(1);
}

    public float getHealth()
    {
        return health;
    }
    public float getMaxHealth()
    {
        return maxHealth;
    }
    public void DamageSelf(float damage)
    {
        health -= damage;
    }

    public void HealSelf(float healing)
    {
        health += healing;
        if (health > maxHealth)
            health = maxHealth;
    }

    private void Die()
    {

    }

}
