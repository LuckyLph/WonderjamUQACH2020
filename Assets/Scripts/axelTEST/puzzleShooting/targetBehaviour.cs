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

    private SpriteRenderer whiteChild1;
    private SpriteRenderer whiteChild2;

    void Awake()
    {
        this.parentScript = this.GetComponentInParent<ShootPuzzleBehaviour>();
        this.whiteChild1 = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        this.whiteChild2 = this.transform.GetChild(2).GetComponent<SpriteRenderer>();
    }

    private void Activate()
    {
        this.isActive = true;
        this.whiteChild1.color = Color.green;
        this.whiteChild2.color = Color.green;
    }

    private void Deactivate()
    {
        this.isActive = false;
        this.whiteChild1.color = Color.white;
        this.whiteChild2.color = Color.white;
    }

    public void TakeDamage(int damage)
    {
        if (!this.isActive)
        {
            this.remainingTimeInSec = this.activationTimeInSec;
            this.Activate();
            StartCoroutine(this.startTimer());
        }
    }

    private void TellParent()
    {

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
