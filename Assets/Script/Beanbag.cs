using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beanbag : MonoBehaviour
{

    public void Thrown()
    {
        BeanBagController.Instance.SpawnBeanBag();
        gameObject.layer = 0;
    }
}
