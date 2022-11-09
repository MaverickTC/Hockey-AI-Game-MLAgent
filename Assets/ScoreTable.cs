using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTable : MonoBehaviour
{
    public TMP_Text text1, text2;
    private int score1, score2;

    public void IncrementScore(bool which){
        if(!which){
            score1++;
            text1.text = score1.ToString();
        } else {
            score2++;
            text2.text = score2.ToString();
        }
    }
}
