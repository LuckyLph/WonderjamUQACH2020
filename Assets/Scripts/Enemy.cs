using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 0;

    private AudioManager audioManager;

    private void Awake()
    {
        this.audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        this.audioManager.PlaySound("zombie_hit");
        this.health -= damage;
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
