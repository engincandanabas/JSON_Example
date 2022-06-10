using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    public string username;
    public int userLevel;
    public int highScore;
    public int moneyCount;

    public CharacterStats()
    {
        
    }

    public CharacterStats(string username, int userLevel, int highScore, int moneyCount)
    {
        this.username = username;
        this.userLevel = userLevel;
        this.highScore = highScore;
        this.moneyCount = moneyCount;
    }
}
