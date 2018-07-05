using System;
using System.Collections.Generic;
using System.Text;
using Persistence;
using Models;
using System.Linq;

namespace Services
{

    public interface IPacienteServices
    {
        IEnumerable<Paciente> GetAll();
        Paciente Get(int id);
        bool Add(Paciente model);
        IEnumerable<Paciente> GetFiltro(string filtro);
      //  bool Guardar(ObservacionesPaciente observacionesPaciente);
        bool Update(Paciente paciente);
        bool Delete(int id);
    }

  public class PacienteServices : IPacienteServices
    {
        private ApplicationDbContext _applicationDbContext;

        public PacienteServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }



        //Conseguir todos los Pacientes
        public IEnumerable<Paciente> GetAll()
        {
            var result = new List<Paciente>();

            try
            {
                result = _applicationDbContext.Paciente.ToList();

            }
            catch (Exception error)
            {

            }
            return result;
        }

        // Conseguir un paciente en especifico por el ID
        public Paciente Get(int id)
        {
            var result = new Paciente();

            try
            {

                result = _applicationDbContext.Paciente.Single(x => x.idPaciente == id);

            }
            catch (Exception error)
            {

            }
            return result;
        }

        public IEnumerable<Paciente> GetFiltro(string filtro)
        {
            var result = new List<Paciente>();
            try
            {

                result = _applicationDbContext.Paciente.Where(p => (p.nombre.Contains(filtro) || p.apellido.Contains(filtro) || p.cedula.Contains(filtro))).ToList();



            }
            catch (Exception)
            {


            }
            return result;
        }



        //Agregar un paciente y su observacion 
        /*  public bool Guardar(ObservacionesPaciente observacionesPaciente)
          {

              try
              {



                  _applicationDbContext.Add(observacionesPaciente.paciente);
                  _applicationDbContext.SaveChanges();

                  observacionesPaciente.observaciones.idPaciente = 5;

                  _applicationDbContext.Add(observacionesPaciente.observaciones);
                 _applicationDbContext.SaveChanges();


              }
              catch (Exception)
              {

                  return false;
              }

     return true;


          }

      */

        //Agregar un nuevo paciente
        public bool Add(Paciente model)
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

        //Metodo para actualizar un paciente
        public bool Update(Paciente paciente)
        {
            try
            {
                var originalPaciente = _applicationDbContext.Paciente.Single(x => x.idPaciente == paciente.idPaciente);


                originalPaciente.nombre = paciente.nombre;
                originalPaciente.apellido = paciente.apellido;
                originalPaciente.cedula = paciente.cedula;
                originalPaciente.telefono = paciente.telefono;
                originalPaciente.fechaNacimiento = paciente.fechaNacimiento;
                originalPaciente.grupoSanguineo = paciente.grupoSanguineo;

                _applicationDbContext.Update(originalPaciente);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        // Funcion para borrar un paciente
        public bool Delete(int id)
        {
            try
            {
                _applicationDbContext.Entry(new Paciente { idPaciente = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
