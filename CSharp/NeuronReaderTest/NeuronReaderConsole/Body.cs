using NeuronReaderConsole.BodyParts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
//using System.Xml.Serialization;

namespace NeuronReaderConsole
{
    [Serializable()]
    public class Body
    {
        private static Body actualBody { get; set; }
        public static Body ActualBody
        {
            get
            {
                if (actualBody == null)
                    actualBody = new Body();
                return actualBody;
            }
            set
            {
                actualBody = value;
                OnActualBodyChange();
            }
        }
        private List<BodyPart> parts;
        public List<BodyPart> Parts
        {
            get
            {
                if(parts == null)
                {
                    parts = new List<BodyPart>();
                }
                return parts;
            }
        }
        public static EventHandler ActualBodyChange;

        private static void OnActualBodyChange()
        {
            if (ActualBodyChange != null)
                ActualBodyChange(actualBody, null);
        }

        public void Save(string filePath)
        {
            Stream stream = File.Open(filePath, FileMode.Create);
            //XmlSerializer formatter = new XmlSerializer(typeof(Body));
            //SoapFormatter formatter = new SoapFormatter();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static Body Load(string filePath)
        {
            Stream stream = File.Open(filePath, FileMode.Open);
            //XmlSerializer formatter = new XmlSerializer(typeof(Body));
            BinaryFormatter formatter = new BinaryFormatter();
            //SoapFormatter formatter = new SoapFormatter();
            Body loaded = (Body)formatter.Deserialize(stream);
            stream.Close();
            return loaded;
        }
    }
}
