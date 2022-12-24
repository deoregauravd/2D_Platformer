using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
// instance 
    private static Player instance;
    public static Player Instance { get {return instance;}}

    private Rigidbody2D rb;
    private float dirX = 0f;
    private float Movespeed = 6f;
    private float JumpSpeed = 10f;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask Jumpableground;
    private Animator anim;
    private SpriteRenderer sprite;
    private enum MovementState { idle, running, jumping, falling }
    private float lockpos = 0;
    private GameObject player;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * Movespeed, rb.velocity.y);
        transform.rotation = Quaternion.Euler(lockpos, lockpos, lockpos);
        

        if (CrossPlatformInputManager.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

        UpdateAnimatorAnimation();
    }


private void UpdateAnimatorAnimation()
    {
        MovementState state;

        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, Jumpableground);
    }
}
