using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the Transform Reset Functions of the Augmented Objects
public class resetObjectTransform : MonoBehaviour
{
    public GameObject object_Watercycle, object_Heart, object_Jallian, object_Covid, imageTarget_Watercycle, imageTarget_Heart, imageTarget_Jallian, imageTarget_Covid;
    public Quaternion originalRotationValue;
    public float rotationSpeed = 2.5f;

    public AudioSource buttonAudioSource;
    public AudioClip buttonAudioClip;

    public void RESETpos()
    {
        //Play sound
        buttonAudioSource.PlayOneShot(buttonAudioClip);

        /* 
            - Stores the Transform Values of the ImageTarget as it has a fixed Transform
            - Then the Rotation and Scale are resetted to the original values using the stored value
        */

        originalRotationValue = imageTarget_Heart.transform.rotation;
        object_Heart.transform.rotation = Quaternion.Slerp(object_Heart.transform.rotation, originalRotationValue, Time.time * rotationSpeed);
        object_Heart.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

        originalRotationValue = imageTarget_Watercycle.transform.rotation;
        object_Watercycle.transform.rotation = Quaternion.Slerp(object_Watercycle.transform.rotation, originalRotationValue, Time.time * rotationSpeed);
        object_Watercycle.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

        originalRotationValue = imageTarget_Jallian.transform.rotation;
        object_Jallian.transform.rotation = Quaternion.Slerp(object_Jallian.transform.rotation, originalRotationValue, Time.time * rotationSpeed);
        object_Jallian.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

        originalRotationValue = imageTarget_Covid.transform.rotation;
        object_Covid.transform.rotation = Quaternion.Slerp(object_Covid.transform.rotation, originalRotationValue, Time.time * rotationSpeed);
        object_Covid.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
    }
}
