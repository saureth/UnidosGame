using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;
    public List<string> CharacterPossibilities = new LinkedList<string>();
    public int selectedCharacterIndex;
    public string selectedCharacter;

    public string randomlyGenerateCharacter()
    {
        this.selectedCharacterIndex = Random.Range(0, this.CharacterPossibilities.Count);
        this.selectedCharacter = this.CharacterPossibilities[this.selectedCharacterIndex];
        return this.selectedCharacter;
    }

}
