using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotator : MonoBehaviour
{

    [SerializeField] private string mouseInputAxis;
    [SerializeField] private float sensitive;
    
    private void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));

        if(Input.GetMouseButton(0) == true)
        {
            transform.Rotate(0, Input.GetAxis(mouseInputAxis) * -sensitive, 0); // инвертированное вращение
            //Debug.Log("Rotation");
        }        
    }
}
