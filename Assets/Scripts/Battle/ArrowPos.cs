using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPos : MonoBehaviour
{
    //Locations for the arrow to go based on given attackTurn.
    public Transform[] locations;
    // Start is called before the first frame update
    void Start()
    {
        //Set initial location to where the player is. (Because player always gets the first turn.
        gameObject.transform.position = locations[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets arrow's location to given locations in array of transforms based on the attackTurn.
        switch(GameManager.Instance.attackTurn)
        {
            case 0:
                gameObject.transform.position = locations[0].position;
                break;
            case 1:
                gameObject.transform.position = locations[1].position;
                break;
            case 2:
                gameObject.transform.position = locations[2].position;
                break;
            case 3:
                gameObject.transform.position = locations[3].position;
                break;
        }
    }
}
