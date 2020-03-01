using UnityEngine;
using Harmony;

public class GameManager : MonoBehaviour
{
  public AI_Spawner[] AI_Spawners;
  public float numberZombieFaibleMax;
  public float numberZombieFortMax;
  public float coeficientSpawnZombiesFaibles = 0.01f;
  public float coeficientSpawnZombiesForts = 0.005f;
  private float coeficientSpawnZombiesFaiblesStable;
  private float coeficientSpawnZombiesFortsStable;

  public float coeficientSpawnDropMunition;
  public float coeficientSpawnDropVie;
  public float coeficientSpawnDropFrenzy;
  public float CoeficientSpawnDropMunition { get; set; }
  public float CoeficientSpawnDropVie { get; set; }
  public float CoeficientSpawnDropFrenzy { get; set; }
  private float coeficientSpawnDropMunitionStable;
  private float coeficientSpawnDropVieStable;
  private float coeficientSpawnDropFrenzyStable;

  public int Score { get; set; }
  public int Frenzy { get; set; }
  public bool FrenzyOn { get; private set; }
  public int maxFrenzyForMode;
  public float frenzyDuration;
  private float frenzyBaseTimer;

  private float formuleSpawnZombiesFaible;
  private float formuleSpawnZombiesForts;

  private GameObject player;
  private Vector3 playerPosition;

  private void Start()
  {
    //AudioManager.instance
  }

  private void Awake()
  {
    InvokeRepeating("UpdateFormula", 1f, 1f);
    coeficientSpawnZombiesFaiblesStable = coeficientSpawnZombiesFaibles;
    coeficientSpawnZombiesFortsStable = coeficientSpawnZombiesForts;
    coeficientSpawnDropMunitionStable = 1 - coeficientSpawnDropMunition;
    coeficientSpawnDropVieStable = 1 - coeficientSpawnDropVie;
    coeficientSpawnDropFrenzyStable = 1 - coeficientSpawnDropFrenzy;
    Score = 0;
    Frenzy = 0;
    FrenzyOn = false;
    frenzyBaseTimer = frenzyDuration;
    player = GameObject.FindGameObjectWithTag(R.S.Tag.Player).gameObject;
    playerPosition = player.transform.position;
  }

  private void Update()
  {
    playerPosition = player.transform.position;
    if (Frenzy == maxFrenzyForMode)
    {
      ModeFrenzy();
    }
    if (FrenzyOn)
    {
      frenzyDuration -= Time.deltaTime;
      if (frenzyDuration <= 0)
      {
        FrenzyOn = false;
      }
    }
  }

  private void UpdateFormula()
  {
    formuleSpawnZombiesFaible = coeficientSpawnZombiesFaibles / (1 + coeficientSpawnZombiesFaibles);
    coeficientSpawnZombiesFaibles += coeficientSpawnZombiesFaiblesStable;
    formuleSpawnZombiesForts = coeficientSpawnZombiesForts / (1 + coeficientSpawnZombiesForts);
    coeficientSpawnZombiesForts += coeficientSpawnZombiesFortsStable;
    SpawnerZombies();

    CoeficientSpawnDropMunition = 0.1f * ((1 + coeficientSpawnDropMunition) / coeficientSpawnDropMunition);
    coeficientSpawnDropMunition -= coeficientSpawnDropMunitionStable;
    CoeficientSpawnDropVie = 0.1f * ((1 + coeficientSpawnDropVie) / coeficientSpawnDropVie);
    coeficientSpawnDropVie -= coeficientSpawnDropVieStable;
    CoeficientSpawnDropFrenzy = 0.1f * ((1 + coeficientSpawnDropFrenzy) / coeficientSpawnDropFrenzy);
    coeficientSpawnDropFrenzy -= coeficientSpawnDropFrenzyStable;
  }

  private void SpawnerZombies()
  {
    //int indexSpawnerChoisi = Random.Range(0, AI_Spawners.Length);
    //AI_Spawners[indexSpawnerChoisi].NumberZombiesFaibles = (int)Mathf.Round(numberZombieFaibleMax * formuleSpawnZombiesFaible);
    //AI_Spawners[indexSpawnerChoisi].NumberZombiesForts = (int)Mathf.Round(numberZombieFortMax * formuleSpawnZombiesForts);
    //if (FrenzyOn)
    //{
    //  AI_Spawners[indexSpawnerChoisi].NumberZombiesFaibles *= 2;
    //  AI_Spawners[indexSpawnerChoisi].NumberZombiesForts *= 2;
    //}
    //AI_Spawners[indexSpawnerChoisi].Spawn_Zombies();

    float smallestDistance = 0;
    AI_Spawner spawnerChoisi = null;
    foreach (AI_Spawner ai_spawner in AI_Spawners)
    {
      float distanceBetweenPlayerAndSpawner = Vector3.Distance(ai_spawner.transform.position, player.transform.position);
      if (smallestDistance == 0)
      {
        smallestDistance = distanceBetweenPlayerAndSpawner;
        spawnerChoisi = ai_spawner;
      }
      else if (smallestDistance >= distanceBetweenPlayerAndSpawner)
      {
        smallestDistance = distanceBetweenPlayerAndSpawner;
        spawnerChoisi = ai_spawner;
      }
      //ai_spawner.NumberZombiesFaibles = (int)Mathf.Round(numberZombieFaibleMax * formuleSpawnZombiesFaible);
      //ai_spawner.NumberZombiesForts = (int)Mathf.Round(numberZombieFortMax * formuleSpawnZombiesForts);
      ai_spawner.NumberZombiesFaibles = 1;
      ai_spawner.NumberZombiesForts = 1;
      if (FrenzyOn)
      {
        ai_spawner.NumberZombiesFaibles *= 2;
        ai_spawner.NumberZombiesForts *= 2;
      }
    }
    if (spawnerChoisi)
    {
      spawnerChoisi.Spawn_Zombies();
    }
  }

  private void ModeFrenzy()
  {
    Frenzy = 0;
    FrenzyOn = true;
  }
}