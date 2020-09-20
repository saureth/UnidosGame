using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorCubos : MonoBehaviour
{
    public MusicControl musicControl;
    public List<Spawner> spawners = new List<Spawner>();
    public Analizador analizador;
    public float[] anterior;
    public float periodo = 0.5f;
    float timeAccount = 0f;

    IEnumerator Start()
    {
        anterior = new float[4];
        yield return new WaitForSeconds(periodo);
        for (int i = 0; i < 4; i++)
        {
            anterior[i] = analizador.valores[i] + 0f;
        }
        while (true)
        {
            int cuenta = 0;
            for (int i = 3; i >= 0; i--)
            {
                if (analizador.valores[i] > 1 && anterior[i] == 0 && cuenta < 2)
                {
                    GameObject go = Instantiate(analizador.cubo.gameObject) as GameObject;
                    go.transform.position = Vector3.right * i;
                    go.SetActive(true);
                    cuenta++;
                    Spawner sp = new Spawner();
                    sp.spawnerIndex = i;
                    sp.delay = Time.time - timeAccount;
                    timeAccount = Time.time;
                    spawners.Add(sp);
                }

            }
            for (int i = 0; i < 4; i++)
            {
                anterior[i] = analizador.valores[i] + 0f;
            }
            yield return new WaitForSeconds(periodo);
        }
    }

    [ContextMenu("Pasar al archivo")]
    public void Export()
    {
        musicControl.clip = GetComponent<AudioSource>().clip;
        musicControl.spawners = spawners.ToArray();
    }

}
