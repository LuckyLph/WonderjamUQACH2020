using Harmony;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
  public Text ammoDisplay;
  private int ammo;
    private Player pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag(R.S.Tag.Player).GetComponent<Player>();
  }

  // Update is called once per frame
  void Update()
  {
        ammo = pl.weapons[pl.index].ammunition;

        Debug.Log(ammo);
        ammoDisplay.text = ammo.ToString();
  }
}
