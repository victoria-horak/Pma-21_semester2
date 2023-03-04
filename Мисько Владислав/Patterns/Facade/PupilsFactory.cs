using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Facade
{
    public static class PupilsFactory
    {
        public static Pupil Create(int id, string name, string surname)
        {
            return new Pupil(id, name, surname);
        }

        public static Pupil[] CreateMultiple()
        {
            return new Pupil[5]
            {
                Create(1, "Petro", "Pavlenko"),
                Create(2, "Ivan", "Petrenko"),
                Create(3, "John", "Cena"),
                Create(4, "Olaf", "Scholz"),
                Create(5, "Joe", "Biden")
            };
        }

    }
}
