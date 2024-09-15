using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    [SerializeField]
    private float damage;
    [SerializeField]
    private AudioManager.ClipName clipName;
    [SerializeField]
    private float explosionSize;
    [SerializeField]
    private float explosionTime;

    private float currentSize;

    private List<GameObject> enemyList;

    private void Update() {
        currentSize += explosionSize * Time.deltaTime / explosionTime;

        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }
    
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag != "Enemy") {
            return;
        }   ;

        collision.gameObject.GetComponentInParent<Enemy>().takeDamage(this.damage);
    }

    public void Explode() {
        currentSize = 0;
        FindObjectOfType<AudioManager>().PlayAudioClip(clipName);
        Destroy(gameObject, explosionTime);
    }
}