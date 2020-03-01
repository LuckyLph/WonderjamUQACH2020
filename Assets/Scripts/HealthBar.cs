using UnityEngine;
using UnityEngine.UI;
using Harmony;

public class HealthBar : MonoBehaviour
{
  public Slider healthBar;
  private int playerHealth;

  // Start is called before the first frame update
  void Start()
  {
    playerHealth = GameObject.FindGameObjectWithTag(R.S.Tag.Player).GetComponent<Player>().health;
  }

  // Update is called once per frame
  void Update()
  {
    healthBar.value = playerHealth;
  }
}
