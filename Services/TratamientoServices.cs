using System;
using System.Collections.Generic;
using System.Text;
using Persistence;
using Models;
using System.Linq;

namespace Services
{

    public interface ITratamientoServices
    {
        IEnumerable<Tratamiento> GetAll();
        Tratamiento Get(int id);
        bool Add(Tratamiento model);
        bool Update(Tratamiento tratamiento);
        bool Delete(int id);
    }

   public class TratamientoServices : ITratamientoServices
    {

        private ApplicationDbContext _applicationDbContext;

        public TratamientoServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //Conseguir todos los Tratamientos
        public IEnumerable<Tratamiento> GetAll()
        {
            var result = new List<Tratamiento>();

            try
            {
                result = _applicationDbContext.Tratamiento.ToList();

            }
            catch (Exception error)
            {

            }
            return result;
        }

        // Conseguir un Tratamiento en especifico por el ID
        public Tratamiento Get(int id)
        {
            var result = new Tratamiento();

            try
            {

                result = _applicationDbContext.Tratamiento.Single(x => x.idTratamiento == id);

            }
            catch (Exception error)
            {

            }
            return result;
        }

        //Agregar un nuevo tratamiento
        public bool Add(Tratamiento model)
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


        //Metodo para actualizar un tratamiento
        public bool Update(Tratamiento tratamiento)
        {
            try
            {
                var originalTratamiento = _applicationDbContext.Tratamiento.Single(x => x.idTratamiento == tratamiento.idTratamiento);


                originalTratamiento.idDiagnostico = tratamiento.idDiagnostico;
                originalTratamiento.fechaInicio = tratamiento.fechaInicio;
                originalTratamiento.fechaFin = tratamiento.fechaFin;
                originalTratamiento.comentario = tratamiento.comentario;
             

                _applicationDbContext.Update(originalTratamiento);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        // Funcion para borrar un tratamiento
        public bool Delete(int id)
        {
            try
            {
                _applicationDbContext.Entry(new Tratamiento { idTratamiento = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
