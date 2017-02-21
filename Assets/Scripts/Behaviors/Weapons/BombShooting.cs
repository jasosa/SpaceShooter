using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BombShooting : MonoBehaviour
{
    public UnityEvent onBombShooted;

    public GameObject shoot;
    public Transform shootSpawn;

    private bool bombEnabled = true;

    public void ActivateBomb()
    {
        bombEnabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombEnabled)
        {
            StartCoroutine(ThrowBoomb());
        }
    }

    private IEnumerator ThrowBoomb()
    {
        for (int i = 0; i < 3; i++)
        {
            GetComponent<AudioSource>().Play();
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation *= Quaternion.Euler(0, 45, 0));
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation *= Quaternion.Euler(0, 90, 0));
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation *= Quaternion.Euler(0, 135, 0));
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation *= Quaternion.Euler(0, 180, 0));
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation *= Quaternion.Euler(0, 225, 0));
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation *= Quaternion.Euler(0, 270, 0));
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation *= Quaternion.Euler(0, 315, 0));
            yield return new WaitForSeconds(0.2f);
        }

        bombEnabled = false;
        onBombShooted.Invoke();
    }
}