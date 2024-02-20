using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
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
    private void Start()
    {
        _startingbool = false;
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
         }
    }
}
