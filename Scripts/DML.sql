--DML   Data Manipulation Language
USE [Event+];

INSERT INTO TipoDeUsuario (TituloTipoUsuario)
VALUES('Administrador'),('Comum')

--EXEMPLO DE FORMA SIMPLIFICADA, OBRIGADO PREENCHER TODOS OS CAMPOS NA ORDEM
--INSERT INTO TipoDeUsuario VALUES('Administrador'),('Comum')

INSERT INTO TipoDeEvento (TituloTipoEvento)
VALUES('SQL Server')

INSERT INTO Instituicao (CNPJ,NomeFantasia,Endereco)
VALUES('12345678901234', 'Rua Niter�i 180', 'DevSchool')

INSERT INTO Usuario (IdTipoDeUsuario,Nome,Email,Senha)
VALUES (1,'Paulo','admin@gmail.com','admin1234')

INSERT INTO Evento (IdInstituicao,IdTipoDeEvento,NomeDoEvento,Descricao,DataEvento,HoraEvento)
VALUES(1,1,'Introdu��o ao Banco de Dados SQL Server','Aprenda os conceitos b�sicos do SQL Server','2023-08-10','10:00:00')

INSERT INTO PresencasDeEvento(IdUsuario,IdEvento) --Situacao n�o precisa colocar se o usuario nao cadastrar o BIT
VALUES(1,1)

INSERT INTO Comentario(IdUsuario,IdEvento,DescricaoComentario,ExibirComentario)
VALUES (1,1,'Excelente evento!',1)