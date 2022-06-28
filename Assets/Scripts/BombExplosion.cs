using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] float countdown = 2f;
    [SerializeField] GameObject explosion;
    [SerializeField] ParticleSystem explosionParticles;
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
            Destroy(gameObject);
            Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
    }
}
