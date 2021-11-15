using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DynamicHPSlider : MonoBehaviour
{
    [SerializeField] TMP_Text name, desc;
    [SerializeField] CustomHPSlider common;
    [SerializeField] CustomHPSlider elite;
    [SerializeField] CustomHPSlider boss;
    
    [SerializeField] PlayerInputHandler input;
    bool displaying = false;
    Enemy current;

    private void Awake()
    {
        input.OnRaycastObjectHitChanged.AddListener(UpdateDisplay);
    }

    void UpdateDisplay(GameObject newTarget)
    {
        if(newTarget.CompareTag("Enemy"))
        {
            current = newTarget.GetComponent<Enemy>();
            DisplayCommon();
            displaying = true;

        }
        else
        {
            if(displaying) DisplayNone();
        }
    }

    void DisplayCommon()
    {
        DisplayNone();
        common.health = current.HealthCPNT;
        name.text = current.data.enemyName;
        desc.text = current.data.desc;
        name.gameObject.SetActive(true);
        desc.gameObject.SetActive(true);
        common.gameObject.SetActive(true);
    }
    void DisplayElite()
    {
        DisplayNone();

    }
    void DisplayBoss()
    {
        DisplayNone();

    }
    void DisplayNone()
    {
        name.gameObject.SetActive(false);
        desc.gameObject.SetActive(false);
        common.gameObject.SetActive(false);
        elite.gameObject.SetActive(false);
        boss.gameObject.SetActive(false);
    }




}
