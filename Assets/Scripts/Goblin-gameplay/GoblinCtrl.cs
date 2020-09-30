using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCtrl : MonoBehaviour
{
    public static GoblinCtrl singleton;
    public int cuentaGoblins;
    public int goblinsVictoriosos;
    public int goblinsDerrotados;
    private void Awake()
    {
        if (singleton!= null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        singleton = this;
    }

    public void Good()
    {
        BattleStart.batallaActiva.animControl.SetTrigger("Bien");
    }
    public void Bad()
    {
        BattleStart.batallaActiva.animControl.SetTrigger("Mal");
        goblinsVictoriosos++;
        if ((goblinsVictoriosos + goblinsDerrotados) == cuentaGoblins)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

    public void Die()
    {
        BattleStart.batallaActiva.animControl.SetTrigger("Perdio");
        goblinsDerrotados++;
    }
}
