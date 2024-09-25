using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class character : MonoBehaviour
{

    private Rigidbody player_rb;
    public PlayerInput playerInput;
    private Vector2 meveinput;
    private Vector2 rotacion;

    Vector3 direccion;


    public float speed;
    public float jumpforce;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent <Rigidbody>();
        playerInput = GetComponent<PlayerInput>();


    }

    // Update is called once per frame
    void Update()
    {
   
        if (rotacion.x != 0)
        {

        //gameObject.transform.rotation = Quaternion.Euler(0, rotacion.x * 360, 0);
            transform.rotation = transform.rotation * Quaternion.Euler(0, rotacion.x, 0);

        }
    }
    private void FixedUpdate()
    {
       // player_rb.velocity = new Vector3(meveinput.x * speed, player_rb.velocity.y, meveinput.y * speed);
        direccion = meveinput.y * transform.forward + meveinput.x * transform.right;

        player_rb.velocity = direccion * speed + new Vector3(0, player_rb.velocity.y, 0);

    }
    public void mov(InputAction.CallbackContext context)
    {
        print("mov");
        meveinput = context.ReadValue<Vector2>();
    }
    public void rotar(InputAction.CallbackContext context)
    {
        print("mov");

        rotacion = context.ReadValue<Vector2>();
      
    }














  
}
