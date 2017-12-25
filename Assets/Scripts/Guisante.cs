using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guisante : MonoBehaviour {

    public int velocidad = 10;
    public int daño = 1;


    void Update()
    {
        transform.position += Vector3.right * velocidad * Time.deltaTime;
    }
}
