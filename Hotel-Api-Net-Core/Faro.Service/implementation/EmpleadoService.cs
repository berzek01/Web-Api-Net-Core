using System.Collections.Generic;
using Faro.Domain;
using Faro.Repository;

namespace Faro.Service.implementation
{
    public class EmpleadoService : IEmpleadoService
    {
        private IEmpleadoRepository empleadoRepository;
        
        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository=empleadoRepository;
        }
        public bool Delete(int id)
        {
            return empleadoRepository.Delete(id);
        }

        public Empleado Get(int id)
        {
            return empleadoRepository.Get(id);
        }

        public IEnumerable<Empleado> GetAll()
        {
            return empleadoRepository.GetAll();  
        }

        public bool Save(Empleado entity)
        {
            return empleadoRepository.Save(entity);
        }

        public bool Update(Empleado entity)
        {
            throw new System.NotImplementedException();
        }
    }
}