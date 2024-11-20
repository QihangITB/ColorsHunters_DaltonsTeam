--Tabla con los datos del oftalmologo--
CREATE TABLE oftalmologos (
    id_oftalmologo SERIAL PRIMARY KEY,
    documento_identidad VARCHAR(20) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    correo VARCHAR(100),
    CONSTRAINT unique_documento_identidad_of UNIQUE(documento_identidad)
);

--Tabla con los datos del cliente--
CREATE TABLE clientes (
    id_cliente SERIAL PRIMARY KEY,
    documento_identidad VARCHAR(20) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    correo VARCHAR(100),
    direccion TEXT,
    id_oftalmologo INT,
    CONSTRAINT unique_documento_identidad_cli UNIQUE(documento_identidad),
    CONSTRAINT fk_oftalmologo_asociado FOREIGN KEY (id_oftalmologo) REFERENCES oftalmologos(id_oftalmologo) ON DELETE SET NULL
);