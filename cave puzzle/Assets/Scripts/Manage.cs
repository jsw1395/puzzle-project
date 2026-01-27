using UnityEngine;
using UnityEngine.SceneManagement;

public class Manage : MonoBehaviour
{
    public static Manage Instance;

    public GameObject player;
    public GameObject bat;
    public bool playerEnable;
    public bool batEnable;
    public int sceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;   // 추가
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        InitSceneObjects(); // 현재 씬 초기화(에디터 시작 시)
    }

    public void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.F))
        { 
            if (sceneIndex >= 7) 
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

        if (Input.GetKeyDown(KeyCode.N)) 
        { 
            NextScene(); 
        } 
    }

    private void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneIndex = scene.buildIndex;
        InitSceneObjects(); // 씬 로드 완료 후에 잡기
    }

    private void InitSceneObjects()
    {
        if (sceneIndex < 2) return;

        player = GameObject.FindWithTag("Player");
        bat = GameObject.FindWithTag("Bat");

        // 태그 오브젝트가 씬에 없거나 비활성화면 FindWithTag는 못 찾습니다.
        // null 체크 해두는 게 안전합니다.
        if (player == null) Debug.LogError("[Manage] Player tag object not found");
        if (sceneIndex >= 7 && bat == null) Debug.LogError("[Manage] Bat tag object not found");

        if (sceneIndex >= 7)
        {
            playerEnable = false;
            batEnable = true;
        }
        else
        {
            playerEnable = true;
            batEnable = false;
        }

        if (player != null) Change();

        var goal = GameObject.FindWithTag("Goal");
        if (goal != null) goal.GetComponent<GoalControl>().Set(sceneIndex);
        else Debug.LogError("[Manage] Goal tag object not found");
    }

    public void LoadSceneIdx(int idx)
    {
        SceneManager.LoadScene(idx); // 여기서는 Find하지 않음
    }

    public void NextScene()
    {
        int nextIndex = sceneIndex + 1;
        if (nextIndex >= SceneManager.sceneCountInBuildSettings) nextIndex = 0;
        if (nextIndex == 6) nextIndex++;
        LoadSceneIdx(nextIndex);
    }

    public void Change()
    {
        // null 보호
        if (player == null) return;

        var p = player.GetComponent<Player>();
        if (p != null) p.enabled = playerEnable;

        if (sceneIndex >= 7 && bat != null)
        {
            var b = bat.GetComponent<Bat>();
            if (b != null) b.enabled = batEnable;
        }

        // SpriteRenderer도 null 보호 권장
        var pr = player.GetComponent<SpriteRenderer>();
        if (pr != null)
        {
            var col1 = pr.color;
            col1.a = playerEnable ? 1.0f : 0.5f;
            pr.color = col1;
        }

        if (sceneIndex >= 7 && bat != null)
        {
            var br = bat.GetComponent<SpriteRenderer>();
            if (br != null)
            {
                var col2 = br.color;
                col2.a = playerEnable ? 0.5f : 1.0f;
                br.color = col2;
            }
        }
    }
}