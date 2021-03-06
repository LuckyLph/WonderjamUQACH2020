﻿using UnityEngine;

public class AI_Spawner : MonoBehaviour
{
  public GameObject zombieFaible;
  public GameObject zombieFort;
  public int NumberZombiesFaibles { get; set; }
  public int NumberZombiesForts { get; set; }

  private int compteur = 0;

  // Start is called before the first frame update
  private void Awake()
  {
    NumberZombiesFaibles = 1;
    NumberZombiesForts = 0;
    //Spawn_Zombies();
  }

  public void Spawn_Zombies()
  {
    for (int i = 0; i < NumberZombiesFaibles; i++)
    {
      GameObject z = Instantiate(zombieFaible) as GameObject;
      z.transform.position = transform.position;
    }
    for (int i = 0; i < NumberZombiesForts; i++)
    {
      GameObject z = Instantiate(zombieFort) as GameObject;
      z.transform.position = transform.position;
    }

  }
}