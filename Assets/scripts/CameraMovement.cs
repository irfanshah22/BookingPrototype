using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Transform _CameraLookandPOs;

    public float sensitivity;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
 
    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private bool _startingbool;
    public bool _CameraLookandPOsBool;

    private void Start()
    {
        _startingbool = false;
        _CameraLookandPOsBool = false;

    }
    public void Startmovement()
    {
         // Keep a note of the time the movement started.
        startTime = Time.time;
        startMarker = this.transform;
         // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, target.position);
        _startingbool = true;
    }
 
    void FixedUpdate()
    {
        if(_startingbool)
        {
             // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, target.position, fractionOfJourney);
            if(Vector3.Distance(this.transform.position, target.position) < 1)
            {
                 _startingbool = false;
                journeyLength = Vector3.Distance(this.transform.position, _CameraLookandPOs.position);
                 _CameraLookandPOsBool = true;
                startTime = Time.time;
                 print("Hey reached Destination");
            }  
         }
      else  if (_CameraLookandPOsBool)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;
             // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;
             // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(this.transform.position, _CameraLookandPOs.position, fractionOfJourney/4);
            transform.rotation = Quaternion.Slerp(this.transform.rotation, _CameraLookandPOs.rotation, fractionOfJourney/4); 
             if (Vector3.Distance(this.transform.position, _CameraLookandPOs.position) < .1f)
            {
                SeatsController._Instance.ReachedDestination();
                 _startingbool = false;
                _CameraLookandPOsBool = false;
                 print("Hey reached Destination");
            }
        } 

    }
}
