using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class TokenCreator : MonoBehaviour
{
    public bool debugear;
    public MusicControl musicControl;

    public AudioSource errorSound;

    AudioSource musicSource;

    public UnityEvent iniciaCombate;
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

    public BattleStart currentGoblinBattle = null;

    public bool juegoActivo;

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
        errorCount = 0;
        successCount = 0;
        iniciaCombate.Invoke();
        //Debug.Log("Inicia Spawn");
        this.currentGoblinBattle = BattleStart.batallaActiva;
        this.uiCanvas.SetActive(true);
        this.spawners = musicControl.spawners;
        musicSource.clip = musicControl.clip;
        StartCoroutine(SpawnRepeating());
    }

    IEnumerator SpawnRepeating()
    {

        for (int j = 0; j < repetitions; j++)
        {
            juegoActivo = true;
            StartCoroutine(PlayConDelay(1.5f));
            for (int i = 0; i < spawners.Length; i++)
            {
                yield return new WaitForSeconds(spawners[i].delay);
                Instantiate(tokenPrefab, spawnPoints[spawners[i].spawnerIndex].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(lifeTime);
            juegoActivo = false;
            if ((errorCount - successCount) > maxErrors)
            {
                j = repetitions;
                pierdeCombate.Invoke();
                this.GameOver();
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
            uiCanvas.SetActive(false);
            ganaCombate.Invoke();
            this.currentGoblinBattle.TerminarCombate();
        }
    }

    public IEnumerator PlayConDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        musicSource.Play();
        GoblinCtrl.singleton.Daze();
    }

    public void Print(string message)
    {
        if (debugear) print(message);
    }

    void GameOver()
    {
        this.currentGoblinBattle.TerminarCombate();
    }

    public void Correct()
    {
        if (!juegoActivo) return;

        if (debugear) print("¡Correcto!");
        successCount++;
    }

    public void Wrong()
    {
        if (!juegoActivo) return;
        errorSound.Play();
        if (debugear) print("¡Mal!");
        errorCount++;
    }

}


[System.Serializable]
public class Spawner
{
    public float delay;
    public int spawnerIndex;
}