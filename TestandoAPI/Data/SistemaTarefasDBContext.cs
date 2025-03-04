﻿using Microsoft.EntityFrameworkCore;
using TestandoAPI.Models;

namespace TestandoAPI.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext ( DbContextOptions<SistemaTarefasDBContext> options ) : base( options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
