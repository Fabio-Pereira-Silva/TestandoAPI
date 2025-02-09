using Microsoft.EntityFrameworkCore;
using TestandoAPI.Data;
using TestandoAPI.Models;
using TestandoAPI.Repositorios.Interface;

namespace TestandoAPI.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContex;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContex = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            _dbContex.Usuarios.Add(usuario);
            _dbContex.SaveChanges();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {

                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }
             
            _dbContex.Usuarios.Remove(usuarioPorId);
            _dbContex.SaveChanges();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {

                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContex.Usuarios.Update(usuarioPorId);
            _dbContex.SaveChanges();

            return usuarioPorId;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContex.Usuarios.FirstAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }
    }
}
