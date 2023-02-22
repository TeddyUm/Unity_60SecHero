using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{

    //Buttons for choosing player's attack types
    public Button basicButton;
    public Button magicButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sets player's attack and changes button's interactable status
        if(GameManager.Instance.pAbility == PlayerAbilities.Basic)
        {
            GameManager.Instance.playerAtkType = GameManager.Instance.playerAtk;
            basicButton.interactable = false;
            magicButton.interactable = true;
        }
        if(GameManager.Instance.pAbility == PlayerAbilities.Magic)
        {
            GameManager.Instance.playerAtkType = GameManager.Instance.playerMagicAtk;
            magicButton.interactable = false;
            basicButton.interactable = true;
        }
    }

    //Changes player's attack type to basic (melee)
    public void changeAbilitytoBasic()
    {
        GameManager.Instance.pAbility = PlayerAbilities.Basic;
    }

    //Changes player's attack type to magic (ranged)
    public void changeAbilitytoMagic()
    {
        GameManager.Instance.pAbility = PlayerAbilities.Magic;
    }
}
