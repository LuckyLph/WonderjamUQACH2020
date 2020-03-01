using UnityEngine;

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

  public int score;

  private float formuleSpawnZombiesFaible;
  private float formuleSpawnZombiesForts;

  private void Awake()
  {
    InvokeRepeating("UpdateFormula", 1f, 1f);
    coeficientSpawnZombiesFaiblesStable = coeficientSpawnZombiesFaibles;
    coeficientSpawnZombiesFortsStable = coeficientSpawnZombiesForts;
    coeficientSpawnDropMunitionStable = 1 - coeficientSpawnDropMunition;
    coeficientSpawnDropVieStable = 1 - coeficientSpawnDropVie;
    coeficientSpawnDropFrenzyStable = 1 - coeficientSpawnDropFrenzy;
    score = 0;
  }

  private void UpdateFormula()
  {
    formuleSpawnZombiesFaible = coeficientSpawnZombiesFaibles / (1 + coeficientSpawnZombiesFaibles);
    coeficientSpawnZombiesFaibles += coeficientSpawnZombiesFaiblesStable;
    formuleSpawnZombiesForts = coeficientSpawnZombiesForts / (1 + coeficientSpawnZombiesForts);
    coeficientSpawnZombiesForts += coeficientSpawnZombiesFortsStable;
    foreach (AI_Spawner ai_spawner in AI_Spawners)
    {
      ai_spawner.NumberZombiesFaibles = (int)Mathf.Round(numberZombieFaibleMax * formuleSpawnZombiesFaible);
      ai_spawner.NumberZombiesForts = (int)Mathf.Round(numberZombieFortMax * formuleSpawnZombiesForts);
      ai_spawner.Spawn_Zombies();
    }

    CoeficientSpawnDropMunition = 0.1f * ((1 + coeficientSpawnDropMunition) / coeficientSpawnDropMunition);
    coeficientSpawnDropMunition -= coeficientSpawnDropMunitionStable;
    CoeficientSpawnDropVie = 0.1f* ((1 + coeficientSpawnDropVie) / coeficientSpawnDropVie);
    coeficientSpawnDropVie -= coeficientSpawnDropVieStable;
    CoeficientSpawnDropFrenzy = 0.1f * ((1 + coeficientSpawnDropFrenzy) / coeficientSpawnDropFrenzy);
    coeficientSpawnDropFrenzy -= coeficientSpawnDropFrenzyStable;
  }
}