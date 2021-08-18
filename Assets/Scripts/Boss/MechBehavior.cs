using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBehavior : MonoBehaviour
{
    public float speed;

    public int startHp;
    int hp;

    public float bulletCooldown;
    float bulletTimer;

    public Vector2 turn;

    public float sensitivity = .5f;

    public Vector3 deltaMove;

    public float rotSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxisRaw("ZAxis") * speed * Time.deltaTime);
        bulletTimer -= Time.deltaTime;

        turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //turn.y += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && bulletTimer <=0)
        {
            hp -= 1;
            bulletTimer = bulletCooldown;
            //put audio cue here
        }
    }
}
