using UnityEngine;
using Harmony;

public class AI : MonoBehaviour
{
  public GameObject attack;
  public float timerBeforeAttackingAgain;
  public float baseTimer;
  private AudioManager audioManager;

  private void Awake()
  {
    audioManager = FindObjectOfType<AudioManager>();
  }

  private void Update()
  {
    timerBeforeAttackingAgain -= Time.deltaTime;
  }

  private void OnTriggerStay2D(Collider2D collider)
  {
    if (collider.tag == R.S.Tag.Player )
    {
      InstantiateAttack();
    }
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.tag == R.S.Tag.Player)
    {
      InstantiateAttack();
    }
  }

  private void InstantiateAttack()
  {
    if (timerBeforeAttackingAgain <= 0.0f)
    {
      gameObject.GetComponentInChildren<Animator>().SetBool("IsAttacking", true);
      timerBeforeAttackingAgain = baseTimer;
      GameObject a = Instantiate(attack, transform) as GameObject;
      audioManager.PlaySound("ennemie_punch");
      a.transform.position = transform.position;
      a.transform.rotation = transform.rotation;
    }
  }
}