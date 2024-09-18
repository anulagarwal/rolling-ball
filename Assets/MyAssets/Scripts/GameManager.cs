using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject retryPanel, winPanel, startPanel, commingSoonPanel;
    private bool retry, win;
    public Text levelText, coinsText;
    public GameObject[] ballChanceImages;
    private int ballChanceCount = 0;
    public int coinsCount;
    public GameObject shopCanvas, shopBtn, shopCloseBtn, gameCamera, joystick;

    void Awake()
    {
        Application.targetFrameRate = 60;
        int levelNo = PlayerPrefs.GetInt("Level", 0);

        int num = levelNo + 1;
        levelText.text = "Level " + num.ToString();

        coinsCount = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coinsCount.ToString();

        FindObjectOfType<LevelSpawner>().SpawnLevel(levelNo);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PlayerPrefs.DeleteAll();

        if (Input.GetKey(KeyCode.C))
            CoinCollect();
    }

    public void RetryGame()
    {
        if (!win && !retry && !winPanel.activeSelf)
        {
            Destroy(FindObjectOfType<Ball>().gameObject);
            retry = true;
            Invoke("InvokeRetryGame", 1);
        }
    }

    private void InvokeRetryGame()
    {
        print("Failed");
        AudioManager.Instance.Play("Retry");
        retryPanel.SetActive(true);
        retryPanel.transform.DOScale(new Vector3(1, 1, 1), .5f);
    }

    public void Reload()
    {
        AudioManager.Instance.Play("Click");

        AdsManager.Instance.ShowAdmobInterstitial();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        AudioManager.Instance.Play("Click");
        startPanel.SetActive(false);
        FindObjectOfType<Ball>().enabled = true;
    }

    public void Win()
    {
        if (!win && !retry && !retryPanel.activeSelf)
        {
            Invoke("InvokeWinGame", 1);
        }
    }

    private void InvokeWinGame()
    {
        print("Win");
        AudioManager.Instance.Play("Win");

        if (SceneManager.GetActiveScene().buildIndex < 49)
        {
            winPanel.SetActive(true);
            winPanel.transform.DOScale(new Vector3(1, 1, 1), .5f);
        }
        else
        {
            commingSoonPanel.SetActive(true);
            commingSoonPanel.transform.DOScale(new Vector3(1, 1, 1), .5f);
        }

        win = false;
    }

    public void Next()
    {
        AudioManager.Instance.Play("Click");

        AdsManager.Instance.ShowAdmobInterstitial();

        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);      
    }

    public void SoundToggle()
    {
        AudioManager.Instance.Play("Click");
        AudioManager.Instance.SoundToggle();
    }

    public void Home()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void RemoveBallChance()
    {
        Destroy(ballChanceImages[ballChanceCount]);
        ballChanceCount++;
    }

    public void CoinCollect()
    {
        coinsCount++;
        coinsText.text = coinsCount.ToString();
        PlayerPrefs.SetInt("Coins", coinsCount);
    }

    public void TestCoinCollect()
    {
        coinsCount += 500;
        coinsText.text = coinsCount.ToString();
        PlayerPrefs.SetInt("Coins", coinsCount);
    }

    public void LessCoin(int val)
    {
        coinsCount -= val;
        PlayerPrefs.SetInt("Coins", coinsCount);
        coinsText.text = coinsCount.ToString();
    }

    public void OpenShop()
    {
        shopCanvas.SetActive(true);
        levelText.gameObject.SetActive(false);
        shopBtn.SetActive(false);
        shopCloseBtn.SetActive(true);
        gameCamera.SetActive(false);
        startPanel.SetActive(false);
        joystick.SetActive(false);
    }

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
        levelText.gameObject.SetActive(true);
        shopBtn.SetActive(true);
        shopCloseBtn.SetActive(false);
        gameCamera.SetActive(true);
        startPanel.SetActive(true);
        joystick.SetActive(true);
    }

    public void OpenCommingSoonPanel()
    {
        commingSoonPanel.SetActive(true);
        commingSoonPanel.transform.DOScale(new Vector3(1, 1, 1), .5f);
    }

    public void CommingSoon()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
