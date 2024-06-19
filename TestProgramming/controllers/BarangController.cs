[Route("api/[controller]")]
[ApiController]
public class BarangController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BarangController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Barang
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Barang>>> GetBarang()
    {
        return await _context.Barang.Include(b => b.Gudang).ToListAsync();
    }

    // GET: api/Barang/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Barang>> GetBarang(int id)
    {
        var barang = await _context.Barang.Include(b => b.Gudang).FirstOrDefaultAsync(b => b.KodeBarang == id);

        if (barang == null)
        {
            return NotFound();
        }

        return barang;
    }

    // POST: api/Barang
    [HttpPost]
    public async Task<ActionResult<Barang>> PostBarang(Barang barang)
    {
        _context.Barang.Add(barang);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBarang", new { id = barang.KodeBarang }, barang);
    }

    // PUT: api/Barang/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBarang(int id, Barang barang)
    {
        if (id != barang.KodeBarang)
        {
            return BadRequest();
        }

        _context.Entry(barang).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BarangExists(id))
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

    // DELETE: api/Barang/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarang(int id)
    {
        var barang = await _context.Barang.FindAsync(id);
        if (barang == null)
        {
            return NotFound();
        }

        _context.Barang.Remove(barang);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BarangExists(int id)
    {
        return _context.Barang.Any(e => e.KodeBarang == id);
    }
}