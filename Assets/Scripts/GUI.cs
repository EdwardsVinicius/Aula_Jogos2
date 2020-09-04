using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    public GameObject startPanel, HUD, pausePanel, endPanel;
    public Button pauseBtn, resumeBtn, playAgainBtn, nextLvlBtn, exitBtn;
    public Text levelTxt;
    bool started;
    public int level;

    public static GUI gui;

    void Awake()
    {
        if (gui == null) gui = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(this);

        startPanel.SetActive(true);
        HUD.SetActive(false);
        pausePanel.SetActive(false);
        endPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.onClick.AddListener(Pause);
        resumeBtn.onClick.AddListener(Resume);
        nextLvlBtn.onClick.AddListener(NextLevel);
        playAgainBtn.onClick.AddListener(Replay);
        exitBtn.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && Input.anyKey)
        {
            started = true;
            startPanel.SetActive(false);
            int currentLevel = level + 1;
            levelTxt.text = "Level: "+currentLevel;
            HUD.SetActive(true);
        }
    }

    void Pause ()
    {
        HUD.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0;
    }

    void Resume ()
    {
        HUD.SetActive(true);
        pausePanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void EndGame ()
    {
        endPanel.SetActive(true);
        HUD.SetActive(false);
    }

    void Replay ()
    {
        endPanel.SetActive(false);
        HUD.SetActive(true);
        SceneManager.LoadScene(level);
    }

    void NextLevel ()
    {
        endPanel.SetActive(false);
        HUD.SetActive(true);

        level++;

        int currentLevel = level + 1;
            levelTxt.text = "Level: "+currentLevel;

        if (SceneManager.sceneCount <= level)
            SceneManager.LoadScene(level);
    }

    void Quit ()
    {
        #if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
