using System.Collections;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(LoopAnimation());
    }

    IEnumerator LoopAnimation()
    {
        while(true)
        {
            animator.SetBool("Crouch", true);
            yield return new WaitForSeconds(1f);

            animator.SetBool("Crouch", false);
            yield return new WaitForSeconds(1f);

            animator.SetBool("OnGround", false);
            yield return new WaitForSeconds(1f);

            animator.SetBool("OnGround", true);
            yield return new WaitForSeconds(1f);
        }
    }
}
