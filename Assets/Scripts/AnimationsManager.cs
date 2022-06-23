using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    [SerializeField] Animator playerOneAnimator;
    [SerializeField] Animator playerTwoAnimator;
    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;
    // Update is called once per frame
    void Update()
    {
        if (playerOneAnimator && playerTwoAnimator)
        {

            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                playerOneAnimator.SetTrigger("Right");
            }
            if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                playerOneAnimator.SetTrigger("Left");               
            }
            if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
            {
                playerOneAnimator.SetTrigger("Idle");
            }
            if (Input.GetAxisRaw("Vertical") == 1f)
            {
                playerOneAnimator.SetTrigger("Up");
            }
            if (Input.GetAxisRaw("Vertical") == -1f)
            {
                playerOneAnimator.SetTrigger("Down");
            }

            if (Input.GetAxisRaw("ArrowsH") == 1f)
            {
                playerTwoAnimator.SetTrigger("Right");
            }
            if (Input.GetAxisRaw("ArrowsH") == -1f)
            {
                playerTwoAnimator.SetTrigger("Left");
            }
            if (Input.GetAxisRaw("ArrowsH") == 0f && Input.GetAxisRaw("ArrowsV") == 0f)
            {
                playerTwoAnimator.SetTrigger("Idle");
            }
            if (Input.GetAxisRaw("ArrowsV") == 1f)
            {
                playerTwoAnimator.SetTrigger("Up");
            }
            if (Input.GetAxisRaw("ArrowsV") == -1f)
            {
                playerTwoAnimator.SetTrigger("Down");
            }
        }
    }
}
