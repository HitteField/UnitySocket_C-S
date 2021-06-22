using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgPing : MsgBase
{
    public MsgPing() { protoName = "MsgPing"; }
}

public class MsgPong : MsgBase
{
    public MsgPong() { protoName = "MsgPong"; }
}

public class MsgVersionCheck : MsgBase
{
    public MsgVersionCheck() { protoName = "MsgVersionCheck"; }

    public string version = "";
}
