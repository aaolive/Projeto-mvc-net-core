using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_mvc_net_core.Models;

namespace Projeto_mvc_net_core.Context
{
    public class AgendaContext: DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
            
        }

        public DbSet<Contato> Contatos {get; set;}
    }
}