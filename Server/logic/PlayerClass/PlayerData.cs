using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


/// <summary>
/// 需要保存在数据库中的信息
/// </summary>
public class PlayerData
{
    public string nickname;
    /// <summary>
    /// 胜场数
    /// </summary>
    public int win = 0;

    public PlayerData()
    {
        nickname = "LeoField";
        win = 0;
    }

    public static string GetJsonData(PlayerData playerData)
    {
        return JsonConvert.SerializeObject(playerData);
    }
}