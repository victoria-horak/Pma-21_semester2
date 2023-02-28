using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Facade
    {
        private MasterAssistant _masterAssistant;
        private TrackReferencing _trackReferencing;
        private Equalizer _equalizer;

        public Facade()
        {
            _masterAssistant = new MasterAssistant();
            _trackReferencing = new TrackReferencing();
            _equalizer = new Equalizer();
        }

        public void Operation()
        {
            Console.WriteLine("Start:\n");
            _masterAssistant.MasteringProcess();
            _masterAssistant.Mastering();

            Console.WriteLine("Start:\n");
            _trackReferencing.TrackProcess();            
            _trackReferencing.TrackFinished();

            Console.WriteLine("Start:\n");
            _equalizer.EQProcess();      
            _equalizer.EQFinished();
        }
    }
}
