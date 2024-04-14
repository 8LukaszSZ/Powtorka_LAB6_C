using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{

    public delegate void ObsługaBłęduHandler(string opisBłędu);
    public class Stozek
    {
        private double wysokość;
        private double promień;

        public event ObsługaBłęduHandler ObsługaBłędu;

        public double Wysokość
        {
            get => wysokość;
            set
            {
                if (value < 0)
                {
                    ObsługaBłędu?.Invoke("Wysokość nie może być ujemna!");
                }
                else
                {
                    wysokość = value;
                }
            }
        }

        public double Promień
        {
            get => promień;
            set
            {
                if (value < 0)
                {
                    ObsługaBłędu?.Invoke("Promień nie może być ujemny!");
                }
                else
                {
                    promień = value;
                }
            }
        }
    }
}
