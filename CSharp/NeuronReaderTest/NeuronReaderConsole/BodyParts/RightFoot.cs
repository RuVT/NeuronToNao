using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole.BodyParts
{
    //public class RightFoot: BodyPart<FootState>
    //{
    //    Process currentProcess;
    //    double UpLeg, Leg;
    //    public RightFoot():base()
    //    {
    //        State = FootState.MIDDLE;
    //        currentProcess = null;
    //        Bone upLeg = new Bone(1);
    //        upLeg.Rot.YValueChanged += UpLeg_RotYValueChanged;
    //        //Bone leg = new Bone(2);
    //        //leg.Rot.YValueChanged += Rot_YValueChanged;
    //        Bones.Add(upLeg);
    //        //Bones.Add(leg);
    //    }

    //    void Rot_YValueChanged(object sender, ValueChangedEventArgs e)
    //    {
    //        Leg = e.value;
    //        TestMove();
    //    }

    //    void UpLeg_RotYValueChanged(object sender, ValueChangedEventArgs e)
    //    {
    //        if(e.value < 10 && e.value > -10  && State != FootState.MIDDLE)
    //        {
    //            if (currentProcess == null)
    //            {
    //                Console.WriteLine("Walking Stop");
    //                State = FootState.MIDDLE;
    //                ProcessStartInfo info = new ProcessStartInfo();
    //                info.WindowStyle = ProcessWindowStyle.Hidden;
    //                info.FileName = "cmd.exe";
    //                info.Arguments = "/C Python walkStop2.py";
    //                currentProcess = Process.Start(info);
    //                currentProcess.WaitForExit();
    //                currentProcess.Close();
    //                currentProcess = null;
    //            }
    //        }
    //        else if (e.value < -40 && State != FootState.IN_FRONT)
    //        {
    //            if (currentProcess == null)
    //            {
    //                Console.WriteLine("Walking forward");
    //                State = FootState.IN_FRONT;
    //                ProcessStartInfo info = new ProcessStartInfo();
    //                info.WindowStyle = ProcessWindowStyle.Hidden;
    //                info.FileName = "cmd.exe";
    //                info.Arguments = "/C Python walkStart2.py";
    //                currentProcess = Process.Start(info);
    //                currentProcess.WaitForExit();
    //                currentProcess.Close();
    //                currentProcess = null;
    //            }
    //        }
    //    }

    //    public void TestMove()
    //    {
    //        if (UpLeg < -25 && Leg > 8 && State != FootState.IN_FRONT)
    //        {
    //            if (currentProcess == null)
    //            {
    //                State = FootState.IN_FRONT;
    //                ProcessStartInfo info = new ProcessStartInfo();
    //                info.WindowStyle = ProcessWindowStyle.Hidden;
    //                info.FileName = "cmd.exe";
    //                info.Arguments = "/C Python walkStart.py";
    //                currentProcess = Process.Start(info);
    //                currentProcess.WaitForExit();
    //                currentProcess = null;
    //                Console.WriteLine("Walking");
    //            }
    //        }
    //    }
    //}
}
