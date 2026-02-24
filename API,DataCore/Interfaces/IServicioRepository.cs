using API.CoreBusiness.Entity;
using API.GenericCore.GenericRepository.Interfaces;

namespace API_DataCore.Interfaces;

public interface IServicioRepository : IGenericRepository<Servicio>
{
    void SoftDelete(Servicio servicio); 
}