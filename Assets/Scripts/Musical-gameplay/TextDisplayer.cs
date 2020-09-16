using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour
{
    public TMP_Text text;
    public Image image;
    public List<string> CharacterPossibilities = new List<string>();
    public int selectedCharacterIndex = 0;
    public string selectedCharacter = "W";

    public float speedBetweenRandomCharsChanges = 0.025f;
    float auxTimeCounter = 0f;

    public string randomlyGenerateCharacter()
    {
        this.selectedCharacterIndex = Random.Range(0, this.CharacterPossibilities.Count);
        this.selectedCharacter = this.CharacterPossibilities[this.selectedCharacterIndex];
        return this.selectedCharacter;
    }

    public void setTextToDisplayer(string textToDisplay)
    {
        this.text.SetText(textToDisplay);
    }

    public void keepDisplayingRandomChars(float timeToStop)
    {
        StartCoroutine(displayRandomCharsUntil(timeToStop));
    }

    IEnumerator displayRandomCharsUntil(float timeToStop)
    {
        if (timeToStop > this.speedBetweenRandomCharsChanges)
        {
            yield return null;
        }
        this.setTextToDisplayer(this.randomlyGenerateCharacter());
        yield return new WaitForSeconds(this.speedBetweenRandomCharsChanges);
        this.auxTimeCounter += this.speedBetweenRandomCharsChanges;
        if (this.auxTimeCounter <= timeToStop)
        {
            StartCoroutine(displayRandomCharsUntil(timeToStop));
        }
    }

}
