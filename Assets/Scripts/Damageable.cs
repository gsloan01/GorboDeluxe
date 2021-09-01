using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    Health health;
    Dictionary<Damage.dtype, float> damageMods = new Dictionary<Damage.dtype, float>();
    float healingMod = 1;
    public bool allowHealingFromNegativeDamage = false;
    public bool isDead { get { return health.isDead; } }
    public Slider hpSlider;
    Canvas sliderCanvas;
    public GameObject HurtSFX;

    private void Awake()
    {
        health = GetComponent<Health>();
        if(hpSlider != null)
        {
            hpSlider.maxValue = health.max;
            hpSlider.value = health.max;
        }
        if(GetComponent<Enemy>() != null)
        {
            sliderCanvas = hpSlider.GetComponentInParent<Canvas>();
        }

    }
    void Update()
    {
        if(sliderCanvas != null)
        {

            Vector3 direction = (Camera.main.transform.position - sliderCanvas.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            sliderCanvas.transform.rotation = Quaternion.Slerp(sliderCanvas.transform.rotation, lookRotation, Time.deltaTime * 5);
            
        }
    }
    /// <summary>
    /// Call this method to deal damage to a damagable entity
    /// </summary>
    /// <param name="damages">List of all damage properties</param>
    public void RecieveDamage(List<Damage> damages, GameObject source)
    {
        //total damage from this full attack
        float final = 0;
        //go through every damage source
        foreach (Damage d in damages)
        {
            final += damageMods.Count > 0 ?  (damageMods.TryGetValue(d.damageType, out float mod) ? d.value /* mod */ : d.value)  : d.value;
            //if there is a damage modifier
            //then multiply the incoming damage by the modifier
            //otherwise, add the full damage
            
        }
        //if we dont allow healing from negative...
        if(!allowHealingFromNegativeDamage)
        {
            //then if the final damage is negative, set it to zero
            if (final <= 0) final = 0;
        }
        //finally apply all damage
        if (GameSettings.Instance.debug) Debug.Log($"{gameObject.name} taking {final} damage from {source.name}");
        if(GetComponent<Enemy>() != null)
        {
            GetComponent<Enemy>().animatorController.HurtAnim();
        }
        if (HurtSFX != null) Instantiate(HurtSFX, transform.position, Quaternion.identity, null);
        health.Apply(-final);
        if (hpSlider != null) hpSlider.value = health.Current;
        
    }

    public void RecieveHealing(float healingValue)
    {
        health.Apply(healingValue * healingMod);
        if (hpSlider != null) hpSlider.value = health.Current;
    }

}
