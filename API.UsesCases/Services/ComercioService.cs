using API.CoreBusiness.Response;
using API.CoreBusiness.Request;
using API.CoreBusiness.Entity;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.UsesCases.Services
{
    public class ComercioService : IComercioService
    {
        private readonly IUnitOfWork unitOfWork;

        public ComercioService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ComercioResponse> GetComercios()
        {
            var comercios = unitOfWork.ComercioRepository.GetAll();

            return comercios.Select(c => new ComercioResponse
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Direccion ?? "Sin dirección",
                Id_Categoria = c.Id_Categoria,
                Id_Cliente = c.Id_Cliente
            }).ToList();
        }

        public ComercioResponse CrearComercio(ComercioRequest request)
        {
            var nuevoComercio = new Comercio
            {
                Nombre = request.Nombre,
                Direccion = request.Direccion,
                Id_Categoria = request.Id_Categoria,
                Id_Cliente = request.Id_Cliente,
                Dias = request.Dias,
                DatosAdicionales = request.DatosAdicionales
            };

            try
            {
                if (!string.IsNullOrEmpty(request.Horario_Inicio))
                    nuevoComercio.Horario_Inicio = DateTime.Parse(request.Horario_Inicio);

                if (!string.IsNullOrEmpty(request.Horario_Fin))
                    nuevoComercio.Horario_Fin = DateTime.Parse(request.Horario_Fin);
            }
            catch
            {
                nuevoComercio.Horario_Inicio = null;
                nuevoComercio.Horario_Fin = null;
            }

            unitOfWork.ComercioRepository.Insert(nuevoComercio);
            unitOfWork.Save();

            return new ComercioResponse
            {
                Id = nuevoComercio.Id,
                Nombre = nuevoComercio.Nombre,
                Direccion = nuevoComercio.Direccion ?? "",
                Id_Categoria = nuevoComercio.Id_Categoria,
                Id_Cliente = nuevoComercio.Id_Cliente
            };
        }

        public ComercioResponse? GetComercioPorCliente(int idCliente)
        {
            var comercio = unitOfWork.ComercioRepository.GetAll()
                            .FirstOrDefault(c => c.Id_Cliente == idCliente);

            if (comercio == null) return null;

            return new ComercioResponse
            {
                Id = comercio.Id,
                Nombre = comercio.Nombre,
                Direccion = comercio.Direccion ?? "",
                Id_Categoria = comercio.Id_Categoria,
                Id_Cliente = comercio.Id_Cliente
            };
        }
    }
}