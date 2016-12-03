using NeuralNetwork.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace NeuronReaderConsole.BodyParts
{
    [Serializable()]
    public class BodyPart : IObserver<float[]>
    {
        [NonSerialized()]
        public EventHandler StateChanged;

        [NonSerialized()]
        public EventHandler TrainingEnded;

        [NonSerialized()]
        public EventHandler OutputChanged;

        [NonSerialized()]
        public IDisposable Subcription;

        public int SampleLength = 100;

        public string[] OutputActions = new string[10];

        [NonSerialized()]
        public double[] outputArray;

        public string[] ScriptActions = new string[10];

        [NonSerialized()]
        private NetworkSate state;

        public bool ApplayScrips = true;

        public NetworkSate State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnStateChanged();
            }
        }

        private void OnStateChanged()
        {
            if (StateChanged != null)
            {
                StateChanged(this, null);
            }
        }

        protected List<DataSet> dataSets;

        public List<DataSet> DataSets
        {
            get
            {
                if (dataSets == null)
                    dataSets = new List<DataSet>();
                return dataSets;
            }
        }

        [NonSerialized()]
        protected double[] inputArray;

        protected Network network;

        [NonSerialized()]
        protected double[] realOutput;

        private int SetCount;

        public int[] BoneNumbers { get; set; }

        public string Name { get; set; }

        public Network Network
        {
            get
            {
                if (network == null)
                {
                    network = new Network(BoneNumbers.Length * 6, BoneNumbers.Length * 12, OutputActions.Length);
                }
                return network;
            }
        }

        public double[] RealOutput
        {
            get
            {
                return realOutput;
            }
        }

        public virtual void DoActions(double[] output)
        {
            if (realOutput == null)
                realOutput = new double[output.Length];
            if (state == NetworkSate.COMPUTING)
            {
                for (int n = 0; n < output.Length; n++)
                {
                    if (realOutput[n] < 0.5 && output[n] > 0.5)
                    {
                        Console.WriteLine(OutputActions[n]);
                        if (n < ScriptActions.Length && ScriptActions[n]!= null && ScriptActions[n] != "")//ApplayScrips)
                        {
                            ProcessStartInfo info = new ProcessStartInfo();
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            info.FileName = "cmd.exe";
                            info.Arguments = string.Format("/C Python {0}", ScriptActions[n]);
                            ScriptExecutionList.Instance.ProcessList.Add(info);
                        }
                    }
                }
            }
        }

        public void FillInputArray(float[] value)
        {
            for (int n = 0; n < BoneNumbers.Length; n++)
            {
                inputArray[n * 6 + 0] = value[BoneNumbers[n] * 6 + 0];//Pos X
                inputArray[n * 6 + 1] = value[BoneNumbers[n] * 6 + 1];//Pos Y
                inputArray[n * 6 + 2] = value[BoneNumbers[n] * 6 + 2];//Pos Z
                inputArray[n * 6 + 3] = value[BoneNumbers[n] * 6 + 3];//Rot X
                inputArray[n * 6 + 4] = value[BoneNumbers[n] * 6 + 4];//Rot Y
                inputArray[n * 6 + 5] = value[BoneNumbers[n] * 6 + 5];//Rot Z
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(float[] value)
        {
            inputArray = new double[BoneNumbers.Length * 6];
            FillInputArray(value);
            switch (state)
            {
                case NetworkSate.RECORDING:
                    if (SetCount < SampleLength)
                    {
                        DataSets.Add(new DataSet(inputArray, outputArray));
                        SetCount++;
                    }
                    else
                    {
                        State = NetworkSate.NO_ACTION;
                        SetCount = 0;
                    }
                    break;

                case NetworkSate.TRAINING:
                    Network.Train(DataSets, 0.01);
                    OnTrainingEnded();
                    State = NetworkSate.NO_ACTION;
                    break;

                case NetworkSate.COMPUTING:
                    double[] temp = Network.Compute(inputArray);
                    DoActions(temp);
                    realOutput = temp;
                    OnOutputChanged();
                    break;
            }
        }

        private void OnOutputChanged()
        {
            if(OutputChanged != null)
            {
                OutputChanged(this, null);
            }
        }

        private void OnTrainingEnded()
        {
            if (TrainingEnded != null)
                TrainingEnded(this, null);
        }
    }
}