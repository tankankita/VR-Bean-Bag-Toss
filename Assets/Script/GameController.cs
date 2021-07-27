using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject lostPanel;
    public GameObject winPanel;

    public Transform cornHoleBoard;
    public float boardMinDistance = 1.3f;
    public Slider slider;
    public List<GameObject> environments;
    public TextMeshProUGUI levelTracker;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void moveBoard(float distance)
    {
        Vector3 position = cornHoleBoard.position;
        position.z = distance + boardMinDistance;
        cornHoleBoard.position = position;
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        BeanBagController.Instance.RemoveOnDeckBag();
    }

    public void LoseGame()
    {
        lostPanel.SetActive(true);
        BeanBagController.Instance.RemoveOnDeckBag();
    }

    public void ResetUI()
    {
        winPanel.SetActive(false);
        lostPanel.SetActive(false);

    }
    private void Start()
    {
        ResetUI();
        StartGame();
    }

    public void StartGame()
    {
        slider.interactable = false;
    }

    public void ResetGame()
    {
        ResetUI();
        slider.interactable = true;
        ScoreController.Instance.ResetScore();
        BeanBagController.Instance.CleanupBags();
        BeanBagController.Instance.SpawnBeanBag();

    }

    public void updateEnvironments(int value)
    {
        levelTracker.text = value.ToString();
        for(int i = 0; i< environments.Count;i++)
        {
            environments[i].SetActive(i+1 == value);
        }
    }
}
