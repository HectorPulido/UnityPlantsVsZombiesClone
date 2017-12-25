using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantas : MonoBehaviour
{
    public Sprite cartaAsignada;
    public int precioSoles;
    public int vida;

    void Morder()
    {
        vida--;
        if (vida <= 0)
            Destroy(gameObject);

    }
}
