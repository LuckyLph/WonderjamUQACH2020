using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryJewels : MonoBehaviour
{
    [Range(0.001f,0.1f)]
    public float speed = 0.05f;
    [Range(0.001f, 1f)]
    public float distancePlace = 0.05f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject place;
    [SerializeField]
    private bool isFollowing = false;
    [SerializeField]
    private bool m_isPlaced = false;
  

    private void Awake()
    {
    }

    public bool isPlaced
    {
        get
        {
            return m_isPlaced;
        }
        set
        {
            m_isPlaced = value;
            if (OnVariableChange != null)
                OnVariableChange(this.m_isPlaced);
        }
    }
    public delegate void OnVariableChangeDelegate(bool newVal);
    public event OnVariableChangeDelegate OnVariableChange;


    [SerializeField]
    private bool moving = true;
    [SerializeField]
    public Color myColor;

    private void Update()
    {
        if (isFollowing)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.player.transform.position, speed);
        }
        if (isPlaced && moving)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.place.transform.position, speed);
            if(Vector2.Distance(this.transform.position, this.place.transform.position) <= distancePlace)
            {
                this.moving = false;
                this.transform.position = this.place.transform.position;
                this.player.GetComponent<IsCarrying>().isCarryingJewel = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<IsCarrying>().isCarryingJewel)
            {
                this.player = collision.gameObject;
                this.player.GetComponent<IsCarrying>().isCarryingJewel = true;
                AudioManager.instance.PlaySound("pick_jewel");
                this.isFollowing = true;
            }
        }
        if (collision.gameObject.tag == "JewelPlace")
        {
            if(collision.gameObject.GetComponent<SpriteRenderer>().color == this.myColor)
            {
                this.place = collision.gameObject;
                this.place.GetComponent<SpriteRenderer>().color = new Color(this.place.GetComponent<SpriteRenderer>().color.r, this.place.GetComponent<SpriteRenderer>().color.g, this.place.GetComponent<SpriteRenderer>().color.b, 0.5f);
                this.placed();
            }
        }

    }

    public void placed()
    {
        AudioManager.instance.PlaySound("place_jewel");
        Destroy(this.gameObject.GetComponent<CircleCollider2D>());
        this.isPlaced = true;
        this.isFollowing = false;
    }

}
