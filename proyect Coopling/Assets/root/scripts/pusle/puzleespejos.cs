using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class puzleespejos : MonoBehaviour
{
    public GameObject controlador;

    public int id;
    public int rotacion;
    public int posicion;
    public int posicion_inicial;
    public GameObject rayog;
    bool x = true;
    bool y = true;

    public int actibador = 0;
    public GameObject objetoImpactado;
    public bool impacto = false;


    float longitudRayo = 20f;
    // Start is called before the first frame update
    void Start()
    {
        posicion = posicion_inicial;
        RotarEspejo();
    }


    void RotarEspejo()
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
                RaycastHit hit1;

                // Verificar si el Raycast impacta un objeto con collider
                if (Physics.Raycast(ray, out hit1))
                {
                    // Si el objeto tocado es este GameObject
                    if (hit1.transform == transform)
                    {
                        RotarEspejo(); // Ejecutar la funci�n si se toca el objeto
                    }
                }
            }
        }



        if (impacto)
        {
            if (x)
            {
                x = false;
                y = true;
                rayog.SetActive(true);
                controlador.GetComponent<controladorpuzleespejos>().listar(id);
            }
        }
        else
        {
            if (y)
            {
                y = false;
                x = true;
                rayog.SetActive(false);

                controlador.GetComponent<controladorpuzleespejos>().borrar(id);
                actibador = 0;
            }
        }








        Vector3 origenRayo = transform.position + new Vector3(0, 0.2f, 0);

        // Direcci�n del rayo (hacia adelante desde el objeto)
        Vector3 direccionRayo = transform.right;

        // Crear el rayo y verificar si golpea algo
        Ray rayo = new Ray(origenRayo, direccionRayo);
        RaycastHit hit;

        // Dibujar el rayo en la escena (opcional, para depuraci�n)
        Debug.DrawRay(origenRayo, direccionRayo * longitudRayo, Color.red);

        // Si el rayo choca con algo en un rango de 10 unidades
        if (impacto)
        {

            if (Physics.Raycast(rayo, out hit, longitudRayo))
            {
                // Mostrar el nombre del objeto con el que choca
                if (hit.collider.CompareTag("Espejo"))
                {


                    if (objetoImpactado == null)
                    {
                        // Si antes no habia impacto y ahora hay, el rayo ha impactado por primera vez
                        objetoImpactado = hit.collider.gameObject;
                        hit.collider.GetComponent<puzleespejos>().impacto = true;
                        Debug.Log("El rayo ha comenzado a impactar: " + objetoImpactado.name);
                        if (objetoImpactado.GetComponent<Collider>().GetComponent<puzleespejos>().actibador == 0)
                        {
                            objetoImpactado.GetComponent<Collider>().GetComponent<puzleespejos>().actibador = id;

                        }
                    }
                }
                if (hit.collider.CompareTag("Final"))
                {
                    objetoImpactado.GetComponent<Collider>().GetComponent<controladorpuzleespejos>().final = true;
                }
            }
            else
            {
                // Si antes est�bamos impactando y ahora no, el rayo ha dejado de impactar
                if (objetoImpactado != null && objetoImpactado.GetComponent<Collider>().GetComponent<puzleespejos>().actibador == id)
                {

                    objetoImpactado.GetComponent<Collider>().GetComponent<puzleespejos>().impacto = false;
                    objetoImpactado = null;  // Restablecer el objeto impactado
                }
                else
                {
                    objetoImpactado = null;

                }

            }
                // Aqui puedes hacer algo cuando el rayo golpea un objeto, como aplicar dato o activar una animaci�n
            }



        }


        IEnumerator cambiocamara()
        {

            // camara.gameObject.transform.position = punto.transform.position;
            while (Mathf.Abs(gameObject.transform.eulerAngles.y - rotacion) > 00.1f)
            {
                // Esperar 0.001 segundos entre cada movimiento
                yield return new WaitForSeconds(0.001f);

                // Crear un Quaternion a partir de la rotaci�n deseada en el eje Y
                Quaternion rotacionDeseada = Quaternion.Euler(0, rotacion, 0);

                // Interpolar la rotaci�n actual hacia la rotaci�n deseada
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotacionDeseada, 2 * Time.deltaTime);
            }



          
        }





    public void reinicio()
    {
        posicion=posicion_inicial;
        RotarEspejo();
    }
    }

