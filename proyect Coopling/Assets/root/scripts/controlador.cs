using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class controlador : MonoBehaviour
{

    public static controlador Controlador;

    // Start is called before the first frame update



    [SerializeField] private TMP_Text timerText;
    public float fallos = 1f;


    [SerializeField, Tooltip("Tiempo en segundos")] private float timerTime;
    private int minutes, seconds, cents;


    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {

        timerTime += Time.deltaTime * fallos;

        /*if (timerTime < 0) timerTime = 0;

        timerText.text = timerTime.ToString();

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);
        cents = (int)((timerTime - (int)timerTime) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);

        */
    }

    void contarfallos()
    {
        print("contar");
        fallos += 0.5f;

    }
}
