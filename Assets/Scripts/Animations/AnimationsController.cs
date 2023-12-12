using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementController;

public class AnimationsController : MonoBehaviour
{
    public static AnimationsController animationsInstance;
    private void Awake() => animationsInstance = this;
    public Animator playerAnim;
    public bool isAnimation = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetAnimationTriggers(Vector3 direction)
    {
        if (direction.z > 0) // if moving forward
        {
            if (Input.GetKey(KeyCode.LeftShift)) // if running
            {
                if (direction.x < 0) // if moving left
                {
                    // reset all other animations
                    playerAnim.ResetTrigger("idle");
                    playerAnim.ResetTrigger("walk");
                    playerAnim.ResetTrigger("run");
                    playerAnim.ResetTrigger("left");
                    playerAnim.ResetTrigger("right");
                    playerAnim.ResetTrigger("walkback");
                    playerAnim.ResetTrigger("leftwalk");
                    playerAnim.ResetTrigger("rightwalk");
                    playerAnim.ResetTrigger("leftwalkback");
                    playerAnim.ResetTrigger("rightwalkback");
                    playerAnim.ResetTrigger("rightrun");
                    // run left on diagonal
                    playerAnim.SetTrigger("leftrun");
                }
                else if (direction.x > 0) // if moving right
                {
                    // reset all other animations
                    playerAnim.ResetTrigger("idle");
                    playerAnim.ResetTrigger("walk");
                    playerAnim.ResetTrigger("run");
                    playerAnim.ResetTrigger("left");
                    playerAnim.ResetTrigger("right");
                    playerAnim.ResetTrigger("walkback");
                    playerAnim.ResetTrigger("leftwalk");
                    playerAnim.ResetTrigger("rightwalk");
                    playerAnim.ResetTrigger("leftwalkback");
                    playerAnim.ResetTrigger("rightwalkback");
                    playerAnim.ResetTrigger("leftrun");
                    // run right on diagonal
                    playerAnim.SetTrigger("rightrun");
                }
                else // if not moving left or right
                {
                    // reset all other animations
                    playerAnim.ResetTrigger("idle");
                    playerAnim.ResetTrigger("walk");
                    playerAnim.ResetTrigger("left");
                    playerAnim.ResetTrigger("right");
                    playerAnim.ResetTrigger("walkback");
                    playerAnim.ResetTrigger("leftwalk");
                    playerAnim.ResetTrigger("rightwalk");
                    playerAnim.ResetTrigger("leftwalkback");
                    playerAnim.ResetTrigger("rightwalkback");
                    playerAnim.ResetTrigger("leftrun");
                    playerAnim.ResetTrigger("rightrun");
                    // run forward
                    playerAnim.SetTrigger("run");
                }
            }
            else // if walking (not running)
            {
                if (direction.x < 0) // if moving left
                {
                    // reset all other animations
                    playerAnim.ResetTrigger("idle");
                    playerAnim.ResetTrigger("walk");
                    playerAnim.ResetTrigger("run");
                    playerAnim.ResetTrigger("left");
                    playerAnim.ResetTrigger("right");
                    playerAnim.ResetTrigger("walkback");
                    playerAnim.ResetTrigger("rightwalk");
                    playerAnim.ResetTrigger("leftwalkback");
                    playerAnim.ResetTrigger("rightwalkback");
                    playerAnim.ResetTrigger("leftrun");
                    playerAnim.ResetTrigger("rightrun");
                    // walk left on diagonal
                    playerAnim.SetTrigger("leftwalk");
                }
                else if (direction.x > 0) // if moving right
                {
                    // reset all other animations
                    playerAnim.ResetTrigger("idle");
                    playerAnim.ResetTrigger("walk");
                    playerAnim.ResetTrigger("run");
                    playerAnim.ResetTrigger("left");
                    playerAnim.ResetTrigger("right");
                    playerAnim.ResetTrigger("walkback");
                    playerAnim.ResetTrigger("leftwalk");
                    playerAnim.ResetTrigger("leftwalkback");
                    playerAnim.ResetTrigger("rightwalkback");
                    playerAnim.ResetTrigger("leftrun");
                    playerAnim.ResetTrigger("rightrun");
                    // walk right on diagonal
                    playerAnim.SetTrigger("rightwalk");
                }
                else // if not moving left or right
                {
                    // reset all other animations
                    playerAnim.ResetTrigger("idle");
                    playerAnim.ResetTrigger("run");
                    playerAnim.ResetTrigger("left");
                    playerAnim.ResetTrigger("right");
                    playerAnim.ResetTrigger("walkback");
                    playerAnim.ResetTrigger("leftwalk");
                    playerAnim.ResetTrigger("rightwalk");
                    playerAnim.ResetTrigger("leftwalkback");
                    playerAnim.ResetTrigger("rightwalkback");
                    playerAnim.ResetTrigger("leftrun");
                    playerAnim.ResetTrigger("rightrun");
                    // walk forward
                    playerAnim.SetTrigger("walk");
                }
            }
        }
        else if (direction.z < 0) // if moving backward
        {
            
            if (direction.x < 0) // if moving left
            {
                // reset all other animations
                playerAnim.ResetTrigger("idle");
                playerAnim.ResetTrigger("walk");
                playerAnim.ResetTrigger("run");
                playerAnim.ResetTrigger("left");
                playerAnim.ResetTrigger("right");
                playerAnim.ResetTrigger("walkback");
                playerAnim.ResetTrigger("leftwalk");
                playerAnim.ResetTrigger("rightwalk");
                playerAnim.ResetTrigger("rightwalkback");
                playerAnim.ResetTrigger("leftrun");
                playerAnim.ResetTrigger("rightrun");
                // walk backward left on diagonal
                playerAnim.SetTrigger("leftwalkback");
            }
            else if (direction.x > 0) // if moving right
            {
                // reset all other animations
                playerAnim.ResetTrigger("idle");
                playerAnim.ResetTrigger("walk");
                playerAnim.ResetTrigger("run");
                playerAnim.ResetTrigger("left");
                playerAnim.ResetTrigger("right");
                playerAnim.ResetTrigger("walkback");
                playerAnim.ResetTrigger("leftwalk");
                playerAnim.ResetTrigger("rightwalk");
                playerAnim.ResetTrigger("leftwalkback");
                playerAnim.ResetTrigger("leftrun");
                playerAnim.ResetTrigger("rightrun");
                // walk backward right on diagonal
                playerAnim.SetTrigger("rightwalkback");
            }
            else // if not moving left or right
            {
                // reset all other animations
                playerAnim.ResetTrigger("idle");
                playerAnim.ResetTrigger("walk");
                playerAnim.ResetTrigger("run");
                playerAnim.ResetTrigger("left");
                playerAnim.ResetTrigger("right");
                playerAnim.ResetTrigger("leftwalk");
                playerAnim.ResetTrigger("rightwalk");
                playerAnim.ResetTrigger("leftwalkback");
                playerAnim.ResetTrigger("rightwalkback");
                playerAnim.ResetTrigger("leftrun");
                playerAnim.ResetTrigger("rightrun");
                // walk backward
                playerAnim.SetTrigger("walkback");
            }
        }
        else if (direction.x > 0) // if moving right (not forward or backward)
        {
            // reset all other animations
            playerAnim.ResetTrigger("idle");
            playerAnim.ResetTrigger("walk");
            playerAnim.ResetTrigger("run");
            playerAnim.ResetTrigger("left");
            playerAnim.ResetTrigger("walkback");
            playerAnim.ResetTrigger("leftwalk");
            playerAnim.ResetTrigger("rightwalk");
            playerAnim.ResetTrigger("leftwalkback");
            playerAnim.ResetTrigger("rightwalkback");
            playerAnim.ResetTrigger("leftrun");
            playerAnim.ResetTrigger("rightrun");
            // walk right
            playerAnim.SetTrigger("right");
        }
        else if (direction.x < 0) // if moving left (not forward or backward)
        {
            // reset all other animations
            playerAnim.ResetTrigger("idle");
            playerAnim.ResetTrigger("walk");
            playerAnim.ResetTrigger("run");
            playerAnim.ResetTrigger("right");
            playerAnim.ResetTrigger("walkback");
            playerAnim.ResetTrigger("leftwalk");
            playerAnim.ResetTrigger("rightwalk");
            playerAnim.ResetTrigger("leftwalkback");
            playerAnim.ResetTrigger("rightwalkback");
            playerAnim.ResetTrigger("leftrun");
            playerAnim.ResetTrigger("rightrun");
            // walk left
            playerAnim.SetTrigger("left");
        }
    }

    public void ResetAnimationTriggers()
    {
        // reset all other animations
        playerAnim.ResetTrigger("walk");
        playerAnim.ResetTrigger("run");
        playerAnim.ResetTrigger("left");
        playerAnim.ResetTrigger("right");
        playerAnim.ResetTrigger("walkback");
        playerAnim.ResetTrigger("leftwalk");
        playerAnim.ResetTrigger("rightwalk");
        playerAnim.ResetTrigger("leftwalkback");
        playerAnim.ResetTrigger("rightwalkback");
        playerAnim.ResetTrigger("leftrun");
        playerAnim.ResetTrigger("rightrun");
        // idle
        playerAnim.SetTrigger("idle");
    }
}
