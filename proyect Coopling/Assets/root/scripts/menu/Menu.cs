using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu, instruciones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jugador1()
    {
        SceneManager.LoadScene("mapa1");

    }
    public void jugador2()
    {
        menu.SetActive(false);
        instruciones.SetActive(true);
    }
    public void salir()
    {
        Application.Quit();

    }
}
