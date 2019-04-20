using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseLogic : MonoBehaviour
{

    [Header("Button Values")]
    public int healingAmount = 1;
    public int ammoAmount = 1;
    private bool isHealPressed;
    private GameObject player;

    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (isHealPressed)
            player.gameObject.GetComponent<Health>().HealSelf(healingAmount);
    }

    public void onPointerDownHealing()
    {
        isHealPressed = true;
    }
    public void onPointerUpHealing()
    {
        isHealPressed = false;
    }
}
