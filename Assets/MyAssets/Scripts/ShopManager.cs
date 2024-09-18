using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public GameObject[] balls;
    public int[] prices;
    public GameManager gameManager;
    public GameObject[] buttons;
    public GameObject defaultBall;

    private GameObject[] selectedImg, selectButtons, buyButtons;
    public Animator toast;
    public ParticleSystem selectedParticle;

    private void Awake()
    {
        int length = buttons.Length;

        selectedImg = new GameObject[length];
        selectButtons = new GameObject[length];
        buyButtons = new GameObject[length];

        for (int i = 0; i< buttons.Length; i++)
        {
            selectedImg[i] = buttons[i].transform.GetChild(0).gameObject;
            selectButtons[i] = buttons[i].transform.GetChild(1).gameObject;
            buyButtons[i] = buttons[i].transform.GetChild(2).gameObject;

            buyButtons[i].GetComponentInChildren<Text>().text = prices[i].ToString();
        }
    }

    private void Start()
    {
        for(int i =0; i < buttons.Length; i++)
        {
            if (PlayerPrefs.HasKey(buttons[i].name))
            {
                Destroy(buyButtons[i]);

                if(int.Parse(buttons[i].name) == PlayerPrefs.GetInt("Selected"))
                {
                   selectButtons[i].SetActive(false);
                   SetPlayerMaterials(int.Parse(buttons[i].name));
                }
            }
        }
    }

    public void Purchase()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        GameObject clickedBtn = EventSystem.current.currentSelectedGameObject;
        int btnId = int.Parse(clickedBtn.transform.parent.gameObject.name);

        Text priceText = clickedBtn.transform.parent.transform.GetChild(2).GetComponentInChildren<Text>();

        int purchaseAmount = int.Parse(priceText.text);

        if (gameManager.coinsCount >= purchaseAmount)
        {
            gameManager.LessCoin(purchaseAmount);
            Destroy(clickedBtn);

            PlayerPrefs.SetString(btnId.ToString(), "Purchased");
        }
        else
            toast.SetTrigger("Toast");
    }

    public void Select()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        GameObject clickedBtn = EventSystem.current.currentSelectedGameObject;
        int btnId = int.Parse(clickedBtn.transform.parent.gameObject.name);

        PlayerPrefs.SetInt("Selected", btnId);

        StartCoroutine(ActivateSelectButtons(clickedBtn, btnId));

        selectedParticle.Play();
        FindObjectOfType<AudioManager>().Play("WinParticle");
    }

    IEnumerator ActivateSelectButtons(GameObject clickedBtn, int btnId)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            selectButtons[i].SetActive(true);
            yield return null;

        }
        clickedBtn.gameObject.SetActive(false);
        SetPlayerMaterials(btnId);
    }

    public void SetPlayerMaterials(int btnId)
    {
        defaultBall.SetActive(false);
        foreach(GameObject ball in balls)
        {
            ball.SetActive(false);
        }

        balls[btnId].SetActive(true);
    }
}
