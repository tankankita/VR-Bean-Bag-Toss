using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    int _score;
    bool _isAssessing;
    public TextMeshProUGUI ScoreUI;

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

    // Update is called once per frame
    void Start()
    {
        ScoreUI.text = _score.ToString();
    }

    public void UpdateScore(int value)
    {
        if(_score==0)
        {
            GameController.Instance.StartGame();
        }
        _score += value;
        ScoreUI.text = _score.ToString();
        Debug.Log("Score is "+ _score);
        if(!_isAssessing)
        {
            StartCoroutine(AssessScore());
        }
     
    }

    IEnumerator AssessScore()
    {
        _isAssessing = true;
        yield return new WaitForSeconds(2f);
        if(_score == 21)
        {
            GameController.Instance.WinGame();
        }else if (_score>21)
        {
            GameController.Instance.LoseGame();
        }
        _isAssessing = false;
    }

    public void ResetScore()
    {
        _score = 0;
        ScoreUI.text = _score.ToString();
    }
}
