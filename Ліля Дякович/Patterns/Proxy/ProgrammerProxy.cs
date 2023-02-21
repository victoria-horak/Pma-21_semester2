using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class ProgrammerProxy : IProgrammer
    {
        private readonly Programmer _programmer;
        private IDictionary<int, string> _status;
        public ProgrammerProxy(Programmer programmer)
        {
            this._programmer = programmer;
        }

        public IEnumerable<Projects> GetProjects()
        {
            return _programmer.GetProjects();
        }

        public IDictionary<int, string> WorkStatus()
        {
            if(_status == null)
            {
                _status = _programmer.WorkStatus();
            }
            return _status;
        }
    }
}
