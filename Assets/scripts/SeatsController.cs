using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeatsController : MonoBehaviour
{
    public static SeatsController _Instance;
    public myviewObj[] _seatsArea;
    public GameObject FirstCamera;
    public GameObject SecondCamera;
    public GameObject SecondCameradependentObj;
    public myviewObj Temptarget;
    public GameObject bookingPanel;
    public GameObject ConfirmationPanel;
    public GameObject AlreadyBookedPanel;
    public Text _selectedDate; 
    public Text _selectedDate2; 
    public SittingAnimation _SittingAnimationController;
    public Button _bookAnotherDate;
    public Button _CheckAnotherTicket;
    public Button _BookthisSeat;
    public Transform initialPositionofCam1;
    public Material _NormalMaterial;
    public Material _BookedMaterial;
     // Start is called before the first frame update
 
    // Start is called before the first frame update
    void Start()
    {
         _bookAnotherDate.onClick.AddListener(BacktoAnotherBooking);
        _CheckAnotherTicket.onClick.AddListener(CheckAnotherSeat);

        _BookthisSeat.onClick.AddListener(OpenConfirmationPanelSeat);
         _Instance = this;
        _seatsArea =  GetComponentsInChildren<myviewObj>();
        _BookthisSeat.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //  seatpoint
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 300.0f))
            {
                if(hit.transform.gameObject.tag == "seatpoint")
                {
                      Temptarget =  hit.transform.gameObject.GetComponent<myviewObj>();
                      bookingPanel.SetActive(true);
                    _selectedDate.text = AlreadySignedIn.Instance.SelectedDate;
                    _selectedDate2.text = AlreadySignedIn.Instance.SelectedDate;
                 }  
                else if(hit.transform.gameObject.tag == "booked")
                {
                    AlreadyBookedPanel.SetActive(true);
                }  
                 Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }
    public void BookthisSeat()
    {
        for(int i=0; i< _seatsArea.Length; i++)
        {
            _seatsArea[i].gameObject.GetComponent<MeshRenderer>().enabled = false;
        } 
        _bookAnotherDate.interactable = false;
        _CheckAnotherTicket.interactable = false;
        
        Transform tempTarget = Temptarget.ViewPosition.transform;
        FirstCamera.GetComponent<CameraMovement>().target = tempTarget;
        FirstCamera.GetComponent<CameraMovement>().Startmovement();
        FirstCamera.GetComponent<CameraMovement>()._CameraLookandPOs = Temptarget.ViewNextCamPosition.transform; 
         SecondCameradependentObj.GetComponent<CinemachineVirtualCamera>().LookAt = tempTarget;
         SecondCameradependentObj.transform.position = Temptarget.ViewNextCamPosition.transform.position;
        SecondCamera.transform.position = Temptarget.ViewNextCamPosition.transform.position;
        SecondCameradependentObj.transform.rotation = Temptarget.ViewNextCamPosition.transform.rotation;
        SecondCamera.transform.rotation = Temptarget.ViewNextCamPosition.transform.rotation;
     }
    public void OpenConfirmationPanelSeat()
    {
        ConfirmationPanel.SetActive(true);
     }
   
    public void ConfirmTicket()
    {
         ConfirmationPanel.SetActive(false);
        Temptarget.gameObject.GetComponent<MeshRenderer>().material = _BookedMaterial;
        Temptarget.gameObject.GetComponent<MeshRenderer>().tag = "booked";
         CheckAnotherSeat();
     } 
    public void CheckAnotherSeat()
    {
        _BookthisSeat.gameObject.SetActive(false);

        for (int i = 0; i < _seatsArea.Length; i++)
        {
            _seatsArea[i].gameObject.GetComponent<MeshRenderer>().enabled = true;
        } 
        FirstCamera.SetActive(true);
        SecondCamera.SetActive(false);
    }
     public void ReachedDestination()
    {
         FirstCamera.SetActive(false);
        SecondCamera.SetActive(true);
        _bookAnotherDate.interactable = true;
        _CheckAnotherTicket.interactable = true;
        _BookthisSeat.gameObject.SetActive(true);
        _SittingAnimationController.StartLookingAround() ;
        FirstCamera.transform.rotation = initialPositionofCam1.rotation;
        FirstCamera.transform.position = initialPositionofCam1.position;
        _SittingAnimationController.ResetValues();
     }   
      void BacktoAnotherBooking()
    {
        SceneManager.LoadScene(0);
    }
}
  