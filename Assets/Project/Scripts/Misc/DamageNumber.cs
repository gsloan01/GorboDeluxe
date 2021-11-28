using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(FaceCamera))]
public class DamageNumber : MonoBehaviour
{

    [SerializeField] TMPro.TMP_Text numberTXT;
    int number;
    bool crit;

    public DamageNumber(int num, bool crits)
    {
        Set(num, crits);
    }
    public void Set(int num, bool crits)
    {
        number = num;
        crit = crits;
    }
    private void Start()
    {
        numberTXT.text = number.ToString();
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 2.5f), Random.Range(-0.75f, -0.2f)), ForceMode.VelocityChange);
        
    }
}
