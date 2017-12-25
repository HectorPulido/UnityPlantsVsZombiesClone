using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Plantas> plantasAUsar;

    public GameObject Deck;
    public GameObject PrefabCarta;

    public Text TxtSoles;

    int Soles = 200;
    int PlantaAusar = 0;

    void Start()
    {
        ActualizarSoles(0);
        for (int i = 0; i < plantasAUsar.Count; i++)
        {
            GameObject go = Instantiate(PrefabCarta) as GameObject;
            go.transform.SetParent(Deck.transform);
            go.transform.position = Vector3.zero;
            go.transform.localScale = Vector3.one;

            Image img = go.GetComponent<Image>();
            img.sprite = plantasAUsar[i].cartaAsignada;

            Button bot = go.GetComponent<Button>();
            bot.onClick.RemoveAllListeners();
            int u = i;
            bot.onClick.AddListener(() => { PlantaAusar = u; });
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin,r.direction);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Cuadricula"))
                {
                    Transform t = hit.collider.transform;
                    CrearPlanta(PlantaAusar, t);
                }
                else if (hit.collider.CompareTag("Sol"))
                {
                    ActualizarSoles(50);
                    Destroy(hit.collider.gameObject);
                }
            }
        }

    }

    void CrearPlanta(int numero, Transform t)
    {
        if (plantasAUsar[numero].precioSoles > Soles)
            return;
        if (t.childCount != 0)
            return;

        GameObject g = Instantiate(plantasAUsar[PlantaAusar].gameObject, t.position, gameObject.transform.rotation) as GameObject;
        g.transform.SetParent(t);

        ActualizarSoles(-plantasAUsar[numero].precioSoles);
    }

    public void ActualizarSoles(int Add)
    {
        Soles += Add;
        TxtSoles.text = Soles.ToString();
    }


}
