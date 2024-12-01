-- Tabla con los datos del oftalmólogo
CREATE TABLE oftalmologos (
    id_oftalmologo INT AUTO_INCREMENT PRIMARY KEY,
    documento_identidad VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    correo VARCHAR(100)
);

-- Tabla con los datos del cliente
CREATE TABLE clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    documento_identidad VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    edad VARCHAR(2) NOT NULL,
    telefono VARCHAR(20),
    correo VARCHAR(100),
    direccion TEXT,
    id_oftalmologo INT,
    CONSTRAINT fk_oftalmologo_asociado FOREIGN KEY (id_oftalmologo) REFERENCES oftalmologos(id_oftalmologo) ON DELETE SET NULL
);

-- Tabla con los resultados de las pruebas
CREATE TABLE resultados (
    id_resultado INT AUTO_INCREMENT PRIMARY KEY,     
    id_cliente INT NOT NULL,                          
    resultado_prueba TEXT NOT NULL,                   
    fecha DATE,                   
    CONSTRAINT fk_cliente_asociado FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)  ON DELETE CASCADE
);