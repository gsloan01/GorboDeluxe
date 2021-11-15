using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomHPSlider : MonoBehaviour
{
    public Health health;
    [SerializeField] Image fill;
    [SerializeField] TMP_Text amount;

    private void Start()
    {
        if(health != null)
        {
            OnHealthUpdated();
            health.OnHurt.AddListener(OnHealthUpdated);
            health.OnHealed.AddListener(OnHealthUpdated);
        }

    }
    private void OnEnable()
    {
        OnHealthUpdated();
        health.OnHurt.AddListener(OnHealthUpdated);
        health.OnHealed.AddListener(OnHealthUpdated);
    }
    void OnHealthUpdated()
    {
        Debug.Log("HP updated");
        if(amount != null) amount.text = health.Current.ToString();
        if(fill != null) fill.fillAmount = health.Current / health.max;

    }

}
