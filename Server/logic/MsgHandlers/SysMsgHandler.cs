﻿using System;
using System.Collections.Generic;
using System.Text;

public partial class MsgHandler
{
    public static void MsgPing(ClientState state,MsgBase msg)
    {
        //Tool.DebugLog("MsgPing");
        state.lastPingTime = Tool.GetTimeStamp();
        //收到ping包后要回复一个pong包
        MsgPong msgPong = new MsgPong();
        NetManager.Send(state, msgPong);
    }

    

}