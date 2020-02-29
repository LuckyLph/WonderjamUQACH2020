using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int bulletDamage;
    public float bulletTime, bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.takeDamage(this.bulletDamage);
            Destroy(this.gameObject);
        }
    }
}
