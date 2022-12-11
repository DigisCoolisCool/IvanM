using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNPC : MonoBehaviour
{
    public int health;
    public GameObject lastSmoke;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    public void GotHit()
    {
        health-=5;
    }

    public void DestroyNPC()
    {
        GameObject smoke = Instantiate(lastSmoke, transform.position, Quaternion.identity);
        Destroy(smoke, 3);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) DestroyNPC();
    }
}
