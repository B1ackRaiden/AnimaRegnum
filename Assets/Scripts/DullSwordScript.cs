using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DullSwordScript : MonoBehaviour
{
    public float swordTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        swordTimer += Time.deltaTime;
        if(swordTimer > 1f)
        {
            GetComponent<Animator>().Play("idle");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("An enemy has been taken out");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
