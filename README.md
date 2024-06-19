# .Net_Assessment

## 1. Bisa mengukur algoritma berfikir 
beberapa solusi dari studi kasus Gudang supermarket yaitu : 

1. Mengelola data dan labeling guna mengkategorikan berdasarkan expired terdekat setiap barang atau stok hal ini akan berefek dengan :
- Rotasi stok dalam waktu berkala karena metode yang akan berlaku menjadi first in first out.
- labeling mempermudah karyawan untuk mengecek barang

2. pengelolaan data akan menghasilkan laporan tercetak guna mudah melakukan tracing barang yang mendekati masa kadaluarsa.pengelolaan ini juga bermanfaat untuk manajemen stok barang kedepan agar dapat mengelompokkan barang yang fast moving maupun bukan sekaligus berdampak pada pengurangan kelebihan barang yang mendekati kadaluarsa.

3. Perjanjian return barang yang mendekati kadaluarsa kepada distributor/pemasok.

4. membuat sistem monitoring barang, hal ini akan berdampak dengan pemanfaatan teknologi seperti :
- database : pembuatan tabel yang berisi informasi tentang produk-produk supermarket beserta kadaluarsanya
- alert check : dari database yang sudah dibuat dan dimasukkan tadi juga bisa dimanfaatkan untuk reminder barang mana saya yang mungkin akan kadaluarsa dalam waktu dekat sehingga pengambilan keputusan juga akan sangat cepat diambil. 


## 2. Penguasaan terhadap query db 
1. tabel gudang dan barang
```
CREATE TABLE Gudang (
    Id_Gudang SERIAL PRIMARY KEY,
    NamaGudang VARCHAR(100) NOT NULL
);

CREATE TABLE Barang (
    Id_Barang SERIAL PRIMARY KEY,
    NamaBarang VARCHAR(100) NOT NULL,
    HargaBarang DECIMAL(18, 2) NOT NULL,
    JumlahBarang INT NOT NULL,
    ExpiredBarang DATE NOT NULL,
    Id_Gudang INT NOT NULL,
    fk_id_gudang FOREIGN KEY(Id_Gudang) REFERENCES Gudang(Id_Gudang)
);

-- Membuat Index
CREATE INDEX IDX_ExpiredBarang ON Barang(ExpiredBarang);
CREATE INDEX IDX_Id_Gudang ON Barang(Id_Gudang);
```

2. Store Prosedure menggunakan dynamic query dan paging 
```
CREATE OR REPLACE FUNCTION GetBarangWithPaging(
    p_page_number INT,
    p_page_size INT,
    p_sort_column VARCHAR,
    p_sort_direction VARCHAR
) RETURNS TABLE (
    Id_Gudang INT,
    NamaGudang VARCHAR,
    Id_Barang INT,
    NamaBarang VARCHAR,
    HargaBarang DECIMAL,
    JumlahBarang INT,
    ExpiredBarang DATE
) AS $$
BEGIN
    RETURN QUERY EXECUTE
    'SELECT g."Id_Gudang", g."NamaGudang", b."Id_Barang", b."NamaBarang", b."HargaBarang", b."JumlahBarang", b."ExpiredBarang"
     FROM "Barang" b
     JOIN "Gudang" g ON b."Id_Gudang" = g."Id_Gudang"
     ORDER BY ' || p_sort_column || ' ' || p_sort_direction ||
     ' OFFSET ' || (p_page_number - 1) * p_page_size ||
     ' LIMIT ' || p_page_size;
END;
```

3. Trigger ketika Input Barang di salah satu gudang muncul kan barang yang kadaluarsa
```

```

## 3. Kemampuan programming  
