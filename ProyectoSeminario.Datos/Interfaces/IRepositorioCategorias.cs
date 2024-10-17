﻿using ProyectoSeminario.Entidades.Dtos;
using ProyectoSeminario.Entidades.Entidades;
using System.Data.SqlClient;

namespace ProyectoSeminario.Datos.Interfaces
{
    public interface IRepositorioCategorias
    {
        void Borrar(int CategoriaId, SqlConnection conn, SqlTransaction? tran = null);

        void Agregar(Categoria categoria, SqlConnection conn, SqlTransaction? tran = null);

        bool Existe(Categoria categoria, SqlConnection conn, SqlTransaction? tran = null);

        void Editar(Categoria categoria, SqlConnection conn, SqlTransaction? tran = null);
        List<CategoriaListDto> GetLista(SqlConnection conn, int currentPage,
            int pageSize, Func<CategoriaListDto, bool>? filter = null, SqlTransaction? tran = null);
        int GetCantidad(SqlConnection conn, Func<CategoriaListDto, bool>? filter = null, SqlTransaction? tran = null);
        int GetCategoriaIdIfExists(Categoria categoria, SqlConnection conn,
            SqlTransaction? tran = null);
        Categoria? GetCategoriaPorId(int categoriaId, SqlConnection conn,
            SqlTransaction? tran = null);
        List<Categoria> GetProductosPorCategoriaId(int categoriaId,
            SqlConnection conn, SqlTransaction? tran = null);
    }
}
