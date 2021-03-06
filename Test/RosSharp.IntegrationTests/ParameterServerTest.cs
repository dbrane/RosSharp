﻿using System;
using System.Reactive.Linq;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosSharp.Master;
using RosSharp.Parameter;

namespace RosSharp.IntegrationTests
{
    [TestClass]
    public class ParameterServerTest
    {
        private MasterServer _masterServer;

        [TestInitialize]
        public void Initialize()
        {
            Ros.MasterUri = new Uri("http://localhost:11311/");
            Ros.HostName = "localhost";
            Ros.TopicTimeout = 3000;
            Ros.XmlRpcTimeout = 3000;

            _masterServer = new MasterServer(11311);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Ros.Dispose();
            _masterServer.Dispose();
        }

        [TestMethod]
        public void IntParameter()
        {
            var node = Ros.InitNodeAsync("test", enableLogger: false).Result;
            
            var param = node.PrimitiveParameterAsync<int>("test_param").Result;

            param.Subscribe(x => Console.WriteLine("param = {0}", x), ex => Console.WriteLine(ex));

            for(int i=0;i<10;i++)
            {
                param.Value = i;
            }
        }
        
        [TestMethod]
        public void DoubleParameter()
        {
            var node = Ros.InitNodeAsync("test").Result;

            var param = node.PrimitiveParameterAsync<double>("test_param").Result;

            param.Subscribe(x => Console.WriteLine("param = {0}", x), ex => Console.WriteLine(ex));

            for (double i = 0.0; i < 10.0; i+=1.1)
            {
                param.Value = i;
            }
        }

        [TestMethod]
        public void StringParameter()
        {
            var node = Ros.InitNodeAsync("test").Result;

            var param = node.PrimitiveParameterAsync<string>("test_param").Result;

            param.Subscribe(x => Console.WriteLine("param = {0}", x), ex => Console.WriteLine(ex));

            for (int i = 0; i < 10; i++)
            {
                param.Value = i.ToString();
            }
        }
        
        [TestMethod]
        public void ListParameter()
        {
            var node = Ros.InitNodeAsync("test").Result;

            var param = node.ListParameterAsync<int>("test_param").Result;

            param.Subscribe(xs => Console.WriteLine("param = {0}", string.Join(",", xs)), ex => Console.WriteLine(ex));

            for (int i = 0; i < 10; i++)
            {
                param.Value = new List<int>() {i, i + 1, i + 2, i + 3};
            }
        }
        [TestMethod]
        public void DictionaryParameter()
        {
            var node = Ros.InitNodeAsync("test").Result;

            var param = node.DynamicParameterAsync("test_param").Result;

            param.Subscribe(x => Console.WriteLine("param = {0}", x), ex => Console.WriteLine(ex));

            for (int i = 0; i < 10; i++)
            {
                dynamic val = param.Value;
                val.IntValue = i;
                val.StringValue = i.ToString();
            }
        }
    }
}
