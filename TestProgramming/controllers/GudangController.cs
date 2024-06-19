[Route("api/[controller]")]
[ApiController]
public class GudangController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GudangController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Gudang
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gudang>>> GetGudang()
    {
        return await _context.Gudang.ToListAsync();
    }

    // GET: api/Gudang/
    [HttpGet("{id}")]
    public async Task<ActionResult<Gudang>> GetGudang(int id)
    {
        var gudang = await _context.Gudang.FindAsync(id);

        if (gudang == null)
        {
            return NotFound();
        }

        return gudang;
    }

    // POST: api/Gudang
    [HttpPost]
    public async Task<ActionResult<Gudang>> PostGudang(Gudang gudang)
    {
        _context.Gudang.Add(gudang);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGudang", new { id = gudang.KodeGudang }, gudang);
    }

    // PUT: api/Gudang/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGudang(int id, Gudang gudang)
    {
        if (id != gudang.KodeGudang)
        {
            return BadRequest();
        }

        _context.Entry(gudang).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GudangExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Gudang/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGudang(int id)
    {
        var gudang = await _context.Gudang.FindAsync(id);
        if (gudang == null)
        {
            return NotFound();
        }

        _context.Gudang.Remove(gudang);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GudangExists(int id)
    {
        return _context.Gudang.Any(e => e.KodeGudang == id);
    }
}
