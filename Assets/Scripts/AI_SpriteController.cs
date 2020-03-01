using UnityEngine;

public class AI_SpriteController : MonoBehaviour
{
  public Animator animator;

  public void AttackEnd()
  {
    animator.SetBool("IsAttacking", false);
  }
}