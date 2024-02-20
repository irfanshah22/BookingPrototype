using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SeatsController : MonoBehaviour
{
    public myviewObj[] _seatsArea;
    public GameObject FirstCamera;

    // Start is called before the first frame update
    void Start()
    {
        _seatsArea =  GetComponentsInChildren<myviewObj>();
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
                      Transform tempTarget =  hit.transform.gameObject.GetComponent<myviewObj>().ViewPosition.transform;

                    FirstCamera.GetComponent<CameraMovement>().target = tempTarget;
                    FirstCamera.GetComponent<CameraMovement>().Startmovement();

                }
                 Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }
}
  