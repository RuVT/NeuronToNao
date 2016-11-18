using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuronReaderConsole;
using System.Threading;
using NeuronReaderConsole.BodyParts;
using NeuralNetwork.Network;

namespace UnitTestNeuronReader
{
    [TestClass]
    public class UnitTest1
    {
        Body body;

        [TestInitialize]
        public void Init()
        {
            
        }

        [TestMethod]
        public void SaveBody()
        {
            body = new Body();
            body.Parts.Add(
                new BodyPart
                {
                    Name = "test part",
                    BoneNumbers = new int[] { 1, 2 },
                    OutputActions = new string[] {"A1", "A2", "A3"}
                });
            Network n = body.Parts[0].Network;
            body.Save("test1.xml");
        }

        [TestMethod]
        public void LoadBody()
        {
            body = Body.Load("test1.01");
        }

        public void WalkFront()
        {
                        
        }
    }
}
