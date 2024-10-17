﻿using ProyectoSeminario.Datos.Interfaces;
using ProyectoSeminario.Entidades.Dtos;
using ProyectoSeminario.Entidades.Entidades;
using ProyectoSeminario.Servicios.Interfaces;
using System.Data.SqlClient;

namespace ProyectoSeminario.Servicios.Servicios
{
    public class ServiciosCategorias : IServiciosCategorias
    {
        private readonly IRepositorioCategorias? _repositorioCategorias;
        private readonly string? _cadena;
        public ServiciosCategorias(IRepositorioCategorias? repositorio, string? cadena)
        {
            _repositorioCategorias = repositorio ?? throw new ApplicationException("Dependencias no cargadas!!!");
            _cadena = cadena;
        }

        public void Borrar(int categoriaId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad(Func<CategoriaListDto, bool>? filter = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorioCategorias!.GetCantidad(conn, filter);
            }
        }

        public List<CategoriaListDto> GetLista(int currentPage, int pageSize, Func<CategoriaListDto, bool>? filter = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorioCategorias.GetLista(conn, currentPage, pageSize, filter);
            }
        }

        public Categoria? GetCategoriaPorId(int categoriaId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                var categoria = _repositorioCategorias.GetCategoriaPorId(categoriaId, conn);
                return categoria;
            }
        }

        public void Guardar(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
