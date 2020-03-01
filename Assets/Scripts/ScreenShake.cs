using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    
    private Transform t;
    // Desired duration of the shake effect
    private float shakeDurationRemaining, dampingShake;

    public GameObject player;

    public float shakeDurationBase, shakeMagnitude, dampingSpeed;

    [Range(0.001f,0.2f)]
    public float secondBetweenShakes = 0.001f;

    private bool isShaking = false;
    
    // The initial position of the GameObject
    Vector3 initialPosition;

    void Awake()
    {
        if (transform == null)
        {
            t = this.GetComponent(typeof(Transform)) as Transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {/*
        if (shakeDurationRemaining > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude * shakeDurationRemaining * dampingShake;
            shakeDurationRemaining -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDurationRemaining = 0f;
            transform.localPosition = initialPosition;
        }
        */
    if (player)
    {
      this.initialPosition = new Vector3(this.player.transform.position.x, this.player.transform.position.y, this.transform.position.z);
    }
        
        //this.initialPosition = this.transform.position;



    }

    public void TriggerShake() {
        shakeDurationRemaining = shakeDurationBase;
        dampingShake = 1/shakeDurationRemaining;
        if (!isShaking)
        {
            StartCoroutine(shaking());
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private IEnumerator shaking()
    {
        this.isShaking = true;
        while (shakeDurationRemaining > 0)
        {
            //this.initialPosition = GameObject.Find("Player").transform.position;

            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude * shakeDurationRemaining * dampingShake;
            shakeDurationRemaining -= Time.deltaTime * dampingSpeed;
            this.shakeDurationRemaining -= this.secondBetweenShakes;
            yield return new WaitForSeconds(this.secondBetweenShakes);
        }

        shakeDurationRemaining = 0f;
        transform.localPosition = initialPosition;
        this.isShaking = false;
        
    }
}
