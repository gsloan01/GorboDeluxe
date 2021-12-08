using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get { return instance; } }
    static CinemachineShake instance;

    private CinemachineVirtualCamera cmVCam;
    private CinemachineBasicMultiChannelPerlin cmBasicMCPerlin;

    private void Awake()
    {
        instance = this;
        cmVCam = GetComponent<CinemachineVirtualCamera>();

    }

    public void Shake(float intensity, float duration, float easeInTime = 0, float easeOutTime = 0)
    {
        cmBasicMCPerlin = cmVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine(CameraShake(intensity, duration, easeInTime, easeOutTime));
    }

    IEnumerator CameraShake(float intensity, float duration, float easeInTime, float easeOutTime)
    {
        cmBasicMCPerlin.m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(duration);
        cmBasicMCPerlin.m_AmplitudeGain = 0;
        

        //#region Ease-In
        //if (easeInTime > 0)
        //{
        //    while (timer < easeInTime)
        //    {
        //        Debug.Log("Easing In");
        //        cmBasicMCPerlin.m_AmplitudeGain = Mathf.Lerp(cmBasicMCPerlin.m_AmplitudeGain, intensity, easeInTime * Time.deltaTime);
        //        timer += Time.deltaTime;
        //        yield return null;
        //    }
        //    cmBasicMCPerlin.m_AmplitudeGain = intensity;
        //}
        //else
        //{
        //    Debug.Log("Easing In Instantly");
        //    cmBasicMCPerlin.m_AmplitudeGain = intensity;
        //}
        //#endregion

        //#region Shake Body
        //if (duration > 0)
        //{
        //    while (timer < duration - easeOutTime)
        //    {
        //        Debug.Log("Shaking");
        //        timer += Time.deltaTime;
        //        yield return null;
        //    }
        //}
        //#endregion
        //#region Ease-Out
        //if (easeOutTime > 0)
        //{
        //    while (cmBasicMCPerlin.m_AmplitudeGain != 0 || timer < duration)
        //    {
        //        Debug.Log("Easing Out");
        //        cmBasicMCPerlin.m_AmplitudeGain = Mathf.Lerp(cmBasicMCPerlin.m_AmplitudeGain, 0, easeOutTime * Time.deltaTime);
        //        timer += Time.deltaTime;
        //        yield return null;
        //    }
        //    cmBasicMCPerlin.m_AmplitudeGain = 0;
        //}
        //else
        //{
        //    Debug.Log("Easing Out Instantly");
        //    cmBasicMCPerlin.m_AmplitudeGain = 0;
        //}
        //#endregion

        //timer = 0;
        //cmBasicMCPerlin.m_AmplitudeGain = 0;
        //yield return null;
    }
}
