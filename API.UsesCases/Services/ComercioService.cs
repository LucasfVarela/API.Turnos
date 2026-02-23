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
                Id_Cliente = c.Id_Cliente,
                Dias = c.Dias, // AHORA SÍ PASAMOS LOS DÍAS
                Horario_Inicio = c.Horario_Inicio,
                Horario_Fin = c.Horario_Fin,
                DatosAdicionales = c.DatosAdicionales
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
                Id_Cliente = nuevoComercio.Id_Cliente,
                Dias = nuevoComercio.Dias,
                Horario_Inicio = nuevoComercio.Horario_Inicio,
                Horario_Fin = nuevoComercio.Horario_Fin,
                DatosAdicionales = nuevoComercio.DatosAdicionales
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
                Id_Cliente = comercio.Id_Cliente,
                Dias = comercio.Dias, // AHORA SÍ SE MANDAN AL PERFIL
                Horario_Inicio = comercio.Horario_Inicio,
                Horario_Fin = comercio.Horario_Fin,
                DatosAdicionales = comercio.DatosAdicionales
            };
        }

        public ComercioResponse ActualizarComercio(int id, ComercioRequest request)
        {
            var comercio = unitOfWork.ComercioRepository.GetAll().FirstOrDefault(c => c.Id == id);
            if (comercio == null) return null;

            comercio.Nombre = request.Nombre; // <-- Agregado
            comercio.Direccion = request.Direccion;
            comercio.Id_Categoria = request.Id_Categoria; // <-- Agregado
            comercio.Dias = request.Dias;
            comercio.DatosAdicionales = request.DatosAdicionales; // <-- Agregado

            try
            {
                if (!string.IsNullOrEmpty(request.Horario_Inicio))
                    comercio.Horario_Inicio = DateTime.Parse(request.Horario_Inicio);

                if (!string.IsNullOrEmpty(request.Horario_Fin))
                    comercio.Horario_Fin = DateTime.Parse(request.Horario_Fin);
            }
            catch { }

            unitOfWork.ComercioRepository.Update(comercio);
            unitOfWork.Save();

            return new ComercioResponse
            {
                Id = comercio.Id,
                Nombre = comercio.Nombre,
                Direccion = comercio.Direccion,
                Id_Categoria = comercio.Id_Categoria,
                Id_Cliente = comercio.Id_Cliente,
                Dias = comercio.Dias,
                Horario_Inicio = comercio.Horario_Inicio,
                Horario_Fin = comercio.Horario_Fin,
                DatosAdicionales = comercio.DatosAdicionales
            };
        }
    }
}