using Akka.Actor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKit.MsTest.On.NetFx
{
    [TestClass]
    public class UnitTest1: Akka.TestKit.MsTest.TestKit
    {
        [TestMethod]
        public void TestMethod1()
        {
            var echo = Sys.ActorOf(Props.Create(() => new EchoActor()));
            
            echo.Tell("Test");
            ExpectMsg("Test");
        }
    }

    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            ReceiveAny(msg => Sender.Tell(msg));
        }
    }
}

