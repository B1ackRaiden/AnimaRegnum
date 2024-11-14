using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveDirection;
    public LayerMask MovementStop;

    public CollectionManager Cm;

    public bool IsAttacking;
    public float ReadyAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Movement Script
    void Update()
    {

        if (Input.GetKey(KeyCode.F))
        {
            ReadyAttack += Time.deltaTime;
            if(ReadyAttack >= .5f)
            {
                IsAttacking = true;
                ReadyAttack = 0;
                GetComponent<Animator>().Play("MCSpriteAttack");
            }
        }
        else
        {
            IsAttacking = false;
            ReadyAttack = 0;
            GetComponent<Animator>().Play("idle");
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, y, 0);
        transform.Translate(moveDirection * Time.fixedDeltaTime * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            Cm.Itemcount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (IsAttacking == true)
            {
                Debug.Log("An enemy has been taken out");
                Destroy(collision.gameObject);
            }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            IsAttacking = false;
            ReadyAttack = 0;
        }
    }
}
