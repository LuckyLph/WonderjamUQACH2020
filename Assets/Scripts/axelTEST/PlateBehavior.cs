using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    [SerializeField]
    private bool isActive;

    private SpriteRenderer render;
    private puzzlePlateBehavior puzzle;

    void Awake()
    {
        this.render = this.gameObject.GetComponent<SpriteRenderer>();
        this.puzzle = this.GetComponentInParent<puzzlePlateBehavior>();
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
        this.tellParent();
    }

    public void deactivate()
    {
        this.isActive = false;
        this.render.color = Color.red;
    }

    private void tellParent()
    {
        puzzle.buttonActivated(this.gameObject);
    }


}
