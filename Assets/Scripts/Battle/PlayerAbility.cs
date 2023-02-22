using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Enumerators for Player's attack types
public enum PlayerAbilities
{
    Basic,
    Magic
}

public class PlayerAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Set player's attack to basic
        GameManager.Instance.pAbility = PlayerAbilities.Basic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
