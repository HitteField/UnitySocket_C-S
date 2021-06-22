### Client

需要在某个Unity脚本的Update()方法里调用NetManager.Update()

NetManager提供了AddEventListener()和AddMsgListener()两个方法，可以提供网络事件和网络消息到来时的监听

#### 比如：
在某个脚本里写好了处理连接成功网络事件的回调函数public void OnConnectSucc(string err) 

和处理在收到了消息MsgKick时的回调函数public void OnMsgkick(MsgBase msgBase)

那么就需要在此脚本的Start()方法里写这么两行代码：

NetManager.AddEventListener(NetManager.NetEvent.ConnectSucc, OnConnectSucc);

NetManager.AddMsgListener("MsgKick", OnMsgkick);


##### 警告:
在此脚本的生命周期结束的时候记得调用对应的NetManager.RemoveXXXListener()来取消监听
