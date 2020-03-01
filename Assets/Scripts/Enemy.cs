using UnityEngine;

public class Enemy : MonoBehaviour
{
  private bool hasTakenDamage = false;
  public int health = 0;
  public int score = 100;
  public GameObject dropMunition;
  public GameObject dropVie;
  public GameObject dropFrenzy;
  private GameManager gameManager;
  private AudioManager audioManager;

  private void Awake()
  {
    gameManager = FindObjectOfType<GameManager>();
    audioManager = FindObjectOfType<AudioManager>();
  }

  public void TakeDamage(int damage)
  {
    audioManager.PlaySound("zombie_hit");
    health -= damage;
    Debug.Log(health);
    if (health <= 0)
    {
      gameManager.Score += score;
      DropMunition();
      DropVie();
      DropFrenzy();
      hasTakenDamage = true;
      Debug.Log("not cool" + health);
      Destroy(gameObject);
    }
  }

  private void DropMunition()
  {
    float rand = Random.value;
    if (rand <= gameManager.CoeficientSpawnDropMunition)
    {
      GameObject d = Instantiate(dropMunition) as GameObject;
      d.transform.position = transform.position;
    }
  }

  void OnDestroy(){
    if (hasTakenDamage)
    {
      Debug.Log("hasTakenDamage");
      //gameManager.score += score;
      //DropMunition();
      //DropVie();
      //DropFrenzy();
    }
  }

  private void DropVie()
  {
    float rand = Random.value;
    if (rand <= gameManager.CoeficientSpawnDropVie)
    {
      GameObject d = Instantiate(dropVie) as GameObject;
      d.transform.position = transform.position;
    }
  }

  private void DropFrenzy()
  {
    if (!gameManager.FrenzyOn)
    {
      float rand = Random.value;
      if (rand <= gameManager.CoeficientSpawnDropVie)
      {
        GameObject d = Instantiate(dropFrenzy) as GameObject;
        d.transform.position = transform.position;
      }
    }
  }
}
