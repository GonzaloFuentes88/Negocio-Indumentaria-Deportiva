﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Entidades
{
    public class Talle
    {
        private long _idtalle;
        public long idTalle
        {
            get { return _idtalle; }
            set { _idtalle = value; }
        }

        private string _talles;
        public string Talles
        {
            get { return _talles; }
            set { _talles = value; }
        }

        public Talle(long idTalle)
        {
            this.idTalle = idTalle;
        }
        public Talle()
        {
      
        }
        public Talle(long idTalle, string talles)
        {
            this.idTalle = idTalle;
            this.Talles = talles;
        }
        

    }

}
