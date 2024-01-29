using Microsoft.EntityFrameworkCore;
public class ClientesBLL
{
    private Context _context;

    public ClientesBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int ClienteId)
    {
        return _context.clientes.Any(c => c.ClienteId == ClienteId);
    }

    public bool Insertar(Clientes cliente)
    {
        _context.clientes.Add(cliente);
        int guardado = _context.SaveChanges();
        _context.Entry(cliente).State = EntityState.Detached;
        return guardado > 0;
    }

    public bool Modificar(Clientes cliente)
    {
        _context.Update(cliente);
        int modificado = _context.SaveChanges();
        _context.Entry(cliente).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Clientes cliente)
    {
        if(!Existe(cliente.ClienteId))
        {
            return Insertar(cliente);
        }
        else
        {
            return Modificar(cliente);
        }
    }

    public bool Eliminar(Clientes clientes)
    {
        _context.clientes.Remove(clientes);
        int eliminado = _context.SaveChanges();
        _context.Entry(clientes).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Clientes? Buscar(int ClienteId)
    {
        return _context.clientes.AsNoTracking().SingleOrDefault(c => c.ClienteId == ClienteId);
    }
}