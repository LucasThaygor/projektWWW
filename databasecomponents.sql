use konfiguratorprojekt;

CREATE TABLE IF NOT EXISTS PlytyGlowne (
    plyta_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    plyta_nazwa VARCHAR(255),
    plyta_chipset VARCHAR(50),
    plyta_socket VARCHAR(50),
    plyta_ddr VARCHAR(50),
    plyta_slotyram INT,
    plyta_taktowanieram INT,
    plyta_maxram INT
);

CREATE TABLE IF NOT EXISTS Procesory (
    procesor_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    procesor_nazwa VARCHAR(255),
    procesor_socket VARCHAR(50),
    procesor_ddr VARCHAR(50),
    procesor_grafika INT,
    procesor_taktowanie DOUBLE
);

CREATE TABLE IF NOT EXISTS RAM (
    ram_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    ram_nazwa VARCHAR(255),
    ram_ddr VARCHAR(50),
    ram_taktowanie INT,
    ram_slotyram INT,
    ram_rozmiar INT
);

CREATE TABLE IF NOT EXISTS KartyGraficzne (
    karta_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    karta_nazwa VARCHAR(255),
    karta_grafika INT,
    karta_pamiec INT
);

use konfiguratorprojekt;
select * from PlytyGlowne;
select * from Procesory;
select * from RAM;
select * from KartyGraficzne;