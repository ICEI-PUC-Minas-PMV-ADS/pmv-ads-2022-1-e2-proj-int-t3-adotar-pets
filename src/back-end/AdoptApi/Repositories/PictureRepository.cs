using AdoptApi.Database;
using AdoptApi.Models;

namespace AdoptApi.Repositories;

public class PictureRepository
{
    private Context _context;

    public PictureRepository(Context context)
    {
        _context = context;
    }

    public async Task<Picture> AddPicture(Picture picture)
    {
        await _context.Pictures.AddAsync(picture);
        await _context.SaveChangesAsync();
        return picture;
    }
}