using UnityEngine;

public class AI : MonoBehaviour
{
  public GameObject attack;

  private void OnTriggerEnter2D(Collider2D player)
  {
    Debug.Log("collider detected");
    GameObject a = Instantiate(attack) as GameObject;
  }
}