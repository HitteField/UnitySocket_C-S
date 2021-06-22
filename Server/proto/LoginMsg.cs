using System;
using System.Collections.Generic;
using System.Text;

public class MsgRegister:MsgBase
{
    public MsgRegister() { protoName = "MsgRegister"; }
    //客户端发送的信息
    public string id = "";
    public string pw = "";
    /// <summary>
    /// 服务器返回的信息
    /// 0：注册成功
    /// 1：注册失败-用户名已注册
    /// 2：注册失败-非法用户名
    /// 3：注册失败-未知原因
    /// </summary>
    public int result = 0;
}

public class MsgLogin:MsgBase
{
    public MsgLogin() { protoName = "MsgLogin"; }
    //客户端发送的消息
    public string id = "";
    public string pw = "";
    public string nick = "";
    /// <summary>
    /// 服务器返回的消息
    /// 0：登录成功
    /// 1：登陆失败-用户名或密码错误
    /// 2：登录失败-重复登陆
    /// 3：登陆失败-未知原因
    /// </summary>
    public int result = 0;
}

public class MsgKick:MsgBase
{
    public MsgKick() { protoName = "MsgKick"; }
    /// <summary>
    /// 服务器发送的消息
    /// 0：被挤下线
    /// 1：其他原因
    /// </summary>
    public int reason = 0;
}
