using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;

    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 targetPos;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Init()
    {
        transform.position = pointA.position;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.Log("Animator is null in spider");
        }
    }

    public virtual void Start()
    {
        Init();
    }

    protected virtual void Attack()
    {

    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    private void Movement()
    {
        if (targetPos == pointA.position)
        {
            spriteRenderer.flipX = true;

        }
        else if (targetPos == pointB.position)
        {
            spriteRenderer.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            targetPos = pointB.position;
            animator.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            targetPos = pointA.position;
            animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

}
