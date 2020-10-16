using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpyGame.Models
{
    public class BancoDeDados
    {
        public int IdLocal { get; set; }
        public string NomeLocal { get; set; }
        public int IdPersonagem { get; set; }
        public string NomePersonagem { get; set; }
    }
}