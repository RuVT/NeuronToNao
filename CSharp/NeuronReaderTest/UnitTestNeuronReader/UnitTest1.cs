using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuronReaderConsole;
using System.Threading;
using NeuronReaderConsole.BodyParts;
using NeuralNetwork.Network;
using System.IO;

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
            string path = @"C:\Users\Ruben\Documents\GitHub\NAO_Neuron_Project\Sesiones\Partes";
            Body body1 = Body.Load(Path.Combine(path, "brazoDer.01"));
            Body body2 = Body.Load(Path.Combine(path, "brazoIzq.01"));
            body1.Parts.AddRange(body2.Parts.ToArray());
            body1.Save(Path.Combine(path, "DosBrazos.01"));
        }

        public void WalkFront()
        {
                        
        }
    }
}
