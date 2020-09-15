using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameplayOrchester : MonoBehaviour
{
    public TextDisplayer TextDisplayer;
    public int type = 1;

    private void Awake()
    {
        if (this.type.Equals(1))
        {
            this.BeginOne();
        }
    }

    private void BeginOne()
    {

    }
}
