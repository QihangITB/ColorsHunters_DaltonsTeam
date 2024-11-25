-- Insertamos algunos oftalmólogos
INSERT INTO oftalmologos (documento_identidad, nombre, apellidos, telefono, correo)
VALUES
('12345678A', 'Juan', 'Pérez', '635 122 512', 'juan.perez@ejemplo.com'),
('87654321B', 'Ana', 'Gómez', '665 122 323', 'ana.gomez@ejemplo.com'),
('23456789C', 'Carlos', 'Martínez', '697 434 512', 'carlos.martinez@ejemplo.com'),
('34567890D', 'Laura', 'López', '678 122 234', 'laura.lopez@ejemplo.com'),
('45678901E', 'Pedro', 'Sánchez', '623 122 745', 'pedro.sanchez@ejemplo.com');

-- Insertamos algunos clientes de ejemplo
INSERT INTO clientes (documento_identidad, nombre, apellidos, telefono, correo, direccion, id_oftalmologo)
VALUES
('11223344A', 'Miguel', 'Ramírez', '634 123 123', 'miguel.ramirez@ejemplo.com', 'Calle Falsa 123, Madrid', 1),
('22334455B', 'Sofía', 'Martín', '623 234 234', 'sofia.martin@ejemplo.com', 'Avenida de la Libertad 456, Valencia', 2),
('33445566C', 'Luis', 'Fernández', '622 345 345', 'luis.fernandez@ejemplo.com', 'Plaza Mayor 789, Sevilla', 3),
('44556677D', 'Marta', 'García', '666 456 456', 'marta.garcia@ejemplo.com', 'Carrer de Gran Via 101, Barcelona', 3),
('55667788E', 'Roberto', 'López', '678 567 567', 'roberto.lopez@ejemplo.com', 'Calle del Sol 202, Málaga', 2);