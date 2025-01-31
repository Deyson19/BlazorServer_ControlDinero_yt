using BlazorServer_ControlDinero.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer_ControlDinero.Services
{
    public class ControlDineroService(ApplicationDbContext dbContext, ILogger<ControlDineroService> logger) : IControlDineroService
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly ILogger<ControlDineroService> _logger = logger;

        public async Task<ControlDinero> Actualizar(int id, UpsertControlDinero model)
        {
            var registro = await GetControlDinero(id);
            if (registro != null)
            {
                registro.Descripcion = model.Descripcion;
                registro.Valor = model.Valor;
                registro.EsIngreso = model.EsIngreso;

                _dbContext.Entry(registro).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Se actualizó un registro");
                return registro;
            }
            return null!;
        }

        public async Task<ControlDinero> Crear(UpsertControlDinero model)
        {
            if (model != null)
            {
                ControlDinero modelToEntity = new()
                {
                    Descripcion = model.Descripcion,
                    Valor = model.Valor,
                    EsIngreso = model.EsIngreso,
                    FechaIngreso = DateTime.Now,
                };
                var result = await _dbContext.ControlDineros.AddAsync(modelToEntity);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null!;
        }

        public async Task<ControlDinero> Detalle(int id)
        {
            return await GetControlDinero(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            var registro = await GetControlDinero(id);
            if (registro != null)
            {
                _dbContext.ControlDineros.Remove(registro);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Se eliminó un registro");
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ControlDinero>> Listado()
        {
            return await _dbContext.ControlDineros.ToListAsync();
        }

        public async Task<IEnumerable<ControlDinero>> Listado(DateTime fechaInial, DateTime fechaFinal)
        {
            var listado = await _dbContext.ControlDineros.Where(
                x => x.FechaIngreso > fechaInial || x.FechaIngreso < fechaFinal
                ).ToListAsync();
            return listado;
        }

        private async Task<ControlDinero> GetControlDinero(int id)
        {
            var registro = await _dbContext.ControlDineros.FindAsync(id);
            return registro!;
        }
    }
}
