using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 全体玩家管理器
/// </summary>
public class PlayerManager
{
    /// <summary>
    /// 全体玩家的（玩家id-玩家信息）键值对字典
    /// </summary>
    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    /// <summary>
    /// 判断某个玩家当前是否在线
    /// </summary>
    /// <param name="id">玩家id</param>
    /// <returns>该玩家是否在线</returns>
    public static bool IsOnline(string id)
    {
        return players.ContainsKey(id);
    }
    /// <summary>
    /// 根据玩家id获取玩家
    /// </summary>
    /// <param name="id">玩家id</param>
    /// <returns>若该玩家在线则返回该玩家，否则返回null</returns>
    public static Player GetPlayer(string id)
    {
        if(players.ContainsKey(id))
        {
            return players[id];
        }
        return null;
    }

    /// <summary>
    /// 将一个玩家信息添加到玩家列表中
    /// </summary>
    /// <param name="id">玩家id</param>
    /// <param name="player">玩家信息类</param>
    /// <returns>是否成功添加该玩家信息</returns>
    public static bool AddPlayer(string id,Player player)
    {
        if (player != null)
        {
            players.Add(id, player);
            return true;
        }
        else return false;
    }

    public static bool RemovePlayer(string id)
    {
        return players.Remove(id);
    }
}
