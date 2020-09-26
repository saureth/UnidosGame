using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class TokenCreator : MonoBehaviour
{
    public MusicControl musicControl;

    public AudioSource errorSound;

    AudioSource musicSource;

    public UnityEvent ganaCombate;
    public UnityEvent ganaBatalla;
    public UnityEvent pierdeCombate;

    public GameObject tokenPrefab;
    public Transform[] spawnPoints;
    public Spawner[] spawners;
    public static TokenCreator singleton;

    public GameObject uiCanvas;

    public float upDownSpeed = 8;
    public float lifeTime = 10;

    public int repetitions = 4;

    public int errorCount = 0;

    public int successCount = 0;

    public int maxErrors = 4;

    public float timeForAnimation = 4f;

    void Awake()
    {
        uiCanvas = GameObject.FindGameObjectWithTag("GameController");
        uiCanvas.SetActive(false);
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
        this.musicSource = GetComponent<AudioSource>();
    }

    public void Spawn()
    {
        Debug.Log("Inicia Spawn");
        this.uiCanvas.SetActive(true);
        this.spawners = musicControl.spawners;
        musicSource.clip = musicControl.clip;
        StartCoroutine(SpawnRepeating());
    }

    IEnumerator SpawnRepeating()
    {
        for (int j = 0; j < repetitions; j++)
        {
            musicSource.Play();
            for (int i = 0; i < spawners.Length; i++)
            {
                yield return new WaitForSeconds(spawners[i].delay);
                Instantiate(tokenPrefab, spawnPoints[spawners[i].spawnerIndex].position, Quaternion.identity);
            }
            if ((errorCount - successCount) > maxErrors)
            {
                this.GameOver();
                j = repetitions;
                pierdeCombate.Invoke();
                // Perdió el combate
            }
            else
            {
                if (j < (repetitions - 1))
                {
                    // Ganó Batalla
                    ganaBatalla.Invoke();
                    yield return new WaitForSeconds(timeForAnimation);
                }
            }
        }
        if (!((errorCount - successCount) > maxErrors))
        {
            // Ganó combate
            ganaCombate.Invoke();
        }
    }

    public void Print(string message)
    {
        print(message);
    }

    void GameOver()
    {

    }

    public void Correct()
    {
        print("¡Correcto!");
        successCount++;
    }

    public void Wrong()
    {
        errorSound.Play();
        print("¡Mal!");
        errorCount++;
    }

}


[System.Serializable]
public class Spawner
{
    public float delay;
    public int spawnerIndex;
}