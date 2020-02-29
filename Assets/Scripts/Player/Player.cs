using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private ScreenShake shake;
    PlayerControls controls;
    public float speed, spreadRange;
    private Transform firePoint;
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    Vector2 move, aimJ, aimM;
    public int health, ammunition;
    private bool MouseUse, isShooting;
    private Vector3 spread;
    [Range(1,10000)]
    public float roundPerMin;
    private float DelayUntilNextShot = 0;

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
    }

    void Movement(){
        rb.velocity = new Vector2(move.x, move.y) * speed;
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
        else if(ammunition == 0)
        {
            this.audioManager.StopSound("no_ammo"); //inutile?
            this.audioManager.PlaySound("no_ammo");
            DelayUntilNextShot = 60 / roundPerMin;
        }else{
            this.playRandomUziSound();
            //shake.TriggerShake();
            DelayUntilNextShot = 60/roundPerMin;
            ammunition--;
            spread = new Vector3(0, 0, Random.Range(-spreadRange, spreadRange));
            GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation*Quaternion.Euler(spread));
            bulletInstance.GetComponent<Rigidbody2D>().velocity =   bulletInstance.transform.up * bulletInstance.GetComponent<Bullet>().bulletSpeed;
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
