using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
public class TicketBLL
{
    private Context _context;

    public TicketBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int TicketsId)
    {
        return _context.tickets.Any(t => t.TicketId == TicketsId);
    }

    public bool Insertar(Tickets tickets)
    {
        _context.tickets.Add(tickets);
        int guardado = _context.SaveChanges();
        _context.Entry(tickets).State = EntityState.Detached;
        return guardado > 0;
    }

    public bool Modificar(Tickets tickets)
    {
        _context.Update(tickets);
        int modificado = _context.SaveChanges();
        _context.Entry(tickets).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Tickets tickets)
    {
        if(!Existe(tickets.TicketId))
        {
            return Insertar(tickets);
        }
        else
        {
            return Modificar(tickets);
        }
    }

    public bool Eliminar(Tickets tickets)
    {
        _context.tickets.Remove(tickets);
        int eliminado = _context.SaveChanges();
        _context.Entry(tickets).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Tickets? Buscar(int TicketsId)
    {
        return _context.tickets.AsNoTracking().SingleOrDefault(t => t.TicketId == TicketsId);
    }

    public List<Tickets> Listar(Expression<Func<Tickets, bool>> Criterio)
    {
        return _context.tickets.Where(Criterio).AsNoTracking().ToList();
    }

}
