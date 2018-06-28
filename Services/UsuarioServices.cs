using System;
using System.Collections.Generic;
using System.Text;
using Persistence;
using Models;
using System.Linq;

namespace Services
{

    public interface IUsuarioServices
    {
        IEnumerable<Usuario> GetAll();
        Usuario Get(int id);
        bool Add(Usuario model);
        bool Update(Usuario usuario);
        bool Delete(int id);
    }

    public class UsuarioServices : IUsuarioServices
    {
        private ApplicationDbContext _applicationDbContext;

        public UsuarioServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }


        //Conseguir todos los usuarios
        public IEnumerable<Usuario> GetAll()
        {
            var result = new List<Usuario>();

            try
            {
                result = _applicationDbContext.Usuario.ToList();

            }
            catch (Exception error)
            {
                
            }
            return result;
        }

        // Conseguir un usuario en especifico por el ID
        public Usuario Get(int id)
        {
            var result = new Usuario();

            try
            {
               
                result = _applicationDbContext.Usuario.Single(x => x.idUsuario == id);

            }
            catch (Exception error)
            {

            }
            return result;
        }

        //Agregar un nuevo usuario
        public bool Add(Usuario model)
        {
            try
            {
                _applicationDbContext.Add(model);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        //Metodo para actualizar un usuario
        public bool Update(Usuario usuario)
        {
            try
            {
                var originalUser = _applicationDbContext.Usuario.Single(x => x.idUsuario == usuario.idUsuario);


                originalUser.nombre = usuario.nombre;
                originalUser.apellido = usuario.apellido;
                originalUser.especialidad = usuario.especialidad;
                originalUser.tipo = usuario.tipo;
                originalUser.email = usuario.email;
                originalUser.contraseña = usuario.contraseña;
            
                _applicationDbContext.Update(originalUser);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool Delete (int id)
        {
            try
            {
                _applicationDbContext.Entry(new Usuario { idUsuario = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

    }
}
