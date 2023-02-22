using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonBehavior : MonoBehaviour
{
    [Header("Player")]
    public GameObject hero;

    [Header("Player Locations")]
    public Transform initialPos;
    public Transform enemyPos;



    //Timers for PlayerButtonBehaviour
    [SerializeField]
    private float timeRemaining = 0.5f;
    private float textRemaining = 1;

    //Checkers
    [SerializeField]
    private int enemyAttacked;
    private bool attackSuccessful;
    private bool buttonClicked;

    //Particle System for magic
    public ParticleSystem[] attackEffects;
    
    //Display Text
    [Header("System Text")]
    public Text textT;
    [SerializeField]
    private bool textOn;

    // Start is called before the first frame update
    void Start()
    {
        textOn = false;
        attackSuccessful = false;
        buttonClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (buttonClicked)
        {
            if (attackSuccessful) 
            { 
            GameManager.Instance.attackTurn = 1;
            attackSuccessful = false;
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                hero.gameObject.transform.position = initialPos.position;
                timeRemaining = 0.5f;
                buttonClicked = false;
            }
        }
        if (textOn)
        {

            if (textRemaining > 0)
            {
                textT.text = "Not Enough Mana";
                textRemaining -= Time.deltaTime;
            }
            else
            {
                textT.text = "";
                textOn = false;
                textRemaining = 1;
            }

        }

    }

    public void movePlayer()
    {
        if (GameManager.Instance.attackTurn == 0)
        {
            buttonClicked = true;
            if (GameManager.Instance.pAbility == PlayerAbilities.Basic)
            {
                hero.gameObject.transform.position = enemyPos.position;
                GameManager.Instance.playerMP = GameManager.Instance.playerMP + 10;

                playAnimation(attackEffects[0]);
                SoundManager.Instance.Play("MeleeSound");
                if (GameManager.Instance.playerMP > 100)
                {
                    GameManager.Instance.playerMP = 100;
                }
                attackSuccessful = true;
            }
            else if(GameManager.Instance.pAbility == PlayerAbilities.Magic)
            {
                if (GameManager.Instance.playerMP >= 50)
                {
                    playAnimation(attackEffects[1]);
                    GameManager.Instance.playerMP = GameManager.Instance.playerMP - 50;
                    attackSuccessful = true;
                    SoundManager.Instance.Play("MagicSound");
                }
                else
                {
                    textOn = true;
                    GameManager.Instance.pAbility = PlayerAbilities.Basic;
                    attackSuccessful = false;

                }
            }
            if (attackSuccessful)
            {
                GameManager.Instance.enemyAttacked = enemyAttacked;
            }

        }
    }

    void playAnimation(ParticleSystem specParticle)
    {
        switch (enemyAttacked)
        {
            case 1:
                specParticle.transform.position = new Vector3(2.31f, 0.68f, 0);
                specParticle.Play();
                break;
            case 2:
                specParticle.transform.position = new Vector3(2.31f, -1.32f, 0);
                specParticle.Play();
                break;
            case 3:
                specParticle.transform.position = new Vector3(2.31f, -3.32f, 0);
                specParticle.Play();
                break;
        }
    }
}
