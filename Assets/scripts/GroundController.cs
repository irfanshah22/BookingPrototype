using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GroundController : MonoBehaviour
{
    public Button _bookAnotherTicket;
    // Start is called before the first frame update
    void Start()
    {
        _bookAnotherTicket.onClick.AddListener(BacktoAnotherBooking);
    }
    void BacktoAnotherBooking()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }  

}
