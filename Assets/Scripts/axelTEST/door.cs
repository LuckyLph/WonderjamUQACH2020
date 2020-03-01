using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool shouldCicleColors = false;
    private bool _isOpen = false;
    public bool isOpen
    {
        get
        {
            return this._isOpen;
        }
        set
        {
            this._isOpen = value;
            if (value)
            {
                this.OpenDoor();
            }
        }
    }
    void Start()
    {
        if (this.shouldCicleColors)
        {
            foreach (Transform child in this.transform)
            {
                child.gameObject.AddComponent<circleThroughAllColors>();
            }
        }
    }

    private void OpenDoor()
    {
        Destroy(this.gameObject);
    }
}

