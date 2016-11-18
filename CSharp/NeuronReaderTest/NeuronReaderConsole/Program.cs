using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronDataReaderWraper;
using NeuronReaderConsole.BodyParts;
using System.Threading;
namespace NeuronReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        { 
            IntPtr mySocket = IntPtr.Zero;
            mySocket = NeuronDataReader.BRConnectTo("127.0.0.1", 7001);
            Body myBody = new Body();
            myBody.Parts.Add(
                new BodyPart()
                {
                    BoneNumbers = new int[] { 0, 1, 2, 3, 4, 5, 6 },
                    OutputActions = new string[]
                    {
                        "MOVE_FORWARD",
                        "MOVE_BACKWARDS",
                        "STANDING"
                    },
                    ScriptActions = new string[] 
                    {
                        "walkStart.py",
                        "walkReverse.py",
                        "walkStop2.py"
                    },
                    Name = "Pies",
                    outputArray = new double[] {1, 0, 0}
                });
            NeuronReceiver.Instance.Subscribe(myBody.Parts[0]);
            while (true)
            {
                switch (NeuronDataReader.BRGetSocketStatus(mySocket))
                {
                    case SocketStatus.CS_Starting:
                        Console.WriteLine("Starting");
                        break;
                    case SocketStatus.CS_Running:
                        Console.WriteLine("Running");
                        break;
                    case SocketStatus.CS_OffWork:
                        Console.WriteLine("Not working");
                        break;
                }
                Console.WriteLine("Read[0] Train[1] Test[2] Save[4] Load[5]");
                char key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '0':
                        Console.WriteLine("Expected result?");
                        string output = Console.ReadLine();
                        string[] nums = output.Trim().Split(' ');
                        myBody.Parts[0].outputArray = nums.Select(t => double.Parse(t)).ToArray();
                        myBody.Parts[0].State = NetworkSate.RECORDING;
                        break;
                    case '1':
                        Console.WriteLine();
                        output = Console.ReadLine();
                        Console.WriteLine("Expected result?");
                        //nums = output.Trim().Split(' ');
                        //myBody.Parts[0].outputArray = nums.Select(t => double.Parse(t)).ToArray();
                        myBody.Parts[0].State = NetworkSate.TRAINING;
                        break;
                    case '2':
                        myBody.Parts[0].State = NetworkSate.COMPUTING;
                        Thread.Sleep(5000);
                        break;
                    case '3':
                        myBody.Save("body.01");
                        break;
                }

                Thread.Sleep(1000);               
            }
            //_DataReceived = new FrameDataReceived(bvhDataReceived);
            //NeuronDataReader.BRRegisterFrameDataCallback(IntPtr.Zero, _DataReceived);

            //_CalcDataReceived = new FrameDataReceived(calcDataReceived);
            //NeuronDataReader.BRRegisterCalculationDataCallback(IntPtr.Zero, _CalcDataReceived); 

            //_SocketStatusChanged = new SocketStatusChanged(socketStatusChanged);
            //NeuronDataReader.BRRegisterSocketStatusCallback(IntPtr.Zero, _SocketStatusChanged);
        }

        private static void socketStatusChanged(IntPtr customObject, IntPtr sockRef, SocketStatus status, string msg)
        {
            throw new NotImplementedException();
        }

        private static void calcDataReceived(IntPtr customObject, IntPtr sockRef, IntPtr DataHeader, IntPtr data)
        {
            throw new NotImplementedException();
        }

        private static void bvhDataReceived(IntPtr customObject, IntPtr sockRef, IntPtr DataHeader, IntPtr data)
        {
            throw new NotImplementedException();
        }

        public static FrameDataReceived _DataReceived { get; set; }

        public static FrameDataReceived _CalcDataReceived { get; set; }

        public static SocketStatusChanged _SocketStatusChanged { get; set; }
    }
}
