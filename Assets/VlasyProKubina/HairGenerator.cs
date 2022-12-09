using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HairGenerator : MonoBehaviour
{
    [SerializeField]
    float interval = 0.5f;
    float currentCooldown = 0;

    [SerializeField]
    List<GameObject> prefabs; // normal, zlaty, random

    [SerializeField]
    List<int> probabilities; // 50, 5, 30

    void Start()
    {

    }

    void Update()
    {
        if(currentCooldown <= 0)
        {
            GenerateHair();
            currentCooldown = interval;
        } else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void GenerateHair()
    {
        GameObject chosenPrefab = ChoosePrefab();
        Destroy(Instantiate(chosenPrefab, GeneratePosition(), Quaternion.identity), 4f);
    }

    private GameObject ChoosePrefab()
    {
        int rand = Random.Range(0, probabilities.Sum());
        int rest = 0;
        for(int i = 0; i < probabilities.Count; i++)
        {
            if(rand < probabilities[i] + rest)
            {
                return prefabs[i];
            }
            rest += probabilities[i];
        }
        return prefabs.First();
    }

    Vector3 GeneratePosition()
    {
        return new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, transform.position.z);
    }
}
