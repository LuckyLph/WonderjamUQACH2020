﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    Weapon weapon;
    private int index = 0;
    private string[] weapons = {"Handgun", "Rifle"};
    [SerializeField]
    private Weapon[] varWeapon = {new Weapon(230, 2, 2, 20, 1, 100), new Weapon(1000, 5, 1, 20, 1, 1000)};
    private string currentWeapon;
    PlayerControls controls;
    private ScreenShake shake;
    private Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 move, aimJ, aimM;
    private bool MouseUse, isShooting;
    private float DelayUntilNextShot = 0;
    private Vector3 spread;
    public int health;
    public GameObject bulletPrefab;
    public float speed;
    public Animator animator;
    [Range(0.1f,1f)]
    public float secBetweenSteps = 0.5f;
    private float secRemainingStep = 0f;

    private AudioManager audioManager;

    void Awake(){

        this.audioManager = GameObject.FindObjectOfType<AudioManager>();

        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Aim_Mouse.performed += ctx => aimM = ctx.ReadValue<Vector2>();

        controls.Gameplay.Aim_Joystick.performed += ctx => aimJ = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim_Joystick.canceled += ctx => aimJ = Vector2.zero;

        controls.Gameplay.Shoot.started += ctx => this.isShooting = true;
        controls.Gameplay.Shoot.canceled += ctx => this.isShooting = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firePoint = transform.GetChild(0).transform;
        shake = GameObject.Find("Main Camera").GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Aim();
        if (DelayUntilNextShot >= 0)
        {
            DelayUntilNextShot -= Time.deltaTime;
        }
        if (isShooting)
        {
            Shoot();
        }

        //Weapon
        if (Input.mouseScrollDelta.y > 0)
        {
            ChooseWeapon(true);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            ChooseWeapon(false);
        }
    }

    void Movement(){
        rb.velocity = new Vector2(move.x, move.y) * speed;
        if(this.secRemainingStep <= 0 && rb.velocity != Vector2.zero)
        {
            this.TakeAStep();
            this.secRemainingStep = this.secBetweenSteps;
        } else
        {
            this.secRemainingStep -= Time.deltaTime;
        }
        if (rb.velocity != Vector2.zero)
        {
            animator.Play(currentWeapon + "_Move");
        }
        else if (rb.velocity == Vector2.zero)
        {
            animator.Play(currentWeapon + "_Idle");
        }
    }

    private void TakeAStep()
    {
        switch (Random.Range(0,3))
        {
            case 0:
                this.audioManager.PlaySound("player_step1");
                break;
            case 1:
                this.audioManager.PlaySound("player_step2");
                break;
            case 2:
                this.audioManager.PlaySound("player_step3");
                break;
            case 3:
                this.audioManager.PlaySound("player_step4");
                break;
            default:
                break;
        }
    }

    void Aim(){
        if(Input.GetAxis("Mouse X")<0 || Input.GetAxis("Mouse X")>0 || Input.GetAxis("Mouse Y")<0 || Input.GetAxis("Mouse Y")>0){
            MouseUse = true;
        }
        else if(Input.GetAxis("RightJoystickHorizontal") < 0 || Input.GetAxis("RightJoystickHorizontal") > 0 || Input.GetAxis("RightJoystickVertical") < 0 || Input.GetAxis("RightJoystickVertical") > 0){
            MouseUse = false;
        }

        if (MouseUse)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(new Vector2(aimM.x, aimM.y)) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }else{
            //Vector3 dir = Input.mousePosition -  Camera.main.WorldToScreenPoint(transform.position);
            Vector2 dir = new Vector2(aimJ.x, aimJ.y);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        }
    }

    void Shoot(){
        if (DelayUntilNextShot >= 0)
        {
            return;
        }
        else if(varWeapon[index].ammunition == 0)
        {
            this.audioManager.StopSound("no_ammo"); //inutile?
            this.audioManager.PlaySound("no_ammo");
            DelayUntilNextShot = 60 / varWeapon[index].roundPerMin;
        }else{
            //animator.Play("Handgun_Shoot");
            this.playRandomUziSound();
            shake.TriggerShake();
            DelayUntilNextShot = 60/varWeapon[index].roundPerMin;
            varWeapon[index].ammunition--;
            spread = new Vector3(0, 0, Random.Range(-varWeapon[index].spreadRange, varWeapon[index].spreadRange));
            GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation*Quaternion.Euler(spread));
            bulletInstance.GetComponent<Rigidbody2D>().velocity =   bulletInstance.transform.up * varWeapon[index].bulletSpeed;
        }
    }

    private void playRandomUziSound()
    {
        switch (Random.Range(0,4))
        {
            case 0:
                this.audioManager.PlaySound("fire_uzi1");
                break;
            case 1:
                this.audioManager.PlaySound("fire_uzi2");
                break;
            case 2:
                this.audioManager.PlaySound("fire_uzi3");
                break;
            case 3:
                this.audioManager.PlaySound("fire_uzi4");
                break;
            case 4:
                this.audioManager.PlaySound("fire_uzi5");
                break;
            default:
                break;
        }
    }

    void ChooseWeapon(bool up){
        currentWeapon = weapons[index];
        if (up)
        {
            index++;
            if (index == weapons.Length)
            {
                index = 0;
            }
        }else{
            if (index == 0)
            {
                index = weapons.Length;
            }
            index--;
        }
        currentWeapon = weapons[index];
        Debug.Log(currentWeapon);
    }

    public void takeDamage(int damage){
        this.health -= damage;
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnEnable(){
        controls.Gameplay.Enable();
    }

    void OnDisable(){
        controls.Gameplay.Disable();
    }
}
