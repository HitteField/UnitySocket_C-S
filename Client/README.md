# Client

需要在某个Unity脚本的`Update()`方法里调用`NetManager.Update()`

NetManager提供了`AddEventListener()`和`AddMsgListener()`两个方法，可以提供网络事件和网络消息到来时的监听

请务必在调用`NetManager.Connect()`连接服务器之前设置完这些监听

### 比如：
在某个脚本里写好了处理连接成功网络事件的回调函数`public void OnConnectSucc(string err) `

和处理在收到了消息MsgKick时的回调函数`public void OnMsgkick(MsgBase msgBase)`

那么就需要在此脚本的`Start()`方法里写这么两行代码：

` NetManager.AddEventListener(NetManager.NetEvent.ConnectSucc, OnConnectSucc);`

` NetManager.AddMsgListener("MsgKick", OnMsgkick);`
***

### 警告:
在此脚本的生命周期结束的时候记得调用对应的`NetManager.RemoveXXXListener()`来取消监听
