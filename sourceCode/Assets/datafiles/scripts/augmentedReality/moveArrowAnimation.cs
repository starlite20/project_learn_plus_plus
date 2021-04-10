using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animates the Arrows for the Water Cycle AR Object
public class moveArrowAnimation : MonoBehaviour
{
    public float y_Value = 0.8f;

    void Update()
    {
        transform.Translate(new Vector3 (0.0f, y_Value, 0.0f) * Time.deltaTime);
    }
}
