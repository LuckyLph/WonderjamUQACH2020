using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
  public Text scoreDisplay;
  private int score;
  private GameManager gameManager;

  // Start is called before the first frame update
  void Awake()
  {
    gameManager = FindObjectOfType<GameManager>();
    score = gameManager.Score;
  }

  // Update is called once per frame
  void Update()
  {
    scoreDisplay.text = score.ToString();
  }
}
