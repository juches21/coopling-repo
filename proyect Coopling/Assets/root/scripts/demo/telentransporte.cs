using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telentransporte : MonoBehaviour
{
    public int portal;
    public GameObject ancla; 
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
        if (portal==1)
        {
            other.transform.position = ancla.transform.position;
            other.transform.rotation = ancla.transform.rotation;
        }
    }
}
