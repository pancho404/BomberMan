using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTwoMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Transform movePoint;

    [SerializeField] LayerMask whatStops;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("ArrowsH")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("ArrowsH"), 0f, 0f), .05f, whatStops))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("ArrowsH"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("ArrowsV")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("ArrowsV"), 0f), .05f, whatStops))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("ArrowsV"), 0f);
                }
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Destroy(gameObject);
        SceneManager.LoadScene("OneWins");
    }
}
