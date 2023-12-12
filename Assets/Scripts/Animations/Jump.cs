using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AnimationsController;
using static MovementController;

public class Jump : MonoBehaviour
{
    public Animator playerAnim;
    public AnimationClip jumpAnimationClip;
    
    public void JumpAnimation()
    {
        playerAnim.SetTrigger("jump");
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        yield return null;
        //game waits for one frame before executing the following code
        animationsInstance.isAnimation = true;
        //movementInstance.canMove = false;
        yield return new WaitForSeconds(jumpAnimationClip.length);
        //game waits the duration of the animation before executing the following code
        playerAnim.ResetTrigger("jump");
		movementInstance.jumped = false;
        animationsInstance.isAnimation = false;
        movementInstance.canMove = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movementInstance.jumped && !animationsInstance.isAnimation && movementInstance.canMove)
        {
            JumpAnimation();
            movementInstance.jumped = false;
        }
    }
}