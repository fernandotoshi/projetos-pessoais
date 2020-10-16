using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpyGame.Models;

namespace SpyGame.Controllers
{
    public class JogoController : Controller
    {
        public static List<LocalModels> BDLocais = new List<LocalModels>();
        public static List<PersonagemModels> BDPersonagens = new List<PersonagemModels>();
        public static List<BancoDeDados> BDGeral = new List<BancoDeDados>();

        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult IniciarAplicacao()
        {
            criaBancoDeDados();
            return View();
        }

        public void criaBancoDeDados()
        {
            BDLocais.AddRange(new[] {
                new LocalModels(1, "UFABC"),
                new LocalModels(2, "Hospital"),
                new LocalModels(3, "Manicômio"),
                new LocalModels(4, "Delegacia Policial"),
                new LocalModels(5, "Escola")
            });
            BDPersonagens.AddRange(new[] {
                new PersonagemModels(1, 1, "Estudante"),
                new PersonagemModels(1, 2, "Professor"),
                new PersonagemModels(2, 1, "Médico"),
                new PersonagemModels(2, 2, "Segurança"),
                new PersonagemModels(3, 1, "Maníaco da Serra Elétrica"),
                new PersonagemModels(3, 2, "Enfermeiro"),
                new PersonagemModels(4, 1, "Policial"),
                new PersonagemModels(4, 2, "Preso"),
                new PersonagemModels(5, 1, "Professor"),
                new PersonagemModels(5, 2, "Criança")
            });

            var lista = from local in BDLocais
                                        join personagem in BDPersonagens
                                        on local.IdLocal equals personagem.IdLocal
                                        select new BancoDeDados
                                        {
                                            IdLocal = local.IdLocal,
                                            NomeLocal = local.NomeLocal,
                                            IdPersonagem = personagem.IdPersonagem,
                                            NomePersonagem = personagem.NomePersonagem
                                        };
            foreach(var objeto in lista)
            {
                BDGeral.Add(objeto);
            }
        }

        public ActionResult MostraBancoDeDados()
        {
            return View(BDGeral);
        }

        [HttpPost]
        public ActionResult JogoIniciado(JogoModels model)
        {
            var qntJogadores = model.QuantidadeJogadores;
            var qntEspioes = model.QuantidadeEspioes;

            Random rnd = new Random();
            var idLocal = 0;
            while(idLocal == 0)
            {
                idLocal = rnd.Next(BDLocais.Count + 1);
            }

            var localEscolhido = BDLocais.Where(x => x.IdLocal == idLocal).First();
            var personagensDoLocal = BDPersonagens.Where(x => x.IdLocal == idLocal);

            List<int> listaIdPersonagens = new List<int>();
            while(listaIdPersonagens.Count != (qntJogadores - qntEspioes))
            {
                var idPersonagem = 0;
                while (idPersonagem == 0)
                {
                    idPersonagem = rnd.Next(personagensDoLocal.Count() + 1);
                }
                if (!listaIdPersonagens.Contains(idPersonagem))
                {
                    listaIdPersonagens.Add(idPersonagem);
                }
            }

            List<PersonagemModels> listaPersonagensEscolhidos = new List<PersonagemModels>();
            for (int i = 0; i < (qntJogadores - qntEspioes); i++)
            {
                var personagem = personagensDoLocal.Where(x => x.IdPersonagem == listaIdPersonagens.ElementAt(i)).First();
                listaPersonagensEscolhidos.Add(personagem);
            }

            return View(listaPersonagensEscolhidos);
        }
    }
}