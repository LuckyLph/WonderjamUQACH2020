using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickPowerUp : MonoBehaviour
{
    private GameManager gm;
    private Player pl;

    private List<Player> pla = new List<Player>();

    

    private void Awake()
    {
        this.gm = GameObject.FindObjectOfType<GameManager>();
        this.pl = GameObject.FindObjectOfType<Player>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (this.tag)
            {
                case "lifeDrop":
                    this.pl.health++;
                    Debug.Log(this.tag);
                    break;
                case "ammoDrop":
                    foreach (var weap in this.pl.weapons)
                    {
                        weap.ammunition += 20;
                    }
                    Debug.Log(this.tag);
                    break;
                case "frenzyDrop":
                    Debug.Log(this.tag);
                    this.pl.frenzy+=10;
                    break;
                default:
                    break;
            }
            //playsound
            Destroy(this.gameObject);
        }
    }




}
