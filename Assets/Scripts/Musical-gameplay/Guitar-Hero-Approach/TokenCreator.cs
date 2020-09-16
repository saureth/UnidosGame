using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCreator : MonoBehaviour
{
    public GameObject tokenPrefab;
    public Transform[] spawnPoints;
    public Spawner[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            yield return new WaitForSeconds(spawners[i].delay);
            Instantiate(tokenPrefab, spawnPoints[spawners[i].spawnerIndex].position, Quaternion.identity);
        }
    }

}


[System.Serializable]
public class Spawner
{
    public float delay;
    public int spawnerIndex;
}