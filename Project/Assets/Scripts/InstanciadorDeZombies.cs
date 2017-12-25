using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorDeZombies : MonoBehaviour {


    public int[] tiempos;

    public GameObject Zombie;

    void Start()
    {
        for (int i = 0; i < tiempos.Length; i++)
        {
            Invoke("InstanciarZombie", tiempos[i]);
        }
    }
    void InstanciarZombie()
    {
        Instantiate(Zombie, transform.position, Zombie.transform.rotation);
    }
}
