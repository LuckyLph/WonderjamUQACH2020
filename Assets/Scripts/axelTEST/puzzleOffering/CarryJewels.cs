using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private bool isFollowing = false;


    private void Update()
    {
        if (isFollowing)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.player.transform.position, 0.5f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding !");
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<IsCarrying>().isCarryingJewel)
            {
                this.player = collision.gameObject;
                this.isFollowing = true;
                
            }
        }
    }

    public void placed()
    {
        Destroy(this.gameObject.GetComponent<CircleCollider2D>());
        this.isFollowing = false;
    }

}
