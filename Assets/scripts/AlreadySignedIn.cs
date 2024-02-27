using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AlreadySignedIn : MonoBehaviour
{
    public static AlreadySignedIn Instance;
    public bool SignedInBool;
    public String SelectedDate;
    private void Awake()
    {
        //check if instance is null, if null then create 
        if (Instance == null)
        {
             Instance = this;
             DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }  
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
