using System;
using System.Collections.Generic;
using System.Text;
using Persistence;
using Models;
using System.Linq;

namespace Services
{

    public interface IDiagnosticoServices
    {

        IEnumerable<Diagnostico> GetAll();
        Diagnostico Get(int id);
        bool Add(Diagnostico model);
        bool Update(Diagnostico paciente);
        bool Delete(int id);

    }

  public  class DiagnosticoServices : IDiagnosticoServices
    {
        ApplicationDbContext _applicationDbContext;

        public DiagnosticoServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //Conseguir todos los Diagnosticos
        public IEnumerable<Diagnostico> GetAll()
        {
            var result = new List<Diagnostico>();

            try
            {
                result = _applicationDbContext.Diagnostico.ToList();

            }
            catch (Exception error)
            {

            }
            return result;
        }

        // Conseguir un diagnostico en especifico por el ID
        public Diagnostico Get(int id)
        {
            var result = new Diagnostico();

            try
            {

                result = _applicationDbContext.Diagnostico.Single(x => x.idDiagnostico == id);

            }
            catch (Exception error)
            {

            }
            return result;
        }

        //Agregar un nuevo Diagnostico
        public bool Add(Diagnostico model)
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

        //Metodo para actualizar un diagnostico
        public bool Update(Diagnostico diagnostico)
        {
            try
            {
                var originalDiagnostico = _applicationDbContext.Diagnostico.Single(x => x.idDiagnostico == diagnostico.idDiagnostico);


                originalDiagnostico.idPaciente = diagnostico.idPaciente;
                originalDiagnostico.idUsuario = diagnostico.idUsuario;
                originalDiagnostico.sintomas = diagnostico.sintomas;
                originalDiagnostico.enfermedad = diagnostico.enfermedad;
                originalDiagnostico.especialidad = diagnostico.especialidad;
                originalDiagnostico.comentario = diagnostico.comentario;
                originalDiagnostico.fecha = diagnostico.fecha;

                _applicationDbContext.Update(originalDiagnostico);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        // Funcion para borrar un diagnostico
        public bool Delete(int id)
        {
            try
            {
                _applicationDbContext.Entry(new Diagnostico { idDiagnostico = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
