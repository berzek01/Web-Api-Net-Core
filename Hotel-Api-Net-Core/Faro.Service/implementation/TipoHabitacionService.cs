using System.Collections.Generic;
using Faro.Domain;
using Faro.Repository;

namespace Faro.Service.implementation
{
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private ITipoHabitacionRepository tipoHabitacionRepository;
        public TipoHabitacionService(ITipoHabitacionRepository tipoHabitacionRepository)
        {
            this.tipoHabitacionRepository=tipoHabitacionRepository;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public TipoHabitacion Get(int id)
        {
            return tipoHabitacionRepository.Get(id);
        }

        public IEnumerable<TipoHabitacion> GetAll()
        {
            return tipoHabitacionRepository.GetAll();
        }

        public bool Save(TipoHabitacion entity)
        {
            return tipoHabitacionRepository.Save(entity);
        }

        public bool Update(TipoHabitacion entity)
        {
            return tipoHabitacionRepository.Update(entity);
        }
    }
}