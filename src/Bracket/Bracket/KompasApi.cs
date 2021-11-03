using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using KompasAPI7;

namespace Bracket
{
    class KompasApi
    {
        public KompasObject Kompas { get; set; }
        //KompasObject kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
        // KompasObject kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
        //Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
        //KompasObject kompas = (KompasObject)Activator.CreateInstance(t);
        //if (kompas != null)
        //{
        //    kompas.Visible = true;
        //    kompas.ActivateControllerAPI();
        //    ksDocument3D iDocument3D = (ksDocument3D)kompas.Document3D();
        //    iDocument3D.Create(false /*видимый*/, true /*деталь*/);
        //}
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
                throw new COMException("Failed to open Kompas!");
            }
        }

        public void CreateRegtangle()
        {

        }

        public void ExtrudeRegtangle()
        {

        }

        public void CreateCircle()
        {

        }

        public void ExtrudeCircle()
        {

        }

        public KompasApi()
        {
            Kompas = OpenKompas();
        }
    }
}
