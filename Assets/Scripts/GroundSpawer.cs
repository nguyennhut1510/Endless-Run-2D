using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawer : MonoBehaviour
{
    public GameObject Ground1, Ground2, Ground3, Ground4, Ground5, Ground6;
    bool hasGround = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
      
    }
    private void SpawnGround()
    {
        int randomNum = Random.Range(1, 7);
        if (randomNum == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + 3, -4.4f, 0), Quaternion.identity);
        }
        if (randomNum == 2)
        {
            Instantiate(Ground2, new Vector3(transform.position.x + 3, -2f, 0), Quaternion.identity);
        }
        if (randomNum == 3)
        {
            Instantiate(Ground3, new Vector3(transform.position.x + 3, -3f, 0), Quaternion.identity);
        }
        if (randomNum == 4)
        {
            Instantiate(Ground4, new Vector3(transform.position.x + 3, -2.5f, 0), Quaternion.identity);
        }
        if (randomNum == 5)
        {
            Instantiate(Ground5, new Vector3(transform.position.x + 3, -3.5f, 0), Quaternion.identity);
        }
        if (randomNum == 6)
        {
            Instantiate(Ground6, new Vector3(transform.position.x + 3, -1.6f, 0), Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }


}
