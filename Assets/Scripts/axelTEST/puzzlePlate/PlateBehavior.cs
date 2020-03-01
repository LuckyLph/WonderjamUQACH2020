using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    [SerializeField]
    private bool isActive;

    public Sprite button_up;
    public Sprite button_down;

    private SpriteRenderer render;
    private puzzlePlateBehavior puzzle;
  

    void Awake()
    {
        this.render = this.gameObject.GetComponent<SpriteRenderer>();
        this.puzzle = this.GetComponentInParent<puzzlePlateBehavior>();
        this.render.sprite = this.button_up;
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
        this.render.sprite = this.button_down;
        this.isActive = true;
        //this.render.color = Color.blue;
        AudioManager.instance.PlaySound("plate_activated");
        this.tellParent();
    }

    public void deactivate()
    {
        this.render.sprite = this.button_up;
        this.isActive = false;
        AudioManager.instance.PlaySound("plate_activated");
        //this.render.color = Color.red;
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
