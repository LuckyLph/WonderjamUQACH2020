using UnityEngine;
using UnityEngine.UI;

public class FrenzyDisplay : MonoBehaviour
{
  public Text frenzyDisplay;
  private GameManager gameManager;

  // Start is called before the first frame update
  void Awake()
  {
    gameManager = FindObjectOfType<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    if (gameManager != null)
    {
      frenzyDisplay.enabled = gameManager.FrenzyOn;
    }
  }
}
