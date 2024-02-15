using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour {
    public Button _mybutton;
    public bool Matchday;
    private void Start()
    {
        _mybutton = GetComponent<Button>(); 
        _mybutton.onClick.AddListener(OnDateItemClick);
    }

    public void OnDateItemClick()
    {
        CalendarController._calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
    }
}
