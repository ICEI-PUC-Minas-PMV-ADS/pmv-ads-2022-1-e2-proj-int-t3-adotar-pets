using AdoptApi.Database;

namespace AdoptApi.Repositories;

public class PetRepository
{
    private Context _context;

    public PetRepository(Context context)
    {
        _context = context;
    }
    
    //@TODO Implementar camada de dados (Data Layer)
}