using UnityEngine;

public class AI_Attack : MonoBehaviour
{
  //public float timer;
  //// Update is called once per frame
  //void Update()
  //{
  //  timer -= Time.deltaTime;
  //  if (timer <= 0.0f)
  //  {
  //    TimerEnded();
  //  }
  //}

  //void TimerEnded()
  //{
  //  gameObject.GetComponent<BoxCollider2D>().enabled = true;
  //}

  private void OnTriggerEnter2D(Collider2D collider)
  {

  }

  public void AttackEnded()
  {
    Destroy(gameObject);
  }
}