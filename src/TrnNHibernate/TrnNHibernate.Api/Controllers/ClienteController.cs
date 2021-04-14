﻿using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrnNHibernate.Api.Core;
using TrnNHibernate.Api.Core.Requests;
using TrnNHibernate.Entidades;

namespace TrnNHibernate.Api.Controllers
{
    [Route("cliente")]
    public class ClienteController :ControllerBase
    {
        private readonly ISession _session;

        public ClienteController(ISession session)
        {
            _session = session;
        }

        [HttpPost]
        [Route("persist")]
        public IActionResult NovoCliente([FromBody]ClienteRequest clienteRequest)
        {
            var cliente = new Cliente(clienteRequest.Nome, clienteRequest.Email, clienteRequest.Senha);
            _session.Save(cliente);
            return Ok("Cliente gravado com sucesso");
        }

        [HttpPost]
        [Route("atualizar")]
        public IActionResult AtualizarCliente([FromBody] ClienteRequest clienteRequest)
        {
            using(ITransaction transaction = _session.BeginTransaction())
            {
                var clienteExistente = _session.Get<Cliente>(clienteRequest.Id);
                clienteExistente.Atualizar(clienteRequest.Nome, clienteRequest.Email, clienteRequest.Senha);
                _session.Update(clienteExistente);

                transaction.Commit();
            }
          
            return Ok("Cliente atualizado com sucesso");
        }

       
    }
}
