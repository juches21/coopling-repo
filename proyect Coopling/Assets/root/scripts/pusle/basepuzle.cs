using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class basepuzle : MonoBehaviour
{
    public GameObject camara;
    public GameObject puntopuzzle;
    public GameObject puntooriginal;

    public GameObject controlador;


    Vector3 posicioncamara;
    public int puzzle;

    public GameObject panelcontroles;
    public GameObject panelpuzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 

    public void OnTouch()
    {
        // gameObject.SetActive(false);
       // posicioncamara = camara.transform.position;
        StartCoroutine(cambiocamara());
       
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



     
    }
   public void salir()
    {
        StartCoroutine(salirpuzle());
    }
    IEnumerator cambiocamara()
    {
       
        // camara.gameObject.transform.position = punto.transform.position;
        while (Vector3.Distance(camara.transform.position, puntopuzzle.transform.position) > 0.01f)
        {
        yield return new WaitForSeconds(0.001f);
            camara.transform.position = Vector3.Lerp(camara.transform.position, puntopuzzle.transform.position, 2 * Time.deltaTime);
            camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, puntopuzzle.transform.rotation, 2 * Time.deltaTime);
        }
        cambiaruipuzle();

        if (puzzle == 1)
        {
            gameObject.GetComponent<puzzlecandado>().aparecer = true;
        }if(puzzle == 4)
        {
            gameObject.GetComponent<puzzlepesas>().aparecer = true;
        }
      
        }
    IEnumerator volvercambiocamara()
    {
        while (Vector3.Distance(camara.transform.position, puntooriginal.transform.position) > 0.01f)
        {
            yield return new WaitForSeconds(0.001f);
          
            camara.transform.position = Vector3.Lerp(camara.transform.position, puntooriginal.transform.position, 2 * Time.deltaTime);

            camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, puntooriginal.transform.rotation, 2 * Time.deltaTime);
            //camara.gameObject.transform.LookAt(gameObject.transform);
        }
        cambiaruicontroles();
        gameObject.SetActive(false);

    }



    IEnumerator salirpuzle()
    {
        while (Vector3.Distance(camara.transform.position, puntooriginal.transform.position) > 0.01f)
        {
            yield return new WaitForSeconds(0.001f);
            print("asdasd");
            camara.transform.position = Vector3.Lerp(camara.transform.position, puntooriginal.transform.position, 2 * Time.deltaTime);

            camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, puntooriginal.transform.rotation, 2 * Time.deltaTime);
            //camara.gameObject.transform.LookAt(gameObject.transform);
        }
        cambiaruicontroles();
      

    }

    public void cambiaruipuzle()
    {
        panelcontroles.SetActive(false);
        panelpuzzle.SetActive(true);
}



    public void cambiaruicontroles()
    {
        panelcontroles.SetActive(true);
        panelpuzzle.SetActive(false);
    }

    public void fallo()
    {
        controlador.GetComponent<controlador>().contarfallos();
    }

    public void acierto()
    {
        StartCoroutine(volvercambiocamara());
    }
}

