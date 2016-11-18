using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.Network;
using NeuronDataReaderWraper;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

namespace NeuronReaderConsole
{
    public enum NetManagerState {NO_ACTION, TRAINING, TESTING, COMPUTING};
    public class NeuronalNetManager
    {
        
        private static NeuronalNetManager instance;
        private BvhDataHeader _bvhHeader;
        private FrameDataReceived _DataReceived;
        private double[] _expectedResults;
        private double[] _realResults;
        private float[] _valuesBuffer = new float[354];
        private double[] _valuesBuffer2 = new double[354];
        private List<DataSet> dataSets;
        private int outputSize = 50;
        private Network SkyNet;
        private NetManagerState State = NetManagerState.NO_ACTION;
        private BackgroundWorker testing;
        private BackgroundWorker training;
        private NeuronalNetManager()
        {
            dataSets = new List<DataSet>();
            if (Properties.Settings.Default.UseNeuronDSK)
            {
                _DataReceived = new FrameDataReceived(bvhDataReceived);
                NeuronDataReader.BRRegisterFrameDataCallback(IntPtr.Zero, _DataReceived);
            }
        }
        public static NeuronalNetManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NeuronalNetManager();
                }
                return instance;
            }
        }

        public double[] ExpectedResults
        {
            get
            {
                if (_expectedResults == null)
                {
                    _expectedResults = new double[outputSize];
                }
                return _expectedResults;
            }
            set
            {
                for(int n = 0; n < ExpectedResults.Length; n++)
                {
                    ExpectedResults[n] = (n < value.Length) ? value[n] : 0;
                }
            }
        }
        public Network MainNetwork
        {
            get
            {
                if (SkyNet == null)
                {
                    SkyNet = new Network(354, 354 * 2, outputSize);
                }
                return SkyNet;
            }
        }

        public double[] RealResults
        {
            get
            {
                if (_realResults == null)
                {
                    _realResults = new double[outputSize];
                }
                return _expectedResults;
            }
            set
            {
                if (_realResults == null)
                {
                    _realResults = value;
                }
                else
                {
                    for (int n = 0; n < _realResults.Length; n++)
                    {
                        if (_realResults[n] != value[n])
                        {
                            OnOutputChange(n, _realResults[n], value[n]);
                            _realResults[n] = value[n];
                        }
                    }
                }
            }
        }

        public BackgroundWorker Training
        {
            get
            {
                if(training == null)
                {
                    training = new BackgroundWorker();
                    training.WorkerReportsProgress = true;
                    training.DoWork += Training_DoWork;
                }
                return training;
            }
        }

        public BackgroundWorker Tresting
        {
            get
            {
                if (testing == null)
                {
                    testing = new BackgroundWorker();
                    testing.DoWork += Testing_DoWork;
                }
                return testing;
            }
        }

        void bvhDataReceived(IntPtr customObject, IntPtr sockRef, IntPtr DataHeader, IntPtr data)
        {
            _bvhHeader = (BvhDataHeader)Marshal.PtrToStructure(DataHeader, typeof(BvhDataHeader));
            if (_bvhHeader.DataCount != _valuesBuffer.Length)
            {
                _valuesBuffer = new float[_bvhHeader.DataCount];
            }
            Marshal.Copy(data, _valuesBuffer, 0, (int)_bvhHeader.DataCount);
            for(int n = 0; n < _valuesBuffer.Length; n++)
            {
                _valuesBuffer2[n] = Convert.ToDouble(_valuesBuffer[n]) / 100.0;
            }
            if (_bvhHeader.bWithDisp == 1)
            {
                PerformRead();
            }
            else
            { }
        }

        private void OnOutputChange(int n, double v1, double v2)
        {
            throw new NotImplementedException();
        }

        void PerformRead()
        {
            switch (State)
            {
                case NetManagerState.TRAINING:
                    dataSets.Add(new DataSet(_valuesBuffer2, ExpectedResults));
                    break;
                case NetManagerState.TESTING:
                    _realResults = MainNetwork.Compute(_valuesBuffer2);
                    State = NetManagerState.NO_ACTION;
                    break;
                case NetManagerState.COMPUTING:
                    RealResults = MainNetwork.Compute(_valuesBuffer2);
                    break;
                case NetManagerState.NO_ACTION:
                    break;
            }
        }

        private void Testing_DoWork(object sender, DoWorkEventArgs e)
        {
            if(State != NetManagerState.TESTING)
            {
                State = NetManagerState.TESTING;
                Thread.Sleep(1000);

            }
        }
        private void Training_DoWork(object sender, DoWorkEventArgs e)
        {
            if(State != NetManagerState.TRAINING)
            {
                State = NetManagerState.TRAINING;
                //for (int t = 0; t < 1; t++)
                //{
                //    Training.ReportProgress(t);
                //    Thread.Sleep(10);
                //}
                while(dataSets.Count < 100)
                {
                    Thread.Sleep(10);
                }
                State = NetManagerState.NO_ACTION;
                MainNetwork.Train(dataSets, 0.1);
            }
        }
    }
}
