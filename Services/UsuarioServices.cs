using System;
using System.Collections.Generic;
using System.Text;
using Persistence;
using Models;

namespace Services
{

    public interface IUsuarioServices
    {

    }

    public class UsuarioServices : IUsuarioServices
    {
        private ApplicationDbContext _applicationDbContext;

        public UsuarioServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

    }
}
