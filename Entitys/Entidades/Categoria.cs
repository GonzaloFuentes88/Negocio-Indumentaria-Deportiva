﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Entidades
{
    public class Categoria
    {
        private long _idcategoria;
        public long idCategoria
        {
            get { return _idcategoria; }
            set { _idcategoria = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public Categoria()
        {
        }
        public Categoria(int IdCategoria, string Nombre)
        {
                this.idCategoria = IdCategoria;
                this.Nombre = Nombre;

        }
    }
}
