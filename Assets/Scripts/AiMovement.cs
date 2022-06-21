using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] LayerMask whatStops;
    [SerializeField] Animator playerTwoAnimator;
    private float countdown = 2f;


    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (gameObject && player)
        {
            //playerTwoAnimator.SetTrigger("Idle");
            if (countdown <= 0)
            {
                if (!Physics2D.OverlapCircle(gameObject.transform.position + new Vector3(0f, 1f, 0f), .05f, whatStops) && !Physics2D.OverlapCircle(gameObject.transform.position + new Vector3(0f, -1f, 0f), .05f, whatStops))
                {
                    if (gameObject.transform.position.y < player.transform.position.y)
                    {
                        gameObject.transform.position += new Vector3(0f, 1f, 0f);
                        playerTwoAnimator.SetTrigger("Up");
                    }
                    if (gameObject.transform.position.y > player.transform.position.y)
                    {
                        gameObject.transform.position += new Vector3(0f, -1f, 0f);
                        playerTwoAnimator.SetTrigger("Down");
                    }
                }
                if (!Physics2D.OverlapCircle(gameObject.transform.position + new Vector3(1f, 0f, 0f), .05f, whatStops) && !Physics2D.OverlapCircle(gameObject.transform.position + new Vector3(-1f, 0f, 0f), .05f, whatStops))
                {
                    if (gameObject.transform.position.x < player.transform.position.x)
                    {
                        gameObject.transform.position += new Vector3(1f, 0f, 0f);
                        playerTwoAnimator.SetTrigger("Right");
                    }
                    if (gameObject.transform.position.x > player.transform.position.x)
                    {
                        gameObject.transform.position += new Vector3(-1f, 0f, 0f);
                        playerTwoAnimator.SetTrigger("Left");
                    }
                }
                countdown = 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Destroy(gameObject);
            FindObjectOfType<LoadScene>().LoadOneWins();
        }
        if (collision.tag == "PlayerOne")
        {
            Destroy(player);
            FindObjectOfType<LoadScene>().LoadTwoWins();
        }
    }
}
