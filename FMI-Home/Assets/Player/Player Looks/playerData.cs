using System.Collections.Generic;

[System.Serializable]
public class PlayerDataArray
{
    public List<PlayerData> data;
}

[System.Serializable]
public class PlayerData
{
    public string _id {get; set;}
    public string playerName {get; set;}
    public string facultyNumber {get; set;}
    public int points {get; set;}
}