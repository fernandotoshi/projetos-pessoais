using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpyGame.Models;

namespace SpyGame.Models
{
    public class PersonagemModels
    {
        public int IdLocal { get; set; }
        public int IdPersonagem { get; set; }
        public string NomePersonagem { get; set; }
        public PersonagemModels(int idLocal, int idP01, string p01)
        {
            IdLocal = idLocal;
            IdPersonagem = idP01;
            NomePersonagem = p01;
        }
    }
}