using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{
    public Button _myButton;
    public Text _myText;
    public int monthindex;
    // Start is called before the first frame update

    private void Awake()
    {
        _myButton = GetComponent<Button>();
        _myText = GetComponentInChildren<Text>();
    } 

    void Start()
    {
        _myButton.onClick.AddListener(MonthbuttonCalled);
    }

    void MonthbuttonCalled()
    {
        print(monthindex);
        CalendarController._calendarInstance.GetSpecificMonth(monthindex);
    }
  
}
