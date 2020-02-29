using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    PlayerControls controls;
    public float speed;
    private Transform firePoint;
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    Vector2 move, aimJ, aimM;
    //Vector2 movement;

    void Awake(){
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Aim_Mouse.performed += ctx => aimM = ctx.ReadValue<Vector2>();

        controls.Gameplay.Aim_Joystick.performed += ctx => aimJ = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aim_Joystick.canceled += ctx => aimJ = Vector2.zero;

        controls.Gameplay.Shoot.started += ctx => Shoot();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firePoint = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Aim();
    }

    void Movement(){
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime * speed;
        transform.Translate(m, Space.World);
    }

    void Aim(){
        if(Input.GetAxis("Mouse X")<0 || Input.GetAxis("Mouse X")>0 || Input.GetAxis("Mouse Y")<0 || Input.GetAxis("Mouse Y")>0){
            Vector2 dir = Camera.main.ScreenToWorldPoint(new Vector2(aimM.x, aimM.y)) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  
        }
        else if(Input.GetAxis("RightJoystickHorizontal") < 0 || Input.GetAxis("RightJoystickHorizontal") > 0 || Input.GetAxis("RightJoystickVertical") < 0 || Input.GetAxis("RightJoystickVertical") > 0){
            //Vector3 dir = Input.mousePosition -  Camera.main.WorldToScreenPoint(transform.position);
            Vector2 dir = new Vector2(aimJ.x, aimJ.y);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        }
    }

    void Shoot(){
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = firePoint.up * bulletInstance.GetComponent<Bullet>().bulletSpeed;
    }



    void OnEnable(){
        controls.Gameplay.Enable();
    }

    void OnDisable(){
        controls.Gameplay.Disable();
    }
}
