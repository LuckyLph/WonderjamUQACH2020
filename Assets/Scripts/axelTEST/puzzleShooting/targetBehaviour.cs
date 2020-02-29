using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetBehaviour : MonoBehaviour
{
    private ShootPuzzleBehaviour parentScript;
    private bool m_isActive = false;
    public int activationTimeInSec = 1;
    [SerializeField]
    private int remainingTimeInSec;
    public bool isActive
    {
        get
        {
            return this.m_isActive;
        }
        set
        {
            this.m_isActive = value;
            if(value == true)
            {
                this.TellParent();
            }
        }
    }

    public bool puzzleSolved = false;

    private SpriteRenderer whiteChild1;
    private SpriteRenderer whiteChild2;

    private AudioManager audioManager;


    void Awake()
    {
        this.parentScript = this.GetComponentInParent<ShootPuzzleBehaviour>();
        this.whiteChild1 = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        this.whiteChild2 = this.transform.GetChild(2).GetComponent<SpriteRenderer>();
        this.audioManager = GameObject.FindObjectOfType<AudioManager>();

    }
    public void TakeDamage(int damage)
    {
        if (this.puzzleSolved)
        {
            return;
        }

        this.audioManager.PlaySound("hit_target");

        if (!this.isActive)
        {
            this.remainingTimeInSec = this.activationTimeInSec;
            this.Activate();
            StartCoroutine(this.startTimer());
        } else
        {
            this.remainingTimeInSec = this.activationTimeInSec;
        }
    }

    private void Activate()
    {
        if (this.puzzleSolved)
        {
            return;
        }
        this.isActive = true;
        this.whiteChild1.color = Color.green;
        this.whiteChild2.color = Color.green;
    }

    private void Deactivate()
    {
        if (this.puzzleSolved)
        {
            return;
        }
        this.isActive = false;
        this.whiteChild1.color = Color.white;
        this.whiteChild2.color = Color.white;
    }


    private void TellParent()
    {
        this.GetComponentInParent<ShootPuzzleBehaviour>().targetActivated(this.gameObject);
    }

    IEnumerator startTimer()
    {
        for (int i = 0; i <= this.remainingTimeInSec; this.remainingTimeInSec--)
        {
            yield return new WaitForSeconds(1);
        }
        this.Deactivate();
    }
}
