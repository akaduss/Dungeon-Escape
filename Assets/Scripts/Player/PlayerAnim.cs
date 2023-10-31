using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private Animator swordArcAnimator;


    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponentInChildren<Animator>();
        swordArcAnimator = transform.GetChild(1).GetComponent<Animator>();
    }


    public void IsRunning(float horizontalInput)
    {
        if (horizontalInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
            animator.SetBool("IsRunning", false);
    }

    public void HandleJumpAnim(bool isJumping)
    {
        if (isJumping)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    public void AttackAnim()
    {
        animator.SetTrigger("Attacking");
        swordArcAnimator.SetTrigger("SwordEffect");
    }

}
