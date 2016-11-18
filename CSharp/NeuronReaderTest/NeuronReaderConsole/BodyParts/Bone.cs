using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole.BodyParts
{
    public class Bone
    {
        int number;
        Vector3D pos;
        Vector3D rot;
        public Vector3D Pos
        {
            get
            {
                if (pos == null)
                {
                    pos = new Vector3D(0, 0, 0);
                }
                return pos;
            }
        }
        public Vector3D Rot
        {
            get
            {
                if (rot == null)
                {
                    rot = new Vector3D(0, 0, 0);
                }
                return rot;
            }
        }
        public int Number { get { return number; } }
        public Bone(int bone_number)
        {
            number = bone_number;
        }
    }
}
