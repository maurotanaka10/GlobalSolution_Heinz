using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float carVelocity;

    void Update()
    {
        transform.Translate(Vector3.right * carVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("Canvas").GetComponent<UIManager>().Penalty();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Enviroment")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "InvisibleWall")
        {
            Destroy(gameObject);
        }

    }
}
