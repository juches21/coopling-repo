using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzlepesas : MonoBehaviour
{
    public GameObject panel;
    public GameObject pesas;

    public GameObject pesa1;
    public GameObject pesaboton1;

    public GameObject pesa2;
    public GameObject pesaboton2;

    public GameObject pesa3;
    public GameObject pesaboton3;

    public GameObject pesa4;
    public GameObject pesaboton4;

    public GameObject pesa5;
    public GameObject pesaboton5;


    public bool aparecer = false;
    public GameObject puerta;

    public Vector4 colorpanel;
    public Vector4 colorpanelrojo = new Vector4(250, 0, 0, 100);
    public Vector4 colorpanelverde = new Vector4(0, 250, 0, 100);


    public int valorcorrecto;
    public int valoractual;

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
            pesas.SetActive(true);
            
        }
        else
        {
            pesas.SetActive(false);
           
        }

        if (valoractual == valorcorrecto)
        {
            correcto();
            valorcorrecto = 0;
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


    public void ponerpesa1()
    {
        valoractual += 1;
        pesa1.gameObject.SetActive(true);
        pesaboton1.gameObject.SetActive(false);
    }

    public void ponerpesa2()
    {
        valoractual += 2;
        pesa2.gameObject.SetActive(true);
        pesaboton2.gameObject.SetActive(false);
    }

    public void ponerpesa3()
    {
        valoractual += 3;
        pesa3.gameObject.SetActive(true);
        pesaboton3.gameObject.SetActive(false);
    }

    public void ponerpesa4()
    {
        valoractual += 4;
        pesa4.gameObject.SetActive(true);
        pesaboton4.gameObject.SetActive(false);
    }

    public void ponerpesa5()
    {
        valoractual += 5;
        pesa5.gameObject.SetActive(true);
        pesaboton5.gameObject.SetActive(false);
    }




    public void restart()
    {
        // Reiniciar el estado de la pesa 1
        pesa1.gameObject.SetActive(false);
        pesaboton1.gameObject.SetActive(true);

        // Reiniciar el estado de la pesa 2
        pesa2.gameObject.SetActive(false);
        pesaboton2.gameObject.SetActive(true);

        // Reiniciar el estado de la pesa 3
        pesa3.gameObject.SetActive(false);
        pesaboton3.gameObject.SetActive(true);

        // Reiniciar el estado de la pesa 4
        pesa4.gameObject.SetActive(false);
        pesaboton4.gameObject.SetActive(true);

        // Reiniciar el estado de la pesa 5
        pesa5.gameObject.SetActive(false);
        pesaboton5.gameObject.SetActive(true);

        // Reiniciar el valor actual
        valoractual = 0;
    }


}
