using UnityEngine;
using UnityEngine.UI;

public enum ITEMTYPE
{
    TIME,
    HP,
    MP,
    EXP
}

public class WorldItem : MonoBehaviour
{
    // total item num
    [SerializeField]
    private int itemNum;
    // Item message
    [SerializeField]
    private Text message;
    // particle of items
    [SerializeField]
    private GameObject particle;
    // item type
    private ITEMTYPE itemType;

    void Start()
    {
        // random item get function
        int roll = Random.Range(0, 100);
        if(roll < 40)
        {
            itemType = ITEMTYPE.TIME;
        }
        else if (roll >= 40 && roll < 60)
        {
            itemType = ITEMTYPE.HP;
        }
        else if (roll >= 60 && roll < 80)
        {
            itemType = ITEMTYPE.MP;
        }
        else
        {
            itemType = ITEMTYPE.EXP;
        }

        // item status refresh
        for (int i = 0; i < GameManager.Instance.itemGetNum.Length; i++)
        {
            if(i == itemNum && GameManager.Instance.itemGetNum[itemNum])
            {
                DestroyItem();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // consumption items
        if(collision.CompareTag("Player"))
        {
            // random item get
            if(itemType == ITEMTYPE.TIME)
            {
                GameManager.Instance.time += 20.0f;
                message.text = "Time Extend";
            }
            else if (itemType == ITEMTYPE.HP)
            {
                GameManager.Instance.playerHP = 100;
                message.text = "HP restore";
            }
            else if (itemType == ITEMTYPE.MP)
            {
                GameManager.Instance.playerMP = 100;
                message.text = "MP Restore";
            }
            else if (itemType == ITEMTYPE.EXP)
            {
                GameManager.Instance.playerEXP += 50;
                message.text = "Get EXP";
            }
            // Item get effects and destroy
            Instantiate(particle, transform.position, Quaternion.identity);
            message.enabled = true;
            GameManager.Instance.itemGetNum[itemNum] = true;
            SoundManager.Instance.Play("Item");
            Invoke("OffText", 2.0f);
            Invoke("DestroyItem", 0.5f);
        }
    }

    void DestroyItem()
    {
        gameObject.SetActive(false);
    }

    void OffText()
    {
        message.enabled = false;
    }
}
