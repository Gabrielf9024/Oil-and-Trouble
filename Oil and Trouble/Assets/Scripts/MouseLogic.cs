using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseLogic : MonoBehaviour
{

    [Header("Button Values")]
    public int healingAmount = 1;
    private bool isHealPressed;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (isHealPressed)
            GameObject.FindWithTag("Player").gameObject.GetComponent<RobotStatus>().HealSelf(healingAmount);
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
