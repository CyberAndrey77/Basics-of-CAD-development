using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Bracket
{
    class BracketBuilder
    {
        private KompasApi _kompasApi;

        public void CreateModel(BracketParameters _parameters)
        {
            _kompasApi = new KompasApi();
            CreatePlate(_parameters);
            CreateTube(_parameters);
            CreateWall(_parameters);
        }

        private void CreatePlate(BracketParameters _parameters)
        {

        }

        private void CreateTube(BracketParameters _parameters)
        {

        }

        private void CreateWall(BracketParameters _parameters)
        {

        }
    }
}
