using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 originalPosCam;
    private Vector3 originalPosPlay;
    // Start is called before the first frame update
    void Start()
    {
        this.originalPosCam = this.transform.position;
        this.originalPosPlay = this.player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = this.originalPosPlay - this.player.transform.position;
        Debug.Log(move);
        Debug.Log(this.transform.position);
        if (move != Vector3.zero)
        {
            this.transform.position = this.originalPosCam - move;
        }
    }
}
