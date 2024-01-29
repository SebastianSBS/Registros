using Microsoft.EntityFrameworkCore;
public class PrioridadesBLL
{
    private Context _context;

    public PrioridadesBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int PrioridadId)
    {
        return _context.prioridades.Any(p => p.PrioridadId == PrioridadId);
    }

    public bool Insertar(Prioridades prioridades)
    {
        _context.prioridades.Add(prioridades);
        int guardado = _context.SaveChanges();
        _context.Entry(prioridades).State = EntityState.Detached;
        return guardado > 0;
    }

    public bool Modificar(Prioridades prioridades)
    {
        _context.Update(prioridades);
        int modificado = _context.SaveChanges();
        _context.Entry(prioridades).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Prioridades prioridades)
    {
        if(!Existe(prioridades.PrioridadId))
        {
            return Insertar(prioridades);
        }
        else
        {
            return Modificar(prioridades);
        }
    }

    public bool Eliminar(Prioridades prioridades)
    {
        _context.prioridades.Remove(prioridades);
        int eliminado = _context.SaveChanges();
        _context.Entry(prioridades).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Prioridades? Buscar(int PrioridadId)
    {
        return _context.prioridades.AsNoTracking().SingleOrDefault(p => p.PrioridadId == PrioridadId);
    }
}