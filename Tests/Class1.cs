using Actor;
using MessageLayer;
using NUnit.Framework;
using Originator;
using TinyMessenger;

namespace Tests
{
    [TestFixture]
    public class SimpleTestOfPubSubref
    {
        [Test]
        public void TestMe()
        {
           
            var th = new TinyMessengerHub();
           
            var orig = new OuterDevice(th);
            var act = new InnerDevice(th);

            var mh = new Handler(th);

            orig.TriggerPublish();


        }
    }
}
