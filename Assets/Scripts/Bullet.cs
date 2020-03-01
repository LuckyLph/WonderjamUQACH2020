using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Player player;
    public int bulletDamage;
    public float bulletTime, bulletSpeed;
    // Start is called before the first frame update

    private AudioManager audioManager;

    private void Awake()
    {
        player = Object.FindObjectOfType<Player>();
        this.audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        Destroy(gameObject, player.varWeapon[player.index].bulletTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(player.varWeapon[player.index].bulletDamage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Target")
        {
            targetBehaviour target = collision.gameObject.GetComponent<targetBehaviour>();
            target.TakeDamage(player.varWeapon[player.index].bulletDamage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Target")
        {
            Destroy(this.gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(player.varWeapon[player.index].bulletDamage);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Target")
        {
            targetBehaviour target = other.gameObject.GetComponent<targetBehaviour>();
            target.TakeDamage(player.varWeapon[player.index].bulletDamage);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
    
}
