using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseLogic : MonoBehaviour
{

    [Header("Button Values")]
    public float healingAmount = 1;
    public int ammoAmount = 1;
    private bool isHealPressed;
    private GameObject player;

    public AudioSource audioSource;
    public AudioClip [] audioClips;

    private GameObject rightShield, leftShield;

    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        player = GameObject.FindWithTag("Player");
        leftShield = GameObject.Find("LeftShield");
        rightShield = GameObject.Find("RightShield");
        SetLeftShield(false);
        SetRightShield(false);
    }

    void Update()
    {
        if (isHealPressed)
            player.gameObject.GetComponent<Health>().HealSelf(healingAmount);
    }

    public void onPointerDownHealing()
    {
        isHealPressed = true;
        audioSource.clip = audioClips[0];
        audioSource.pitch = 1.0f;
        audioSource.Play();
    }
    public void onPointerUpHealing()
    {
        isHealPressed = false;
    }

    public void SetRightShield( bool status )
    {
        rightShield.gameObject.SetActive(status);
        audioSource.clip = audioClips[2];
        audioSource.pitch = 0.7f;
        audioSource.Play();
    }
    public void SetLeftShield( bool status )
    {
        leftShield.gameObject.SetActive(status);
        audioSource.clip = audioClips[2];
        audioSource.pitch = 1.0f;
        audioSource.Play();
    }
}
