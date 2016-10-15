using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NeuronReaderConsole.BodyParts
{
    enum HeadState {HeadLeft, HeadRight, HeadCenter}
    class Head: BodyPart<HeadState>
    {
        Process currentProcess;
        public Head():base()
        {
            State = HeadState.HeadCenter;
            currentProcess = null;
            Bone bone = new Bone(12);
            bone.Rot.XValueChanged += Rot_XValueChanhed;
            Bones.Add(bone);
        }

        void Rot_XValueChanhed(object sender, ValueChangedEventArgs e)
        {
            if (e.value > 25)
            {
                if(currentProcess == null && State != HeadState.HeadLeft)
                {
                    State = HeadState.HeadLeft;
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    info.FileName = "cmd.exe";
                    info.Arguments = "/C Python moveHeadLeft.py";
                    currentProcess = Process.Start(info);
                    currentProcess.WaitForExit();
                    currentProcess = null;
                    Console.WriteLine("Head move left");
                }
            }
            if (e.value < -25)
            {
                if (currentProcess == null && State != HeadState.HeadRight)
                {
                    State = HeadState.HeadRight;
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    info.FileName = "cmd.exe";
                    info.Arguments = "/C Python moveHeadRight.py";
                    currentProcess = Process.Start(info);
                    currentProcess.WaitForExit();
                    currentProcess = null;
                    Console.WriteLine("Head move right");
                }
            }
            if (e.value > -25 && e.value < 25)
            {
                if (currentProcess == null && State != HeadState.HeadCenter)
                {
                    State = HeadState.HeadCenter;
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    info.FileName = "cmd.exe";
                    info.Arguments = "/C Python moveHeadCenter.py";
                    currentProcess = Process.Start(info);
                    currentProcess.WaitForExit();
                    currentProcess = null;
                    Console.WriteLine("Head move center");
                }
            }
        }
    }
}
