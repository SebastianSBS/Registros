using Microsoft.EntityFrameworkCore;
public class SistemasBLL
{
    private Context _context;

    public SistemasBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int SistemaId)
    {
        return _context.sistemas.Any(s => s.SistemaId == SistemaId);
    }

    public bool Insertar(Sistemas sistemas)
    {
        _context.sistemas.Add(sistemas);
        int guardado = _context.SaveChanges();
        _context.Entry(sistemas).State = EntityState.Detached;
        return guardado > 0;
    }

    public bool Modificar(Sistemas sistemas)
    {
        _context.Update(sistemas);
        int modificado = _context.SaveChanges();
        _context.Entry(sistemas).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Sistemas sistemas)
    {
        if(!Existe(sistemas.SistemaId))
        {
            return Insertar(sistemas);
        }
        else
        {
            return Modificar(sistemas);
        }
    }

    public bool Eliminar(Sistemas sistemas)
    {
        _context.sistemas.Remove(sistemas);
        int eliminado = _context.SaveChanges();
        _context.Entry(sistemas).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Sistemas? Buscar(int sistemasId)
    {
        return _context.sistemas.AsNoTracking().SingleOrDefault(p => p.SistemaId == sistemasId);
    }
}