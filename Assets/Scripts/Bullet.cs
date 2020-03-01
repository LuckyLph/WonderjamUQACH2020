using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Player player;
    public int bulletDamage;
    public float bulletTime, bulletSpeed;
    // Start is called before the first frame update
    

    private void Awake()
    {
        player = Object.FindObjectOfType<Player>();
    }
    void Start()
    {
        Destroy(gameObject, player.weapons[player.index].bulletTime);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(player.varWeapon[player.index].bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Target")
        {
            targetBehaviour target = collision.gameObject.GetComponent<targetBehaviour>();
            target.TakeDamage(player.varWeapon[player.index].bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
    }*/
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Enemy>().TakeDamage(player.weapons[player.index].bulletDamage);
        }
        else if(other.gameObject.tag == "Target")
        {
            targetBehaviour target = other.gameObject.GetComponent<targetBehaviour>();
            target.TakeDamage(player.weapons[player.index].bulletDamage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
    
}
