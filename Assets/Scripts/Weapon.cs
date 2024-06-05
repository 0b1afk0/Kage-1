using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponType
{
    Hand,
    Pistol
}

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponType weapon;
    [SerializeField] public GameObject item;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletStart;
    [SerializeField] private int damage;
    [SerializeField] private float force;
    [SerializeField] private Vector2 direction;
    [SerializeField] public bool isPlayer = true;
    private Transform target;
    private Camera cam;

    private void Start()
    {
        transform.SetLocalPositionAndRotation(Vector2.zero, Quaternion.identity);
        cam = FindObjectOfType<Camera>();
        if (isPlayer)
        {
            target = FindObjectOfType<Player>().transform;
        }
    }
    private void FixedUpdate()
    {
        //LookAtMouse();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
            
    }
    //private void LookAtMouse()
    //{
    //    Vector2 cursorPos = cam.ScreenToViewportPoint(Input.mousePosition);
    //    Vector2 direction = (cursorPos - new Vector2(transform.position.x, transform.position.y)).normalized;
    //    if (isPlayer)
    //        cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
    //    else
    //        cursorPos = target.position;
    //    float a = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    //    if (transform.parent.parent.parent.localScale.x > 0) 
    //    {
    //        a += 180;
    //    }
    //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, a));
    //}
    private void Attack()
    {
        if (weapon == WeaponType.Pistol)
        {
            GameObject inst = Instantiate(bullet, bulletStart.position, Quaternion.Euler(0, 0, transform.localEulerAngles.z));
            inst.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}
