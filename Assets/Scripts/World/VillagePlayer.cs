using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagePlayer : MonoBehaviour
{
    // move speed
    [SerializeField]
    private float speed;
    // player start position
    [SerializeField]
    private Transform startPos;
    // animator
    [SerializeField]
    private Animator anim;
    // particles
    [SerializeField]
    private GameObject priestParticle;
    [SerializeField]
    private GameObject wizardParticle;
    // NPC positions
    [SerializeField]
    private Transform priestPos;
    [SerializeField]
    private Transform wizardPos;
    // title
    [SerializeField]
    private Text context;
    // time text
    [SerializeField]
    private Text TimeText;

    private bool canMoving = true;

    void Start()
    {
        SoundManager.Instance.Stop("MainGameBGM");
        SoundManager.Instance.Play("WinBGM");
    }

    void Update()
    {
        // move to foward
        if (canMoving)
        {
            gameObject.transform.Translate(new Vector2(Time.deltaTime * speed, 0));

            anim.SetFloat("MoveX", 1);
            anim.SetBool("IsMoving", true);
        }
        // stop move
        else
        {
            anim.SetFloat("MoveX", 0);
            anim.SetBool("IsMoving", false);
        }

        // decrease time limit
        GameManager.Instance.time -= Time.deltaTime;

        // time print
        TimeText.text = "Time: " + (int)GameManager.Instance.time;

        // time over
        if(GameManager.Instance.time < 0)
        {
            SoundManager.Instance.Stop("WinBGM");
            GameManager.Instance.SceneChange("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when finish the village, restore HP, MP and move to field
        if(collision.CompareTag("Finish"))
        {
            GameManager.Instance.playerHP = 100;
            GameManager.Instance.playerMP = 100;
            SoundManager.Instance.Stop("WinBGM");
            SoundManager.Instance.Play("MainGameBGM");
            GameManager.Instance.SceneChange("WorldScene");

            if (GameManager.Instance.VillageIn)
            {
                GameManager.Instance.VillageIn = false;
                GameManager.Instance.VillageOut = true;
            }
            else if (GameManager.Instance.Village2In)
            {
                GameManager.Instance.Village2In = false;
                GameManager.Instance.Village2Out = true;
            }
            else if (GameManager.Instance.Village3In)
            {
                GameManager.Instance.Village3In = false;
                GameManager.Instance.Village3Out = true;
            }
        }
        // when contact with NPC, stop and message print
        else if (collision.CompareTag("NPC"))
        {
            context.enabled = true;
            context.text = "HP is restored";
            Instantiate(priestParticle, priestPos);
            canMoving = false;
            StartCoroutine("MovingDelay");
        }
        else if (collision.CompareTag("NextNPC"))
        {
            context.enabled = true;
            context.text = "MP is restored";
            Instantiate(wizardParticle, wizardPos);
            canMoving = false;
            StartCoroutine("MovingDelay");
        }
    }

    // stop with NPC delay
    IEnumerator MovingDelay()
    {
        yield return new WaitForSeconds(1.0f);
        canMoving = true;
        context.enabled = false;
    }
}
