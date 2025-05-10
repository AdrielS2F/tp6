using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_Grupo_5.Conexion
{
	public class Producto
	{
        private int _IdProducto;
        private string _NombreProducto;
        private string _CantxUni;
        private decimal _PrecioU;

        public Producto()
        {

        }

        public Producto(int idProducto)
        {
            _IdProducto = idProducto;
        }

        public Producto(int idProducto, string nombreProducto, string cantxUni, decimal precioU)
        {
            _IdProducto = idProducto;
            _NombreProducto = nombreProducto;
            _CantxUni = cantxUni;
            _PrecioU = precioU;
        }

        public int idProducto
        {
            get
            {
                return _IdProducto;
            }
            set
            {
                _IdProducto = value;
            }
        }

        public string nombreProducto
        {
            get
            {
                return _NombreProducto;
            }
            set
            {
                _NombreProducto = value;
            }
        }

        public string cantidadUnitaria
        {
            get
            {
                return _CantxUni;
            }
            set
            {
                _CantxUni = value;
            }
        }

        public decimal precio
        {
            get
            {
                return _PrecioU;
            }
            set
            {
                _PrecioU = value;
            }
        }
    }
}