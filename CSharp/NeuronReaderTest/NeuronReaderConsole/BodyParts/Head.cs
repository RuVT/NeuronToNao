using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole.BodyParts
{
    class Head: BodyPart
    {
        public Head():base()
        {
            Bone bone = new Bone(15);
            bone.Rot.YValueChanhed += Rot_YValueChanhed;
            Bones.Add(bone);
        }

        void Rot_YValueChanhed(object sender, ValueChangedEventArgs e)
        {
            Console.WriteLine("y="+e.value);
            if (e.value > 10)
            {
                Console.WriteLine("Head move");
            }
        }
    }
}
