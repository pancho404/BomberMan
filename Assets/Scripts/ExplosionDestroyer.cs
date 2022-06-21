using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{
    [SerializeField] float countdown = 2f;
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
    }
}
