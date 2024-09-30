using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzlecandado : MonoBehaviour
{
    public GameObject panel;
    public GameObject llave1, llave2, llave3, llave4,llave5;
    public bool aparecer = false;
    public GameObject puerta;

    public Vector4 colorpanel;
    public Vector4 colorpanelrojo= new Vector4(250,0,0,100);
    public Vector4 colorpanelverde = new Vector4(0, 250, 0, 100);


    // Start is called before the first frame update
    void Start()
    {
        colorpanel = panel.gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (aparecer)
        {
            llave1.SetActive(true);
            llave2.SetActive(true);
            llave3.SetActive(true);
            llave4.SetActive(true);
            llave5.SetActive(true);
        }
        else
        {
            llave1.SetActive(false);
            llave2.SetActive(false);
            llave3.SetActive(false);
            llave4.SetActive(false);
            llave5.SetActive(false);
        }



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
        panel.gameObject.GetComponent<Image>().color = colorpanelverde;
        yield return new WaitForSeconds(0.5f);
        panel.gameObject.GetComponent<Image>().color = colorpanel;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<basepuzle>().StartCoroutine("volvercambiocamara");
        puerta.SetActive(false);



    }

    IEnumerator notpass()
    {
        panel.gameObject.GetComponent<Image>().color = colorpanelrojo;
        yield return new WaitForSeconds(0.5f);
        panel.gameObject.GetComponent<Image>().color = colorpanel;
    }
}
