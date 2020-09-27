using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCtrl : MonoBehaviour
{

    public void Good()
    {
        BattleStart.batallaActiva.animControl.SetTrigger("Bien");
    }
    public void Bad()
    {
        BattleStart.batallaActiva.animControl.SetTrigger("Mal");
    }

    public void Die()
    {
        BattleStart.batallaActiva.animControl.SetTrigger("Perdio");
    }
}
