using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Behavior());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        var new_bullet = Instantiate(bullet,
                     transform.position + transform.rotation * new Vector3(0, 0, 3),
                     transform.rotation);
        new_bullet = Instantiate(bullet,
                     transform.position - transform.rotation * new Vector3(0, 0, 3),
                     transform.rotation*Quaternion.Euler(0,180,0));

        new_bullet = Instantiate(bullet,
                     transform.position + Quaternion.Euler(0, 90, 0)* transform.rotation * new Vector3(0, 0, 3),
                     transform.rotation * Quaternion.Euler(0, 90, 0));
        new_bullet = Instantiate(bullet,
                     transform.position + Quaternion.Euler(0, -90, 0) * transform.rotation * new Vector3(0, 0, 3),
                     transform.rotation * Quaternion.Euler(0, -90, 0));
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Rotate(float degrees, float velocity)
    {
        float t = 0;
        while (t < degrees)
        {
            float dt = velocity * Time.deltaTime;
            if (t + dt > degrees)
            {
                dt = degrees - t;
            }
            transform.Rotate(0, dt, 0);
            t += dt;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Behavior()
    { 
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(0.5f);
            yield return Rotate(45, 90);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
