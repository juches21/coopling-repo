using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class controladorpuzleespejos : MonoBehaviour
{
    // Start is called before the first frame update
    public List<int> combinacion = new List<int>();
    public List<int> combinacioncorrecta = new List<int>();


    public bool final = false;
    void Start()
    {
        
           
       
    }

    // Update is called once per frame
    void Update()
    {


        if (final)
        {
            if(combinacion.SequenceEqual(combinacioncorrecta))
            {
                print("correcto");
                pass();
                final = false;
            }
            else
            {
                print("fallo");
                reinicio();
                final = false;
            }
        }
    }
    public void listar(int espejo)
    {
        if (combinacion.Count < 5 && espejo != 46)
        {
            
            combinacion.Add(espejo);
        }
    }
    public void borrar(int espejo)
    {
      

            if (combinacion.Remove(espejo))
            {
                Debug.Log("N�mero " + espejo + " eliminado de la lista.");
            }
            else
            {
                Debug.Log("N�mero " + espejo + " no encontrado en la lista.");
            }
        }


    public void actibarcandado(int espejo)
    {
        print("puzle candado on");
    }
    public void pass()
{
        print("puzle espejos resuelto");
}

    public void reinicio()
    {
        GameObject[] espejos = GameObject.FindGameObjectsWithTag("Espejo");

        // Iterar sobre todos los espejos encontrados
        foreach (GameObject espejo in espejos)
        {
            // Acceder a un componente espec�fico, por ejemplo, el componente "Renderr"
            espejo.GetComponent<puzleespejos>().reinicio();
        }
    }
}
