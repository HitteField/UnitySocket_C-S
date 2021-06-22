using System;
using System.Collections.Generic;
using System.Text;

public partial class MsgHandler
{
    //注册消息
    public static void MsgRegister(ClientState cs,MsgBase msgBase)
    {
        MsgRegister msg = (MsgRegister)msgBase;
        msg.result = DBManager.Register(msg.id, msg.pw);
        if (msg.result == 0) 
        {
            DBManager.CreatePlayerData(msg.id);
        }
        msg.pw = "";
        NetManager.Send(cs, msg);
    }

    //登陆消息
    public static void MsgLogin(ClientState cs,MsgBase msgBase)
    {
        MsgLogin msg = (MsgLogin)msgBase;
        //检查密码是否正确
        if(!DBManager.CheckPassword(msg.id,msg.pw))
        {
            msg.result = 1;
            msg.pw = "";
            NetManager.Send(cs, msg);
            return;
        }
        //阻止重复登录
        if(cs.player!=null)
        {
            msg.result = 2;
            msg.pw = "";
            NetManager.Send(cs, msg);
            return;
        }
        //如果其他客户端登录，踢下线
        if(PlayerManager.IsOnline(msg.id))
        {
            Player other = PlayerManager.GetPlayer(msg.id);
            MsgKick msgKick = new MsgKick();
            msgKick.reason = 0;
            other.Send(msgKick);
            NetManager.Close(other.state);
        }
        //获取玩家数据
        PlayerData playerData = DBManager.GetPlayerData(msg.id);
        if(playerData==null)
        {
            msg.result = 3;
            msg.pw = "";
            NetManager.Send(cs, msg);
            return;
        }
        //构建Player对象
        Player player = new Player(cs);
        player.id = msg.id;
        player.data = playerData;
        PlayerManager.AddPlayer(msg.id, player);
        cs.player = player;

        msg.result = 0;
        msg.pw = "";
        msg.nick = cs.player.data.nickname;
        player.Send(msg);
        Tool.DebugLog(string.Format("clients {0} login with account {1}", cs.RemoteName, player.id));
    }
}
