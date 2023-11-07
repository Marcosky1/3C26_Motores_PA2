using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    public Rigidbody2D myRB;
    [SerializeField] private float speed;
    public int player_lives = 4;
    // Start is called before the first frame update
    void Start()
    {     
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    private void Update()
    {
        float translacion = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("UP");
            translacion = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            translacion = -1f;
            Debug.Log("DOWN");
        }
        else
        {
            translacion = 0f;
        }

        myRB.velocity = new Vector2(0, translacion * speed);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {

        Debug.Log("On Movement");
        Debug.Log(context.ReadValue<float>());

        float Direccion = context.ReadValue<float>() * speed;
        transform.position = new Vector2(transform.position.x,transform.position.y + Direccion);
    }   

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }if(other.tag == "Enemy")
        {
            EnemyGenerator.instance.ManageEnemy(other.gameObject.GetComponent<EnemyController>(),this);
        }
    }
}
