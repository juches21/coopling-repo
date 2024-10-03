using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public int rotacion;
    public int posicion;
    public int posicion_correcta;
    public GameObject rayo;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTouch()
    {
        posicion++;
        switch (posicion)
        {
            case 0:
                rotacion = 0;
                break;
            case 1:
                rotacion = 45;
                break;
            case 2:
                rotacion = 90;
                break;
            case 3:
                rotacion = 135;
                break;
            case 4:
                rotacion = 180;
                break;
            case 5:
                rotacion = 225;
                break;
            case 6:
                rotacion = 270;
                break;
            case 7:
                rotacion = 315;
                break;
            default:
                rotacion = 0; 
                posicion = 0;
                break;
        }

        //juaneselmejor:)
        StartCoroutine(cambiocamara());


    }
    // Update is called once per frame
    void Update()
    {
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


        if (posicion == posicion_correcta)
        {
            rayo.SetActive(true);
        }
        else
        {
            rayo.SetActive(false);

        }
    }


    IEnumerator cambiocamara()
    {
      
        // camara.gameObject.transform.position = punto.transform.position;
        while (Mathf.Abs(gameObject.transform.eulerAngles.y - rotacion) > 00.1f)
        {
            // Esperar 0.001 segundos entre cada movimiento
            yield return new WaitForSeconds(0.001f);

            // Crear un Quaternion a partir de la rotación deseada en el eje Y
            Quaternion rotacionDeseada = Quaternion.Euler(0, rotacion, 0);

            // Interpolar la rotación actual hacia la rotación deseada
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotacionDeseada, 2 * Time.deltaTime);
        }
      
        print(gameObject.transform.rotation);

        StopCoroutine(cambiocamara());
    }
}
