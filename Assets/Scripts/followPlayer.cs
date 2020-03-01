using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    private Vector3 originalPosCam;
    private Vector3 originalPosPlay;
    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera");
        this.originalPosPlay = this.transform.position;
        this.mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.mainCamera.transform.position.z);
        this.originalPosCam = this.mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = this.originalPosPlay - this.transform.position;
        if (move != Vector3.zero)
        {
            this.mainCamera.transform.position = this.originalPosCam - move;
        }
    }
}
