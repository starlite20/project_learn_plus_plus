using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObjForMenu : MonoBehaviour
{
    //Used for the animation of background elements present in the Main Menu
    
    public float x_Val = 5.0f;
    public float y_Val = 5.0f;
    public float z_Val = 5.0f;
    
    void Update()
    {
        transform.Rotate(new Vector3(x_Val, y_Val, z_Val) * Time.deltaTime );
    }
}
