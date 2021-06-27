# Server

服务端是一个控制台程序，请创建一个新的Csharp项目然后将代码导入进项目中。

核心类位于 **net/NetManager.cs** 中，定义了几乎所有的套接字的操作，包括多路复用监听，接收客户端连接请求，接收与转发消息等。

启动时，请务必在`Main(string[] args)`方法里调用`NetManager.StartLoop(int)`，参数是监听的端口。

### 具体使用方法

服务端的核心功能是与数据库进行通讯以及消息转发与广播，使用服务端之前应该首先编写“在服务端收到了一条消息后应该做什么”的回调函数。

请把这些回调函数全都放在`MsgHandler`类中，这个类里面定义了所有的对收到的消息的回调函数，并且要求函数名必须和对应的消息协议的类名相同。

因此，如果定义了一个协议MsgLogin:MsgBase，那么有两件事需要做：

1. 在MsgLogin类的构造函数中添加这句代码：
      ```C#
          protoName = "MsgLogin";   //此成员变量的值必须与此消息协议的类名同名
      ```
2. 在MsgHandler类中定义结构如下的回调处理函数：
      ```C#
      public partial class MsgHandler
      {
          //收到类型为MsgLogin的消息时，系统会调用此函数对收到的消息进行处理
          public static void MsgLogin(ClientState cs,MsgBase msgBase)
          {
              MsgLogin whatReceived = (MsgLogin)msgBase;
              
              //对whatReceived对象进行一些操作：
              //...
              //...
              
              //填写服务端的处理结果
              whatReceived.result = 0;
              
              //反馈此条登录消息的处理结果给发送此消息的客户端
              NetManager.Send(cs,whatReceived);
          }
      }
      ```
      
在目录 **logic/MsgHandlers/** 下已经有一些回调函数的定义了，供以参考。（这些参考里可能有一些代码是此通讯模型里没定义的，比如DBManager，这个是我设计的服务端和数据库交流的管理类，不属于此通讯模型的范畴，所以没有上传（23333），直接删除这些代码吧，是时候写一些你自己的处理回调函数了）

### 备注

`MsgHandler`类是partical的，方便将不同类别的协议的处理方法归类管理。

所有的自定义协议请务必继承自类`MsgBase`，**proto**目录下有一些已经写好的协议供参考。

自定义协议的声明与定义请务必保证服务端与客户端相同。

**tools**目录下有一些工具类，但是定时器类`Clocker`在目录**net**下，这个类是用于完成一些定时任务的（周期性任务/一次性延时任务）
