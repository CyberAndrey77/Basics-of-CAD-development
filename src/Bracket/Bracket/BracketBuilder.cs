using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Bracket
{
    public class BracketBuilder
    {
        private KompasApi _kompasApi;

        public void CreateModel(BracketParameters parameters)
        {
            _kompasApi = new KompasApi();

            var x1 = -parameters[ParameterName.PlateLength].Value / 2;
            var x2 = parameters[ParameterName.PlateLength].Value / 2;
            var y1 = -parameters[ParameterName.PlateWidth].Value / 2;
            var y2 = parameters[ParameterName.PlateWidth].Value / 2;

            CreatePlate(parameters);
            CreateTube(parameters[ParameterName.OuterTubeDiameter].Value / 2);

            CreateWalls(parameters);

        }

        private void CreatePlate(BracketParameters parameters)
        {
            var x1 = -parameters[ParameterName.PlateLength].Value / 2;
            var x2 = parameters[ParameterName.PlateLength].Value / 2;
            var y1 = -parameters[ParameterName.PlateWidth].Value / 2;
            var y2 = parameters[ParameterName.PlateWidth].Value / 2;

            _kompasApi.CreateRegtangle(x1, y1, x2, y2);
            _kompasApi.ExtrudeRegtangle(-3);
        }

        private void CreateTube(double radius)
        {
            _kompasApi.CreateCircle(0, 0, radius, 1);
            _kompasApi.ExtrudeCircle(81, true, 5);
        }

        private void CreateWalls(BracketParameters parameters)
        {
            var x1 = -parameters[ParameterName.PlateLength].Value / 2;
            var x2 = parameters[ParameterName.PlateLength].Value / 2;
            var y1 = -parameters[ParameterName.PlateWidth].Value / 2;
            var y2 = y1 + 3;

            //строим первую стенку
            _kompasApi.CreateRegtangle(x1, y1, x2, y2);
            _kompasApi.ExtrudeRegtangle(parameters[ParameterName.SideWallHeight].Value - 3);

            y2 = parameters[ParameterName.PlateWidth].Value / 2;
            y1 = y2 - 3;
            //строим вторую стенку
            _kompasApi.CreateRegtangle(x1, y1, x2, y2);
            _kompasApi.ExtrudeRegtangle(parameters[ParameterName.SideWallHeight].Value - 3);


            _kompasApi.CreateCircle(x2 - (parameters[ParameterName.MountingHoleDiameter].Value / 2 + 5), -parameters[ParameterName.HoleHeight].Value + 3, parameters[ParameterName.MountingHoleDiameter].Value / 2, 2);
            _kompasApi.CutExtrudeCircle();
        }
    }
}
