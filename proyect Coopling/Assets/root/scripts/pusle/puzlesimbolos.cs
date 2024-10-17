using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class puzlesimbolos : MonoBehaviour
{
    // Start is called before the first frame update
 

    //public float rotationSpeed = 90f; // grados por segundo
   


    // Referencias a la imagen y botones
    public GameObject imageToRotate_externo;
    public GameObject imageToRotate_interno;

    

   

    public int rotacion_externo;
    public int posicion_externo;

    public int rotacion_interno;
    public int posicion_interno;

    public int posicion_externo_correcta;
    public int posicion_interno_correcta;

    // Start is called before the first frame update
    private void Update()
    {
        if(posicion_externo==posicion_externo_correcta && posicion_interno == posicion_interno_correcta)
        {
            gameObject.GetComponent<basepuzle>().StartCoroutine("volvercambiocamara");
        }
    }
    public void derecha_externo()
    {
        posicion_externo++;
        print(posicion_externo);
        Rotarcirculo_externo();
     
    }

    public void derecha_interno()
    {
        posicion_interno++;
        Rotarcirculo_interno();
    }


    

    public void Rotarcirculo_externo()
    {
        
        switch (posicion_externo)
        {
            case 0:
                rotacion_externo = 0;
                break;
            case 1:
                rotacion_externo = 45;
                break;
            case 2:
                rotacion_externo = 90;
                break;
            case 3:
                rotacion_externo = 135;
                break;
            case 4:
                rotacion_externo = 180;
                break;
            case 5:
                rotacion_externo = 225;
                break;
            case 6:
                rotacion_externo = 270;
                break;
            case 7:
                rotacion_externo = 315;
                break;
            default:
                rotacion_externo = 0;
                posicion_externo = 0;
                break;
        }

        //juaneselmejor:)
        StartCoroutine(rotar_externo());


    }

    public void Rotarcirculo_interno()
    {
       
        switch (posicion_interno)
        {
            case 0:
                rotacion_interno = 0;
                break;
            case 1:
                rotacion_interno = 45;
                break;
            case 2:
                rotacion_interno = 90;
                break;
            case 3:
                rotacion_interno = 135;
                break;
            case 4:
                rotacion_interno = 180;
                break;
            case 5:
                rotacion_interno = 225;
                break;
            case 6:
                rotacion_interno = 270;
                break;
            case 7:
                rotacion_interno = 315;
                break;
            default:
                rotacion_interno = 0;
                posicion_interno = 0;
                break;
        }

        //juaneselmejor:)
        StartCoroutine(rotar_interno());


    }

    // Update is called once per frame




    IEnumerator rotar_externo()
    {
        print("test1");

        // Mientras la diferencia de la rotación actual y la rotación deseada sea mayor a 0.5 grados
        while (Quaternion.Angle(imageToRotate_externo.transform.rotation, Quaternion.Euler(rotacion_externo, 0, 0)) > 0.5f)
        {
            print("test2");

            // Esperar 0.001 segundos entre cada movimiento
            yield return new WaitForSeconds(0.001f);

            Quaternion rotacionDeseada_ex = Quaternion.Euler(rotacion_externo, 90, 90);

            // Interpolar la rotación actual hacia la rotación deseada
            imageToRotate_externo.transform.rotation = Quaternion.Slerp(imageToRotate_externo.transform.rotation, rotacionDeseada_ex, 2 * Time.deltaTime);
        }

        // Fin de la corrutina cuando el bucle termina
    }

    IEnumerator rotar_interno()
    {
        // Mientras la diferencia de rotación entre la actual y la deseada sea mayor a 0.1 grados
        while (Quaternion.Angle(imageToRotate_interno.transform.rotation, Quaternion.Euler(0, rotacion_interno, 0)) > 0.1f)
        {
            // Esperar 0.001 segundos entre cada movimiento
            yield return new WaitForSeconds(0.001f);

            // Crear un Quaternion a partir de la rotación deseada en el eje Y
            Quaternion rotacionDeseada = Quaternion.Euler( rotacion_interno, 90,90);

            // Interpolar la rotación actual hacia la rotación deseada
            imageToRotate_interno.transform.rotation = Quaternion.Slerp(imageToRotate_interno.transform.rotation, rotacionDeseada, 2 * Time.deltaTime);
        }

        // La corrutina se detendrá automáticamente cuando termine el bucle
    }

}
