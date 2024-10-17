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
        StartCoroutine(pass());
    }

    public void incorrecto()
    {
        StartCoroutine(notpass());
    }


    IEnumerator pass()
    {
        print("correcto");
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<basepuzle>().StartCoroutine("volvercambiocamara");
        //puerta.SetActive(false);



    }

    IEnumerator notpass()
    {
        print("fallo");
        yield return new WaitForSeconds(0.5f);
      
    }
}