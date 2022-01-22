using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Bracket;

namespace Kompass
{
    /// <summary>
    /// Класс для постройки модели.
    /// </summary>
    public class BracketBuilder
    {
        /// <summary>
        /// Ссылка на Компас.
        /// </summary>
        private KompasApi _kompasApi;

        /// <summary>
        /// Метод для построения модели.
        /// </summary>
        /// <param name="parameters">Параметры модели</param>
        public void CreateModel(BracketParameters parameters)
        {
            _kompasApi = new KompasApi();

            CreatePlate(parameters);
            CreateTube(parameters);

            CreateWalls(parameters);

        }

        /// <summary>
        /// Создание полки для модели.
        /// </summary>
        /// <param name="parameters">Параметры модели</param>
        private void CreatePlate(BracketParameters parameters)
        {
            var x1 = -parameters[ParameterName.PlateLength].Value / 2;
            var x2 = parameters[ParameterName.PlateLength].Value / 2;
            var y1 = -parameters[ParameterName.PlateWidth].Value / 2;
            var y2 = parameters[ParameterName.PlateWidth].Value / 2;

            _kompasApi.CreateRegtangle(x1, y1, x2, y2);
            _kompasApi.ExtrudeRegtangle(-parameters[ParameterName.PlaneThickness].Value);
        }

        /// <summary>
        /// Создание трубки у модели.
        /// </summary>
        /// <param name="parameters">Параметры модели</param>
        private void CreateTube(BracketParameters parameters)
        {
            _kompasApi.CreateCircle(0, 0,
                parameters[ParameterName.OuterTubeDiameter].Value / 2, Plane.PlaneXOY);

            _kompasApi.ExtrudeCircle(parameters[ParameterName.TubeHeight].Value, true,
                parameters[ParameterName.TubeWallThickness].Value);
        }

        /// <summary>
        /// Создание стенок модели.
        /// </summary>
        /// <param name="parameters">Параметры модели</param>
        private void CreateWalls(BracketParameters parameters)
        {
            var x1 = -parameters[ParameterName.PlateLength].Value / 2;
            var x2 = parameters[ParameterName.PlateLength].Value / 2;
            var y1 = -parameters[ParameterName.PlateWidth].Value / 2;
            var y2 = y1 + parameters[ParameterName.PlaneThickness].Value;

            //строим первую стенку
            _kompasApi.CreateRegtangle(x1, y1, x2, y2);
            _kompasApi.ExtrudeRegtangle(parameters[ParameterName.SideWallHeight].Value -
                parameters[ParameterName.PlaneThickness].Value);

            y2 = parameters[ParameterName.PlateWidth].Value / 2;
            y1 = y2 - parameters[ParameterName.PlaneThickness].Value;

            //строим вторую стенку
            _kompasApi.CreateRegtangle(x1, y1, x2, y2);
            _kompasApi.ExtrudeRegtangle(parameters[ParameterName.SideWallHeight].Value -
                parameters[ParameterName.PlaneThickness].Value);


            _kompasApi.CreateCircle(x2 - (parameters[ParameterName.MountingHoleRadius].Value + 
                parameters[ParameterName.DistanceFromWall].Value),
                -parameters[ParameterName.HoleHeight].Value + parameters[ParameterName.PlaneThickness].Value,
                parameters[ParameterName.MountingHoleRadius].Value, Plane.PlaneXOZ);
            _kompasApi.CutExtrudeCircle();
        }
    }
}
