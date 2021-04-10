using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the rotation function for the Augmented Object
public class autoRotateObject : MonoBehaviour
{
    public float y_Value = 3.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, y_Value, 0) * Time.deltaTime);
    }
}
