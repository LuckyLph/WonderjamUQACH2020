﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    
    private Transform t;
    // Desired duration of the shake effect
    private float shakeDurationRemaining, dampingShake;

    public float shakeDurationBase, shakeMagnitude, dampingSpeed;
    
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

    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void TriggerShake() {
        shakeDurationRemaining = shakeDurationBase;
        dampingShake = 1/shakeDurationRemaining;
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
}