﻿using apiweb.event_.Domains;

namespace apiweb.event_.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tipoUsuario);
        void Deletar(Guid id);
        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(Guid id);
        void Atualizar(Guid id, TiposUsuario tipoUsuario);
    }
}
