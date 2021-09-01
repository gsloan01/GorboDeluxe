using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    public Image cooldown1;
    public Image cooldown2;
    public Image cooldown3;
    public Image cooldown4;

    bool abil1Cooldown;
    bool abil2Cooldown;
    bool abil3Cooldown;
    bool abil4Cooldown;

    //times
    float abil1Time, abil2Time, abil3Time, abil4Time;
    float abil1Timer, abil2Timer, abil3Timer, abil4Timer;


    //
    // CooldownUI height is 100
    // need to Lerp from 100 to 0 at the rate of cooldown
    //
    //
    
    void Update()
    {
        if(abil1Cooldown)
        {
            abil1Timer -= Time.deltaTime;
            float newHeight = (abil1Timer/abil1Time) * 100;
            if (newHeight <= 0)
            {
                cooldown1.gameObject.SetActive(false);
                abil1Cooldown = false;
            }

            cooldown1.rectTransform.sizeDelta = new Vector2(100, newHeight);
        }
        if (abil2Cooldown)
        {
            abil2Timer -= Time.deltaTime;
            float newHeight = (abil2Timer / abil2Time) * 100;
            if (newHeight <= 0)
            {
                cooldown2.gameObject.SetActive(false);
                abil2Cooldown = false;
            }

            cooldown2.rectTransform.sizeDelta = new Vector2(100, newHeight);
        }
        if (abil3Cooldown)
        {
            abil3Timer -= Time.deltaTime;
            float newHeight = (abil3Timer / abil3Time) * 100;
            Debug.Log(newHeight);
            if (newHeight <= 0)
            {
                cooldown3.gameObject.SetActive(false);
                abil3Cooldown = false;
            }

            cooldown3.rectTransform.sizeDelta = new Vector2(100, newHeight);
        }
        if (abil4Cooldown)
        {
            abil4Timer -= Time.deltaTime;
            float newHeight = (abil4Timer / abil4Time) * 100;
            Debug.Log(newHeight);
            if (newHeight <= 0)
            {
                cooldown4.gameObject.SetActive(false);
                abil4Cooldown = false;
            }

            cooldown4.rectTransform.sizeDelta = new Vector2(100, newHeight);
        }
    }

    public void StartCooldown(int slot, float cooldown)
    {
        switch (slot)
        {
            case 1:
                cooldown1.gameObject.SetActive(true);
                cooldown1.rectTransform.sizeDelta = new Vector2(100, 100);
                abil1Cooldown = true;
                abil1Time = cooldown;
                abil1Timer = abil1Time;
                break;           
            case 2:
                cooldown2.gameObject.SetActive(true);
                cooldown2.rectTransform.sizeDelta = new Vector2(100, 100);
                abil2Cooldown = true;
                abil2Time = cooldown;
                abil2Timer = abil2Time;
                break;           
            case 3:
                cooldown3.gameObject.SetActive(true);
                cooldown3.rectTransform.sizeDelta = new Vector2(100, 100);
                abil3Cooldown = true;
                abil3Time = cooldown;
                abil3Timer = abil3Time;
                break;           
            case 4:
                cooldown4.gameObject.SetActive(true);
                cooldown4.rectTransform.sizeDelta = new Vector2(100, 100);
                abil4Cooldown = true;
                abil4Time = cooldown;
                abil4Timer = abil4Time;
                break;
            default:
                break;
        }
    }
}
