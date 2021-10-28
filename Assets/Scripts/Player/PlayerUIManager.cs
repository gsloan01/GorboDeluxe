using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    Player player;
    Health health;
    /// <summary>
    /// Health slider
    /// </summary>
    public Slider HPSlider;
    public TMP_Text HPValueTXT;
    /// <summary>
    /// Resource Point Slider
    /// </summary>
    public Slider RPSlider;
    /// <summary>
    /// Experience Point Slider
    /// </summary>
    public Slider XPSlider;


    private void Awake()
    {
        player = GetComponent<Player>();
        health = GetComponent<Health>();
        player.OnPlayerGainXP.AddListener(UpdateXP);
        health.OnHealed.AddListener(UpdateHP);
        health.OnHurt.AddListener(UpdateHP);


        

    }
    private void Start()
    {
        HPSlider.maxValue = health.max;
        UpdateHP();
    }
    void UpdateHP()
    {
        HPSlider.value = health.Current;
        HPValueTXT.text = $"{health.Current} / {health.max}";
    }

    void UpdateRP()
    {

    }
    void UpdateXP(float xpGained)
    {
        
    }
}
