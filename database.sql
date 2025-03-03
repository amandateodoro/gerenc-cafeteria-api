CREATE DATABASE cafe_mania_db;
USE cafe_mania_db;
DROP DATABASE cafe_mania_db;

CREATE TABLE Colaborador (
id_colaborador INT NOT NULL AUTO_INCREMENT,	
nome_colaborador VARCHAR(255) NOT NULL,
contato_colaborador VARCHAR(255) NOT NULL,
cargo_colaborador VARCHAR(255) NOT NULL,
permissoes_colaborador BOOLEAN NOT NULL,
usuario_colaborador VARCHAR(255) NOT NULL,
senha_colaborador VARCHAR(255) NOT NULL,
PRIMARY KEY (id_colaborador)
);

CREATE TABLE Estoque (
id_estoque INT NOT NULL AUTO_INCREMENT,	
quantidade_prod INT NOT NULL,
data_validade DATE NOT NULL,
tipo_movimento VARCHAR(255) NOT NULL,
fk_id_produto INT NOT NULL,
PRIMARY KEY (id_estoque),
FOREIGN KEY (fk_id_produto) REFERENCES Produto(id_produto)
);

CREATE TABLE Fornecedor (
id_fornecedor INT NOT NULL AUTO_INCREMENT,	
nome_fornecedor VARCHAR(255) NOT NULL,
contato_fornecedor VARCHAR(255) NOT NULL,
endereco_fornecedor VARCHAR(255) NOT NULL,
PRIMARY KEY (id_fornecedor)
);

CREATE TABLE Produto (
id_produto INT NOT NULL AUTO_INCREMENT,	
nome_produto VARCHAR(255) NOT NULL,
desc_produto VARCHAR(255) NOT NULL,
valor_un_produto DOUBLE NOT NULL,
quant_estoque INT NOT NULL,
data_validade DATE NOT NULL,
fk_id_fornecedor INT NOT NULL,
PRIMARY KEY (id_produto),
FOREIGN KEY (fk_id_fornecedor) REFERENCES Fornecedor(id_fornecedor)
);

CREATE TABLE Venda (
id_venda INT NOT NULL AUTO_INCREMENT,
data_hora_venda DATETIME NOT NULL,
quantidade_produto INT NOT NULL,
forma_pagamento VARCHAR(50) NOT NULL,
valor_total DOUBLE NOT NULL,
fk_id_colaborador INT NOT NULL,
fk_id_produto INT NOT NULL,
fk_id_relatorioVenda INT NOT NULL,
PRIMARY KEY (id_venda),
FOREIGN KEY (fk_id_colaborador) REFERENCES Colaborador(id_colaborador),
FOREIGN KEY (fk_id_relatorioVenda) REFERENCES Relatorio_venda(id_relatorioVenda),
FOREIGN KEY (fk_id_produto) REFERENCES Produto(id_produto)
);

CREATE TABLE Relatorio_venda (
id_relatorioVenda INT NOT NULL AUTO_INCREMENT,	
data_relatorioVenda DATETIME NOT NULL,
dados_relatorioVenda VARCHAR(255) NOT NULL,
PRIMARY KEY (id_relatorioVenda)
);

##INSERT INTO Colaborador VALUES ();
##INSERT INTO Estoque VALUES ();
##INSERT INTO Fornecedor VALUES ();
##INSERT INTO Pagamento VALUES ();
##INSERT INTO Produto VALUES ();
##INSERT INTO Relatorio_venda VALUES ();
##INSERT INTO Venda VALUES ();
    
##SELECT * FROM servidor, campus WHERE id_cam_fk = id_cam;
##SELECT * FROM Colaborador;
##SELECT * FROM Estoque;

## DROP TABLE Venda;
 

