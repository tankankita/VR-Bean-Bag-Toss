using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBagController : MonoBehaviour
{
    public static BeanBagController Instance;
    [SerializeField] Transform beanbagSpawnPoint;
    [SerializeField] GameObject beanbagPrefab;
    GameObject onDeckBag;
    List<GameObject> bags;

    // Start is called before the first frame update
    void Awake()
    {
     if(Instance == null)
        {
            Instance = this;
        }   else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Start()
    {
        bags = new List<GameObject>();
        SpawnBeanBag();

    }

    public void SpawnBeanBag()
    {
        onDeckBag = Instantiate(beanbagPrefab, beanbagSpawnPoint.position, beanbagSpawnPoint.rotation);
        bags.Add(onDeckBag);
    }

    public void RemoveOnDeckBag()
    {
        if (onDeckBag != null)
        {
            bags.Remove(onDeckBag);
            Destroy(onDeckBag);
        }
    }

    public void CleanupBags()
    {
        foreach(var item in bags)
        {
            Destroy(item);
        }
        bags.Clear();
    }
}
