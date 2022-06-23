using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform movePoint;

    [SerializeField] LayerMask whatStops;

    [SerializeField] Animator animator;

    Vector3 horizontal;
    Vector3 vertical;
    Vector3 arrowsH;
    Vector3 arrowsV;
    // Start is called before the first frame update

    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame

    void Update()
    {
        animator.SetBool("Moving", false);

        if (gameObject.tag == "PlayerOne")
        {
            horizontal = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            vertical = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            animator.SetFloat("Horizontal", horizontal.x);
            animator.SetFloat("magH", horizontal.magnitude);
            animator.SetFloat("Vertical", vertical.y);
            animator.SetFloat("magV", vertical.magnitude);
        }
        if (gameObject.tag == "PlayerTwo")
        {
            arrowsH = new Vector3(Input.GetAxis("ArrowsH"), 0f, 0f);
            arrowsV = new Vector3(0f, Input.GetAxis("ArrowsV"), 0f);
            animator.SetFloat("arrowsH", arrowsH.x);
            animator.SetFloat("arrowsV", arrowsV.y);
            animator.SetFloat("arrMagH", arrowsH.magnitude);
            animator.SetFloat("arrMagV", arrowsV.magnitude);
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (gameObject.tag == "PlayerOne")
            {
                if (Input.GetButton("Horizontal"))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .05f, whatStops))
                    {
                        movePoint.position += horizontal;
                        animator.SetBool("Moving", true);
                    }
                }
                else if (Input.GetButton("Vertical"))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .05f, whatStops))
                    {
                        movePoint.position += vertical;
                        animator.SetBool("Moving", true);
                    }
                }
            }
            if (gameObject.tag == "PlayerTwo")
            {
                if (Input.GetButton("ArrowsH"))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("ArrowsH"), 0f, 0f), .05f, whatStops))
                    {
                        movePoint.position += arrowsH;
                        animator.SetBool("Moving", true);
                    }
                }
                else if (Input.GetButton("ArrowsV"))
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("ArrowsV"), 0f), .05f, whatStops))
                    {
                        movePoint.position += arrowsV;
                        animator.SetBool("Moving", true);
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (gameObject.tag == "PlayerOne")
        {
            FindObjectOfType<LoadScene>().LoadTwoWins();
        }
        if (gameObject.tag == "PlayerTwo")
        {
            FindObjectOfType<LoadScene>().LoadOneWins();
        }
    }
}
