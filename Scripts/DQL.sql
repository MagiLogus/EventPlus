--DQL
USE [Event+];

SELECT 
    Usuario.Nome AS 'Nome de Usuario',
    TipoDeUsuario.TituloTipoUsuario AS 'Tipo de Usuario',
    Evento.DataEvento AS 'Data do Evento',
    Instituicao.NomeFantasia AS 'Local do Evento',
    TipoDeEvento.TituloTipoEvento AS 'Tema do Evento',
    Evento.NomeDoEvento AS 'Titulo do Evento',
    Evento.Descricao AS 'Descrição do Evento',
    CASE 
        WHEN PresencasDeEvento.Situacao = 1 THEN 'Presente'
        ELSE 'Ausente' END AS 'Situação do evento',
    Comentario.DescricaoComentario AS 'Comentário do evento'
FROM 
    Usuario

LEFT JOIN 
    TipoDeUsuario ON Usuario.IdTipoDeUsuario = TipoDeUsuario.IdTipoDeUsuario
LEFT JOIN 
    PresencasDeEvento ON Usuario.IdUsuario = PresencasDeEvento.IdUsuario
LEFT JOIN 
    Evento ON PresencasDeEvento.IdEvento = Evento.IdEvento
LEFT JOIN 
    TipoDeEvento ON Evento.IdTipoDeEvento = TipoDeEvento.IdTipoDeEvento
LEFT JOIN 
    Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
LEFT JOIN 
    Comentario ON Usuario.IdUsuario = Comentario.IdUsuario AND Evento.IdEvento = Comentario.IdEvento;



