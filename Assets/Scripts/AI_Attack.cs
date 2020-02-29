using UnityEngine;

public class AI_Attack : MonoBehaviour
{
  public void AttackEnded()
  {
    Destroy(gameObject);
  }
}