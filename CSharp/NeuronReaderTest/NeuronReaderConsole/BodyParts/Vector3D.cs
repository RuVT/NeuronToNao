using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole.BodyParts
{
    class Vector3D
    {
        double _x, _y, _z;
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                OnValueChanged("x", new ValueChangedEventArgs { value = value, oldValue = _x});
                _x = value;
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                OnValueChanged("y", new ValueChangedEventArgs { value = value, oldValue = _y });
                _y = value;
            }
        }
        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                OnValueChanged("z", new ValueChangedEventArgs { value = value, oldValue = _z });
                _z = value;
            }
        }
        public event EventHandler<ValueChangedEventArgs>
            XValueChanhed,
            YValueChanhed,
            ZValueChanhed;
        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        void OnValueChanged(string coor, ValueChangedEventArgs arg) 
        {
            EventHandler<ValueChangedEventArgs> handler =
                (coor == "x") ? XValueChanhed :
                (coor == "y") ? YValueChanhed :
                (coor == "z") ? ZValueChanhed :
                null;
            if (handler != null)
            {
                handler(this, arg);
            }
        }
    }

    public class ValueChangedEventArgs : EventArgs
    {
        public double value;
        public double oldValue;
    }
}
