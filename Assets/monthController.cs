using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class monthController : MonoBehaviour
{
    public buttonController[] MonthsButtons;

    private void Awake()
    {
        MonthsButtons = this.transform.GetComponentsInChildren<buttonController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i< MonthsButtons.Length; i++)
        {
            int j = 0;
            j = i + 1;
            MonthsButtons[i].monthindex = j;
             MonthsButtons[i]._myText.text = j.ToString();
         }
    } 
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
