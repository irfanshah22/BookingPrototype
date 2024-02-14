using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour {
    public Button _mybutton;
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
