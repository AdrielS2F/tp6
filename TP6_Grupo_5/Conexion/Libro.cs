using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_Grupo_5.Conexion
{
	public class Libro
	{
		private int _idLibro;
		private int _idTema;
		private string _titulo;
		private decimal _precio;
		private string _autor;

		public Libro()
		{

		}
		
		public Libro(int idLibro)
		{
			_idLibro = idLibro;
		}

		public Libro(int idLibro, int idTema, string titulo, decimal precio, string autor)
		{
			_idLibro = idLibro;
			_idTema = idTema;
			_titulo = titulo;
			_precio = precio;
			_autor = autor;
		}

		public int IdLibro
		{
			get
			{
				return _idLibro;
			}
			set
			{
				_idLibro = value;
			}
		}

		public int IdTema
		{
			get
			{
				return _idTema;
			}
			set
			{
				_idTema = value;
			}
		}

		public string Titulo
		{
			get
			{
				return _titulo;
			}
			set
			{
				_titulo = value;
			}
		}

		public decimal Precio
		{
			get
			{
				return _precio;
			}
			set
			{
				_precio = value;
			}
		}

		public string Autor
		{
			get
			{
				return _autor;
			}
			set
			{
				_autor = value;
			}
		}
	}
}