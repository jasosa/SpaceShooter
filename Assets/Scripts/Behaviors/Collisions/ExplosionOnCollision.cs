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

        if (gameObject.tag == "Player" && (other.CompareTag("Bolt") || other.CompareTag("Bomb")))
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
    }
}
