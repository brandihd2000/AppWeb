using System;
using System.Collections.Generic;
using System.Text;
using Persistence;
using Models;
using System.Linq;

namespace Services
{

    public interface IObservacionesServices
    {
        IEnumerable<Observaciones> GetAll();
        Observaciones Get(int id);
        bool Add(Observaciones model);
        bool Update(Observaciones observaciones );
        bool Delete(int id);
    }

    public  class ObservacionesServices : IObservacionesServices
    {
        ApplicationDbContext _applicationDbContext; 

        public ObservacionesServices( ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //Conseguir todos las observaciones
        public IEnumerable<Observaciones> GetAll()
        {
            var result = new List<Observaciones>();

            try
            {
                result = _applicationDbContext.Observaciones.ToList();

            }
            catch (Exception error)
            {

            }
            return result;
        }

        // Conseguir una observacion en especifico por el ID
        public Observaciones Get(int id)
        {
            var result = new Observaciones();

            try
            {

                result = _applicationDbContext.Observaciones.Single(x => x.idObservaciones == id);

            }
            catch (Exception error)
            {

            }
            return result;
        }

        //Agregar una nueva observacion
         public bool Add(Observaciones model)
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

        //Metodo para actualizar un observaciones
        public bool Update(Observaciones observaciones)
        {
            try
            {
                var originalObservacion = _applicationDbContext.Observaciones.Single(x => x.idObservaciones == observaciones.idObservaciones);


                originalObservacion.idPaciente = observaciones.idPaciente;
                originalObservacion.discapacidad = observaciones.discapacidad;
                originalObservacion.enfermedades = observaciones.enfermedades;
                originalObservacion.alergias = observaciones.alergias;
                originalObservacion.medicamentos = observaciones.medicamentos;
                

                _applicationDbContext.Update(originalObservacion);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        // funcion para borrar observaciones
        public bool Delete(int id)
        {
            try
            {
                _applicationDbContext.Entry(new Observaciones { idObservaciones = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
