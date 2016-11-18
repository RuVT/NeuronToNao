using NeuronDataReaderWraper;
using NeuronReaderConsole.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole
{
    public enum NetworkSate { NO_ACTION, TRAINING, COMPUTING, RECORDING}

    public class NeuronReceiver: NeuronDataReaderHandler
    {
        private BvhDataHeader _bvhHeader;
        private FrameDataReceived _DataReceived;
        public EventHandler<NeuronDataEventArgs> DataReceived;
        private static NeuronReceiver instance;
        public static NeuronReceiver Instance
        {
            get
            {
                if (instance == null)
                    instance = new NeuronReceiver();
                return instance;
            }
        }

        private NeuronReceiver()
        {
            _DataReceived = new FrameDataReceived(bvhDataReceived);
            NeuronDataReader.BRRegisterFrameDataCallback(IntPtr.Zero, _DataReceived);
        }

        void bvhDataReceived(IntPtr customObject, IntPtr sockRef, IntPtr DataHeader, IntPtr data)
        {
            _bvhHeader = (BvhDataHeader)Marshal.PtrToStructure(DataHeader, typeof(BvhDataHeader));
            if (_bvhHeader.DataCount != _valuesBuffer.Length)
            {
                _valuesBuffer = new float[_bvhHeader.DataCount];
            }
            Marshal.Copy(data, _valuesBuffer, 0, (int)_bvhHeader.DataCount);
            OnDataReceived();
            foreach(var observer in inputObservers)
            {
                observer.OnNext(_valuesBuffer);
            }
        }

        private void OnDataReceived()
        {
            if (DataReceived != null)
            {
                DataReceived(this, new NeuronDataEventArgs(_valuesBuffer));
            }
        }
    }

    public class NeuronDataEventArgs: EventArgs
    {
        public float[] NeuronData { get; set; }
        public NeuronDataEventArgs(float[] data)
        {
            NeuronData = data;
        }
    }
}
