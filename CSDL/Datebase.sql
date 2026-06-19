CREATE TABLE khach_hang (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ma_kh VARCHAR(20) UNIQUE,
    ho_ten VARCHAR(100),
    sdt VARCHAR(20),
    dia_chi VARCHAR(200),
    tong_don INT DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE nhan_vien (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ma_nv VARCHAR(20) UNIQUE,
    ho_ten VARCHAR(100),
    sdt VARCHAR(20),
    chuc_vu VARCHAR(50),
    tai_khoan VARCHAR(50),
    mat_khau VARCHAR(100),
    trang_thai VARCHAR(30)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE san_pham (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ma_banh VARCHAR(20) UNIQUE,
    ten_banh VARCHAR(100),
    loai_banh VARCHAR(50),
    gia_ban DECIMAL(18,2),
    so_luong INT,
    mo_ta TEXT,
    trang_thai VARCHAR(30)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE nguyen_lieu (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ma_nl VARCHAR(20) UNIQUE,
    ten_nl VARCHAR(100),
    don_vi VARCHAR(30),
    so_luong_ton INT,
    trang_thai VARCHAR(30)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE hoa_don (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ma_hd VARCHAR(30) UNIQUE,
    id_khach_hang INT,
    id_nhan_vien INT,
    ngay_lap DATETIME,
    ngay_nhan DATE,
    ghi_chu TEXT,
    tong_tien DECIMAL(18,2),
    trang_thai VARCHAR(30),
    FOREIGN KEY (id_khach_hang) REFERENCES khach_hang(id),
    FOREIGN KEY (id_nhan_vien) REFERENCES nhan_vien(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE chi_tiet_hoa_don (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ma_cthd INT,
    ma_hd VARCHAR(30),
    ma_banh VARCHAR(20),
    so_luong INT,
    don_gia DECIMAL(18,2),
    thanh_tien DECIMAL(18,2),
    FOREIGN KEY (ma_hd) REFERENCES hoa_don(ma_hd),
    FOREIGN KEY (ma_banh) REFERENCES san_pham(ma_banh)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
