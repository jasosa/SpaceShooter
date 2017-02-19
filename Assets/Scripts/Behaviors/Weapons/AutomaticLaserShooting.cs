using UnityEngine;

public class AutomaticLaserShooting : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fire()
    {
        audioSource.Play();
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
