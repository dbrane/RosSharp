RosSharpドキュメント
##################################################

概要
***************************************************
RosSharpは、ROS (Robot Operating System)のC#クライアントライブラリです。

ライセンス: Ms-PL
Copyright (c) 2012 zoetrope. All Rights Reserved. Licensed undear a Microsoft Permissive License (Ms-PL).

ソースコード: https://github.com/zoetrope/RosSharp

特徴: 

* RosSharpは、Reactive Extensionsをベースにして実装しています。
* NuGetでのインストールをサポートしています。
* Create ROS Node
* Master/Slave/ParameterServer API XML-RPC Client
* Master/Slave/ParameterServer API XML-RPC Server
* Topic (TCPROS) Connection
* Service Connection
* RosOut (Logging Node)
* RosCore (Master Server & Parameter Server & RosOut Node)
* GenMsg (Code generation tool from .msg/.srv files)

Does not supported features:

* Remapping Arguments
* Graph Resource Names (supports only the global name)
* Clock Node
* roslang



環境
***************************************************

* .NET Framework 4

* Reactive Extensions
* Common.Logging
* XML-RPC.NET

* F# Runtime 2.0 (for GenMsg)
* FParsec (for GenMsg)



インストール方法
***************************************************

NuGet
==================================================

RosSharpをインストールするには、NuGet Package Manager Consoleから下記のコマンドを実行してください。 ::

  PM> Install-Package RosSharp

バイナリパッケージ
==================================================

https://github.com/zoetrope/RosSharp/downloads



設定
***************************************************


初期化
==================================================


プログラムで
-------------------------------------------------

.. code-block:: csharp

   ROS.HostName = "";
   ROS.MasterUri
   ROS.Timeout


設定ファイル
-------------------------------------------------

.. code-block:: xml

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="rossharp" type="RosSharp.ConfigurationSection, RosSharp.NET40"/>
      </configSections>
      <rossharp>
        <ROS_MASTER_URI value="http://localhost:11311"/>
        <ROS_HOSTNAME value="localhost"/>
        <SOCKET_TIMEOUT value="1000"/>
        <XMLRPC_TIMEOUT value="1000"/>
      </rossharp>
    </configuration>


環境変数
-------------------------------------------------




ログ
==================================================

プログラム
-------------------------------------------------

.. code-block:: csharp

   LogManager.Adapter = new RosOutLoggerFactoryAdapter(properties);


設定ファイル
-------------------------------------------------


see the Common.Logging Documentation

.. code-block:: xml

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <sectionGroup name="common">
          <section name="logging" type="Common.Logging.ConfigurationSectionHandler, Common.Logging" />
        </sectionGroup>
      </configSections>

      <common>
        <logging>
          <factoryAdapter type="RosSharp.Utility.RosOutLoggerFactoryAdapter, RosSharp.NET40">
            <arg key="level" value="DEBUG" />
            <arg key="showLogName" value="true" />
            <arg key="showDataTime" value="true" />
            <arg key="dateTimeFormat" value="yyyy/MM/dd HH:mm:ss:fff" />
          </factoryAdapter>
        </logging>
      </common>
    </configuration>


プログラミング
***************************************************

using derective
==================================================

.. code-block:: csharp

  using RosSharp;
  
  ROS.Initialize();



Create Node
==================================================

.. code-block:: csharp

  var node = ROS.CreateNode("Test");


Create Subscriber
==================================================

.. code-block:: csharp

  var subscriber = node.CreateSubscriber<RosSharp.std_msgs.String>("/chatter");
  subscriber.Subscribe(x => Console.WriteLine(x.data));


Create Publisher
==================================================

.. code-block:: csharp

  var publisher = node.CreatePublisher<RosSharp.std_msgs.String>("/chatter");
  publisher.OnNext(new RosSharp.std_msgs.String {data = "test"});

Create Service
==================================================


.. code-block:: csharp

  node.RegisterService<AddTwoInts, AddTwoInts.Request, AddTwoInts.Response>
                ("/add_two_ints", req => new AddTwoInts.Response {c = req.a + req.b});


Use Service
==================================================


.. code-block:: csharp

  var proxy = node.CreateProxy<AddTwoInts, AddTwoInts.Request, AddTwoInts.Response>("/add_two_ints");
  proxy(new AddTwoInts.Request() { a = 1, b = 2 }).Subscribe(x => Console.WriteLine(x.c));


ParameterServer
==================================================

.. code-block:: csharp



アプリケーション
***************************************************

RosCore
==================================================

RosCore is

* a ROS Master
* a ROS ParameterServer
* a rosout logging node

http://www.ros.org/wiki/roscore


Usage
--------------------------------------------------

> RosCore




GenMsg
==================================================
GenMsg is a tool that code generation from .msg / .srv format files.


Usage
--------------------------------------------------

> GenMsg