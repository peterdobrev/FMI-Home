using System.Collections.Generic;

[System.Serializable]
public class PlayerDataArray
{
    public List<PlayerData> data;
}

[System.Serializable]
public class PlayerData
{
    public string _id;
    public string playerName;
    public string facultyNumber;
    public int points;
}