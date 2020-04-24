using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    public int liveTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(killInSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    IEnumerator killInSeconds()
    {
        yield return new WaitForSeconds(liveTime);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
