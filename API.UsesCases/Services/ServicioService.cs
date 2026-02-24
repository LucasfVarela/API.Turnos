using API.CoreBusiness.Entity;
using API.CoreBusiness.Request; // Asegurate de tener este using
using API.CoreBusiness.Response;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;

namespace API.UsesCases.Services;

public class ServicioService : IServicioService
{
    private readonly IUnitOfWork UnitOfWork;

    public ServicioService(IUnitOfWork unitOfWork)
    {
        this.UnitOfWork = unitOfWork;
    }

    public IEnumerable<ServicioResponse> GetServiciosByComercio(int idComercio)
    {
        var servicios = UnitOfWork.ServicioRepository.Find(x => x.Id_Comercio == idComercio && x.Activo == true);

        return servicios.Select(s => new ServicioResponse
        {
            Id = s.Id,
            Nombre = s.Nombre,
            Id_Comercio = s.Id_Comercio,
            Precio = s.Precio,
            DuracionMinutos = s.DuracionMinutos,
            Descripcion = s.Descripcion,
            Activo = s.Activo
        });
    }

    public ServicioResponse GetServicioById(int id)
    {
        var s = UnitOfWork.ServicioRepository.Find(x => x.Id == id).FirstOrDefault();
        if (s == null) return null;

        return new ServicioResponse
        {
            Id = s.Id,
            Nombre = s.Nombre,
            Id_Comercio = s.Id_Comercio,
            Precio = s.Precio,
            DuracionMinutos = s.DuracionMinutos,
            Descripcion = s.Descripcion,
            Activo = s.Activo
        };
    }

    public ServicioResponse CreateServicio(ServicioRequest request)
    {
        var entity = new Servicio
        {
            Nombre = request.Nombre,
            Id_Comercio = request.Id_Comercio,
            Precio = request.Precio,
            DuracionMinutos = request.DuracionMinutos,
            Descripcion = request.Descripcion,
            Activo = true 
        };

        UnitOfWork.ServicioRepository.Insert(entity);
        UnitOfWork.Save();

        return new ServicioResponse
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Id_Comercio = entity.Id_Comercio,
            Precio = entity.Precio,
            DuracionMinutos = entity.DuracionMinutos,
            Descripcion = entity.Descripcion,
            Activo = entity.Activo
        };
    }

    public ServicioResponse UpdateServicio(int id, ServicioRequest request)
    {
        var entity = UnitOfWork.ServicioRepository.Find(x => x.Id == id).FirstOrDefault();
        
        if (entity == null) return null; 

       
        entity.Nombre = request.Nombre;
        entity.Precio = request.Precio;
        entity.DuracionMinutos = request.DuracionMinutos;
        entity.Descripcion = request.Descripcion;
        entity.Activo = request.Activo;
        
        

        UnitOfWork.ServicioRepository.Update(entity);
        UnitOfWork.Save();

        return new ServicioResponse
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Id_Comercio = entity.Id_Comercio,
            Precio = entity.Precio,
            DuracionMinutos = entity.DuracionMinutos,
            Descripcion = entity.Descripcion,
            Activo = entity.Activo
        };
    }

    
    public bool DeleteServicio(int id)
    {
        var servicio = UnitOfWork.ServicioRepository.Find(x => x.Id == id).FirstOrDefault();
        if (servicio == null) return false;

        UnitOfWork.ServicioRepository.SoftDelete(servicio);
        UnitOfWork.Save();
        return true;
    }
}