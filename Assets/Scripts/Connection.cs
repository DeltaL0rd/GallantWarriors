[System.Serializable]
public class GetUserId
{
    public bool status;
    public string data;
    public string msg;
}

[System.Serializable]
public class SendScore
{
    public bool status;
    public string msg;
}

[System.Serializable]
public class LeaderBoard
{
    public bool status;
    public string msg;
    public LeaderBoardData[] data;

}

[System.Serializable]
public class LeaderBoardData
{
    public string name;
    public int score;
}

public class APIEndPoint
{
    public static string URL = "http://54.177.164.15:7000/";
}