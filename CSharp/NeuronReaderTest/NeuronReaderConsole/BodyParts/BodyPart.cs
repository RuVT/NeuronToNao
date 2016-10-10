using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronDataReaderWraper;
using System.Runtime.InteropServices;
namespace NeuronReaderConsole.BodyParts
{
    class BodyPart
    {
        List<Bone> bones;
        private FrameDataReceived _DataReceived;
        private BvhDataHeader _bvhHeader;
        private float[] _valuesBuffer = new float[354];
        public List<Bone> Bones
        {
            get 
            {
                if (bones == null)
                {
                    bones = new List<Bone>();
                }
                return bones;
            }
        }

        public BodyPart()
        {
            _DataReceived = new FrameDataReceived(bvhDataReceived);
            NeuronDataReader.BRRegisterFrameDataCallback(IntPtr.Zero, _DataReceived);
        }

        void bvhDataReceived(IntPtr customObject, IntPtr sockRef, IntPtr DataHeader, IntPtr data)
        {
            _bvhHeader = (BvhDataHeader)Marshal.PtrToStructure(DataHeader, typeof(BvhDataHeader));

            // Change the buffer length if necessary
            if (_bvhHeader.DataCount != _valuesBuffer.Length)
            {
                _valuesBuffer = new float[_bvhHeader.DataCount];
            }

            Marshal.Copy(data, _valuesBuffer, 0, (int)_bvhHeader.DataCount);
            if (_bvhHeader.bWithDisp == 1)
            {
                foreach (Bone b in Bones)
                {
                    b.Pos.X = _valuesBuffer[b.Number * 6 + 0];
                    b.Pos.Y = _valuesBuffer[b.Number * 6 + 1];
                    b.Pos.Z = _valuesBuffer[b.Number * 6 + 2];

                    b.Rot.X = _valuesBuffer[b.Number * 6 + 3];
                    b.Rot.Y = _valuesBuffer[b.Number * 6 + 4];
                    b.Rot.Z = _valuesBuffer[b.Number * 6 + 5];
                }
            }
            else 
            {
                //if (boneId == 0)
                //{
                //    tbdisp_x.Text = bvhData[boneId * 6 + 0].ToString();
                //    tbdisp_y.Text = bvhData[boneId * 6 + 1].ToString();
                //    tbdisp_z.Text = bvhData[boneId * 6 + 2].ToString();

                //    tbrt_x.Text = bvhData[boneId * 6 + 3].ToString();
                //    tbrt_y.Text = bvhData[boneId * 6 + 4].ToString();
                //    tbrt_z.Text = bvhData[boneId * 6 + 5].ToString();
                //}
                //else 
                //{
                //    tbrt_x.Text = bvhData[3 + boneId * 3 + 0].ToString();
                //    tbrt_y.Text = bvhData[3 + boneId * 3 + 1].ToString();
                //    tbrt_z.Text = bvhData[3 + boneId * 3 + 2].ToString();

                //    tbdisp_x.Text = "0";
                //    tbdisp_y.Text = "0";
                //    tbdisp_z.Text = "0";
                //}
            }
           
        } 

    }
}
