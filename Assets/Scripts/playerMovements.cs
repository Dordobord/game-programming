using UnityEngine;

public class playerMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anima;
    private bool grounded;

    private void Awake()
    {
        // References for (Rigidbody, Animator)
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }
 
    private void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift)) //Shift to Run
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.velocity.y); //x Axis movement

        if(horizontalInput> 0.01f)
            transform.localScale = Vector3.one; //moves sprite to x axis

        else if(horizontalInput< -0.01f)
            transform.localScale = new Vector3(-1,1,1); // Flips sprite to the -x axis

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
 
        if(Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
        
        anima.SetBool("run", horizontalInput != 0); // Animation parameters and idle animation when not running 
        anima.SetBool("grounded", grounded);

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
        anima.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
