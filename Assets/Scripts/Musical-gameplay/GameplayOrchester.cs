using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameplayOrchester : MonoBehaviour
{
    public TextDisplayer textDisplayer;
    public int type = 1;

    public float timeForGenerateCharacter = 0.5f;
    public float[] timeForPlayerInput = new float[2] { 0.05f, 0.25f };
    public bool isWaitingForPlayerInput = false;
    public string playerKeyToPress = "";
    public bool playedPressedKey = false;

    void Start()
    {
        if (this.type.Equals(1))
        {
            StartCoroutine(BeginOne());
            if (this.isWaitingForPlayerInput)
            {

            }
        }
    }

    IEnumerator BeginOne()
    {
        textDisplayer.keepDisplayingRandomChars(this.timeForGenerateCharacter);
        yield return new WaitForSeconds(this.timeForGenerateCharacter);
        playerKeyToPress = textDisplayer.randomlyGenerateCharacter();
        float finalTimeToPress = Random.Range(timeForPlayerInput[0], timeForPlayerInput[1]);
        textDisplayer.setTextToDisplayer(playerKeyToPress);
        isWaitingForPlayerInput = true;
        print("");
        yield return new WaitForSeconds(finalTimeToPress);
        isWaitingForPlayerInput = false;
    }
}
