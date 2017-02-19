using UnityEngine;

public class ExplosionOnCollision : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (gameObject.tag == "EnemyShip" && other.tag == "EnemyBolt")
        {
            return;
        }

        if (gameObject.tag == "EnemyShip" && other.tag.StartsWith("asteroid"))
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);        
    }
}
