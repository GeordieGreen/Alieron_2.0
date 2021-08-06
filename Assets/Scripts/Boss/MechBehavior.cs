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
    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxisRaw("ZAxis") * speed * Time.deltaTime);
        bulletTimer -= Time.deltaTime;
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
