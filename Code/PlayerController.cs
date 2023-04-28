using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    //private GameManager gameManager;
    private Animator animator;
    private Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }
    
    private void InitVariables()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x < 0)
        {
            sr.flipX = true;
        }
        else if(direction.x > 0)
        {
            sr.flipX = false;
        }
        
        // Setting the variables in Animator
        // used for playing animation of walk in right direction
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
    
    private void FixedUpdate()
    {
        // moving player Up/Down/Left/Right
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
