using System;
using NUnit.Framework;
using ProcessServer;

namespace ProcessServer.Tests
{
    [TestFixture]
    public class ArraySliceTests
    {
        [Test]
        public void ArraySliceTest_StopIndexNull_Success()
        {
            string[] input = "Here is a test string".Split(' ');
            string[] output = ProcessServer.ArraySlice(input, 1, null);

            Assert.IsNotNull(output);
            Assert.IsTrue(output[0] == "is");
            Assert.IsTrue(output.Length == 4);
        }

        [Test]
        public void ArraySliceTest_StartIndexNull_Success()
        {
            string[] input = "Here is a test string".Split(' ');
            string[] output = ProcessServer.ArraySlice(input, null, 2);

            Assert.IsNotNull(output);
            Assert.IsTrue(output[0] == "Here");
            Assert.IsTrue(output[output.Length - 1] == "is");
            Assert.IsTrue(output.Length == 2);
        }

        [Test]
        public void ArraySliceTest_StartAndStopIndexOutOfRange_Failure()
        {
            Assert.Throws(typeof(ArgumentException), Delegate_ArraySliceTest_StartIndexOutOfRange);
            Assert.Throws(typeof(ArgumentException), Delegate_ArraySliceTest_StopIndexOutOfRange);
        }

        public void Delegate_ArraySliceTest_StartIndexOutOfRange()
        {
            string[] input = "Here is a test string".Split(' ');
            string[] output = ProcessServer.ArraySlice(input, 15, null);
        }

        public void Delegate_ArraySliceTest_StopIndexOutOfRange()
        {
            string[] input = "Here is a test string".Split(' ');
            string[] output = ProcessServer.ArraySlice(input, null, 15);
        }
    }

    [TestFixture]
    public class DeserializeJSONStringTests
    {
        [Test]
        public void DeserializeJSONString_Success()
        {
            string json = "{\"action\": \"start\", \"path\": \"somePath\", \"args\": \"/SOMEARGS\"}";
            ProcessServer.ProcessRequest result = ProcessServer.DeserializeJSONString(json);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.action == "start");
            Assert.IsTrue(result.path == "somePath");
            Assert.IsTrue(result.args == "/SOMEARGS");
        }
    }

    public class TransportObjectsTests
    {
        [TestFixture]
        public class RequestObjecTests
        {

        }

        [TestFixture]
        public class ProcessResponseTests
        {
            [Test]
            public void ProcessResponse_Success()
            {
                ProcessResponse resp = new ProcessResponse(1234, "hwnd", null, null, true);
                Assert.IsNotNull(resp);
                Assert.IsTrue(resp.Id == 1234);
                Assert.IsTrue(resp.Success);
            }

            [Test]
            public void ProcessResponse_ToJson_Success()
            {
                ProcessResponse resp = new ProcessResponse(1234, "hwnd", null, null, true);
                string jsonResp = resp.ToJsonString();
                Assert.IsTrue(!string.IsNullOrEmpty(jsonResp));
            }
        }
    }
}
