using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorpuzlebaldosas : MonoBehaviour
{
    public bool terminado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            terminado = true;
            gameObject.GetComponent<basepuzle>().OnTouch();
        }
    }
}
