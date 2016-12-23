using UnityEngine;
using System.Collections;

public class LinearShot : MonoBehaviour {

    //shortcuts
    private Rigidbody rb;
    private AttackProperties ap;

    //properties
    public float speed;
    public bool destroyOnPlayerHit, destroyOnObstacleHit;

	void Start () {
        ap = GetComponent<AttackProperties>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
	}

    void OnTriggerEnter(Collider other)
    {
        if (ap == null || rb == null) return;
        
        //ignore the owner
        if (other.gameObject != ap.getOwner())
        {
            if (other.CompareTag("Player"))
            {
                PlayerStatus ps = other.GetComponent<PlayerStatus>();
                ps.subHealth(ap.damage);
                if (destroyOnPlayerHit) Destroy(gameObject);
            }
            else if (other.CompareTag("Obstacle"))
            {
                if (destroyOnObstacleHit) Destroy(gameObject);
            }
        }
    }
}
