using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puzlesimbolos : MonoBehaviour
{
    // Start is called before the first frame update
 

    //public float rotationSpeed = 90f; // grados por segundo
    private float currentRotationSpeed_externo = 0f; // velocidad actual
    private float currentRotationSpeed_interno = 0f; // velocidad actual


    // Referencias a la imagen y botones
    public Image imageToRotate_externo;
    public Image imageToRotate_interno;

    public Button buttonRight_externo;
    public Button buttonLeft_externo;

    public Button buttonRight_interno;
    public Button buttonLeft_interno;

    public bool rotationOn_externo = false;
    public bool rotationOn_interno = false;

    public bool Rueda_externo = false;
    public bool Rueda_interno = false;

    public int Max_externo;
    public int Min_externo;

    public int Max_interno;
    public int Min_interno;


    // Start is called before the first frame update
    void Start()
    {
        //Asignar los metodos a los botones

        buttonRight_externo.onClick.AddListener(RotateRight_externo);

        buttonLeft_externo.onClick.AddListener(RotateLeft_externo);



        buttonRight_interno.onClick.AddListener(RotateRight_interno);

        buttonLeft_interno.onClick.AddListener(RotateLeft_interno);
        //asignar metodos para detener al soltar

     


    }

    // Update is called once per frame
    void Update()
    {
        // Rota la image segun la velocidad actual

        if (currentRotationSpeed_externo != 0)
        {
            imageToRotate_externo.transform.Rotate(Vector3.forward, currentRotationSpeed_externo * Time.deltaTime);
        }

        if (imageToRotate_externo.transform.rotation.z < Max_externo && imageToRotate_externo.transform.rotation.z > Min_externo)
        {
            Rueda_externo = true;
        }
        else
        {
            Rueda_externo = false;
        }

        /*  if (imageToRotate_externo.transform.rotation.z < -Max_externo && imageToRotate_externo.transform.rotation.z > -Min_externo)
          {
              Rueda_externo = true;
          }
          else
          {
              Rueda_externo = false;
          }*/






        if (currentRotationSpeed_interno != 0)
        {
            imageToRotate_interno.transform.Rotate(Vector3.forward, currentRotationSpeed_interno * Time.deltaTime);
        }

        if (imageToRotate_interno.transform.rotation.z < Max_interno && imageToRotate_interno.transform.rotation.z > Min_interno)
        {
            Rueda_interno = true;
        }
        else
        {
            Rueda_interno = false;
        }

        /*if (imageToRotate_interno.transform.rotation.z < -Max_interno && imageToRotate_interno.transform.rotation.z > -Min_interno)
        {
            Rueda_interno = true;
        }
        else
        {
            Rueda_interno = false;
        }*/

    }





    private void RotateImage_externo(float direction)
    {

        imageToRotate_externo.transform.Rotate(Vector3.forward, direction);

    }



    public void RotateRight_externo()
    {
        if (!rotationOn_externo)
        {
            currentRotationSpeed_externo = 90; //Establece la velocidad a la derecha
            rotationOn_externo = true;
        }
        else
        {
            StopRotation_externo();
    
        }



    }

    public void RotateLeft_externo()
    {

        if (!rotationOn_externo)
        {
            currentRotationSpeed_externo = -90; //Establece la velocidad a la derecha
            rotationOn_externo = true;
        }
        else
        {
            StopRotation_externo();
            
        }


    }

    public void StopRotation_externo()
    {

        currentRotationSpeed_externo = 0f; //Detetiene la rotacion
        rotationOn_externo = false;

    }







    //--------------------------------------








    private void RotateImage_interno(float direction)
    {

        imageToRotate_interno.transform.Rotate(Vector3.forward, direction);

    }



    public void RotateRight_interno()
    {
        if (!rotationOn_interno)
        {
            currentRotationSpeed_interno = 90; //Establece la velocidad a la derecha
            rotationOn_interno = true;
        }
        else
        {
            StopRotation_interno();

        }



    }

    public void RotateLeft_interno()
    {

        if (!rotationOn_interno)
        {
            currentRotationSpeed_interno = -90; //Establece la velocidad a la derecha
            rotationOn_interno = true;
        }
        else
        {
            StopRotation_interno();

        }


    }

    public void StopRotation_interno()
    {

        currentRotationSpeed_interno = 0f; //Detetiene la rotacion
        rotationOn_interno = false;

    }
}
