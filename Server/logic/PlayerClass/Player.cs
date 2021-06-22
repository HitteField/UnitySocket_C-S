using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    #region 核心信息变量
    /// <summary>
    /// 玩家id
    /// </summary>
    public string id = "";
    /// <summary>
    /// 玩家对应的客户端信息
    /// </summary>
    public ClientState state;
    #endregion

    #region 运行时临时数据
    #endregion

    #region 数据库数据
    /// <summary>
    /// 玩家的需要保存在数据库中的数据
    /// </summary>
    public PlayerData data;
    #endregion

    #region 方法
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="cs">玩家对应的客户端信息</param>
    public Player(ClientState cs)
    {
        state = cs;
    }
    /// <summary>
    /// 向该玩家发送信息
    /// </summary>
    /// <param name="msgBase"></param>
    public void Send(MsgBase msgBase)
    {
        //Tool.DebugLog(string.Format("Send a {0} to client {1}.", msgBase.protoName, state.RemoteName));
        NetManager.Send(state, msgBase);
    }
    #endregion

}