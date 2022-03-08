using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    BoardManager boardManager;

    public bool playerTurn = true;
    public bool enemyTurn = false;

    public int Level = 1;
    private bool doingSetUp;
    public Text levelText;
    public GameObject levelImage;

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        boardManager = GetComponent<BoardManager>(); 
        // Map生成
        InitGame();
        
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)] // ゲーム開始時に1度呼ばれるもの

    static public void Call() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static private void OnSceneLoaded(Scene next, LoadSceneMode a) {
        instance.Level++;
        instance.InitGame();
    }

    public void InitGame() {
        doingSetUp = true;

        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Day" + Level;

        levelImage.SetActive(true);
        
        Invoke("HideLevelImage", 2f);

        boardManager.SetupScene();
    }

    public void HideLevelImage() {
        levelImage.SetActive(false);

        doingSetUp = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn || enemyTurn || doingSetUp) {
            return;
        }

        // エネミー関数
        StartCoroutine(MoveEnemies());
    }

    IEnumerator MoveEnemies() {
        enemyTurn = true;

        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(0.1f);

        enemyTurn = false;
        playerTurn = true;
    }
}
