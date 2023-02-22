using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotEnemy : MonoBehaviour
{
    //Checks which enemy to attack by comparing the buttons
    public Button button;

    //Check whether if enemy exist or not
    [SerializeField]
    private int spot;

    // Start is called before the first frame update
    void Start()
    {
        spot = 0;
        GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spot == 1)
        {
            button.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            spot = 1;
            //collision.gameObject.GetComponent<EnemyData>().EnemyInitialLoc = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            button.interactable = false;
            spot = 0;
        }
    }

}
