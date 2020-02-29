using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ScreenShake shake;
    public int bulletDamage;
    public float bulletTime, bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletTime);
        shake = GameObject.Find("Main Camera").GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(this.bulletDamage);
            Destroy(this.gameObject);
            shake.TriggerShake();
        }
    }
}
