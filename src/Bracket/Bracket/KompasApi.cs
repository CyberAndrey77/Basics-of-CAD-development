using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;

namespace Bracket
{
    /// <summary>
    /// Класс для связи с Компасом.
    /// </summary>
    class KompasApi
    {
        /// <summary>
        /// Поле 3D документа.
        /// </summary>
        private ksDocument3D _document3D;

        /// <summary>
        /// Поле 2D документа.
        /// </summary>
        private ksDocument2D _document2D;

        /// <summary>
        /// 
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Поле с текущим эскизом.
        /// </summary>
        private ksEntity _sketch;

        /// <summary>
        /// 
        /// </summary>
        private ksSketchDefinition _sketchDefinition;

        /// <summary>
        /// Поле текущего плана.
        /// </summary>
        private ksEntity _currentPlan;

        /// <summary>
        /// 
        /// </summary>
        public KompasObject Kompas { get; }

        /// <summary>
        /// Открытие Компас
        /// </summary>
        /// <returns>Возвращает указатель на Компас</returns>
        private KompasObject OpenKompas()
        {
            if (!GetActiveKompass(out var kompas))
            {
                CreateActiveKompas(out kompas);
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            return kompas;
        }

        /// <summary>
        /// Получение открытого Компаса.
        /// </summary>
        /// <param name="kompasObject">Объект Компаса.</param>
        /// <returns>Возвращает указатель на Компас</returns>
        private bool GetActiveKompass(out KompasObject kompasObject)
        {
            try
            {
                kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                kompasObject = null;
                return false;
            }
        }

        /// <summary>
        /// Открытие Компас.
        /// </summary>
        /// <param name="kompasObject">Объект Компас</param>
        /// <returns>Возвращает указатель на Компас</returns>
        private bool CreateActiveKompas(out KompasObject kompasObject)
        {
            try
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompasObject = (KompasObject)Activator.CreateInstance(type);
                return true;
            }
            catch (COMException)
            {
                throw new COMException("Failed to open Kompas");
            }
        }

        /// <summary>
        /// Создание локумента.
        /// </summary>
        private void CreateDocument()
        {
            _document3D = (ksDocument3D)Kompas.Document3D();
            _document3D.Create(false, true);
            _document2D = (ksDocument2D)Kompas.Document2D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part); // новый компонент
        }

        /// <summary>
        /// Создание прямоугольника.
        /// </summary>
        /// <param name="x1">Координата X1</param>
        /// <param name="y1">Координата Y1</param>
        /// <param name="x2">Координата X2</param>
        /// <param name="y2">Координата Y2</param>
        public void CreateRegtangle(double x1, double y1, double x2, double y2)
        {
            // 1-интерфейс на плоскость XOY
            _currentPlan = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); 
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();

            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();

            _document2D.ksLineSeg(x1, y1, x2, y1, 1);
            _document2D.ksLineSeg(x1, y1, x1, y2, 1);
            _document2D.ksLineSeg(x1, y2, x2, y2, 1);
            _document2D.ksLineSeg(x2, y2, x2, y1, 1);

            _sketchDefinition.EndEdit();
        }

        /// <summary>
        /// Выдавливание прямоугольника.
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        public void ExtrudeRegtangle(double depth)
        {
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksBossExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            // тип выдавливания (строго на глубину)
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = depth;
            entityExtrude.Create();
        }

        /// <summary>
        /// Создание эскиза окружности.
        /// </summary>
        /// <param name="xCenter">Задает центр окружности по X</param>
        /// <param name="yCenter">Задает центр окружности по Y</param>
        /// <param name="radius">Задает радиус окружности</param>
        /// <param name="plane">Задает плоскость для эскиза</param>
        public void CreateCircle(double xCenter, double yCenter, double radius, Plane plane)
        {
            _currentPlan = (ksEntity)_part.GetDefaultEntity((short)(Obj3dType)plane);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();

            _document2D.ksCircle(xCenter, yCenter, radius, 1);

            _sketchDefinition.EndEdit();
        }

        /// <summary>
        /// Выдавливание окружности.
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        /// <param name="thin">Нужны ли стенки</param>
        /// <param name="wallThikness">Толщина стенок</param>
        public void ExtrudeCircle(double depth, bool thin, double wallThikness = 0)
        {
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksBossExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;
            // интерфейс структуры параметров тонкой стенки
            ksThinParam thinParam = (ksThinParam)entityExtrudeDefinition.ThinParam();

            entityExtrudeDefinition.SetSketch(_sketch);
            // тип выдавливания (строго на глубину)
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = depth;
            // тонкая стенка в два направления
            thinParam.thin = thin;
            //Толщина стенки в обратном направлении
            thinParam.reverseThickness = wallThikness;

            //Направление формирования тонкой стенки
            thinParam.thinType = (short)Direction_Type.dtReverse;

            entityExtrude.Create();
        }

        /// <summary>
        /// Вырезание окружности в объекте.
        /// </summary>
        public void CutExtrudeCircle()
        {
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksCutExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtMiddlePlane;

            entityExtrudeDefinition.SetSketch(_sketch);
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = 100;
            entityExtrude.Create();
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public KompasApi()
        {
            Kompas = OpenKompas();
            CreateDocument();
        }
    }
}
