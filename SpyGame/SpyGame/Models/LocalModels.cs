using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpyGame.Models;

namespace SpyGame.Models
{
    public class LocalModels
    {
        public int IdLocal { get; set; }
        public string NomeLocal { get; set; }
        public LocalModels(int id, string nome)
        {
            IdLocal = id;
            NomeLocal = nome;
        }
    }
}