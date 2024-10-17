﻿using Dapper;
using ProyectoSeminario.Datos.Interfaces;
using ProyectoSeminario.Entidades.Dtos;
using ProyectoSeminario.Entidades.Entidades;
using System.Data.SqlClient;

namespace ProyectoSeminario.Datos.Repositorios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        public void Agregar(Categoria categoria, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int CategoriaId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public void Editar(Categoria categoria, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Categoria categoria, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad(SqlConnection conn, Func<CategoriaListDto, bool>? filter = null, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT c.CategoriaId, c.NombreCategoria, c.Activa
                          FROM Categorias c";
            var query = conn.Query<CategoriaListDto>(selectQuery).ToList();
            if (filter != null)
            {
                query = query.Where(filter).ToList();
            }
            return query.Count;
        }

        public int GetCategoriaIdIfExists(Categoria categoria, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT CategoriaId FROM Categorias 
                WHERE NombreCategoria = @NombreCategoria";
            return conn.ExecuteScalar<int>(selectQuery, categoria, tran);
        }

        public Categoria? GetCategoriaPorId(int categoriaId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM Categorias WHERE CategoriaId = @CategoriaId";
            return conn.QuerySingleOrDefault<Categoria>(query, new { CategoriaId = categoriaId }, tran);
        }

        public List<CategoriaListDto> GetLista(SqlConnection conn, int currentPage, int pageSize, Func<CategoriaListDto, bool>? filter = null, SqlTransaction? tran = null)
        {
            var selectQuery =
                 @"SELECT c.CategoriaId, c.NombreCategoria, c.Activa
                          FROM Categorias c";

            var lista = conn.Query<CategoriaListDto>(
                selectQuery,
                transaction: tran
            ).ToList();

            if (filter != null)
            {
                lista = lista.Where(filter).ToList();
            }

            return lista.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Categoria> GetProductosPorCategoriaId(int productoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            SELECT * 
            FROM Categorias c
            JOIN Productos p ON c.CategoriaId = p.CategoriaId
            WHERE p.CategoriaId = @CategoriaId";
            return conn.Query<Categoria>(query, new { ProductoId = productoId }, tran).ToList();
        }
    }
}
