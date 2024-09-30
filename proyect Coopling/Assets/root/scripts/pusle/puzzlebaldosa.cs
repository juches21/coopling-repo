using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlebaldosa : MonoBehaviour
{

    public bool erronea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (erronea&& collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(1, 1, 1);
        }
    }
}
