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
        this.originalPosPlay = this.player.transform.position;
        this.transform.position = new Vector3(this.player.transform.position.x, this.player.transform.position.y, this.transform.position.z);
        this.originalPosCam = this.transform.position;
        
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
