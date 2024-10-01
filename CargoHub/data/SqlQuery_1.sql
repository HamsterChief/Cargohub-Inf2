USE master;
GO

CREATE DATABASE Cargohub ON
(NAME = clients,
    FILENAME = 'C:\Users\jimmy\OneDrive\Documenten\GitHub\Cargohub-Inf2\CargoHub\data',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5)
LOG ON
(NAME = Sales_log,
    FILENAME = 'C:\Users\jimmy\OneDrive\Documenten\GitHub\Cargohub-Inf2\CargoHub\data',
    SIZE = 5 MB,
    MAXSIZE = 25 MB,
    FILEGROWTH = 5 MB);
GO