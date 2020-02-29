using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    [SerializeField]
    private bool isActive;

    private SpriteRenderer render;
    private puzzlePlateBehavior puzzle;

    private AudioManager audioManager;

    void Awake()
    {
        this.render = this.gameObject.GetComponent<SpriteRenderer>();
        this.puzzle = this.GetComponentInParent<puzzlePlateBehavior>();
        this.audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !this.isActive)
        {
            this.activate();
        }
    }







    public void activate()
    {
        this.isActive = true;
        this.render.color = Color.blue;
        this.audioManager.PlaySound("plate_activated");
        this.tellParent();
    }

    public void deactivate()
    {
        this.isActive = false;
        this.audioManager.PlaySound("plate_activated");
        this.render.color = Color.red;
    }

    public void solved()
    {
        this.render.color = Color.green;
        Destroy(this.gameObject.GetComponent<CircleCollider2D>());
    }

    private void tellParent()
    {
        puzzle.buttonActivated(this.gameObject);
    }


}
