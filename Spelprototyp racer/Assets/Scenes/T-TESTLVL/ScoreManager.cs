using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour {

    //Create a map looking like this:
    //
    // LIST OF USERS -> A User -> LIST OF SCORES for User

    //This structure "dictionary in dictionary" enables us to write stuff like
    //"userScores["SocioBlade"]["Laps"] = 2;"
    //"userScores["SocioBlade"]["Time"] = 12034;"
    Dictionary<string, Dictionary<string, int>> userScores;

    int changeCounter = 0;

    void Start()
    {
        SetScore("SocioBlade", "Laps", 0);
        SetScore("SocioBlade", "Time", 123345);

        SetScore("Odralix", "Laps", 3);
        SetScore("Odralix", "Time", 154300);

        SetScore("Ofelie", "Laps", 1);
        SetScore("Ofelie", "Time", 093245);

        Debug.Log(GetScore("SocioBlade", "Laps"));
    }

    void Init()
    {
        if (userScores != null)
            return;

        userScores = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetScore(string username, string scoreType)
    {
        Init();
        if(userScores.ContainsKey(username) == false)
        {
            return 0;
        }

        if(userScores[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }
        return userScores[username][scoreType];
    }

    public void SetScore(string username, string scoreType, int value)
    {
        Init();

        changeCounter++;

        if(userScores.ContainsKey(username) == false)
        {
            userScores[username] = new Dictionary<string, int>();
        }
        userScores[username][scoreType] = value;
    }

    public void ChangeScore(string username, string scoreType, int amount)
    {
        Init();
        int currScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currScore + amount);
    }

    public string[] GetPlayerNames()
    {
        Init();
        return userScores.Keys.ToArray();
    }

    public string[] GetPlayerNames(string sortingScoreType)
    {
        Init();
        return userScores.Keys.OrderByDescending(n => GetScore(n, sortingScoreType)).ToArray();
    }

    public void _DEBUG_ADD_LAPS_SOCIOBLADE()
    {
        ChangeScore("SocioBlade", "Laps", 1);
    }

    public int GetChangeCounter()
    {
        return changeCounter;
    }


}
