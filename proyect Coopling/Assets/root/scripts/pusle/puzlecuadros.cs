using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UI;
public class puzlecuadros : MonoBehaviour
{

    public GameObject panel;

    //public GameObject puerta;

    public Vector4 colorpanel;
    public Vector4 colorpanelrojo = new Vector4(250, 0, 0, 100);
    public Vector4 colorpanelverde = new Vector4(0, 250, 0, 100);





    public GameObject findemo;
    // Start is called before the first frame update
  
    
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
        findemo.SetActive(true);
       // puerta.SetActive(false);
    }

    IEnumerator notpass()
    {
        panel.gameObject.GetComponent<Image>().color = colorpanelrojo;
        yield return new WaitForSeconds(0.5f);
        panel.gameObject.GetComponent<Image>().color = colorpanel;
    }
    
}
