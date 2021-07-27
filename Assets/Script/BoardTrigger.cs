using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        ScoreController.Instance.UpdateScore(1);
    }

    private void OnTriggerExit(Collider collider)
    {
        ScoreController.Instance.UpdateScore(-1);
    }
}
