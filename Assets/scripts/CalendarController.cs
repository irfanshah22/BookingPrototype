using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;
    public Text _monthYearNameText;
     public GameObject _item;
     public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    public DateTime _dateTime;
    public static CalendarController _calendarInstance;
    public Transform daysContainer;
    public Text _getdateText;

    /// <Define Match dates>
    public string dateTimeString = "2018-12-16";
    public List<string> matchdatesString;
    [SerializeField]
    public List<DateTime> matchDates;
    /// </summary>
 

    void Start()
    {
        matchDates = new List<DateTime>();
        matchDates.Clear();
        for (int i = 0; i < matchdatesString.Count; i++)
        {
            matchDates.Add(System.DateTime.Parse(matchdatesString[i]));
         }


        _calendarInstance = this;
         _dateItems.Clear();
        _dateItems.Add(daysContainer.GetChild(0).gameObject);  
  
        for (int i = 1; i < _totalDateNum; i++)
        {
             GameObject item = daysContainer.GetChild(i).gameObject;
            item.name = "Item" + (i + 1).ToString();
            _dateItems.Add(item);
        }  
        _dateTime = DateTime.Now;
        CreateCalendar();
        _getdateText.text = "";
       // _calendarPanel.SetActive(false);
         ShowCalendar(_getdateText);
    }

    void CreateCalendar()
    {  

        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < _totalDateNum; i++)
        {
            Text label = _dateItems[i].GetComponentInChildren<Text>();
            _dateItems[i].SetActive(false);
             if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    _dateItems[i].SetActive(true);  
                     bool matchday = false;
                   for (int matchCount = 0; matchCount < matchdatesString.Count; matchCount++)
                    {
                        if (matchDates[matchCount].Year == _dateTime.Year && matchDates[matchCount].Month == _dateTime.Month && matchDates[matchCount].Day == date + 1)
                        {
                            matchday = true;
                           // label.text = "  " + (date + 1).ToString() + " " + GetMonthNameShort(_dateTime.Month) + "  Match day";
                            label.text = "  " + (date + 1).ToString() + " " + GetMonthNameShort(_dateTime.Month)  ;
                            _dateItems[i].gameObject.GetComponent<CalendarDateItem>().Matchday = matchday;
                            label.color = Color.blue;
                        }   
                    } 
                   if(matchday == false)
                    {
                        label.text = "  " + (date + 1).ToString() + " " + GetMonthNameShort(_dateTime.Month);
                    }
                    date++;
                }  
            }
        }

        _yearNumText.text = _dateTime.Year.ToString();
        _monthNumText.text = _dateTime.Month.ToString();
        _monthYearNameText.text = GetMonthNameLong(_dateTime.Month) + " "+ _dateTime.Year.ToString();
        monthController.Instance.getYearNumber(_dateTime.Year);
    }
 
    String GetMonthNameShort(int _index)
    {
        switch (_index)
        {
            case 1: return "Jan";
            case 2: return "Feb";
            case 3: return "Mar";
            case 4: return "Apr";
            case 5: return "May";
            case 6: return "Jun";
            case 7: return "Jul";
            case 8: return "Aug";
            case 9: return "Sep";
            case 10: return "Oct";
            case 11: return "Nov";
            case 12: return "Dec";
        }
        return "";
    }
    String GetMonthNameLong(int _index)
    {
        switch (_index)
        {
            case 1: return "January";
            case 2: return "February";
            case 3: return "March";
            case 4: return "April";
            case 5: return "May";
            case 6: return "June";
            case 7: return "July";
            case 8: return "August";
            case 9: return "September";
            case 10: return "October";
            case 11: return "November";
            case 12: return "December";
        }
        return "";
    }
    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }
         return 0;
    }
    public void YearPrev()
    {
        _dateTime = _dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        _dateTime = _dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        _dateTime = _dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        _dateTime = _dateTime.AddMonths(1);
        CreateCalendar();
    }
    public void GetSpecificMonth(int _index)
    {
        int CurrentMonth = _dateTime.Month;
        print("current Month " + CurrentMonth);
        print("Index Month " + _index);
        if(_index == CurrentMonth)
        {
            return;
        }
        else if(_index < CurrentMonth)
        {
            int _tempindex = CurrentMonth - _index;
            _dateTime = _dateTime.AddMonths(-_tempindex);
            CreateCalendar();
        }
        else if(_index > CurrentMonth)
        {
            int _tempindex = _index - CurrentMonth;
            _dateTime = _dateTime.AddMonths(_tempindex);
            CreateCalendar();
        }  
    }
    public void ShowCalendar(Text target)
    {
        _calendarPanel.SetActive(true);
        _target = target;  
       // _calendarPanel.transform.position = new Vector3(965, 475, 0);//Input.mousePosition-new Vector3(0,120,0);
    }

    Text _target;
    public void OnDateItemClick(string day)
    {
        //   _target.text = _yearNumText.text + "Year" + _monthNumText.text + "Month" + day+"Day";
        _target.text = day+" " + _yearNumText.text; //+ "Year" + _monthNumText.text + "Month" + day+"Day";
        AlreadySignedIn.Instance.SelectedDate = _target.text;
       // _calendarPanel.SetActive(false);
    }    
}
