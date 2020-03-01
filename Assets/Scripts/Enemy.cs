using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int health = 0;
  public GameObject dropMunition;
  public GameObject dropVie;
  private GameManager gameManager;

  // Update is called once per frame
  void Awake()
  {
    gameManager = FindObjectOfType<GameManager>();
  }

  public void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0)
    {
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
}
