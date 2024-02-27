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
    public Vector2 turn;
    public float sensitivity = .4f;
    private bool ShowMouse;

    // Start is called before the first frame update
    void Start()
    {
        controlBool1 = false;  
        Counter = 0;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = X_Middlepoint;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = Y_upperLimit;
     }  
    public void ResetValues()
    {
          controlBool1 = false;
        Cursor.lockState = CursorLockMode.None;
        //controlBool2 = false;  
        //Counter = 0;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = X_Middlepoint;
        _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = Y_upperLimit;
        SeatsController._Instance.IsreadyBook = true;

    }
    public void StartLookingAround()
    {
        ShowMouse = true;
        turn = new Vector2(-.5f, 1.2f);
        SeatsController._Instance.IsreadyBook = false;
         controlBool1 = true;
     }

    // Update is called once per frame
    void Update()
    {
       if (controlBool1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowMouse = !ShowMouse;
                HideShowMouse();
            } 
             turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = -turn.x;
            _myvirtualCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = turn.y;
        }
     }  
   void HideShowMouse()
    {
        if(ShowMouse)
        {
            Cursor.lockState = CursorLockMode.None;
        } 
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
         }
    }    
}
