using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public static Text textfield;
    void Start()
    {
        textfield = score;
    }


    public static void UpdateScore()
    {
        textfield.text = TestPlayField.score.ToString();
    }
}
