# Client

需要在某个Unity脚本的`Update()`方法里调用`NetManager.Update()`

客户端相比于服务端，多了一个“网络事件”（区别于网络消息协议），在**Framework/NetManager.cs**的`NetManager`类中通过枚举类`NetEvent`定义。

网络事件顾名思义，比如登陆成功，被踢出游戏，掉线...都应该是网络事件。

在某个网络事件发生时，通过调用`NetManager.FireEvent(NetEvent netEvent,string err)`通知所有监听了此网络事件`netEvent`的监听者。

`NetManager`提供了`AddEventListener()`和`AddMsgListener()`两个方法，可以让监听者监听网络事件和网络消息的到来。

请务必在调用`NetManager.Connect()`连接服务器之前设置完这些监听。

请注意网络事件监听委托与网络消息监听委托的区别：
```
  //网络事件监听者
  public delegate void EventListener(string err);
  //网络消息监听者
  public delegate void MsgListener(MsgBase msgBase);
```

### 具体使用方法：
在某个脚本里写好了处理连接成功网络事件的回调函数`public void OnConnectSucc(string err) `

和处理在收到了消息`MsgKick`时的回调函数`public void OnMsgkick(MsgBase msgBase)`

那么就需要在此脚本的`Start()`方法里写这么两行代码：

` NetManager.AddEventListener(NetManager.NetEvent.ConnectSucc, OnConnectSucc);`

` NetManager.AddMsgListener("MsgKick", OnMsgkick);`
***

### 警告:
在此脚本的生命周期结束的时候记得调用对应的`NetManager.RemoveXXXListener()`来取消监听
