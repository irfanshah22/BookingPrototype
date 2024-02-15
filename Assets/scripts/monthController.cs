using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class monthController : MonoBehaviour
{
    public static monthController Instance;
    public buttonController[] MonthsButtons;
     private int Currentyear;
    private void Awake()
    {
        Instance = this;
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
            Setmonth(j);
          }
     }
    void Setmonth(int index)
    {
        if (index == 1)
        {
            MonthsButtons[index-1]._myTextmonth.text = "Jan";
        }
        else if (index==2)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Feb";
        }
        if (index == 3)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Mar";
        }
        else if (index == 4)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Apr";
        }
        if (index == 5)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "May";
        }
        else if (index == 6)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Jun";
        }
        if (index == 7)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Jul";
        }
        else if (index == 8)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Aug";
        }
        if (index == 9)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Sep";
        }
        else if (index == 10)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Oct";
        }
        if (index == 11)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Nov";
        }
        else if (index == 12)
        {
            MonthsButtons[index - 1]._myTextmonth.text = "Dec";
        }
    }
     
    public void getYearNumber(int _year)
    {
        print(_year);
        if(Currentyear == _year)
        { 
            return;
        }  
        else
        {
            Currentyear = _year;
            for (int i = 0; i < MonthsButtons.Length; i++)
            {
                     MonthsButtons[i]._myTextyear.text = _year.ToString();
             }  
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
