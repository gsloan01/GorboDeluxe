using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    public void PreStartStopTime()
    {
        StartCoroutine(WaitingTime());
    }
    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    
    public void StartTime(float please)
    {
        Time.timeScale = 1.0f;
    }
}
