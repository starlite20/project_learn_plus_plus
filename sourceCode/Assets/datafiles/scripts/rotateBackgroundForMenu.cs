using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotates the Image in the Background of the Main Menu
public class rotateBackgroundForMenu : MonoBehaviour
{
    public float z_Value = 0.0f;

    void Update()
    {
        transform.Rotate(new Vector3 (0,0,z_Value) * Time.deltaTime);
    }
}
