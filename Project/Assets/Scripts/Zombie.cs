using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public int vida = 4;
    public float velocidad;
    public LayerMask layerPlanta;

    public float cadencia = 1f;
    float cadAux = 0;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.left* .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, .5f, layerPlanta);
        if (hit.collider != null)
        {
            cadAux += Time.deltaTime;
            if (cadAux >= cadencia)
            {
                cadAux = 0;
                hit.collider.SendMessage("Morder");
            }
        }
        else
        {
            cadAux = 0;
            transform.position -= Vector3.right * velocidad * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Guisante"))
        {
            vida--;
            Destroy(col.gameObject);

            if (vida <= 0)
                Destroy(gameObject);

        }
        if (col.CompareTag("FailState"))
        {
            Destroy(gameObject);
            print("Has perdido");
        }

    }
}
