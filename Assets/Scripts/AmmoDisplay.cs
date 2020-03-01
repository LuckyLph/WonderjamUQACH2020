using Harmony;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
  public Text ammoDisplay;
  private int ammo;

  // Start is called before the first frame update
  void Start()
  {
    ammo = GameObject.FindGameObjectWithTag(R.S.Tag.Player).GetComponent<Player>().ammunition;
  }

  // Update is called once per frame
  void Update()
  {
    ammoDisplay.text = ammo.ToString();
  }
}
