using BlazorServer_ControlDinero.Data;

namespace BlazorServer_ControlDinero.Services
{
    public interface IControlDineroService
    {
        Task<bool> Eliminar(int id);
        Task<IEnumerable<ControlDinero>> Listado();
        Task<IEnumerable<ControlDinero>> Listado(DateTime fechaInial, DateTime fechaFinal);
        Task<ControlDinero> Detalle(int id);
        Task<ControlDinero> Actualizar(int id,UpsertControlDinero model);
        Task<ControlDinero> Crear(UpsertControlDinero model);
    }
}
