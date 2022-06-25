CREATE TABLE daftar (
	id INT NOT NULL PRIMARY KEY IDENTITY,
	nama VARCHAR (100) NOT NULL,
	tanggal VARCHAR (100) NOT NULL,
	keterangan VARCHAR (100) NOT NULL,
	tahap VARCHAR (100)
);

INSERT INTO daftar (nama, tanggal, keterangan, tahap)
VALUES
('Sistem Operasi', '29 Juni 2022', 'makalah kelompok manajemen operasi', 'todo'),
('PBO', '25 Juni 2022', 'WEB CRUD C#', 'todo'),
('TBO', '28 Juni 2022', 'poster kelompok', 'doing'),
('ADPL', '20 Juni 2022', 'Presentasi Tugas Akhir', 'doing'),
('PPL', '18 Juni 2022', 'Presentasi asdos dan dosen', 'done'),
('PWEB', '17 Juni 2022', 'website e-commerce kelompok', 'done')