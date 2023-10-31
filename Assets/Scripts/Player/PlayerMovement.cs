using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private SpriteRenderer swordArcSprite;
    private PlayerAnim playerAnim;

    private Vector2 swordArcPos;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool isGrounded = false;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
        swordArcSprite = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        playerAnim = GetComponentInChildren<PlayerAnim>();
        boxCollider = GetComponent<BoxCollider2D>();
        swordArcPos = swordArcSprite.transform.localPosition;
    }

    void FixedUpdate()
    {
        GroundCheck();


        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            playerAnim.HandleJumpAnim(isJumping);
            rb.AddForce(jumpForce * Time.deltaTime * Vector2.up, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        Movement();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
        {
            playerAnim.AttackAnim();
        }
    }

    private void GroundCheck()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, 1 << 8);

        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), Color.yellow);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), Color.yellow);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraHeight), Vector2.right * (boxCollider.bounds.extents.x), Color.yellow);


        if (hit.collider != null) // when you hit collider(ground)
        {
            isJumping = false;
            playerAnim.HandleJumpAnim(isJumping);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        playerAnim.IsRunning(horizontalInput);
        FlipSprite(horizontalInput);

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private void FlipSprite(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            sprite.flipX = true;
            swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;
            swordArcSprite.transform.localPosition = new Vector3(swordArcPos.x * -1, swordArcPos.y);
        }
        else if (horizontalInput > 0)
        {
            sprite.flipX = false;
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;
            swordArcSprite.transform.localPosition = new Vector3(swordArcPos.x, swordArcPos.y);
        }
    }
}