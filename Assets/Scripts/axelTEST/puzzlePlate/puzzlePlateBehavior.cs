using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlePlateBehavior : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buttons = new List<GameObject>();

    [SerializeField]
    private bool puzzleSolved = false;

    [SerializeField]
    private int currentButtonToPress = 0;

    private AudioManager audioManager;

    public GameObject[] doorToOpen;



    void Awake()
    {
        this.audioManager = GameObject.FindObjectOfType<AudioManager>();

        foreach (Transform child in this.transform) //recupere les enfants (tt les boutons)
        {
            this.buttons.Add(child.gameObject);
        }
        for (int index = 0; index < buttons.Count; index++) //mélange l'ordre des boutons
        {
            int randomIndex = Random.Range(index, this.buttons.Count);

            GameObject temp = this.buttons[index];
            
            this.buttons[index] = this.buttons[randomIndex];
            this.buttons[randomIndex] = temp;
        }
    }

    public void buttonActivated(GameObject buttonPressed)
    {
        if (this.puzzleSolved)
        {
            return;
        }

        int indexPressed = this.buttons.IndexOf(buttonPressed);
        if(indexPressed != this.currentButtonToPress)
        {
            if(this.currentButtonToPress != 0)
            {
                this.audioManager.PlaySound("puzzle_bad");
            }
            this.currentButtonToPress = 0;
            foreach (GameObject button in this.buttons)
            {
                button.GetComponent<PlateBehavior>().deactivate();
            }
        } else if(indexPressed == this.buttons.Count - 1)
        {
            this.puzzleSolved = true;
            foreach (GameObject door in this.doorToOpen)
            {
                door.GetComponent<door>().isOpen = true;
            }

            this.audioManager.PlaySound("puzzle_solved");

            foreach (GameObject button in this.buttons)
            {
                button.GetComponent<PlateBehavior>().solved(); //deactivate permanently the plates
            }
        } else
        {
            this.currentButtonToPress++;
        }
    }
}
