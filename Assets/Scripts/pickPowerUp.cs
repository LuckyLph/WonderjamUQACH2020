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
                case "Shotgun":
                    pl.weapons.Add(new Weapon("Shotgun", 60, 30, 3, 20, 0.2f, 200));
                    break;
                case "Rifle":
                    pl.weapons.Add(new Weapon("Rifle", 1000, 5, 1, 20, 1, 1000));
                    break;
                default:
                    break;

            }
            //playsound
            Destroy(this.gameObject);
        }
    }




}
