CREATE DATABASE cafe_mania_db;
USE cafe_mania_db;
DROP DATABASE cafe_mania_db;

CREATE TABLE Colaborador (
id_colaborador INT NOT NULL AUTO_INCREMENT,	
nome_colaborador VARCHAR(255) NOT NULL,
contato_colaborador VARCHAR(255) NOT NULL,
cargo_colaborador VARCHAR(255) NOT NULL,
permissoes_colaborador VARCHAR(20) NOT NULL,
usuario_colaborador VARCHAR(255) NOT NULL,
senha_colaborador VARCHAR(255) NOT NULL,
PRIMARY KEY (id_colaborador)
);

CREATE TABLE Estoque (
id_estoque INT NOT NULL AUTO_INCREMENT,	
quantidade_prod INT NOT NULL,
data_validade DATE NOT NULL,
tipo_movimento VARCHAR(255) NOT NULL,
PRIMARY KEY (id_estoque)
);

CREATE TABLE Fornecedor (
id_fornecedor INT NOT NULL AUTO_INCREMENT,	
nome_fornecedor VARCHAR(255) NOT NULL,
cnpj_fornecedor VARCHAR(14) NOT NULL,
endereco_fornecedor VARCHAR(255) NOT NULL,
telefone_fornecedor VARCHAR(20) NOT NULL,
PRIMARY KEY (id_fornecedor)
);

CREATE TABLE Produto_fornecedor(
id_produtoFornecedor INT NOT NULL AUTO_INCREMENT,
fk_id_produto INT NOT NULL,
fk_id_fornecedor INT NOT NULL,
PRIMARY KEY (id_produtoFornecedor),
FOREIGN KEY (fk_id_produto) REFERENCES Produto(id_produto), 
FOREIGN KEY (fk_id_fornecedor) REFERENCES Fornecedor(id_fornecedor) 
);

CREATE TABLE Produto (
id_produto INT NOT NULL AUTO_INCREMENT,	
nome_produto VARCHAR(255) NOT NULL,
desc_produto VARCHAR(255) NOT NULL,
valor_un_produto DECIMAL(10,2) NOT NULL,
quant_estoque INT NOT NULL,
fk_id_estoque INT NOT NULL,
PRIMARY KEY (id_produto),
FOREIGN KEY (fk_id_estoque) REFERENCES Estoque(id_estoque)
);

CREATE TABLE Item_venda(
id_itemVenda INT NOT NULL AUTO_INCREMENT,
quantidade_produto_venda INT NOT NULL,
valor_un_produto DECIMAL(10,2) NOT NULL,
subtotal_venda DECIMAL(10,2) NOT NULL,
fk_id_venda INT NOT NULL,
fk_id_produto INT NOT NULL,
PRIMARY KEY (id_itemVenda),
FOREIGN KEY (fk_id_venda) REFERENCES Venda(id_venda), 
FOREIGN KEY (fk_id_produto) REFERENCES Produto(id_produto) 
);

CREATE TABLE Venda (
id_venda INT NOT NULL AUTO_INCREMENT,
data_hora_venda DATETIME NOT NULL,
forma_pagamento VARCHAR(50) NOT NULL,
valor_total DECIMAL(10,2) NOT NULL,
fk_id_colaborador INT NOT NULL,
fk_id_relatorioVenda INT NOT NULL,
PRIMARY KEY (id_venda),
FOREIGN KEY (fk_id_colaborador) REFERENCES Colaborador(id_colaborador),
FOREIGN KEY (fk_id_relatorioVenda) REFERENCES Relatorio_venda(id_relatorioVenda)
);

CREATE TABLE Relatorio_venda (
id_relatorioVenda INT NOT NULL AUTO_INCREMENT,	
data_relatorioVenda DATETIME NOT NULL,
dados_relatorioVenda VARCHAR(255) NOT NULL,
PRIMARY KEY (id_relatorioVenda)
);

INSERT INTO Produto (nome_produto, desc_produto, valor_un_produto, quant_estoque, fk_id_estoque)
VALUES 
    ('Café Expresso', 'Café forte e encorpado', 5.50, 100, 1),
    ('Cappuccino', 'Café com leite e espuma', 7.00, 50, 2),
    ('Chá Verde', 'Chá natural e refrescante', 4.00, 75, 1),
    ('Pão de Queijo', 'Delicioso pão de queijo mineiro', 3.50, 200, 3),
    ('Bolo de Chocolate', 'Fatia de bolo com cobertura', 8.00, 30, 2),
    ('Croissant', 'Massa folhada amanteigada', 6.50, 40, 3),
    ('Suco de Laranja', 'Suco natural sem açúcar', 5.00, 60, 1),
    ('Torrada com Geleia', 'Pão torrado com geleia artesanal', 4.50, 25, 2),
    ('Cookie de Chocolate', 'Biscoito com gotas de chocolate', 3.00, 90, 3),
    ('Muffin de Blueberry', 'Bolinho macio com mirtilos', 6.00, 35, 2);

INSERT INTO Estoque (quantidade_prod, data_validade, tipo_movimento)
VALUES 
    (100, '2025-06-30', 'Entrada'),
    (200, '2025-07-15', 'Saída'),
    (50, '2025-05-20', 'Entrada'),
    (150, '2025-06-10', 'Saída'),
    (75, '2025-08-05', 'Entrada'),
    (180, '2025-06-25', 'Entrada'),
    (60, '2025-07-01', 'Saída'),
    (130, '2025-05-30', 'Entrada'),
    (90, '2025-06-18', 'Saída'),
    (120, '2025-07-07', 'Entrada');

SELECT * FROM Estoque;
SELECT * FROM Produto;
 

