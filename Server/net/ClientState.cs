using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

/// <summary>
/// 客户端信息
/// </summary>
public class ClientState
{
    /// <summary>
    /// 客户端套接字
    /// </summary>
    public Socket socket;
    /// <summary>
    /// 客户端的IP地址和端口信息
    /// </summary>
    public string RemoteName = "";
    /// <summary>
    /// 该客户端的缓冲区
    /// </summary>
    public ByteArray readBuff = new ByteArray();
    /// <summary>
    /// 该客户端上一次发送心跳包的时间
    /// </summary>
    public long lastPingTime = 0;
    /// <summary>
    /// 玩家信息
    /// </summary>
    public Player player;
}
