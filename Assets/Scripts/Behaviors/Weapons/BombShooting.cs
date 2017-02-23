using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BombShooting : MonoBehaviour
{
    public UnityEvent onBombShooted;

    public GameObject sphere;
    public Transform sphereTransform;

    private bool bombEnabled = true;
    private int scaleRate = 30;

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
        bombEnabled = false;
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < 30; i++)
        {           
            sphereTransform.localScale += new Vector3(scaleRate, scaleRate, scaleRate) * Time.deltaTime;           
            yield return new WaitForSeconds(0.01f);
        }

        sphereTransform.localScale = new Vector3(0, 0, 0);        
        onBombShooted.Invoke();
    }
}