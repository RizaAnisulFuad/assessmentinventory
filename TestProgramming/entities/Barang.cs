public class Barang
{
    public int idBarang { get; set; }
    public string namaBarang { get; set; }
    public decimal hargaBarang { get; set; }
    public int jumlahBarang { get; set; }
    public DateTime expiredBarang { get; set; }
    public int idGudang { get; set; }
    
    public Gudang Gudang { get; set; }
}
