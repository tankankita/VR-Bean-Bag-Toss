using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        ScoreController.Instance.UpdateScore(3);
    }
}
