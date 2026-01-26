using UnityEngine;

public class Manage: MonoBehaviour
{
    GameObject player;
    GameObject bat;

    [SerializeField]
    bool playerEnable = true;
    bool batEnable = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        bat = GameObject.FindWithTag("Bat");

        Change();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!playerEnable)
            {
                playerEnable = true;
                batEnable = false;
                Change();
            }
            else 
            {
                playerEnable = false;
                batEnable = true;
                Change();
            }
        }
    }

    void Change()
    {
        player.GetComponent<Collider2D>().enabled = playerEnable;
        player.GetComponent<Rigidbody2D>().simulated = playerEnable;
        player.GetComponent<Player>().enabled = playerEnable;
        bat.GetComponent<Collider2D>().enabled = batEnable;
        bat.GetComponent<Rigidbody2D>().simulated = batEnable;
        bat.GetComponent <Bat>().enabled = batEnable;
        if (playerEnable)
        {
            Color col1 = player.GetComponent<SpriteRenderer>().color;
            col1.a = 1.0f;
            player.GetComponent<SpriteRenderer>().color = col1;

            Color col2 = bat.GetComponent<SpriteRenderer>().color;
            col2.a = 0.5f;
            bat.GetComponent<SpriteRenderer>().color = col2;
        }
        else 
        {
            Color col1 = player.GetComponent<SpriteRenderer>().color;
            col1.a = 0.5f;
            player.GetComponent<SpriteRenderer>().color = col1;

            Color col2 = bat.GetComponent<SpriteRenderer>().color;
            col2.a = 1.0f;
            bat.GetComponent<SpriteRenderer>().color = col2;
        }
    }
}
