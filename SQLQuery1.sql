create database Agen_Viagem

CREATE TABLE Destino(
iddestino INT PRIMARY KEY IDENTITY,
localdestino VARCHAR(60) NOT NULL,
dataida VARCHAR(15),
qtdpassageiros INT NOT NULL
);

select * from Destino

CREATE TABLE Passageiro(
codigocliente INT PRIMARY KEY IDENTITY,
nome VARCHAR(150) NOT NULL,
identidade VARCHAR(50) UNIQUE NOT NULL,
idade VARCHAR(80),
email VARCHAR,
CONSTRAINT fk_Destino_iddestino FOREIGN KEY (codigocliente) REFERENCES Destino(iddestino)
);

select * from Passageiro

CREATE TABLE Hotel(
idhotel INT PRIMARY KEY IDENTITY, 
nome VARCHAR(140) NOT NULL,
qtdhospede INT NOT NULL,
)

select * from Hotel