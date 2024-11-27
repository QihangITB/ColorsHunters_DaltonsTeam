-- Tabla con los datos del oftalmólogo
CREATE TABLE oftalmologos (
    id_oftalmologo INT AUTO_INCREMENT PRIMARY KEY,
    documento_identidad VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    correo VARCHAR(100),
);

-- Tabla con los datos del cliente
CREATE TABLE clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    documento_identidad VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    edad INT NOT NULL,
    telefono VARCHAR(20),
    correo VARCHAR(100),
    direccion TEXT,
    id_oftalmologo INT,
    CONSTRAINT fk_oftalmologo_asociado FOREIGN KEY (id_oftalmologo) REFERENCES oftalmologos(id_oftalmologo) ON DELETE SET NULL
);