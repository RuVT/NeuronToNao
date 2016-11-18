using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole.BodyParts
{
    class Feets: BodyPart
    {

        public Feets()
        {
            BoneNumbers = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            OutputActions = new string[] {
                "WALKING_FORWARD",
                "WALKING_BACKWARDS",
                "STANDING"
            };
            
        }

    }
}
