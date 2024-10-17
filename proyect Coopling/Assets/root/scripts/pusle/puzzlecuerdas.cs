using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzlecuerdas : MonoBehaviour
{
   
    public GameObject puerta;




    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public void correcto()
    {
      
        gameObject.GetComponent<basepuzle>().acierto();
    }

    public void incorrecto()
    {
       
        gameObject.GetComponent<basepuzle>().fallo();
    }


    
}