using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AnimationsController;
using static MovementController;

public class Punch : MonoBehaviour
{
    public Animator playerAnim;
    public AnimationClip punchAnimationClip;
    
    public void PunchAnimation()
    {
        playerAnim.SetTrigger("punch");
        StartCoroutine(PunchCoroutine());
    }

    private IEnumerator PunchCoroutine()
    {
        yield return null;
        //game waits for one frame before executing the following code
        animationsInstance.isAnimation = true;
        movementInstance.canMove = false;
        yield return new WaitForSeconds(punchAnimationClip.length);
        //game waits the duration of the animation before executing the following code
        playerAnim.ResetTrigger("punch");
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
        if (Input.GetMouseButtonDown(0) && !animationsInstance.isAnimation && movementInstance.canMove)
        {
            PunchAnimation();
        }
    }
}
