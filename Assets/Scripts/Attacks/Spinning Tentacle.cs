using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningTentacle : MonoBehaviour
{
    private AudioManager audioManager;

    //[SerializeField] GameObject TentacleGraphics;

    public float spinSpeed = 10;
    public float lifetime = 1.0f;

    public float damage = 1.0f; 

    // Start is called before the first frame update
    void Awake()
    {
        this.audioManager = FindObjectOfType<AudioManager>();
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, spinSpeed * 50 * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider collision) {
        Debug.Log($"Collided with {collision.gameObject.name}");
        if (collision.gameObject.tag != "Enemy") {
            return;
        }


        collision.gameObject.GetComponentInParent<Enemy>().takeDamage(this.damage);
        audioManager.PlayAudioClip(AudioManager.ClipName.projectileHit);
 

    }
}
