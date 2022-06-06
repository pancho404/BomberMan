using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] float countdown = 2f;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown<=0)
        {
            Debug.Log("BOOM");
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
    }
}
