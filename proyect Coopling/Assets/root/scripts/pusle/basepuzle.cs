using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basepuzle : MonoBehaviour
{
    public GameObject camara;
    public GameObject punto;
    Vector3 posicioncamara;
    bool cambio = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 

    void OnTouch()
    {
        // gameObject.SetActive(false);
        posicioncamara = camara.transform.position;
        cambio = true;
        // Aquí puedes agregar la función que quieres ejecutar
    }

    void Update()
    {
        // Detectar si hay toques en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Obtener el primer toque

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                // Convertir el toque en un Raycast
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Verificar si el Raycast impacta un objeto con collider
                if (Physics.Raycast(ray, out hit))
                {
                    // Si el objeto tocado es este GameObject
                    if (hit.transform == transform)
                    {
                        OnTouch(); // Ejecutar la función si se toca el objeto
                    }
                }
            }
        }



        /*if (cambio)
        {


        // camara.gameObject.transform.position = punto.transform.position;
        while (Vector3.Distance(camara.transform.position, punto.transform.position) > 0.01f)
        {

            camara.transform.position = Vector3.Lerp(camara.transform.position, punto.transform.position, 0.0001f * Time.deltaTime);
        }

            // camara.gameObject.transform.LookAt(gameObject.transform);
        }
  
    }*/
    }
   
}
