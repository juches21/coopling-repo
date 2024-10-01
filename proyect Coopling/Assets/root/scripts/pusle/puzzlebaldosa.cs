using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlebaldosa : MonoBehaviour
{
    public GameObject spawn;
    public GameObject controlador;

    public bool erronea;
    public bool terminado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        terminado = controlador.GetComponent<controladorpuzlebaldosas>().terminado;
        if (terminado)
        {
            gameObject.transform.position = gameObject.transform.position+new Vector3(-5,-5,-5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (erronea&& collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawn.transform.position;
            collision.gameObject.transform.rotation = spawn.transform.rotation;
        }
    }


}
