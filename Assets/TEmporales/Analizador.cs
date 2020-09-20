using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Analizador : MonoBehaviour
{
    [Range(0.001f, 0.01f)]
    public float umbral;
    public float[] spectrum = new float[64];
    public float[] espectroPropio = new float[4];
    public Transform cubo;
    public Transform[] cubos;
    Vector3 vectorBase = Vector3.one;
    public float multiplicador = 100;
    public int espectroVisible;
    public int desfase;
    public float[] valores;

    private void Start()
    {
        cubos = new Transform[4];
        valores = new float[4];
    }
    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);

        for (int j = 0; j < 4; j++)
        {
            float prom = 0;
            for (int i = 0; i < espectroVisible; i++)
            {
                prom += spectrum[desfase + j * espectroVisible + i];
            }
            prom /= (espectroVisible + 0f);

            valores[j] = prom.Remapear(umbral) * multiplicador;
        }

    }
}

static class variables
{
    public static float Remapear(this float f, float umbral)
    {
        if (f > umbral)
            return 1;
        return 0f;
    }


}
