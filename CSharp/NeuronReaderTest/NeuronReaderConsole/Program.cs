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
            Head head = new Head();
            IntPtr mySocket = IntPtr.Zero;
            mySocket = NeuronDataReader.BRConnectTo("127.0.0.1", 7001);
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
