using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPuzzleBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    [SerializeField]
    private bool puzzleSolved = false;
  

    public GameObject[] doorToOpen;


    void Awake()
    {

        foreach (Transform child in this.transform) //recupere les enfants (tt les boutons)
        {
            this.targets.Add(child.gameObject);
        }
        for (int index = 0; index < targets.Count; index++) //mélange l'ordre des boutons
        {
            int randomIndex = Random.Range(index, this.targets.Count);

            GameObject temp = this.targets[index];

            this.targets[index] = this.targets[randomIndex];
            this.targets[randomIndex] = temp;
        }
    }

    public void targetActivated(GameObject targetActivated)
    {
        foreach (GameObject target in this.targets)
        {
            if (!target.GetComponent<targetBehaviour>().isActive)
            {
                return;
            }
        }

        this.puzzleSolved = true;
        AudioManager.instance.PlaySound("puzzle_solved");

        foreach (GameObject target in this.targets)
        {
            target.GetComponent<targetBehaviour>().puzzleSolved = true;
            foreach (GameObject door in this.doorToOpen)
            {
                door.GetComponent<door>().isOpen = true;
            }

            target.GetComponent<SpriteRenderer>().color = Color.yellow;
            target.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.yellow;
        }



    }




}
