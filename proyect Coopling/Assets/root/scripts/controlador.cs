using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class controlador : MonoBehaviour
{

    public static controlador Controlador;

    // Start is called before the first frame update

    public static controlador instancia;

    bool play=true;
    [SerializeField] private TMP_Text timerText;
    public float fallos = 1f;


    [SerializeField, Tooltip("Tiempo en segundos")] private float timerTime;
    private int minutes, seconds, cents;

    void Awake()
    {
        // Implementar el patrón singleton
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cargar una nueva escena
        }
        else if (instancia != this)
        {
            Destroy(gameObject); // Destruir la nueva instancia si ya existe una
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        fallos = 1f;


    }

    // Update is called once per frame
    void Update()
    {
        if (play){

        timerTime += Time.deltaTime * fallos;

        /*if (timerTime < 0) timerTime = 0;

        timerText.text = timerTime.ToString();

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);
        cents = (int)((timerTime - (int)timerTime) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);

        */
        if(timerTime>= 1200)
        {
                play = false;
        }
        print(timerTime);
        }
        else
        {
            finjuego();
        }
    }

    public void contarfallos()
    {
        if(fallos >= 2.5f)
        {
            play = false;
        }
        else
        {
        fallos += 1f;

        }

    }
    public void finjuego()
    {
        print("dead");
    }
}

