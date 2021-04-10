using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the Multiple Touch Recognition System within the App for Gesture Support
public class touchControl : MonoBehaviour
{
    //Rotation Control Variables
    Vector3 previousPosition = Vector3.zero; //Start position
    Vector3 positionDelta = Vector3.zero;    //Change in position or direction to rotate
    Vector3 tempPosition = Vector3.zero;     //The temporary position

    //Zoom Control Variables
    public float ZoomControlSensitivity = 0.01f;

    // Update is called once per frame
    void Update()
    {
        rotationControl();
        zoomControl();
    }

    void rotationControl()
    {
        //if one touch is detected
        if( (Input.GetMouseButton(0)) )
        {
            positionDelta = Input.mousePosition - previousPosition;
            
            //the following code is if the object is upside down,
            //rotation gets inverted as it is based on axis 
            if(Vector3.Dot(transform.up, Vector3.up) >= 0)      //Dot = Vector Dot product
            {
                transform.Rotate (transform.up, (-1)*Vector3.Dot(positionDelta, Camera.main.transform.right), Space.World);
            }
            else
            {
                transform.Rotate (transform.up, Vector3.Dot(positionDelta, Camera.main.transform.right), Space.World);
            }
            transform.Rotate (Camera.main.transform.right, Vector3.Dot(positionDelta, Camera.main.transform.up), Space.World);
        }
        previousPosition = Input.mousePosition;
    }

    void zoomControl()
    {
        // If two touches are detected on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMagnitude = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDifference = (prevTouchDeltaMagnitude - touchDeltaMagnitude) * ZoomControlSensitivity * (-1);

            tempPosition = transform.localScale;

            tempPosition.x += deltaMagnitudeDifference;
            tempPosition.y += deltaMagnitudeDifference;
            tempPosition.z += deltaMagnitudeDifference;

            if ( tempPosition.x < 0.1 )
            {
                tempPosition.x = 1;
                tempPosition.y = 1;
                tempPosition.z = 1;
            }

            transform.localScale=tempPosition;
        }
    }
}
