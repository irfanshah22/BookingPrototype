using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SittingAnimation : MonoBehaviour
{
    public float timedelay;
    public float X_Middlepoint;
    public float X_lowerLimit;
    public float X_upperLimit;
    public float Y_lowerLimit;
    public float Y_upperLimit;
    public CinemachineVirtualCamera _myvirtualCam;
    public int Counter;
     public float Speed;
    float currentTime;
    float temptargetValue;
    public bool controlBool1;
    public bool controlBool2;
    // Start is called before the first frame update
    void Start()
    {
        Counter = 0;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = X_Middlepoint;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = Y_upperLimit;
     }
    public void ResetValues()
    {
        StopCoroutine(waitforTransitionSecond());
         controlBool1 = false;
        controlBool2 = false;  
        Counter = 0;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = X_Middlepoint;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = Y_upperLimit;
     }
    public void StartLookingAround()
    {
        StartCoroutine(waitforTransitionSecond());
    }
    IEnumerator waitforTransitionSecond()
    {
        yield return new WaitForSeconds(timedelay);
         if(Counter==0)
        {
            Counter = 1;
            temptargetValue = X_upperLimit;
            controlBool1 = true;
            controlBool2 = false;
        }    
        else if(Counter ==1)
        {
            Counter = 0;
            temptargetValue = X_lowerLimit;
            controlBool1 = false;
            controlBool2 = true;
        }
     }  
      
    // Update is called once per frame
    void Update()
    {   
        if(controlBool1)
        {  
            float lerpedValue = Mathf.Lerp(_myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX, temptargetValue, Time.deltaTime * Speed);
             _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = lerpedValue;
            if (lerpedValue >= (temptargetValue - .15f) && controlBool1)
            {
                controlBool1 = false;
                Debug.Log("11L : " + lerpedValue);
                StartCoroutine(waitforTransitionSecond());
            }
         }
        else if (controlBool2)
        {
            float lerpedValue = Mathf.Lerp(_myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX, temptargetValue, Time.deltaTime * Speed);
             _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = lerpedValue;
            if (lerpedValue <= (temptargetValue + .15f) && controlBool2)
            {
                controlBool2 = false;
                Debug.Log("11L : " + lerpedValue);
                StartCoroutine(waitforTransitionSecond());
            }
        }
     } 
}
