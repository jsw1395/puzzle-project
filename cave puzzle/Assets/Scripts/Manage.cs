using UnityEngine;
using UnityEngine.SceneManagement;

public class Manage: MonoBehaviour
{
    public static Manage Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject player;
    public GameObject bat;
    public bool playerEnable = true;
    public bool batEnable = false;
    public int sceneIndex = 0;

    public void Update()
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

        if (Input.GetKeyDown(KeyCode.N))
        {
            NextScene();
        }
    }

    public void Change()
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

    public void LoadSceneIdx(int idx)
    {
        SceneManager.LoadScene(idx);
        sceneIndex = idx;
        if (sceneIndex >= 2) {
            player = GameObject.FindWithTag("Player");
            bat = GameObject.FindWithTag("Bat");
            Change();
        }   
    }

    public void NextScene()
    {
        int nextIndex = sceneIndex + 1;
        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextIndex = 0;
        }
        LoadSceneIdx(nextIndex);
        if(SceneManager.GetActiveScene().name == "Stage5")
        {
            NextScene();
        }
    }
}
