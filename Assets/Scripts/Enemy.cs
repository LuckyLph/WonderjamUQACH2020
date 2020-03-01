using UnityEngine;

public class Enemy : MonoBehaviour
{
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
    if (health <= 0)
    {
      gameManager.score += score;
      Destroy(gameObject);
      DropMunition();
      DropVie();
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
    float rand = Random.value;
    if (rand <= gameManager.CoeficientSpawnDropVie)
    {
      GameObject d = Instantiate(dropFrenzy) as GameObject;
      d.transform.position = transform.position;
    }
  }
}
