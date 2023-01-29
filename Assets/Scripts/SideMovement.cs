using UnityEngine;

public class SideMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        speed = 4.5f;
        //Grab references from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one * 5;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-5,5,5);

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded())
            Jump();

        if( (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))  && (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
            body.velocity = new Vector2(0, body.velocity.y);

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed*2);
        anim.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        return;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2 (transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

}
