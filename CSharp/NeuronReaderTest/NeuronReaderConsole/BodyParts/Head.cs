using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NeuronReaderConsole.BodyParts
{
    class Head: BodyPart
    {
        Process currentProcess;
        public Head():base()
        {
            currentProcess = null;
            Bone bone = new Bone(12);
            bone.Rot.XValueChanged += Rot_XValueChanhed;
            Bones.Add(bone);
        }

        void Rot_XValueChanhed(object sender, ValueChangedEventArgs e)
        {
            if (e.value > 30)
            {
                if(currentProcess == null)
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    info.FileName = "cmd.exe";
                    info.Arguments = "/C Python moveHead.py 127.0.0.1";
                    currentProcess = Process.Start(info);
                    currentProcess.WaitForExit();
                    currentProcess = null;
                }
                Console.WriteLine("Head move");
            }
        }
    }
}
