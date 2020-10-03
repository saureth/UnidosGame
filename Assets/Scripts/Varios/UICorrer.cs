using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICorrer : MonoBehaviour
{
    public Sprite spIngles;
    public Image imVer;
    // Start is called before the first frame update
    void Start()
    {
        int i = PlayerPrefs.GetInt("idioma", 0);
        if (i!=0)
        {
            imVer.sprite = spIngles;
        }
    }

}
