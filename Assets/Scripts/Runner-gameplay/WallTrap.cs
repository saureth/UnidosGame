using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WallTrap : MonoBehaviour
{
    
    public LayerMask playerLayer;
    //public PlayerRunnerBehaviour pl;
    public Transform[] walls;
    Vector3[] initPos;
    bool animWall = false;
    int random;
    public float speed = 5f;

    void Start()
    {
        initPos = new Vector3[walls.Length];
        for (int i = 0; i < walls.Length; i++)
        {
            initPos[i] = walls[i].transform.position;
            walls[i].transform.position = new Vector3(initPos[i].x, initPos[i].y - 10, initPos[i].z);
        }
    }

    void Update()
    {
        if (animWall)
        {
            walls[random].transform.position = Vector3.Lerp(walls[random].transform.position, initPos[random], Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (((1 << col.gameObject.layer) & playerLayer) != 0)
        {
            SpawnWall();
        }
    }

    void SpawnWall ()
    {
        random = Random.Range(0, walls.Length);
        animWall = true;
    }
}
