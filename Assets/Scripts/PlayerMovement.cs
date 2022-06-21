using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform movePoint;

    [SerializeField] LayerMask whatStops;

    Animator animator;

    // Start is called before the first frame update

    void Start()
    {
        movePoint.parent = null;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 horizontal = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        Vector3 arrowsH = new Vector3(Input.GetAxisRaw("ArrowsH"), 0f, 0f);
        Vector3 vertical = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        Vector3 arrowsV = new Vector3(0f, Input.GetAxisRaw("ArrowsV"), 0f);
        animator.SetFloat("Horizontal", horizontal.x);
        animator.SetFloat("ArrowsH", arrowsH.x);
        animator.SetFloat("Vertical", vertical.y);
        animator.SetFloat("ArrowsV", arrowsV.y);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (gameObject.tag == "PlayerOne")
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .05f, whatStops))
                    {
                        movePoint.position += horizontal;
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .05f, whatStops))
                    {
                        movePoint.position += vertical;
                    }
                }
            }
            if (gameObject.tag == "PlayerTwo")
            {
                if (Mathf.Abs(Input.GetAxisRaw("ArrowsH")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("ArrowsH"), 0f, 0f), .05f, whatStops))
                    {
                        movePoint.position += horizontal;
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("ArrowsV")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("ArrowsV"), 0f), .05f, whatStops))
                    {
                        movePoint.position += vertical;
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
