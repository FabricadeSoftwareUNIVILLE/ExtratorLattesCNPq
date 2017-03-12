using LattesExtractor.Entities;
using LattesExtractor.Entities.Database;
using LattesExtractor.Entities.Xml;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace LattesExtractor.DAO
{
    class ProfessorDAOService
    {
        public const string _NAO_INFORMADO = "Não Informado";
        public const string _NAO_POSSUI = "Não Possui";

        public const string _NIVEL_FAT_ENSINO_MEDIO = "Ensino Médio";
        public const string _NIVEL_FAT_ENSINO_FUNDAMENTAL = "Ensino Fundamental";
        public const string _NIVEL_FAT_GRADUACAO = "Graduação";
        public const string _NIVEL_FAT_ESPECIALIZACAO = "Especialização";
        public const string _NIVEL_FAT_MESTRADO = "Mestrado";
        public const string _NIVEL_FAT_DOUTORADO = "Doutorado";
        public const string _NIVEL_FAT_POS_DOUTORADO = "Pós-Doutorado";
        public const string _NIVEL_FAT_LIVRE_DOCENCIA = "Livre-Docência";
        public const string _NIVEL_FAT_TECNICO_PROFISSIONALIZANTE = "Técnico/Profissionalizante";
        public const string _NIVEL_FAT_RESIDENCIA_MEDICA = "Residência Médica";
        public const string _NIVEL_FAT_APERFEICOAMENTO = "Aperfeiçoamento";
        public const string _NIVEL_FAT_MBA = "MBA";
        public const string _NIVEL_FAT_FCEU = "Formação Complementar de Extensão Universitária";
        public const string _NIVEL_FAT_FCCCD = "Formação Complementar Curso de Curta Duração";
        public const string _NIVEL_FAT_OUTROS = "Outros";

        public const string _TIPO_GD_NORMAL = "Normal";
        public const string _TIPO_GD_COTUTELA = "Co-Tutela";
        public const string _TIPO_GD_SANDUICHE = "Sanduíche";
        public const string _TIPO_GD_COTUTELA_SANDUICHE = "Co-Tutela/Sanduíche";

        public const string _SIT_EM_ANDAMENTO = "Em Andamento";
        public const string _SIT_CONCLUIDO = "Concluído";
        public const string _SIT_INCOMPLETO = "Incompleto";
        public const string _SIT_DESATIVADO = "Desativado";

        public const string _TP_AP_DIRECAO_ADMINISTRACAO = "Direção e Administração";
        public const string _TP_AP_PESQUISA_DESENVOLVIMENTO = "Pesquisa e Desenvolvimento";
        public const string _TP_AP_ENSINO = "Ensino";
        public const string _TP_AP_ESTAGIO = "Estágio";
        public const string _TP_AP_SERVICO_TECNICO_ESPECIALIZADO = "Serviço Técnio Especializado";
        public const string _TP_AP_TREINAMENTO_MINISTRADO = "Treinamento Ministrado";
        public const string _TP_AP_OUTRA_TECNICO_CIENTIFICA = "Outra Atividade Técnico Científica";
        public const string _TP_AP_CONSELHO_COMISSAO_CONSULTORIA = "Conselho/Comissão/Consultoria";
        public const string _TP_AP_PART_PROJETO = "Participação Em Projeto";

        public const string _TP_PT_CULTIVAR_REGISTRADA = "Cultivar Registrada";
        public const string _TP_PT_SOFTWARE = "Software";
        public const string _TP_PT_PATENTE = "Patente";
        public const string _TP_PT_CULTIVAR_PROTEGIDA = "Cultivar Protegida";
        public const string _TP_PT_DESENHO_INDUSTRIAL = "Desenho Industrial";
        public const string _TP_PT_MARCA = "Marca";
        public const string _TP_PT_TOPOGRAFIA_CIRCUITO_INTERGRADO = "Topografia de Circuito Integrado";
        public const string _TP_PT_PRODUTO_TECNOLOGICO = "Produto Tecnilógico";
        public const string _TP_PT_PROCESSOS_TECNICAS = "Processos ou Técnicas";
        public const string _TP_PT_APRESENTACAO_TRABALHO = "Apresentação Trabalho";
        public const string _TP_PT_CARTA_MAPA_SIMILAR = "Carta, Mapa ou Similar";
        public const string _TP_PT_CURSO_CURTA_DURACAO_MINISTRADO = "Curso Curta Duração Ministrado";
        public const string _TP_PT_DESENV_MATERIAL_DIDATIVO_INSTITUCIONAL = "Desenvolvimento Material Didático/Institucional";
        public const string _TP_PT_MANUTENCAO_OBRA_ARTISTICA = "Manutenção Obra Artística";
        public const string _TP_PT_MAQUETE = "Maquete";
        public const string _TP_PT_RELATORIO_PESQUISA = "Relatório Pesquisa";
        public const string _TP_PT_PROGRAMA_RADIO_TV = "Programa de Rádio/TV";
        public const string _TP_PT_EDITORACAO = "Editoração";
        public const string _TP_PT_OUTRA_PRODUCAO_TECNICA = "Outra Produção Técnica";

        public const string _TP_PB_TRABALHO_EVENTOS = "Trabalhos Em Eventos";
        public const string _TP_PB_ARTIGO_PUBLICADO = "Artigo Publicado";
        public const string _TP_PB_LIVRO_PUBLICADO_ORGANIZADO = "Livro Publicado/Organizado";
        public const string _TP_PB_CAPTIULO_PUBLICADO_ORGANIZADO = "Capítulo Publicado/Organizado";
        public const string _TP_PB_TEXTO_JORNAIS_REVISTAS = "Texto Jornais ou Revistas";
        public const string _TP_PB_OUTRA = "Outra";
        public const string _TP_PB_PARTITURA_MUSICAL = "Partitural Musical";
        public const string _TP_PB_PREFACIO_POSFACIO = "Préfacio/Pósfacio";
        public const string _TP_PB_TRADUCAO = "Tradução";
        public const string _TP_PB_ARTIGO_ACEITO_PUBLICACAO = "Artigo Aceito para Publicação";

        public const string _TP_OS_CONCLUIDA = "Concluída";
        public const string _TP_OS_EM_ANDAMENTO = "Em Andamento";

        public const string _TP_BT_MESTRADO = "Mestrado";
        public const string _TP_BT_DOUTORADO = "Doutorado";
        public const string _TP_BT_EXAME_QUALIFICACAO = "Exame Qualificação";
        public const string _TP_BT_APERFEICOAMENTO_ESPECIALIZACAO = "Aperfeiçoamento/Especialização";
        public const string _TP_BT_GRADUACAO = "Gradução";
        public const string _TP_BT_OUTRA = "Outra";

        public const string _TP_BJ_PROFESSOR_TITULAR = "Professor Titular";
        public const string _TP_BJ_CONCURSO_PUBLICO = "Concurso Público";
        public const string _TP_BJ_LIVRE_DOCENCIA = "Livre Docência";
        public const string _TP_BJ_AVALIACAO_CURSO = "Avaliação Curso";
        public const string _TP_BJ_OUTRA = "Outra";

        private static readonly object logLocker = new object();
        private static readonly object saveLocker = new object();

        private LattesDatabase _lattesDatabase;
        private QualisDAOService QualisDAOService;
        private JCRDAOService JCRDAOService;
        private Dictionary<String, CacheInstituicao> cacheInstituicoes = new Dictionary<string, CacheInstituicao>();
        private Dictionary<String, CacheCurso> cacheCursos = new Dictionary<string, CacheCurso>();
        private Dictionary<int, CacheProducao> cacheProducoes = new Dictionary<int, CacheProducao>();
        private Dictionary<int, CacheProducoesProjeto> cacheProducoesProjetos = new Dictionary<int, CacheProducoesProjeto>();

        private static readonly ILog Logger = LogManager.GetLogger(typeof(ProfessorDAOService).Name);

        public ProfessorDAOService(LattesDatabase lattesDatabase)
        {
            this.LattesDatabase = lattesDatabase;
        }

        public LattesDatabase LattesDatabase
        {
            set { this._lattesDatabase = value; }
            get { return this._lattesDatabase; }
        }

        private class CacheInstituicao
        {
            public string codigo;
            public string sigla;
            public bool instituicaoEnsino;
            public string pais;
        }

        private class CacheCurso
        {
            public string codigo;
            public AreaConhecimento area;
        }

        private class CacheProducao
        {
            public int Sequencia;
            public string TipoProducao;
            public string NaturezaProducao;
            public object Producao;
            public List<PalavraChave> PalavrasChave;
            public List<AreaConhecimento> AreasConhecimento;
        }

        private class CacheProducoesProjeto
        {
            public int ProjetoId;
            public List<CacheProducao> Producoes = new List<CacheProducao>();
        }

        public Professor ProcurarProfessorPorNumeroCurriculo(string curriculumVitaeNumber)
        {
            lock (saveLocker)
            {
                return LattesDatabase.Professor.FirstOrDefault(p => p.NumeroCurriculo == curriculumVitaeNumber);
            }
        }

        /// <summary>
        /// Processa as informações do XML para atualizar ie Professor no Banco de Dados
        /// </summary>
        /// <param name="cvXml"></param>
        /// <param name="curriculumVitae"></param>
        public bool ProcessCurriculumVitaeXML(CurriculoVitaeXml cvXml, CurriculoEntry curriculumVitae)
        {
            Professor professor = null;
            bool criarProfessor = false;
            try
            {
                //LattesDatabase.Configuration.AutoDetectChangesEnabled = false;

                if (cvXml.NUMEROIDENTIFICADOR != null && !cvXml.NUMEROIDENTIFICADOR.Equals("") && cvXml.NUMEROIDENTIFICADOR != curriculumVitae.NumeroCurriculo)
                {
                    Logger.Error(String.Format("Curriculo {0} solicitado não corresponde ao recebido {1} !", curriculumVitae.NumeroCurriculo, cvXml.NUMEROIDENTIFICADOR));
                    return false;
                }

                this.QualisDAOService = new QualisDAOService(this.LattesDatabase);
                this.JCRDAOService = new JCRDAOService(this.LattesDatabase);

                try
                {
                    ProcessarCache(cvXml);

                    professor = this.ProcurarProfessorPorNumeroCurriculo(curriculumVitae.NumeroCurriculo);

                    if (professor != null)
                    {
                        RemoverDadosProfessor(professor);
                    }
                    else
                    {
                        // criar o professor
                        professor = LattesDatabase.Professor.Create();
                        criarProfessor = true;
                    }

                    // dados do curriculo
                    professor.NumeroCurriculo = curriculumVitae.NumeroCurriculo;
                    professor.LinkParaCurriculo = String.Format("http://lattes.cnpq.br/{0}", professor.NumeroCurriculo);

                    if (curriculumVitae.DataUltimaAtualizacao == null)
                        curriculumVitae.DataUltimaAtualizacao = DateTime.ParseExact(String.Format("{0} {1}", cvXml.DATAATUALIZACAO, cvXml.HORAATUALIZACAO), Utils.ParseDateFormat(cvXml.FORMATODATAATUALIZACAO) + " %Hmmss", null);

                    professor.DataUltimaAtualizacaoCurriculo = (DateTime)curriculumVitae.DataUltimaAtualizacao;

                    professor.DataUltimaPublicacaoCurriculo = new DateTime(1900, 1, 1); // data qualquer no passado

                    ProcessarDadosGerais(professor, cvXml);

                    ProcessarEnderecosEContatos(professor, cvXml);

                    ProcessarIdiomas(professor, cvXml);

                    ProcessarPremiosETitulos(professor, cvXml);

                    ProcessarFormacaoAcademicaETitulacao(professor, cvXml);

                    ProcessarAreasAtuacaoProfessor(professor, cvXml);

                    ProcessarProducoesTecnicasEPatentes(professor, cvXml);

                    ProcessarProducoesBibliograficas(professor, cvXml);

                    ProcessarParticipacaoEventos(professor, cvXml);

                    ProcessarOrientacoesESupervisoes(professor, cvXml);

                    ProcessarBancasDeTrabalho(professor, cvXml);

                    ProcessarBancasJulgadoras(professor, cvXml);

                    ProcessarAtuacoesProfissionaisEProjetos(professor, cvXml);

                    if (criarProfessor)
                        LattesDatabase.Professor.Add(professor);
                    LattesDatabase.SaveChanges(); // salva registros para gerar chaves sequencias

                    CriarBaseDeConsulta(professor);
                    LattesDatabase.SaveChanges(); // salva base de consulta

                    return true;
                }
                catch (Exception ex)
                {
                    lock (logLocker)
                    {
                        Logger.Error(String.Format("Erros para o Professor {0} - {1}",
                            professor.NumeroCurriculo, professor.NomeProfessor));
                        Logger.Error(ex.Message);

                        if (LattesDatabase.GetValidationErrors() != null)
                        {
                            Logger.Error("Erros de Validação:");
                            foreach (DbEntityValidationResult e in LattesDatabase.GetValidationErrors())
                            {
                                foreach (DbValidationError err in e.ValidationErrors)
                                {
                                    Logger.Error(" * " + err.ErrorMessage);
                                }
                            }
                        }

                        Logger.Error(ex.StackTrace);
                        if (ex.InnerException != null)
                        {
                            Logger.Error("Excessão Interna:");
                            int sequencia = 1;
                            while (ex.InnerException != null)
                            {
                                Logger.Error(String.Format("Excessão Interna [{0}]: {1}", sequencia++, ex.InnerException.Message));
                                Logger.Error(ex.StackTrace);
                                ex = ex.InnerException;
                            }
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lock (logLocker)
                {
                    Logger.Error(String.Format("Erros para o Currículo {0}:", curriculumVitae));
                    Logger.Error(ex.Message);
                    Logger.Error(ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        Logger.Error("Excessão Interna:");
                        int sequencia = 1;
                        while (ex.InnerException != null)
                        {
                            Logger.Error(String.Format("Excessão Interna [{0}]: {1}", sequencia++, ex.InnerException.Message));
                            Logger.Error(ex.StackTrace);
                            ex = ex.InnerException;
                        }
                    }
                }
            }

            return false;
        }

        internal void RegistraCacheProducao(string sequencia, string tipoProducao, string natureza, List<AreaConhecimento> areas, List<PalavraChave> palavras, object producao)
        {
            int sequenciaP = int.Parse(sequencia);
            if (!cacheProducoes.ContainsKey(sequenciaP))
            {
                cacheProducoes.Add(sequenciaP, new CacheProducao()
                {
                    Sequencia = sequenciaP,
                    TipoProducao = tipoProducao,
                    NaturezaProducao = natureza,
                    AreasConhecimento = areas,
                    PalavrasChave = palavras,
                    Producao = producao
                });
            }
        }

        private void RegistraCacheProducaoProjeto(Projeto projeto, CacheProducao cp)
        {
            CacheProducoesProjeto cpp;
            if (!cacheProducoesProjetos.ContainsKey(projeto.ProjetoId))
            {
                cacheProducoesProjetos.Add(projeto.ProjetoId, new CacheProducoesProjeto()
                {
                    ProjetoId = projeto.ProjetoId
                });
            
            }
            
            cpp = cacheProducoesProjetos[projeto.ProjetoId];
            
            if (!cpp.Producoes.Contains(cp))
                cpp.Producoes.Add(cp);
        }

        private void CriarBaseDeConsulta(Professor professor)
        {
            int sequencia = 1;
            BaseDeConsulta bc;
            var portugues = GetIdioma("Português");

            var ieNP = GetInstituicaoEmpresaNaoPossui();
            var ueNP = GetUnidadeInstituicaoEmpresaNaoPossui(ieNP);
            var oeNP = GetOrgaoInstituicaoEmpresaNaoPossui(ieNP);
            var cursoNP = GetCurso(ieNP, "", _NAO_POSSUI, _NAO_POSSUI);
            var afNP = GetAgenciaFinanciadoraNaoPossui();
            var acNP = GetAreaConhecimentoNaoPossui();
            var pcNP = GetPalavraChaveNaoPossui();

            PalavraChave[] palavrasChave;
            AreaConhecimento[] areasConhecimento;

            foreach (var ap in professor.AtividadeProfissional)
            {
                bc = LattesDatabase.BaseDeConsulta.Create();
                bc.SequenciaBaseDeConsulta = sequencia++;
                bc.AtividadeProfissional = ap;
                bc.AtividadeProfissionalId = ap.AtividadeProfissionalId;

                bc.AnoBaseDeConsulta = ap.DataInicioAtividadeProfissional.Year;

                bc.InstituicaoEmpresa = ap.InstituicaoEmpresa;
                bc.UnidadeInstituicaoEmpresa = ap.UnidadeInstituicaoEmpresa;
                bc.OrgaoInstituicaoEmpresa = ap.OrgaoInstituicaoEmpresa;
                bc.AreaConhecimento = acNP;
                bc.PalavraChave = pcNP;
                bc.Idioma = portugues;
                bc.Curso = cursoNP;
                bc.AgenciaFinanciadora = afNP;

                professor.BaseDeConsulta.Add(bc);
            }

            foreach (var pb in professor.ProducaoBibliografica)
            {
                areasConhecimento = pb.AreaConhecimento.ToArray();
                palavrasChave = pb.PalavraChave.ToArray();

                if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP }; ;

                foreach (var pc in palavrasChave)
                {
                    foreach (var ac in areasConhecimento)
                    {
                        bc = LattesDatabase.BaseDeConsulta.Create();
                        bc.SequenciaBaseDeConsulta = sequencia++;
                        bc.ProducaoBibliografica = pb;

                        bc.AnoBaseDeConsulta = pb.AnoProducaoBibliografica;

                        bc.InstituicaoEmpresa = ieNP;
                        bc.UnidadeInstituicaoEmpresa = ueNP;
                        bc.OrgaoInstituicaoEmpresa = oeNP;
                        bc.AreaConhecimento = ac;
                        bc.PalavraChave = pc;
                        bc.Idioma = pb.Idioma;
                        bc.Curso = cursoNP;
                        bc.AgenciaFinanciadora = afNP;

                        professor.BaseDeConsulta.Add(bc);
                    }
                }
            }

            foreach (var pt in professor.ProducaoTecnica)
            {
                areasConhecimento = pt.AreaConhecimento.ToArray();
                palavrasChave = pt.PalavraChave.ToArray();

                if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP };

                foreach (var pc in palavrasChave)
                {
                    foreach (var ac in areasConhecimento)
                    {
                        bc = LattesDatabase.BaseDeConsulta.Create();
                        bc.SequenciaBaseDeConsulta = sequencia++;
                        bc.ProducaoTecnica = pt;

                        bc.AnoBaseDeConsulta = pt.AnoProducaoTecnica;

                        bc.InstituicaoEmpresa = ieNP;
                        bc.UnidadeInstituicaoEmpresa = ueNP;
                        bc.OrgaoInstituicaoEmpresa = oeNP;
                        bc.AreaConhecimento = ac;
                        bc.PalavraChave = pc;
                        bc.Idioma = pt.Idioma;
                        bc.Curso = cursoNP;
                        bc.AgenciaFinanciadora = pt.AgenciaFinanciadora;

                        professor.BaseDeConsulta.Add(bc);
                    }
                }
            }

            foreach (var bt in professor.BancaDeTrabalho)
            {
                areasConhecimento = bt.AreaConhecimento.ToArray();
                palavrasChave = bt.PalavraChave.ToArray();

                if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP };

                foreach (var pc in palavrasChave)
                {
                    foreach (var ac in areasConhecimento)
                    {
                        bc = LattesDatabase.BaseDeConsulta.Create();
                        bc.SequenciaBaseDeConsulta = sequencia++;
                        bc.BancaDeTrabalho = bt;

                        bc.AnoBaseDeConsulta = bt.AnoBancaDeTrabalho;

                        bc.InstituicaoEmpresa = bt.InstituicaoEmpresa;
                        bc.UnidadeInstituicaoEmpresa = ueNP;
                        bc.OrgaoInstituicaoEmpresa = bt.OrgaoInstituicaoEmpresa;
                        bc.Idioma = bt.Idioma;
                        bc.Curso = bt.Curso;
                        bc.AgenciaFinanciadora = afNP;

                        bc.AreaConhecimento = ac;
                        bc.PalavraChave = pc;

                        professor.BaseDeConsulta.Add(bc);
                    }
                }
            }

            foreach (var bj in professor.BancaJulgadora)
            {
                areasConhecimento = bj.AreaConhecimento.ToArray();
                palavrasChave = bj.PalavraChave.ToArray();

                if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP };

                foreach (var pc in palavrasChave)
                {
                    foreach (var ac in areasConhecimento)
                    {
                        bc = LattesDatabase.BaseDeConsulta.Create();
                        bc.SequenciaBaseDeConsulta = sequencia++;
                        bc.BancaJulgadora = bj;

                        bc.AnoBaseDeConsulta = bj.AnoBancaJulgadora;

                        bc.InstituicaoEmpresa = bj.InstituicaoEmpresa;
                        bc.UnidadeInstituicaoEmpresa = ueNP;
                        bc.OrgaoInstituicaoEmpresa = oeNP;
                        bc.Idioma = bj.Idioma;
                        bc.Curso = cursoNP;
                        bc.AgenciaFinanciadora = afNP;

                        bc.AreaConhecimento = ac;
                        bc.PalavraChave = pc;

                        professor.BaseDeConsulta.Add(bc);
                    }
                }
            }

            foreach (var pe in professor.ParticipacaoEvento)
            {
                areasConhecimento = pe.AreaConhecimento.ToArray();
                palavrasChave = pe.PalavraChave.ToArray();

                if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP };

                foreach (var pc in palavrasChave)
                {
                    foreach (var ac in areasConhecimento)
                    {
                        bc = LattesDatabase.BaseDeConsulta.Create();
                        bc.SequenciaBaseDeConsulta = sequencia++;
                        bc.ParticipacaoEvento = pe;

                        bc.AnoBaseDeConsulta = pe.Evento.AnoEvento;

                        bc.InstituicaoEmpresa = pe.Evento.InstituicaoEmpresa;
                        bc.UnidadeInstituicaoEmpresa = ueNP;
                        bc.OrgaoInstituicaoEmpresa = oeNP;
                        bc.Idioma = pe.Idioma;
                        bc.Curso = cursoNP;
                        bc.AgenciaFinanciadora = afNP;
                        bc.Evento = pe.Evento;

                        bc.AreaConhecimento = ac;
                        bc.PalavraChave = pc;

                        professor.BaseDeConsulta.Add(bc);
                    }
                }
            }

            foreach (var fat in professor.FormacaoAcademicaTitulacao)
            {
                areasConhecimento = fat.AreaConhecimento.ToArray();
                palavrasChave = fat.PalavraChave.ToArray();

                if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP };

                foreach (var pc in palavrasChave)
                {
                    foreach (var ac in areasConhecimento)
                    {
                        bc = LattesDatabase.BaseDeConsulta.Create();
                        bc.SequenciaBaseDeConsulta = sequencia++;
                        bc.FormacaoAcademicaTitulacao = fat;

                        bc.AnoBaseDeConsulta = fat.AnoInicioFormacaoAcademicaTitulacao;

                        bc.InstituicaoEmpresa = fat.InstituicaoEmpresa;
                        bc.UnidadeInstituicaoEmpresa = ueNP;
                        bc.OrgaoInstituicaoEmpresa = fat.OrgaoInstituicaoEmpresa;
                        bc.Idioma = portugues;
                        bc.Curso = fat.Curso;
                        bc.AgenciaFinanciadora = fat.AgenciaFinanciadora;

                        bc.AreaConhecimento = ac;
                        bc.PalavraChave = pc;

                        professor.BaseDeConsulta.Add(bc);
                    }
                }
            }

            foreach (var os in professor.OrientacaoSupervisao)
            {
                areasConhecimento = os.AreaConhecimento.ToArray();
                palavrasChave = os.PalavraChave.ToArray();

                if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP };

                foreach (var pc in palavrasChave)
                {
                    foreach (var ac in areasConhecimento)
                    {
                        bc = LattesDatabase.BaseDeConsulta.Create();
                        bc.SequenciaBaseDeConsulta = sequencia++;
                        bc.OrientacaoSupervisao = os;

                        bc.AnoBaseDeConsulta = os.AnoOrientacaoSupervicao;

                        bc.InstituicaoEmpresa = os.InstituicaoEmpresa;
                        bc.UnidadeInstituicaoEmpresa = ueNP;
                        bc.OrgaoInstituicaoEmpresa = os.OrgaoInstituicaoEmpresa;
                        bc.Idioma = os.Idioma;
                        bc.Curso = os.Curso;
                        bc.AgenciaFinanciadora = os.AgenciaFinanciadora;

                        bc.AreaConhecimento = ac;
                        bc.PalavraChave = pc;

                        professor.BaseDeConsulta.Add(bc);
                    }
                }
            }

            CacheProducoesProjeto cpp;
            foreach (var pp in professor.ParticipacaoEmProjeto)
            {
                if (cacheProducoesProjetos.ContainsKey(pp.Projeto.ProjetoId)
                    && cacheProducoesProjetos[pp.Projeto.ProjetoId].Producoes.Count > 0)
                {
                    cpp = cacheProducoesProjetos[pp.Projeto.ProjetoId];

                    foreach (var cp in cpp.Producoes)
                    {
                        areasConhecimento = cp.AreasConhecimento.ToArray();
                        palavrasChave = cp.PalavrasChave.ToArray();

                        if (areasConhecimento.Length == 0) areasConhecimento = new AreaConhecimento[] { acNP };
                        if (palavrasChave.Length == 0) palavrasChave = new PalavraChave[] { pcNP };

                        foreach (var pc in palavrasChave)
                        {
                            foreach (var ac in areasConhecimento)
                            {
                                bc = LattesDatabase.BaseDeConsulta.Create();
                                bc.SequenciaBaseDeConsulta = sequencia++;
                                bc.ParticipacaoEmProjeto = pp;

                                bc.AnoBaseDeConsulta = pp.Projeto.AnoInicioProjeto;

                                bc.InstituicaoEmpresa = pp.Projeto.InstituicaoEmpresa;
                                bc.UnidadeInstituicaoEmpresa = pp.Projeto.UnidadeInstituicaoEmpresa;
                                bc.OrgaoInstituicaoEmpresa = pp.Projeto.OrgaoInstituicaoEmpresa;

                                bc.Idioma = portugues;
                                bc.Curso = cursoNP;
                                bc.AgenciaFinanciadora = afNP;
                                bc.Projeto = pp.Projeto;

                                switch (cp.TipoProducao)
                                {
                                    case "PT":
                                        bc.ProducaoTecnica = ((ProducaoTecnica)cp.Producao);
                                        bc.Idioma = ((ProducaoTecnica)cp.Producao).Idioma;
                                        bc.AgenciaFinanciadora = ((ProducaoTecnica)cp.Producao).AgenciaFinanciadora;
                                        break;
                                    case "PB":
                                        bc.ProducaoBibliografica = ((ProducaoBibliografica)cp.Producao);
                                        bc.Idioma = ((ProducaoBibliografica)cp.Producao).Idioma;
                                        break;
                                    case "BJ":
                                        bc.BancaJulgadora = ((BancaJulgadora)cp.Producao);
                                        bc.Idioma = ((BancaJulgadora)cp.Producao).Idioma;
                                        break;
                                    case "BT":
                                        bc.BancaDeTrabalho = ((BancaDeTrabalho)cp.Producao);
                                        bc.Idioma = ((BancaDeTrabalho)cp.Producao).Idioma;
                                        bc.Curso = ((BancaDeTrabalho)cp.Producao).Curso;
                                        break;
                                    case "OS":
                                        bc.OrientacaoSupervisao = ((OrientacaoSupervisao)cp.Producao);
                                        bc.Idioma = ((OrientacaoSupervisao)cp.Producao).Idioma;
                                        bc.Curso = ((OrientacaoSupervisao)cp.Producao).Curso;
                                        bc.AgenciaFinanciadora = ((OrientacaoSupervisao)cp.Producao).AgenciaFinanciadora;
                                        break;
                                }

                                bc.AreaConhecimento = ac;
                                bc.PalavraChave = pc;

                                professor.BaseDeConsulta.Add(bc);
                            }
                        }
                    }
                }
                else
                {
                    bc = LattesDatabase.BaseDeConsulta.Create();
                    bc.SequenciaBaseDeConsulta = sequencia++;
                    bc.ParticipacaoEmProjeto = pp;

                    bc.AnoBaseDeConsulta = pp.Projeto.AnoInicioProjeto;

                    bc.InstituicaoEmpresa = pp.Projeto.InstituicaoEmpresa;
                    bc.UnidadeInstituicaoEmpresa = pp.Projeto.UnidadeInstituicaoEmpresa;
                    bc.OrgaoInstituicaoEmpresa = pp.Projeto.OrgaoInstituicaoEmpresa;
                    bc.Idioma = portugues;
                    bc.Curso = cursoNP;
                    bc.AgenciaFinanciadora = afNP;

                    bc.AreaConhecimento = acNP;
                    bc.PalavraChave = pcNP;

                    professor.BaseDeConsulta.Add(bc);
                }
            }

            foreach (var pout in professor.PremioOuTitulo)
            {
                bc = LattesDatabase.BaseDeConsulta.Create();
                bc.SequenciaBaseDeConsulta = sequencia++;
                bc.PremioOuTitulo = pout;

                bc.AnoBaseDeConsulta = pout.AnoPremioOuTitulo;

                bc.InstituicaoEmpresa = ieNP;
                bc.UnidadeInstituicaoEmpresa = ueNP;
                bc.OrgaoInstituicaoEmpresa = oeNP;
                bc.Idioma = portugues;
                bc.Curso = cursoNP;
                bc.AgenciaFinanciadora = afNP;

                bc.AreaConhecimento = acNP;
                bc.PalavraChave = pcNP;

                professor.BaseDeConsulta.Add(bc);
            }

            foreach (var vap in professor.VinculoAtuacaoProfissional)
            {
                bc = LattesDatabase.BaseDeConsulta.Create();
                bc.SequenciaBaseDeConsulta = sequencia++;
                bc.VinculoAtuacaoProfissional = vap;

                bc.AnoBaseDeConsulta = vap.DataInicioVinculoAtuacaoProfissional.Year;

                bc.InstituicaoEmpresa = vap.InstituicaoEmpresa;
                bc.UnidadeInstituicaoEmpresa = ueNP;
                bc.OrgaoInstituicaoEmpresa = oeNP;
                bc.Idioma = portugues;
                bc.Curso = cursoNP;
                bc.AgenciaFinanciadora = afNP;

                bc.AreaConhecimento = acNP;
                bc.PalavraChave = pcNP;

                professor.BaseDeConsulta.Add(bc);
            }

            return;
        }

        private void ProcessarBancasJulgadoras(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.DADOSCOMPLEMENTARES.PARTICIPACAOEMBANCAJULGADORA == null)
                return;

            var bancas = cvXml.DADOSCOMPLEMENTARES.PARTICIPACAOEMBANCAJULGADORA;
            BancaJulgadora banca;

            if (bancas.BANCAJULGADORAPARAPROFESSORTITULAR != null)
            {
                foreach (var profTitular in bancas.BANCAJULGADORAPARAPROFESSORTITULAR)
                {
                    var dados = profTitular.DADOSBASICOSDABANCAJULGADORAPARAPROFESSORTITULAR;
                    var detalhes = profTitular.DETALHAMENTODABANCAJULGADORAPARAPROFESSORTITULAR;

                    banca = GetBancaJulgadora(_TP_BJ_PROFESSOR_TITULAR,
                                              dados.TITULO,
                                              dados.ANO);
                    ComplementarBancaJulgadora(banca,
                                               dados.TITULOINGLES,
                                               profTitular.INFORMACOESADICIONAIS,
                                               dados.NATUREZA,
                                               null,
                                               GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                     detalhes.NOMEINSTITUICAO),
                                               GetIdioma(dados.IDIOMA),
                                               dados.PAIS,
                                               dados.HOMEPAGE,
                                               dados.DOI,
                                               ExtrairAreasConhecimento(profTitular.AREASDOCONHECIMENTO),
                                               ExtrairPalavrasChave(profTitular.PALAVRASCHAVE, profTitular.SETORESDEATIVIDADE));
                    professor.BancaJulgadora.Add(banca);
                    
                    RegistraCacheProducao(profTitular.SEQUENCIAPRODUCAO, "BJ", banca.NaturezaBancaJulgadora,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.BANCAJULGADORAPARACONCURSOPUBLICO != null)
            {
                foreach (var concurso in bancas.BANCAJULGADORAPARACONCURSOPUBLICO)
                {
                    var dados = concurso.DADOSBASICOSDABANCAJULGADORAPARACONCURSOPUBLICO;
                    var detalhes = concurso.DETALHAMENTODABANCAJULGADORAPARACONCURSOPUBLICO;

                    banca = GetBancaJulgadora(_TP_BJ_CONCURSO_PUBLICO,
                                              dados.TITULO,
                                              dados.ANO);
                    ComplementarBancaJulgadora(banca,
                                               dados.TITULOINGLES,
                                               concurso.INFORMACOESADICIONAIS,
                                               dados.NATUREZA,
                                               null,
                                               GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                     detalhes.NOMEINSTITUICAO),
                                               GetIdioma(dados.IDIOMA),
                                               dados.PAIS,
                                               dados.HOMEPAGE,
                                               dados.DOI,
                                               ExtrairAreasConhecimento(concurso.AREASDOCONHECIMENTO),
                                               ExtrairPalavrasChave(concurso.PALAVRASCHAVE, concurso.SETORESDEATIVIDADE));
                    professor.BancaJulgadora.Add(banca);

                    RegistraCacheProducao(concurso.SEQUENCIAPRODUCAO, "BJ", banca.NaturezaBancaJulgadora,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.BANCAJULGADORAPARALIVREDOCENCIA != null)
            {
                foreach (var livreDoc in bancas.BANCAJULGADORAPARALIVREDOCENCIA)
                {
                    var dados = livreDoc.DADOSBASICOSDABANCAJULGADORAPARALIVREDOCENCIA;
                    var detalhes = livreDoc.DETALHAMENTODABANCAJULGADORAPARALIVREDOCENCIA;

                    banca = GetBancaJulgadora(_TP_BJ_LIVRE_DOCENCIA,
                                              dados.TITULO,
                                              dados.ANO);
                    ComplementarBancaJulgadora(banca,
                                               dados.TITULOINGLES,
                                               livreDoc.INFORMACOESADICIONAIS,
                                               dados.NATUREZA,
                                               null,
                                               GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                     detalhes.NOMEINSTITUICAO),
                                               GetIdioma(dados.IDIOMA),
                                               dados.PAIS,
                                               dados.HOMEPAGE,
                                               dados.DOI,
                                               ExtrairAreasConhecimento(livreDoc.AREASDOCONHECIMENTO),
                                               ExtrairPalavrasChave(livreDoc.PALAVRASCHAVE, livreDoc.SETORESDEATIVIDADE));
                    professor.BancaJulgadora.Add(banca);

                    RegistraCacheProducao(livreDoc.SEQUENCIAPRODUCAO, "BJ", banca.NaturezaBancaJulgadora,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.BANCAJULGADORAPARAAVALIACAOCURSOS != null)
            {
                foreach (var avalCurso in bancas.BANCAJULGADORAPARAAVALIACAOCURSOS)
                {
                    var dados = avalCurso.DADOSBASICOSDABANCAJULGADORAPARAAVALIACAOCURSOS;
                    var detalhes = avalCurso.DETALHAMENTODABANCAJULGADORAPARAAVALIACAOCURSOS;

                    banca = GetBancaJulgadora(_TP_BJ_AVALIACAO_CURSO,
                                              dados.TITULO,
                                              dados.ANO);
                    ComplementarBancaJulgadora(banca,
                                               dados.TITULOINGLES,
                                               avalCurso.INFORMACOESADICIONAIS,
                                               dados.NATUREZA,
                                               null,
                                               GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                     detalhes.NOMEINSTITUICAO),
                                               GetIdioma(dados.IDIOMA),
                                               dados.PAIS,
                                               dados.HOMEPAGE,
                                               dados.DOI,
                                               ExtrairAreasConhecimento(avalCurso.AREASDOCONHECIMENTO),
                                               ExtrairPalavrasChave(avalCurso.PALAVRASCHAVE, avalCurso.SETORESDEATIVIDADE));
                    professor.BancaJulgadora.Add(banca);

                    RegistraCacheProducao(avalCurso.SEQUENCIAPRODUCAO, "BJ", banca.NaturezaBancaJulgadora,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.OUTRASBANCASJULGADORAS != null)
            {
                foreach (var outras in bancas.OUTRASBANCASJULGADORAS)
                {
                    var dados = outras.DADOSBASICOSDEOUTRASBANCASJULGADORAS;
                    var detalhes = outras.DETALHAMENTODEOUTRASBANCASJULGADORAS;

                    banca = GetBancaJulgadora(_TP_BJ_OUTRA,
                                              dados.TITULO,
                                              dados.ANO);
                    ComplementarBancaJulgadora(banca,
                                               dados.TITULOINGLES,
                                               outras.INFORMACOESADICIONAIS,
                                               dados.NATUREZA,
                                               dados.TIPO,
                                               GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                     detalhes.NOMEINSTITUICAO),
                                               GetIdioma(dados.IDIOMA),
                                               dados.PAIS,
                                               dados.HOMEPAGE,
                                               dados.DOI,
                                               ExtrairAreasConhecimento(outras.AREASDOCONHECIMENTO),
                                               ExtrairPalavrasChave(outras.PALAVRASCHAVE, outras.SETORESDEATIVIDADE));
                    professor.BancaJulgadora.Add(banca);

                    RegistraCacheProducao(outras.SEQUENCIAPRODUCAO, "BJ", banca.NaturezaBancaJulgadora,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }
        }

        private void ComplementarBancaJulgadora(BancaJulgadora banca, string tituloIngles, INFORMACOESADICIONAIS informacoes, string natureza, string tipo, InstituicaoEmpresa inst, Idioma idioma, string pais, string homepage, string doi, AreaConhecimento[] areas, PalavraChave[] palavrasChave)
        {
            lock (saveLocker)
            {
                if (banca.TituloEmInglesBancaJulgadora == "")
                    banca.TituloEmInglesBancaJulgadora = tituloIngles;

                if (informacoes != null)
                {
                    if (banca.InformacoesAdicionaisBancaJulgadora == "")
                        banca.InformacoesAdicionaisBancaJulgadora = informacoes.DESCRICAOINFORMACOESADICIONAIS;

                    if (banca.InformacoesAdicionaisEmInglesBancaJulgadora == "")
                        banca.InformacoesAdicionaisEmInglesBancaJulgadora = informacoes.DESCRICAOINFORMACOESADICIONAISINGLES;
                }

                if (banca.NaturezaBancaJulgadora == "")
                {
                    if (tipo != null)
                    {
                        switch (tipo)
                        {
                            case "ACADEMICO":
                                natureza = String.Format("{0} (Acadêmico)", natureza);
                                break;
                            case "PROFISSIONALIZANTE":
                                natureza = String.Format("{0} (Profissionalizante)", natureza);
                                break;
                            case "NAO_INFORMADO":
                                break;
                            default:
                                natureza = String.Format("{0} ({1})", natureza, tipo);
                                break;
                        }
                    }

                    banca.NaturezaBancaJulgadora = natureza;
                }

                if (banca.InstituicaoEmpresa == null || banca.InstituicaoEmpresa.NomeInstituicaoEmpresa == _NAO_INFORMADO)
                    banca.InstituicaoEmpresa = inst;

                if (banca.Idioma == null || banca.Idioma.NomeIdioma == _NAO_INFORMADO)
                    banca.Idioma = idioma;

                if (banca.PaisBancaJulgadora == "")
                    banca.PaisBancaJulgadora = pais;

                if (banca.HomePageBancaJulgadora == "")
                    banca.HomePageBancaJulgadora = Utils.SetMaxLength(homepage, 300);

                if (banca.DOIBancaJulgadora == "")
                    banca.DOIBancaJulgadora = doi;

                if (areas.Length > 0 && areas[0].GrandeAreaConhecimento != _NAO_POSSUI)
                {
                    foreach (var a in areas)
                    {
                        if (!banca.AreaConhecimento.Contains(a))
                        {
                            banca.AreaConhecimento.Add(a);
                        }
                    }
                }

                if (palavrasChave.Length > 0 && palavrasChave[0].TermoPalavraChave != _NAO_POSSUI)
                {
                    foreach (var pc in palavrasChave)
                    {
                        if (!banca.PalavraChave.Contains(pc))
                        {
                            banca.PalavraChave.Add(pc);
                        }
                    }
                }

                LattesDatabase.SaveChanges();
            }
        }

        private BancaJulgadora GetBancaJulgadora(string tipo, string titulo, string ano)
        {

            decimal anoBanca = int.Parse(ano);

            lock (saveLocker)
            {
                var banca = LattesDatabase.BancaJulgadora.FirstOrDefault(
                    b => b.TipoBancaJulgadora == tipo
                             && b.TituloBancaJulgadora == titulo
                             && b.AnoBancaJulgadora == anoBanca);

                if (banca == null)
                {
                    banca = LattesDatabase.BancaJulgadora.Create();

                    banca.TipoBancaJulgadora = tipo;
                    banca.TituloBancaJulgadora = titulo;
                    banca.AnoBancaJulgadora = anoBanca;

                    LattesDatabase.BancaJulgadora.Add(banca);
                    LattesDatabase.SaveChanges();
                }
                return banca;
            }
        }

        private void ProcessarBancasDeTrabalho(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.DADOSCOMPLEMENTARES.PARTICIPACAOEMBANCATRABALHOSCONCLUSAO == null)
                return;

            var bancas = cvXml.DADOSCOMPLEMENTARES.PARTICIPACAOEMBANCATRABALHOSCONCLUSAO;
            BancaDeTrabalho banca;

            InstituicaoEmpresa inst;

            if (bancas.PARTICIPACAOEMBANCADEMESTRADO != null)
            {
                foreach (var mestrado in bancas.PARTICIPACAOEMBANCADEMESTRADO)
                {
                    var dados = mestrado.DADOSBASICOSDAPARTICIPACAOEMBANCADEMESTRADO;
                    var detalhes = mestrado.DETALHAMENTODAPARTICIPACAOEMBANCADEMESTRADO;

                    banca = GetBancaDeTrabalho(_TP_BT_MESTRADO,
                                               detalhes.NOMEDOCANDIDATO,
                                               dados.TITULO,
                                               dados.ANO);
                    inst = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                 detalhes.NOMEINSTITUICAO);
                    ComplementarBancaDeTrabalho(banca,
                                                dados.TITULOINGLES,
                                                mestrado.INFORMACOESADICIONAIS,
                                                dados.NATUREZA,
                                                dados.TIPO.ToString(),
                                                inst,
                                                GetOrgaoInstituicaoEmpresa(inst,
                                                                           detalhes.NOMEORGAO),
                                                GetCurso(inst,
                                                         detalhes.CODIGOCURSO,
                                                         detalhes.NOMECURSO,
                                                         _NIVEL_FAT_GRADUACAO),
                                                GetIdioma(dados.IDIOMA),
                                                dados.PAIS,
                                                dados.HOMEPAGE,
                                                dados.DOI,
                                                ExtrairAreasConhecimento(mestrado.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(mestrado.PALAVRASCHAVE, mestrado.SETORESDEATIVIDADE));
                    ComplementarCurso(banca.Curso, "", detalhes.NOMECURSOINGLES);

                    professor.BancaDeTrabalho.Add(banca);

                    RegistraCacheProducao(mestrado.SEQUENCIAPRODUCAO, "BT", banca.NaturezaBancaDeTrabalho,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.PARTICIPACAOEMBANCADEDOUTORADO != null)
            {
                foreach (var dout in bancas.PARTICIPACAOEMBANCADEDOUTORADO)
                {
                    var dados = dout.DADOSBASICOSDAPARTICIPACAOEMBANCADEDOUTORADO;
                    var detalhes = dout.DETALHAMENTODAPARTICIPACAOEMBANCADEDOUTORADO;

                    banca = GetBancaDeTrabalho(_TP_BT_DOUTORADO,
                                               detalhes.NOMEDOCANDIDATO,
                                               dados.TITULO,
                                               dados.ANO);
                    inst = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                 detalhes.NOMEINSTITUICAO);
                    ComplementarBancaDeTrabalho(banca,
                                                dados.TITULOINGLES,
                                                dout.INFORMACOESADICIONAIS,
                                                dados.NATUREZA,
                                                null,
                                                inst,
                                                GetOrgaoInstituicaoEmpresa(inst,
                                                                           detalhes.NOMEORGAO),
                                                GetCurso(inst,
                                                         detalhes.CODIGOCURSO,
                                                         detalhes.NOMECURSO,
                                                         _NIVEL_FAT_GRADUACAO),
                                                GetIdioma(dados.IDIOMA),
                                                dados.PAIS,
                                                dados.HOMEPAGE,
                                                dados.DOI,
                                                ExtrairAreasConhecimento(dout.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(dout.PALAVRASCHAVE, dout.SETORESDEATIVIDADE));
                    ComplementarCurso(banca.Curso, "", detalhes.NOMECURSOINGLES);
                    professor.BancaDeTrabalho.Add(banca);

                    RegistraCacheProducao(dout.SEQUENCIAPRODUCAO, "BT", banca.NaturezaBancaDeTrabalho,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.PARTICIPACAOEMBANCADEEXAMEQUALIFICACAO != null)
            {
                foreach (var exam in bancas.PARTICIPACAOEMBANCADEEXAMEQUALIFICACAO)
                {
                    var dados = exam.DADOSBASICOSDAPARTICIPACAOEMBANCADEEXAMEQUALIFICACAO;
                    var detalhes = exam.DETALHAMENTODAPARTICIPACAOEMBANCADEEXAMEQUALIFICACAO;

                    banca = GetBancaDeTrabalho(_TP_BT_EXAME_QUALIFICACAO,
                                               detalhes.NOMEDOCANDIDATO,
                                               dados.TITULO,
                                               dados.ANO);
                    inst = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                 detalhes.NOMEINSTITUICAO);
                    ComplementarBancaDeTrabalho(banca,
                                                dados.TITULOINGLES,
                                                exam.INFORMACOESADICIONAIS,
                                                dados.NATUREZA,
                                                null,
                                                inst,
                                                GetOrgaoInstituicaoEmpresa(inst,
                                                                           detalhes.NOMEORGAO),
                                                GetCurso(inst,
                                                         detalhes.CODIGOCURSO,
                                                         detalhes.NOMECURSO,
                                                         _NIVEL_FAT_GRADUACAO),
                                                GetIdioma(dados.IDIOMA),
                                                dados.PAIS,
                                                dados.HOMEPAGE,
                                                dados.DOI,
                                                ExtrairAreasConhecimento(exam.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(exam.PALAVRASCHAVE, exam.SETORESDEATIVIDADE));
                    ComplementarCurso(banca.Curso, "", detalhes.NOMECURSOINGLES);
                    professor.BancaDeTrabalho.Add(banca);

                    RegistraCacheProducao(exam.SEQUENCIAPRODUCAO, "BT", banca.NaturezaBancaDeTrabalho,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.PARTICIPACAOEMBANCADEAPERFEICOAMENTOESPECIALIZACAO != null)
            {
                foreach (var aperf in bancas.PARTICIPACAOEMBANCADEAPERFEICOAMENTOESPECIALIZACAO)
                {
                    var dados = aperf.DADOSBASICOSDAPARTICIPACAOEMBANCADEAPERFEICOAMENTOESPECIALIZACAO;
                    var detalhes = aperf.DETALHAMENTODAPARTICIPACAOEMBANCADEAPERFEICOAMENTOESPECIALIZACAO;

                    banca = GetBancaDeTrabalho(_TP_BT_APERFEICOAMENTO_ESPECIALIZACAO,
                                               detalhes.NOMEDOCANDIDATO,
                                               dados.TITULO,
                                               dados.ANO);
                    inst = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                 detalhes.NOMEINSTITUICAO);
                    ComplementarBancaDeTrabalho(banca,
                                                dados.TITULOINGLES,
                                                aperf.INFORMACOESADICIONAIS,
                                                dados.NATUREZA,
                                                null,
                                                inst,
                                                GetOrgaoInstituicaoEmpresa(inst,
                                                                           detalhes.NOMEORGAO),
                                                GetCurso(inst,
                                                         detalhes.CODIGOCURSO,
                                                         detalhes.NOMECURSO,
                                                         _NIVEL_FAT_GRADUACAO),
                                                GetIdioma(dados.IDIOMA),
                                                dados.PAIS,
                                                dados.HOMEPAGE,
                                                dados.DOI,
                                                ExtrairAreasConhecimento(aperf.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(aperf.PALAVRASCHAVE, aperf.SETORESDEATIVIDADE));
                    ComplementarCurso(banca.Curso, "", detalhes.NOMECURSOINGLES);
                    professor.BancaDeTrabalho.Add(banca);

                    RegistraCacheProducao(aperf.SEQUENCIAPRODUCAO, "BT", banca.NaturezaBancaDeTrabalho,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.PARTICIPACAOEMBANCADEGRADUACAO != null)
            {
                foreach (var grad in bancas.PARTICIPACAOEMBANCADEGRADUACAO)
                {
                    var dados = grad.DADOSBASICOSDAPARTICIPACAOEMBANCADEGRADUACAO;
                    var detalhes = grad.DETALHAMENTODAPARTICIPACAOEMBANCADEGRADUACAO;

                    banca = GetBancaDeTrabalho(_TP_BT_GRADUACAO,
                                               detalhes.NOMEDOCANDIDATO,
                                               dados.TITULO,
                                               dados.ANO);
                    inst = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                 detalhes.NOMEINSTITUICAO);
                    ComplementarBancaDeTrabalho(banca,
                                                dados.TITULOINGLES,
                                                grad.INFORMACOESADICIONAIS,
                                                dados.NATUREZA,
                                                null,
                                                inst,
                                                GetOrgaoInstituicaoEmpresa(inst,
                                                                           detalhes.NOMEORGAO),
                                                GetCurso(inst,
                                                         detalhes.CODIGOCURSO,
                                                         detalhes.NOMECURSO,
                                                         _NIVEL_FAT_GRADUACAO),
                                                GetIdioma(dados.IDIOMA),
                                                dados.PAIS,
                                                dados.HOMEPAGE,
                                                dados.DOI,
                                                ExtrairAreasConhecimento(grad.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(grad.PALAVRASCHAVE, grad.SETORESDEATIVIDADE));
                    ComplementarCurso(banca.Curso, "", detalhes.NOMECURSOINGLES);
                    professor.BancaDeTrabalho.Add(banca);

                    RegistraCacheProducao(grad.SEQUENCIAPRODUCAO, "BT", banca.NaturezaBancaDeTrabalho,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }

            if (bancas.OUTRASPARTICIPACOESEMBANCA != null)
            {
                foreach (var outra in bancas.OUTRASPARTICIPACOESEMBANCA)
                {
                    var dados = outra.DADOSBASICOSDEOUTRASPARTICIPACOESEMBANCA;
                    var detalhes = outra.DETALHAMENTODEOUTRASPARTICIPACOESEMBANCA;

                    banca = GetBancaDeTrabalho(_TP_BT_OUTRA,
                                               detalhes.NOMEDOCANDIDATO,
                                               dados.TITULO,
                                               dados.ANO);
                    inst = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                 detalhes.NOMEINSTITUICAO);
                    ComplementarBancaDeTrabalho(banca,
                                                dados.TITULOINGLES,
                                                outra.INFORMACOESADICIONAIS,
                                                dados.NATUREZA,
                                                dados.TIPO,
                                                inst,
                                                GetOrgaoInstituicaoEmpresa(inst,
                                                                           detalhes.NOMEORGAO),
                                                GetCurso(inst,
                                                         detalhes.CODIGOCURSO,
                                                         detalhes.NOMECURSO,
                                                         _NIVEL_FAT_GRADUACAO),
                                                GetIdioma(dados.IDIOMA),
                                                dados.PAIS,
                                                dados.HOMEPAGE,
                                                dados.DOI,
                                                ExtrairAreasConhecimento(outra.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(outra.PALAVRASCHAVE, outra.SETORESDEATIVIDADE));
                    ComplementarCurso(banca.Curso, "", detalhes.NOMECURSOINGLES);
                    professor.BancaDeTrabalho.Add(banca);

                    RegistraCacheProducao(outra.SEQUENCIAPRODUCAO, "BT", banca.NaturezaBancaDeTrabalho,
                        banca.AreaConhecimento.ToList(),
                        banca.PalavraChave.ToList(),
                        banca);
                }
            }
        }

        private void ComplementarBancaDeTrabalho(BancaDeTrabalho banca, string tituloIngles, INFORMACOESADICIONAIS informacoes, string natureza, string tipo, InstituicaoEmpresa inst, OrgaoInstituicaoEmpresa orgao, Curso curso, Idioma idioma, string pais, string homepage, string doi, AreaConhecimento[] areas, PalavraChave[] palavrasChave)
        {
            lock (saveLocker)
            {
                if (banca.TituloEmInglesBancaDeTrabalho == "")
                    banca.TituloEmInglesBancaDeTrabalho = tituloIngles;

                if (informacoes != null)
                {
                    if (banca.InformacoesAdicionaisBancaDeTrabalho == "")
                        banca.InformacoesAdicionaisBancaDeTrabalho = informacoes.DESCRICAOINFORMACOESADICIONAIS;

                    if (banca.InformacoesAdicionaisEmInglesBancaDeTrabalho == "")
                        banca.InformacoesAdicionaisEmInglesBancaDeTrabalho = informacoes.DESCRICAOINFORMACOESADICIONAISINGLES;
                }

                if (banca.NaturezaBancaDeTrabalho == "")
                {
                    if (tipo != null)
                    {
                        switch (tipo)
                        {
                            case "ACADEMICO":
                                natureza = String.Format("{0} (Acadêmico)", natureza);
                                break;
                            case "PROFISSIONALIZANTE":
                                natureza = String.Format("{0} (Profissionalizante)", natureza);
                                break;
                            case "NAO_INFORMADO":
                                break;
                            default:
                                natureza = String.Format("{0} ({1})", natureza, tipo);
                                break;
                        }
                    }

                    banca.NaturezaBancaDeTrabalho = natureza;
                }

                if (banca.InstituicaoEmpresa == null || banca.InstituicaoEmpresa.NomeInstituicaoEmpresa == _NAO_INFORMADO)
                    banca.InstituicaoEmpresa = inst;

                if (banca.OrgaoInstituicaoEmpresa == null || banca.OrgaoInstituicaoEmpresa.NomeOrgaoInstituicaoEmpresa == _NAO_INFORMADO)
                    banca.OrgaoInstituicaoEmpresa = orgao;

                if (banca.Curso == null || banca.Curso.NomeCurso == _NAO_INFORMADO)
                    banca.Curso = curso;

                if (banca.Idioma == null || banca.Idioma.NomeIdioma == _NAO_INFORMADO)
                    banca.Idioma = idioma;

                if (banca.PaisBancaDeTrabalho == "")
                    banca.PaisBancaDeTrabalho = pais;

                if (banca.HomePageBancaDeTrabalho == "")
                    banca.HomePageBancaDeTrabalho = Utils.SetMaxLength(homepage, 300);

                if (banca.DOIBancaDeTrabalho == "")
                    banca.DOIBancaDeTrabalho = doi;

                if (areas.Length > 0 && areas[0].GrandeAreaConhecimento != _NAO_POSSUI)
                {
                    foreach (var a in areas)
                    {
                        if (!banca.AreaConhecimento.Contains(a))
                        {
                            banca.AreaConhecimento.Add(a);
                        }
                    }
                }

                if (palavrasChave.Length > 0 && palavrasChave[0].TermoPalavraChave != _NAO_POSSUI)
                {
                    foreach (var pc in palavrasChave)
                    {
                        if (!banca.PalavraChave.Contains(pc))
                        {
                            banca.PalavraChave.Add(pc);
                        }
                    }
                }

                LattesDatabase.SaveChanges();
            }
        }

        private BancaDeTrabalho GetBancaDeTrabalho(string tipo, string nome, string titulo, string ano)
        {
            decimal anoBanca = int.Parse(ano);

            lock (saveLocker)
            {
                var banca = LattesDatabase.BancaDeTrabalho.FirstOrDefault(
                             b => b.TipoBancaDeTrabalho == tipo
                             && b.NomeDoCandidatoBancaDeTrabalho == nome
                             && b.TituloBancaDeTrabalho == titulo
                             && b.AnoBancaDeTrabalho == anoBanca);

                if (banca == null)
                {
                    banca = LattesDatabase.BancaDeTrabalho.Create();

                    banca.TipoBancaDeTrabalho = tipo;
                    banca.NomeDoCandidatoBancaDeTrabalho = nome;
                    banca.TituloBancaDeTrabalho = titulo;
                    banca.AnoBancaDeTrabalho = anoBanca;

                    LattesDatabase.BancaDeTrabalho.Add(banca);
                    LattesDatabase.SaveChanges();
                }
                return banca;
            }
        }

        private void ProcessarOrientacoesESupervisoes(Professor professor, CurriculoVitaeXml cvXml)
        {
            OrientacaoSupervisao orien;
            int sequencia = 1;

            if (cvXml.OUTRAPRODUCAO != null
                && cvXml.OUTRAPRODUCAO.ORIENTACOESCONCLUIDAS != null)
            {
                foreach (var orienCon in cvXml.OUTRAPRODUCAO.ORIENTACOESCONCLUIDAS)
                {
                    if (orienCon.ORIENTACOESCONCLUIDASPARAMESTRADO != null)
                    {
                        foreach (var mestrado in orienCon.ORIENTACOESCONCLUIDASPARAMESTRADO)
                        {
                            if (mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.ANO == null || mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.ANO == "")
                            {
                                lock (logLocker)
                                {
                                    Logger.Error(String.Format("A Orientação ou Supervisão Concluída de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                          mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.TITULO,
                                                                          professor.NumeroCurriculo, professor.NomeProfessor));
                                }
                            }
                            else {

                                orien = LattesDatabase.OrientacaoSupervisao.Create();
                                orien.SequenciaOrientacaoSupervicao = sequencia++;

                                orien.TipoOrientacaoSupervicao = _TP_OS_CONCLUIDA;
                                orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.NATUREZA);

                                if (mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.TIPO ==
                                    DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADOTIPO.ACADEMICO)
                                    orien.NaturezaOrientacaoSupervicao += " (Acadêmico)";
                                else
                                {
                                    if (mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.TIPO ==
                                        DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADOTIPO.PROFISSIONALIZANTE)
                                        orien.NaturezaOrientacaoSupervicao += " (Profissionalizante)";
                                }

                                orien.InstituicaoEmpresa = GetInstituicaoEmpresa(mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.CODIGOINSTITUICAO,
                                                                                 mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.NOMEDAINSTITUICAO);
                                orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                           mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.NOMEORGAO);
                                orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                       mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.CODIGOCURSO,
                                                       mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.NOMEDOCURSO,
                                                       _NIVEL_FAT_MESTRADO);

                                orien.TituloOrientacaoSupervicao = mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.TITULO;
                                orien.TituloEmInglesOrientacaoSupervicao = mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.TITULOINGLES;
                                orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.ANO);

                                orien.NomeOrientandoOrientacaoSupervicao = mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.NOMEDOORIENTADO;
                                orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.FLAGBOLSA.ToString());
                                orien.AgenciaFinanciadora = GetAgenciaFinanciadora(mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.CODIGOAGENCIAFINANCIADORA,
                                                                                   mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.NOMEDAAGENCIA);

                                orien.Idioma = GetIdioma(mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.IDIOMA);

                                orien.PaisOrientacaoSupervicao = mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.PAIS;
                                orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.HOMEPAGE, 300);
                                orien.DOIOrientacaoSupervicao = mestrado.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAMESTRADO.DOI;
                                orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao(mestrado.DETALHAMENTODEORIENTACOESCONCLUIDASPARAMESTRADO.TIPODEORIENTACAO.ToString());

                                if (mestrado.INFORMACOESADICIONAIS != null)
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = mestrado.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = mestrado.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                                }
                                else
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                                }

                                foreach (var area in ExtrairAreasConhecimento(mestrado.AREASDOCONHECIMENTO))
                                    orien.AreaConhecimento.Add(area);

                                foreach (var pc in ExtrairPalavrasChave(mestrado.PALAVRASCHAVE, mestrado.SETORESDEATIVIDADE))
                                    orien.PalavraChave.Add(pc);

                                professor.OrientacaoSupervisao.Add(orien);

                                RegistraCacheProducao(mestrado.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                    orien.AreaConhecimento.ToList(),
                                    orien.PalavraChave.ToList(),
                                    orien);
                            }
                        }
                    }

                    if (orienCon.ORIENTACOESCONCLUIDASPARADOUTORADO != null)
                    {
                        foreach (var dout in orienCon.ORIENTACOESCONCLUIDASPARADOUTORADO)
                        {
                            if (dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.ANO == null || dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.ANO == "")
                            {
                                lock (logLocker)
                                {
                                    Logger.Error(String.Format("A Orientação ou Supervisão Concluída de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                          dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.TITULO,
                                                                          professor.NumeroCurriculo, professor.NomeProfessor));
                                }
                            }
                            else {
                                orien = LattesDatabase.OrientacaoSupervisao.Create();
                                orien.SequenciaOrientacaoSupervicao = sequencia++;

                                orien.TipoOrientacaoSupervicao = _TP_OS_CONCLUIDA;
                                orien.NaturezaOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.NATUREZA;
                                orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                                orien.InstituicaoEmpresa = GetInstituicaoEmpresa(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.CODIGOINSTITUICAO,
                                                                                 dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.NOMEDAINSTITUICAO);
                                orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                           dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.NOMEORGAO);
                                orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                       dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.CODIGOCURSO,
                                                       dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.NOMEDOCURSO,
                                                       _NIVEL_FAT_DOUTORADO);

                                orien.TituloOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.TITULO;
                                orien.TituloEmInglesOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.TITULOINGLES;
                                orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.ANO);

                                orien.NomeOrientandoOrientacaoSupervicao = dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.NOMEDOORIENTADO;
                                orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.FLAGBOLSA.ToString());
                                orien.AgenciaFinanciadora = GetAgenciaFinanciadora(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.CODIGOAGENCIAFINANCIADORA,
                                                                                   dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.NOMEDAAGENCIA);

                                orien.Idioma = GetIdioma(dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.IDIOMA);

                                orien.PaisOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.PAIS;
                                orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.HOMEPAGE, 300);
                                orien.DOIOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARADOUTORADO.DOI;
                                orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARADOUTORADO.TIPODEORIENTACAO.ToString());

                                if (dout.INFORMACOESADICIONAIS != null)
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                                }
                                else
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                                }

                                foreach (var area in ExtrairAreasConhecimento(dout.AREASDOCONHECIMENTO))
                                    orien.AreaConhecimento.Add(area);

                                foreach (var pc in ExtrairPalavrasChave(dout.PALAVRASCHAVE, dout.SETORESDEATIVIDADE))
                                    orien.PalavraChave.Add(pc);

                                professor.OrientacaoSupervisao.Add(orien);

                                RegistraCacheProducao(dout.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                    orien.AreaConhecimento.ToList(),
                                    orien.PalavraChave.ToList(),
                                    orien);
                            }
                        }
                    }

                    if (orienCon.ORIENTACOESCONCLUIDASPARAPOSDOUTORADO != null)
                    {
                        foreach (var dout in orienCon.ORIENTACOESCONCLUIDASPARAPOSDOUTORADO)
                        {
                            if (dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.ANO == null || dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.ANO == "")
                            {
                                lock (logLocker)
                                {
                                    Logger.Error(String.Format("A Orientação ou Supervisão Concluída de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                          dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.TITULO,
                                                                          professor.NumeroCurriculo, professor.NomeProfessor));
                                }
                            }
                            else
                            {
                                orien = LattesDatabase.OrientacaoSupervisao.Create();
                                orien.SequenciaOrientacaoSupervicao = sequencia++;

                                orien.TipoOrientacaoSupervicao = _TP_OS_CONCLUIDA;
                                orien.NaturezaOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.NATUREZA;
                                orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                                orien.InstituicaoEmpresa = GetInstituicaoEmpresa(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.CODIGOINSTITUICAO,
                                                                                 dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.NOMEDAINSTITUICAO);
                                orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                           dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.NOMEORGAO);
                                orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                       dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.CODIGOCURSO,
                                                       dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.NOMEDOCURSO,
                                                       _NIVEL_FAT_POS_DOUTORADO);

                                orien.TituloOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.TITULO;
                                orien.TituloEmInglesOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.TITULOINGLES;
                                orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.ANO);

                                orien.NomeOrientandoOrientacaoSupervicao = dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.NOMEDOORIENTADO;
                                orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.FLAGBOLSA.ToString());
                                orien.AgenciaFinanciadora = GetAgenciaFinanciadora(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.CODIGOAGENCIAFINANCIADORA,
                                                                                   dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.NOMEDAAGENCIA);

                                orien.Idioma = GetIdioma(dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.IDIOMA);

                                orien.PaisOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.PAIS;
                                orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.HOMEPAGE, 300);
                                orien.DOIOrientacaoSupervicao = dout.DADOSBASICOSDEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.DOI;
                                orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao(dout.DETALHAMENTODEORIENTACOESCONCLUIDASPARAPOSDOUTORADO.TIPODEORIENTACAO.ToString());

                                if (dout.INFORMACOESADICIONAIS != null)
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                                }
                                else
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                                }

                                foreach (var area in ExtrairAreasConhecimento(dout.AREASDOCONHECIMENTO))
                                    orien.AreaConhecimento.Add(area);

                                foreach (var pc in ExtrairPalavrasChave(dout.PALAVRASCHAVE, dout.SETORESDEATIVIDADE))
                                    orien.PalavraChave.Add(pc);

                                professor.OrientacaoSupervisao.Add(orien);

                                RegistraCacheProducao(dout.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                    orien.AreaConhecimento.ToList(),
                                    orien.PalavraChave.ToList(),
                                    orien);
                            }
                        }
                    }

                    if (orienCon.OUTRASORIENTACOESCONCLUIDAS != null)
                    {
                        foreach (var outras in orienCon.OUTRASORIENTACOESCONCLUIDAS)
                        {
                            if (outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.ANO == null || outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.ANO == "")
                            {
                                lock (logLocker)
                                {
                                    Logger.Error(String.Format("A Orientação ou Supervisão Concluída de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                          outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.TITULO,
                                                                          professor.NumeroCurriculo, professor.NomeProfessor));
                                }
                            }
                            else {
                                orien = LattesDatabase.OrientacaoSupervisao.Create();
                                orien.SequenciaOrientacaoSupervicao = sequencia++;

                                orien.TipoOrientacaoSupervicao = _TP_OS_CONCLUIDA;
                                orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.NATUREZA.ToString());

                                if (outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.TIPO != null
                                    && outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.TIPO != "")
                                    orien.NaturezaOrientacaoSupervicao = String.Format("{0} ({1})",
                                                                                       orien.NaturezaOrientacaoSupervicao,
                                                                                       outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.TIPO);

                                orien.InstituicaoEmpresa = GetInstituicaoEmpresa(outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.CODIGOINSTITUICAO,
                                                                                 outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.NOMEDAINSTITUICAO);
                                orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                           outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.NOMEORGAO);
                                orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                       outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.CODIGOCURSO,
                                                       outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.NOMEDOCURSO,
                                                       _NIVEL_FAT_OUTROS);

                                orien.TituloOrientacaoSupervicao = outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.TITULO;
                                orien.TituloEmInglesOrientacaoSupervicao = outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.TITULOINGLES;
                                orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.ANO);

                                orien.NomeOrientandoOrientacaoSupervicao = outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.NOMEDOORIENTADO;
                                orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.FLAGBOLSA.ToString());
                                orien.AgenciaFinanciadora = GetAgenciaFinanciadora(outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.CODIGOAGENCIAFINANCIADORA,
                                                                                   outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.NOMEDAAGENCIA);

                                orien.Idioma = GetIdioma(outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.IDIOMA);

                                orien.PaisOrientacaoSupervicao = outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.PAIS;
                                orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.HOMEPAGE, 300);
                                orien.DOIOrientacaoSupervicao = outras.DADOSBASICOSDEOUTRASORIENTACOESCONCLUIDAS.DOI;
                                orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao(outras.DETALHAMENTODEOUTRASORIENTACOESCONCLUIDAS.TIPODEORIENTACAOCONCLUIDA.ToString());

                                if (outras.INFORMACOESADICIONAIS != null)
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = outras.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = outras.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                                }
                                else
                                {
                                    orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                    orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                                }

                                foreach (var area in ExtrairAreasConhecimento(outras.AREASDOCONHECIMENTO))
                                    orien.AreaConhecimento.Add(area);

                                foreach (var pc in ExtrairPalavrasChave(outras.PALAVRASCHAVE, outras.SETORESDEATIVIDADE))
                                    orien.PalavraChave.Add(pc);

                                professor.OrientacaoSupervisao.Add(orien);

                                RegistraCacheProducao(outras.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                    orien.AreaConhecimento.ToList(),
                                    orien.PalavraChave.ToList(),
                                    orien);
                            }
                        }
                    }
                }
            }

            if (cvXml.DADOSCOMPLEMENTARES != null
                && cvXml.DADOSCOMPLEMENTARES.ORIENTACOESEMANDAMENTO != null)
            {
                var orienEmAnd = cvXml.DADOSCOMPLEMENTARES.ORIENTACOESEMANDAMENTO;

                if (orienEmAnd.ORIENTACAOEMANDAMENTODEMESTRADO != null)
                {
                    foreach (var mestrado in orienEmAnd.ORIENTACAOEMANDAMENTODEMESTRADO)
                    {
                        if (mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.ANO == null || mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.ANO == "")
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("A Orientação ou Supervisão Em Andamento de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                      mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.TITULODOTRABALHO,
                                                                      professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else {
                            orien = LattesDatabase.OrientacaoSupervisao.Create();
                            orien.SequenciaOrientacaoSupervicao = sequencia++;

                            orien.TipoOrientacaoSupervicao = _TP_OS_EM_ANDAMENTO;
                            orien.NaturezaOrientacaoSupervicao = mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.NATUREZA;
                            orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                            if (mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.TIPO ==
                                DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADOTIPO.ACADEMICO)
                                orien.NaturezaOrientacaoSupervicao += " (Acadêmico)";
                            else
                            {
                                if (mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.TIPO ==
                                    DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADOTIPO.PROFISSIONALIZANTE)
                                    orien.NaturezaOrientacaoSupervicao += " (Profissionalizante)";
                            }

                            orien.InstituicaoEmpresa = GetInstituicaoEmpresa(mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.CODIGOINSTITUICAO,
                                                                             mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.NOMEINSTITUICAO);
                            orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                       mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.NOMEORGAO);
                            orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                   mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.CODIGOCURSO,
                                                   mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.NOMECURSO,
                                                   _NIVEL_FAT_MESTRADO);

                            orien.TituloOrientacaoSupervicao = mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.TITULODOTRABALHO;
                            orien.TituloEmInglesOrientacaoSupervicao = mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.TITULODOTRABALHOINGLES;
                            orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.ANO);

                            orien.NomeOrientandoOrientacaoSupervicao = mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.NOMEDOORIENTANDO;
                            orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.FLAGBOLSA.ToString());
                            orien.AgenciaFinanciadora = GetAgenciaFinanciadora(mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.CODIGOAGENCIAFINANCIADORA,
                                                                               mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.NOMEDAAGENCIA);

                            orien.Idioma = GetIdioma(mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.IDIOMA);

                            orien.PaisOrientacaoSupervicao = mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.PAIS;
                            orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.HOMEPAGE, 300);
                            orien.DOIOrientacaoSupervicao = mestrado.DADOSBASICOSDAORIENTACAOEMANDAMENTODEMESTRADO.DOI;
                            orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao(mestrado.DETALHAMENTODAORIENTACAOEMANDAMENTODEMESTRADO.TIPODEORIENTACAO.ToString());

                            if (mestrado.INFORMACOESADICIONAIS != null)
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = mestrado.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = mestrado.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                            }

                            foreach (var area in ExtrairAreasConhecimento(mestrado.AREASDOCONHECIMENTO))
                                orien.AreaConhecimento.Add(area);

                            foreach (var pc in ExtrairPalavrasChave(mestrado.PALAVRASCHAVE, mestrado.SETORESDEATIVIDADE))
                                orien.PalavraChave.Add(pc);

                            professor.OrientacaoSupervisao.Add(orien);

                            RegistraCacheProducao(mestrado.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                orien.AreaConhecimento.ToList(),
                                orien.PalavraChave.ToList(),
                                orien);
                        }
                    }
                }

                if (orienEmAnd.ORIENTACAOEMANDAMENTODEDOUTORADO != null)
                {
                    foreach (var dout in orienEmAnd.ORIENTACAOEMANDAMENTODEDOUTORADO)
                    {
                        if (dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.ANO == null || dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.ANO == "")
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("A Orientação ou Supervisão Em Andamento de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                      dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.TITULODOTRABALHO,
                                                                      professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else {
                            orien = LattesDatabase.OrientacaoSupervisao.Create();
                            orien.SequenciaOrientacaoSupervicao = sequencia++;

                            orien.TipoOrientacaoSupervicao = _TP_OS_EM_ANDAMENTO;
                            orien.NaturezaOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.NATUREZA;
                            orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                            orien.InstituicaoEmpresa = GetInstituicaoEmpresa(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.CODIGOINSTITUICAO,
                                                                             dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.NOMEINSTITUICAO);
                            orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                       dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.NOMEORGAO);
                            orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                   dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.CODIGOCURSO,
                                                   dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.NOMECURSO,
                                                   _NIVEL_FAT_DOUTORADO);

                            orien.TituloOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.TITULODOTRABALHO;
                            orien.TituloEmInglesOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.TITULODOTRABALHOINGLES;
                            orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.ANO);

                            orien.NomeOrientandoOrientacaoSupervicao = dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.NOMEDOORIENTANDO;
                            orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.FLAGBOLSA.ToString());
                            orien.AgenciaFinanciadora = GetAgenciaFinanciadora(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.CODIGOAGENCIAFINANCIADORA,
                                                                               dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.NOMEDAAGENCIA);

                            orien.Idioma = GetIdioma(dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.IDIOMA);

                            orien.PaisOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.PAIS;
                            orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.HOMEPAGE, 300);
                            orien.DOIOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEDOUTORADO.DOI;
                            orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEDOUTORADO.TIPODEORIENTACAO.ToString());

                            if (dout.INFORMACOESADICIONAIS != null)
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                            }

                            foreach (var area in ExtrairAreasConhecimento(dout.AREASDOCONHECIMENTO))
                                orien.AreaConhecimento.Add(area);

                            foreach (var pc in ExtrairPalavrasChave(dout.PALAVRASCHAVE, dout.SETORESDEATIVIDADE))
                                orien.PalavraChave.Add(pc);

                            professor.OrientacaoSupervisao.Add(orien);

                            RegistraCacheProducao(dout.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                orien.AreaConhecimento.ToList(),
                                orien.PalavraChave.ToList(),
                                orien);
                        }
                    }
                }

                if (orienEmAnd.ORIENTACAOEMANDAMENTODEPOSDOUTORADO != null)
                {
                    foreach (var dout in orienEmAnd.ORIENTACAOEMANDAMENTODEPOSDOUTORADO)
                    {
                        if (dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.ANO == null || dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.ANO == "")
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("A Orientação ou Supervisão Em Andamento de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                      dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.TITULODOTRABALHO,
                                                                      professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else
                        {
                            orien = LattesDatabase.OrientacaoSupervisao.Create();
                            orien.SequenciaOrientacaoSupervicao = sequencia++;

                            orien.TipoOrientacaoSupervicao = _TP_OS_EM_ANDAMENTO;
                            orien.NaturezaOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.NATUREZA;
                            orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                            orien.InstituicaoEmpresa = GetInstituicaoEmpresa(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.CODIGOINSTITUICAO,
                                                                             dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.NOMEINSTITUICAO);
                            orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                       dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.NOMEORGAO);
                            orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                   dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.CODIGOCURSO,
                                                   dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.NOMECURSO,
                                                   _NIVEL_FAT_POS_DOUTORADO);

                            orien.TituloOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.TITULODOTRABALHO;
                            orien.TituloEmInglesOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.TITULODOTRABALHOINGLES;
                            orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.ANO);

                            orien.NomeOrientandoOrientacaoSupervicao = dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.NOMEDOORIENTANDO;
                            orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.FLAGBOLSA.ToString());
                            orien.AgenciaFinanciadora = GetAgenciaFinanciadora(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.CODIGOAGENCIAFINANCIADORA,
                                                                               dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.NOMEDAAGENCIA);

                            orien.Idioma = GetIdioma(dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.IDIOMA);

                            orien.PaisOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.PAIS;
                            orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.HOMEPAGE, 300);
                            orien.DOIOrientacaoSupervicao = dout.DADOSBASICOSDAORIENTACAOEMANDAMENTODEPOSDOUTORADO.DOI;
                            orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao(dout.DETALHAMENTODAORIENTACAOEMANDAMENTODEPOSDOUTORADO.TIPODEORIENTACAO.ToString());

                            if (dout.INFORMACOESADICIONAIS != null)
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = dout.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                            }

                            foreach (var area in ExtrairAreasConhecimento(dout.AREASDOCONHECIMENTO))
                                orien.AreaConhecimento.Add(area);

                            foreach (var pc in ExtrairPalavrasChave(dout.PALAVRASCHAVE, dout.SETORESDEATIVIDADE))
                                orien.PalavraChave.Add(pc);

                            professor.OrientacaoSupervisao.Add(orien);

                            RegistraCacheProducao(dout.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                orien.AreaConhecimento.ToList(),
                                orien.PalavraChave.ToList(),
                                orien);
                        }
                    }
                }

                if (orienEmAnd.ORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO != null)
                {
                    foreach (var espec in orienEmAnd.ORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO)
                    {
                        if (espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.ANO == null || espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.ANO == "")
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("A Orientação ou Supervisão Em Andamento de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                      espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.TITULODOTRABALHO,
                                                                      professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else
                        {
                            orien = LattesDatabase.OrientacaoSupervisao.Create();
                            orien.SequenciaOrientacaoSupervicao = sequencia++;

                            orien.TipoOrientacaoSupervicao = _TP_OS_EM_ANDAMENTO;
                            orien.NaturezaOrientacaoSupervicao = espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.NATUREZA;
                            orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                            orien.InstituicaoEmpresa = GetInstituicaoEmpresa(espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.CODIGOINSTITUICAO,
                                                                             espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.NOMEINSTITUICAO);
                            orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                       espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.NOMEORGAO);
                            orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                   espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.CODIGOCURSO,
                                                   espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.NOMECURSO,
                                                   _NIVEL_FAT_ESPECIALIZACAO);

                            orien.TituloOrientacaoSupervicao = espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.TITULODOTRABALHO;
                            orien.TituloEmInglesOrientacaoSupervicao = espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.TITULODOTRABALHOINGLES;
                            orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.ANO);

                            orien.NomeOrientandoOrientacaoSupervicao = espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.NOMEDOORIENTANDO;
                            orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.FLAGBOLSA.ToString());
                            orien.AgenciaFinanciadora = GetAgenciaFinanciadora(espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.CODIGOAGENCIAFINANCIADORA,
                                                                               espec.DETALHAMENTODAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.NOMEDAAGENCIA);

                            orien.Idioma = GetIdioma(espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.IDIOMA);

                            orien.PaisOrientacaoSupervicao = espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.PAIS;
                            orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.HOMEPAGE, 300);
                            orien.DOIOrientacaoSupervicao = espec.DADOSBASICOSDAORIENTACAOEMANDAMENTODEAPERFEICOAMENTOESPECIALIZACAO.DOI;
                            orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao("ORIENTADOR_PRINCIPAL");

                            if (espec.INFORMACOESADICIONAIS != null)
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = espec.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = espec.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                            }

                            foreach (var area in ExtrairAreasConhecimento(espec.AREASDOCONHECIMENTO))
                                orien.AreaConhecimento.Add(area);

                            foreach (var pc in ExtrairPalavrasChave(espec.PALAVRASCHAVE, espec.SETORESDEATIVIDADE))
                                orien.PalavraChave.Add(pc);

                            professor.OrientacaoSupervisao.Add(orien);

                            RegistraCacheProducao(espec.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                orien.AreaConhecimento.ToList(),
                                orien.PalavraChave.ToList(),
                                orien);
                        }
                    }
                }

                if (orienEmAnd.ORIENTACAOEMANDAMENTODEGRADUACAO != null)
                {
                    foreach (var grad in orienEmAnd.ORIENTACAOEMANDAMENTODEGRADUACAO)
                    {
                        var dados = grad.DADOSBASICOSDAORIENTACAOEMANDAMENTODEGRADUACAO;
                        var detalhes = grad.DETALHAMENTODAORIENTACAOEMANDAMENTODEGRADUACAO;

                        if (dados.ANO == null || dados.ANO == "")
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("A Orientação ou Supervisão Em Andamento de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                      dados.TITULODOTRABALHO,
                                                                      professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else
                        {
                            orien = LattesDatabase.OrientacaoSupervisao.Create();
                            orien.SequenciaOrientacaoSupervicao = sequencia++;

                            orien.TipoOrientacaoSupervicao = _TP_OS_EM_ANDAMENTO;
                            orien.NaturezaOrientacaoSupervicao = dados.NATUREZA;
                            orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                            orien.InstituicaoEmpresa = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                             detalhes.NOMEINSTITUICAO);
                            orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                       detalhes.NOMEORGAO);
                            orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                   detalhes.CODIGOCURSO,
                                                   detalhes.NOMECURSO,
                                                   _NIVEL_FAT_GRADUACAO);

                            orien.TituloOrientacaoSupervicao = dados.TITULODOTRABALHO;
                            orien.TituloEmInglesOrientacaoSupervicao = dados.TITULODOTRABALHOINGLES;
                            orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(dados.ANO);

                            orien.NomeOrientandoOrientacaoSupervicao = detalhes.NOMEDOORIENTANDO;
                            orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(detalhes.FLAGBOLSA.ToString());
                            orien.AgenciaFinanciadora = GetAgenciaFinanciadora(detalhes.CODIGOAGENCIAFINANCIADORA,
                                                                               detalhes.NOMEDAAGENCIA);

                            orien.Idioma = GetIdioma(dados.IDIOMA);

                            orien.PaisOrientacaoSupervicao = dados.PAIS;
                            orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(dados.HOMEPAGE, 300);
                            orien.DOIOrientacaoSupervicao = dados.DOI;
                            orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao("ORIENTADOR_PRINCIPAL");

                            if (grad.INFORMACOESADICIONAIS != null)
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = grad.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = grad.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                            }

                            foreach (var area in ExtrairAreasConhecimento(grad.AREASDOCONHECIMENTO))
                                orien.AreaConhecimento.Add(area);

                            foreach (var pc in ExtrairPalavrasChave(grad.PALAVRASCHAVE, grad.SETORESDEATIVIDADE))
                                orien.PalavraChave.Add(pc);

                            professor.OrientacaoSupervisao.Add(orien);

                            RegistraCacheProducao(grad.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                orien.AreaConhecimento.ToList(),
                                orien.PalavraChave.ToList(),
                                orien);
                        }
                    }
                }

                if (orienEmAnd.ORIENTACAOEMANDAMENTODEINICIACAOCIENTIFICA != null)
                {
                    foreach (var ic in orienEmAnd.ORIENTACAOEMANDAMENTODEINICIACAOCIENTIFICA)
                    {
                        var dados = ic.DADOSBASICOSDAORIENTACAOEMANDAMENTODEINICIACAOCIENTIFICA;
                        var detalhes = ic.DETALHAMENTODAORIENTACAOEMANDAMENTODEINICIACAOCIENTIFICA;

                        if (dados.ANO == null || dados.ANO == "")
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("A Orientação ou Supervisão Em Andamento de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                      dados.TITULODOTRABALHO,
                                                                      professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else {
                            orien = LattesDatabase.OrientacaoSupervisao.Create();
                            orien.SequenciaOrientacaoSupervicao = sequencia++;

                            orien.TipoOrientacaoSupervicao = _TP_OS_EM_ANDAMENTO;
                            orien.NaturezaOrientacaoSupervicao = dados.NATUREZA;
                            orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                            orien.InstituicaoEmpresa = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                             detalhes.NOMEINSTITUICAO);
                            orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                       detalhes.NOMEORGAO);
                            orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                   detalhes.CODIGOCURSO,
                                                   detalhes.NOMECURSO,
                                                   "Iniciação Científica");

                            orien.TituloOrientacaoSupervicao = dados.TITULODOTRABALHO;
                            orien.TituloEmInglesOrientacaoSupervicao = dados.TITULODOTRABALHOINGLES;
                            orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(dados.ANO);

                            orien.NomeOrientandoOrientacaoSupervicao = detalhes.NOMEDOORIENTANDO;
                            orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(detalhes.FLAGBOLSA.ToString());
                            orien.AgenciaFinanciadora = GetAgenciaFinanciadora(detalhes.CODIGOAGENCIAFINANCIADORA,
                                                                               detalhes.NOMEDAAGENCIA);

                            orien.Idioma = GetIdioma(dados.IDIOMA);

                            orien.PaisOrientacaoSupervicao = dados.PAIS;
                            orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(dados.HOMEPAGE, 300);
                            orien.DOIOrientacaoSupervicao = dados.DOI;
                            orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao("ORIENTADOR_PRINCIPAL");

                            if (ic.INFORMACOESADICIONAIS != null)
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = ic.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = ic.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                            }

                            foreach (var area in ExtrairAreasConhecimento(ic.AREASDOCONHECIMENTO))
                                orien.AreaConhecimento.Add(area);

                            foreach (var pc in ExtrairPalavrasChave(ic.PALAVRASCHAVE, ic.SETORESDEATIVIDADE))
                                orien.PalavraChave.Add(pc);

                            professor.OrientacaoSupervisao.Add(orien);

                            RegistraCacheProducao(ic.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                orien.AreaConhecimento.ToList(),
                                orien.PalavraChave.ToList(),
                                orien);
                        }
                    }
                }

                if (orienEmAnd.OUTRASORIENTACOESEMANDAMENTO != null)
                {
                    foreach (var outras in orienEmAnd.OUTRASORIENTACOESEMANDAMENTO)
                    {
                        var dados = outras.DADOSBASICOSDEOUTRASORIENTACOESEMANDAMENTO;
                        var detalhes = outras.DETALHAMENTODEOUTRASORIENTACOESEMANDAMENTO;

                        if (dados.ANO == null || dados.ANO == "")
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("A Orientação ou Supervisão Em Andamento de nome \"{0}\" {1} - {2} não possui Ano de Ocorrência, somente serão considerados Orientações/Supervições com Ano de Ocorrência",
                                                                      dados.TITULODOTRABALHO,
                                                                      professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else
                        {
                            orien = LattesDatabase.OrientacaoSupervisao.Create();
                            orien.SequenciaOrientacaoSupervicao = sequencia++;

                            orien.TipoOrientacaoSupervicao = _TP_OS_EM_ANDAMENTO;
                            orien.NaturezaOrientacaoSupervicao = dados.NATUREZA;
                            orien.NaturezaOrientacaoSupervicao = TraduzirNaturezaOrientacao(orien.NaturezaOrientacaoSupervicao);

                            orien.InstituicaoEmpresa = GetInstituicaoEmpresa(detalhes.CODIGOINSTITUICAO,
                                                                             detalhes.NOMEINSTITUICAO);
                            orien.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(orien.InstituicaoEmpresa,
                                                                                       detalhes.NOMEORGAO);
                            orien.Curso = GetCurso(orien.InstituicaoEmpresa,
                                                   detalhes.CODIGOCURSO,
                                                   detalhes.NOMECURSO,
                                                   _NIVEL_FAT_OUTROS);

                            orien.TituloOrientacaoSupervicao = dados.TITULODOTRABALHO;
                            orien.TituloEmInglesOrientacaoSupervicao = dados.TITULODOTRABALHOINGLES;
                            orien.AnoOrientacaoSupervicao = (int)Utils.ParseIntegerOrNull(dados.ANO);

                            orien.NomeOrientandoOrientacaoSupervicao = detalhes.NOMEDOORIENTANDO;
                            orien.TemBolsaOrientacaoSupervicao = TraduzirFlags(detalhes.FLAGBOLSA.ToString());
                            orien.AgenciaFinanciadora = GetAgenciaFinanciadora(detalhes.CODIGOAGENCIAFINANCIADORA,
                                                                               detalhes.NOMEDAAGENCIA);

                            orien.Idioma = GetIdioma(dados.IDIOMA);

                            orien.PaisOrientacaoSupervicao = dados.PAIS;
                            orien.HomePageOrientacaoSupervicao = Utils.SetMaxLength(dados.HOMEPAGE, 300);
                            orien.DOIOrientacaoSupervicao = dados.DOI;
                            orien.PapelOrientacaoSupervicao = TraduzirTipoOrientacao("ORIENTADOR_PRINCIPAL");

                            if (outras.INFORMACOESADICIONAIS != null)
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = outras.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = outras.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                orien.InformacoesAdicionaisOrientacaoSupervicao = _NAO_POSSUI;
                                orien.InformacoesAdicionaisEmInglesOrientacaoSupervicao = _NAO_POSSUI;
                            }

                            foreach (var area in ExtrairAreasConhecimento(outras.AREASDOCONHECIMENTO))
                                orien.AreaConhecimento.Add(area);

                            foreach (var pc in ExtrairPalavrasChave(outras.PALAVRASCHAVE, outras.SETORESDEATIVIDADE))
                                orien.PalavraChave.Add(pc);

                            professor.OrientacaoSupervisao.Add(orien);

                            RegistraCacheProducao(outras.SEQUENCIAPRODUCAO, "OS", orien.NaturezaOrientacaoSupervicao,
                                orien.AreaConhecimento.ToList(),
                                orien.PalavraChave.ToList(),
                                orien);
                        }
                    }
                }
            }
        }

        private string TraduzirNaturezaOrientacao(string natureza)
        {
            switch (natureza)
            {
                case "Dissertação de outra":
                    return _NIVEL_FAT_MESTRADO;
                case "MONOGRAFIA_DE_CONCLUSAO_DE_CURSO_APERFEICOAMENTO_E_ESPECIALIZACAO":
                    return _NIVEL_FAT_ESPECIALIZACAO;
                case "Trabalho de conclusão de curso de graduação":
                case "TRABALHO_DE_CONCLUSAO_DE_CURSO_GRADUACAO":
                    return _NIVEL_FAT_GRADUACAO;
                case "ORIENTACAO-DE-OUTRA-NATUREZA":
                case "ORIENTACAODEOUTRANATUREZA":
                    return _NIVEL_FAT_OUTROS;
                case "INICIACAO_CIENTIFICA":
                    return "Iniciação Científica";
                default:
                    return natureza;
            }
        }

        private string TraduzirTipoOrientacao(string tipo)
        {
            switch (tipo)
            {
                case "ORIENTADOR_PRINCIPAL":
                    return "Orientação Principal";
                case "CO_ORIENTADOR":
                    return "Co-Orientador";
                default:
                    return tipo;
            }
        }

        private void ProcessarParticipacaoEventos(Professor professor, CurriculoVitaeXml cvXml)
        {
            ParticipacaoEvento partEvento;
            InstituicaoEmpresa ep;
            int sequencia = 1;

            if (cvXml.PRODUCAOTECNICA != null
                && cvXml.PRODUCAOTECNICA.DEMAISTIPOSDEPRODUCAOTECNICA != null)
            {
                foreach (var demais in cvXml.PRODUCAOTECNICA.DEMAISTIPOSDEPRODUCAOTECNICA)
                {
                    if (demais.ORGANIZACAODEEVENTO != null)
                    {
                        foreach (var orgEvento in demais.ORGANIZACAODEEVENTO)
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa("", orgEvento.DETALHAMENTODAORGANIZACAODEEVENTO.INSTITUICAOPROMOTORA);
                            partEvento.Evento = GetEvento(ep,
                                                          orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.ANO,
                                                          orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.TITULO,
                                                          orgEvento.DETALHAMENTODAORGANIZACAODEEVENTO.CIDADE,
                                                          orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.PAIS,
                                                          orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.TIPO.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = "Organizador";
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.NATUREZA.ToString());
                            partEvento.Idioma = GetIdioma(orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.IDIOMA);
                            partEvento.TituloParticipacaoEvento = orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(orgEvento.DADOSBASICOSDAORGANIZACAODEEVENTO.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if (orgEvento.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = orgEvento.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = orgEvento.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(orgEvento.PALAVRASCHAVE, orgEvento.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(orgEvento.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(orgEvento.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }
            }

            if (cvXml.DADOSCOMPLEMENTARES != null
                && cvXml.DADOSCOMPLEMENTARES.PARTICIPACAOEMEVENTOSCONGRESSOS != null)
            {
                var eventosXml = cvXml.DADOSCOMPLEMENTARES.PARTICIPACAOEMEVENTOSCONGRESSOS;

                if (eventosXml.PARTICIPACAOEMCONGRESSO != null)
                {
                    foreach (var partCongresso in eventosXml.PARTICIPACAOEMCONGRESSO)
                    {
                        if (partCongresso.DETALHAMENTODAPARTICIPACAOEMCONGRESSO == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partCongresso.DETALHAMENTODAPARTICIPACAOEMCONGRESSO.CODIGOINSTITUICAO,
                                                       partCongresso.DETALHAMENTODAPARTICIPACAOEMCONGRESSO.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.ANO,
                                                          partCongresso.DETALHAMENTODAPARTICIPACAOEMCONGRESSO.NOMEDOEVENTO,
                                                          partCongresso.DETALHAMENTODAPARTICIPACAOEMCONGRESSO.CIDADEDOEVENTO,
                                                          partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.PAIS,
                                                          partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partCongresso.DADOSBASICOSDAPARTICIPACAOEMCONGRESSO.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partCongresso.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partCongresso.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partCongresso.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partCongresso.PALAVRASCHAVE, partCongresso.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partCongresso.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partCongresso.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.PARTICIPACAOEMFEIRA != null)
                {
                    foreach (var partFeira in eventosXml.PARTICIPACAOEMFEIRA)
                    {
                        if (partFeira.DETALHAMENTODAPARTICIPACAOEMFEIRA == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partFeira.DETALHAMENTODAPARTICIPACAOEMFEIRA.CODIGOINSTITUICAO,
                                                       partFeira.DETALHAMENTODAPARTICIPACAOEMFEIRA.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.ANO,
                                                          partFeira.DETALHAMENTODAPARTICIPACAOEMFEIRA.NOMEDOEVENTO,
                                                          partFeira.DETALHAMENTODAPARTICIPACAOEMFEIRA.CIDADEDOEVENTO,
                                                          partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.PAIS,
                                                          partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partFeira.DADOSBASICOSDAPARTICIPACAOEMFEIRA.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partFeira.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partFeira.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partFeira.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partFeira.PALAVRASCHAVE, partFeira.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partFeira.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partFeira.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.PARTICIPACAOEMSEMINARIO != null)
                {
                    foreach (var partSeminario in eventosXml.PARTICIPACAOEMSEMINARIO)
                    {
                        if (partSeminario.DETALHAMENTODAPARTICIPACAOEMSEMINARIO == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partSeminario.DETALHAMENTODAPARTICIPACAOEMSEMINARIO.CODIGOINSTITUICAO,
                                                       partSeminario.DETALHAMENTODAPARTICIPACAOEMSEMINARIO.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.ANO,
                                                          partSeminario.DETALHAMENTODAPARTICIPACAOEMSEMINARIO.NOMEDOEVENTO,
                                                          partSeminario.DETALHAMENTODAPARTICIPACAOEMSEMINARIO.CIDADEDOEVENTO,
                                                          partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.PAIS,
                                                          partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partSeminario.DADOSBASICOSDAPARTICIPACAOEMSEMINARIO.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partSeminario.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partSeminario.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partSeminario.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partSeminario.PALAVRASCHAVE, partSeminario.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partSeminario.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partSeminario.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.PARTICIPACAOEMSIMPOSIO != null)
                {
                    foreach (var partSimposio in eventosXml.PARTICIPACAOEMSIMPOSIO)
                    {
                        if (partSimposio.DETALHAMENTODAPARTICIPACAOEMSIMPOSIO == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partSimposio.DETALHAMENTODAPARTICIPACAOEMSIMPOSIO.CODIGOINSTITUICAO,
                                                       partSimposio.DETALHAMENTODAPARTICIPACAOEMSIMPOSIO.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.ANO,
                                                          partSimposio.DETALHAMENTODAPARTICIPACAOEMSIMPOSIO.NOMEDOEVENTO,
                                                          partSimposio.DETALHAMENTODAPARTICIPACAOEMSIMPOSIO.CIDADEDOEVENTO,
                                                          partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.PAIS,
                                                          partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partSimposio.DADOSBASICOSDAPARTICIPACAOEMSIMPOSIO.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partSimposio.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partSimposio.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partSimposio.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partSimposio.PALAVRASCHAVE, partSimposio.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partSimposio.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partSimposio.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.PARTICIPACAOEMOFICINA != null)
                {
                    foreach (var partOficina in eventosXml.PARTICIPACAOEMOFICINA)
                    {
                        if (partOficina.DETALHAMENTODAPARTICIPACAOEMOFICINA == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partOficina.DETALHAMENTODAPARTICIPACAOEMOFICINA.CODIGOINSTITUICAO,
                                                       partOficina.DETALHAMENTODAPARTICIPACAOEMOFICINA.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.ANO,
                                                          partOficina.DETALHAMENTODAPARTICIPACAOEMOFICINA.NOMEDOEVENTO,
                                                          partOficina.DETALHAMENTODAPARTICIPACAOEMOFICINA.CIDADEDOEVENTO,
                                                          partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.PAIS,
                                                          partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partOficina.DADOSBASICOSDAPARTICIPACAOEMOFICINA.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partOficina.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partOficina.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partOficina.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partOficina.PALAVRASCHAVE, partOficina.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partOficina.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partOficina.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.PARTICIPACAOEMENCONTRO != null)
                {
                    foreach (var partEncontro in eventosXml.PARTICIPACAOEMENCONTRO)
                    {
                        if (partEncontro.DETALHAMENTODAPARTICIPACAOEMENCONTRO == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partEncontro.DETALHAMENTODAPARTICIPACAOEMENCONTRO.CODIGOINSTITUICAO,
                                                       partEncontro.DETALHAMENTODAPARTICIPACAOEMENCONTRO.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.ANO,
                                                          partEncontro.DETALHAMENTODAPARTICIPACAOEMENCONTRO.NOMEDOEVENTO,
                                                          partEncontro.DETALHAMENTODAPARTICIPACAOEMENCONTRO.CIDADEDOEVENTO,
                                                          partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.PAIS,
                                                          partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partEncontro.DADOSBASICOSDAPARTICIPACAOEMENCONTRO.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partEncontro.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partEncontro.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEncontro.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partEncontro.PALAVRASCHAVE, partEncontro.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partEncontro.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partEncontro.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.PARTICIPACAOEMEXPOSICAO != null)
                {
                    foreach (var partExposicao in eventosXml.PARTICIPACAOEMEXPOSICAO)
                    {
                        if (partExposicao.DETALHAMENTODAPARTICIPACAOEMEXPOSICAO == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partExposicao.DETALHAMENTODAPARTICIPACAOEMEXPOSICAO.CODIGOINSTITUICAO,
                                                       partExposicao.DETALHAMENTODAPARTICIPACAOEMEXPOSICAO.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.ANO,
                                                          partExposicao.DETALHAMENTODAPARTICIPACAOEMEXPOSICAO.NOMEDOEVENTO,
                                                          partExposicao.DETALHAMENTODAPARTICIPACAOEMEXPOSICAO.CIDADEDOEVENTO,
                                                          partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.PAIS,
                                                          partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partExposicao.DADOSBASICOSDAPARTICIPACAOEMEXPOSICAO.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partExposicao.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partExposicao.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partExposicao.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partExposicao.PALAVRASCHAVE, partExposicao.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partExposicao.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partExposicao.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.PARTICIPACAOEMOLIMPIADA != null)
                {
                    foreach (var partOlimpiada in eventosXml.PARTICIPACAOEMOLIMPIADA)
                    {
                        if (partOlimpiada.DETALHAMENTODAPARTICIPACAOEMOLIMPIADA == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(partOlimpiada.DETALHAMENTODAPARTICIPACAOEMOLIMPIADA.CODIGOINSTITUICAO,
                                                       partOlimpiada.DETALHAMENTODAPARTICIPACAOEMOLIMPIADA.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.ANO,
                                                          partOlimpiada.DETALHAMENTODAPARTICIPACAOEMOLIMPIADA.NOMEDOEVENTO,
                                                          partOlimpiada.DETALHAMENTODAPARTICIPACAOEMOLIMPIADA.CIDADEDOEVENTO,
                                                          partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.PAIS,
                                                          partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.IDIOMA);
                            partEvento.TituloParticipacaoEvento = partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(partOlimpiada.DADOSBASICOSDAPARTICIPACAOEMOLIMPIADA.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (partOlimpiada.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = partOlimpiada.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partOlimpiada.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(partOlimpiada.PALAVRASCHAVE, partOlimpiada.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(partOlimpiada.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(partOlimpiada.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }

                if (eventosXml.OUTRASPARTICIPACOESEMEVENTOSCONGRESSOS != null)
                {
                    foreach (var outras in eventosXml.OUTRASPARTICIPACOESEMEVENTOSCONGRESSOS)
                    {
                        if (outras.DETALHAMENTODEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS == null)
                        {
                            Logger.Error(String.Format("Não foram informados os detalhes da Participação de Evento \"{0}\" do Professor(a) {1} ({2})",
                                                                  outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.TITULO,
                                                                  professor.NomeProfessor, professor.NumeroCurriculo));
                        }
                        else
                        {
                            partEvento = LattesDatabase.ParticipacaoEvento.Create();
                            ep = GetInstituicaoEmpresa(outras.DETALHAMENTODEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.CODIGOINSTITUICAO,
                                                       outras.DETALHAMENTODEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.NOMEINSTITUICAO);
                            partEvento.Evento = GetEvento(ep,
                                                          outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.ANO,
                                                          outras.DETALHAMENTODEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.NOMEDOEVENTO,
                                                          outras.DETALHAMENTODEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.CIDADEDOEVENTO,
                                                          outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.PAIS,
                                                          outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.NATUREZA.ToString());
                            partEvento.SequenciaParticipacaoEvento = sequencia++;
                            partEvento.TipoParticipacaoEvento = TraduzirTipoParticipacaoEvento(outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.TIPOPARTICIPACAO);
                            partEvento.FormaParticipacaoEvento = TraduzirFormaParticipacaoEvento(outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.FORMAPARTICIPACAO);
                            partEvento.Idioma = GetIdioma(outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.IDIOMA);
                            partEvento.TituloParticipacaoEvento = outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.TITULO;
                            partEvento.TituloEmInglesParticipacaoEvento = outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.TITULOINGLES;
                            partEvento.MeioDivulgacaoParticipacaoEvento = TraduzirMeioDivulgacao(outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.MEIODEDIVULGACAO.ToString());
                            partEvento.HomePageParticipacaoEvento = Utils.SetMaxLength(outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.HOMEPAGEDOTRABALHO, 300);
                            partEvento.DOIParticipacaoEvento = outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.DOI;
                            partEvento.DivulgacaoCeTParticipacaoEvento = TraduzirFlags(outras.DADOSBASICOSDEOUTRASPARTICIPACOESEMEVENTOSCONGRESSOS.FLAGDIVULGACAOCIENTIFICA.ToString());

                            if ((partEvento.TituloParticipacaoEvento == "" || partEvento.TituloParticipacaoEvento == null)
                                && partEvento.TipoParticipacaoEvento == "Ouvinte")
                            {
                                partEvento.TituloParticipacaoEvento = "Participação como Ouvinte";
                                partEvento.TituloEmInglesParticipacaoEvento = partEvento.TituloParticipacaoEvento;
                            }

                            if (outras.INFORMACOESADICIONAIS != null)
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = outras.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAIS;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = outras.INFORMACOESADICIONAIS.DESCRICAOINFORMACOESADICIONAISINGLES;
                            }
                            else
                            {
                                partEvento.InformacoesAdicionaisParticipacaoEvento = _NAO_INFORMADO;
                                partEvento.InformacoesAdicionaisEmInglesParticipacaoEvento = partEvento.InformacoesAdicionaisParticipacaoEvento;
                            }

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(outras.PALAVRASCHAVE, outras.SETORESDEATIVIDADE))
                                partEvento.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(outras.AREASDOCONHECIMENTO))
                                partEvento.AreaConhecimento.Add(area);

                            professor.ParticipacaoEvento.Add(partEvento);

                            RegistraCacheProducao(outras.SEQUENCIAPRODUCAO, "PE", partEvento.FormaParticipacaoEvento,
                                partEvento.AreaConhecimento.ToList(),
                                partEvento.PalavraChave.ToList(),
                                partEvento);
                        }
                    }
                }
            }
        }

        private string TraduzirTipoParticipacaoEvento(string tipo)
        {
            if (tipo == null || tipo == "")
                return _NAO_INFORMADO;
            else
                switch (tipo.ToLower())
                {
                    case "apresentação oral":
                        return "Apresentação Oral";
                    default:
                        return tipo;
                }
        }

        private string TraduzirMeioDivulgacao(string meioDivulgacaoXml)
        {
            switch (meioDivulgacaoXml)
            {
                case "IMPRESSO":
                    return "Impresso";
                case "WEB":
                    return "WEB";
                case "MEIO_MAGNETICO":
                    return "Meio Magnético";
                case "MEIO_DIGITAL":
                    return "Meio Digital";
                case "FILME":
                    return "Filme";
                case "HIPERTEXTO":
                    return "Hipertexto";
                case "OUTRO":
                    return "Outro";
                case "VARIOS":
                    return "Vários";
                case "NAO_INFORMADO":
                default:
                    return _NAO_INFORMADO;
            }
        }

        private string TraduzirFormaParticipacaoEvento(string formaXml)
        {
            if (formaXml == null || formaXml == "")
                return _NAO_INFORMADO;

            switch (formaXml)
            {
                case "CURADORIA":
                    return "Curadoria";
                case "MONTAGEM":
                    return "Montagem";
                case "MUSEOLOGIA":
                    return "Museologia";
                case "ORGANIZACAO":
                    return "Organização";
                case "NAO_INFORMADO":
                    return _NAO_INFORMADO;
                default:
                    return formaXml;
            }
        }

        private Evento GetEvento(InstituicaoEmpresa instituicao, string ano, string nomeEvento, string cidade, string pais, string natureza)
        {
            int anoEvento = int.Parse(ano);

            switch (natureza)
            {
                case "CONCERTO":
                    natureza = "Concerto";
                    break;
                case "CONCURSO":
                    natureza = "Concurso";
                    break;
                case "CONGRESSO":
                    natureza = "Congresso";
                    break;
                case "EXPOSICAO":
                    natureza = "Exposição";
                    break;
                case "FESTIVAL":
                    natureza = "Festival";
                    break;
                case "FEIRA":
                    natureza = "Feira";
                    break;
                case "OLIMPÍADA":
                    natureza = "Olimpíada";
                    break;
                case "OUTRO":
                    natureza = "Outro";
                    break;
                case "NAO_INFORMADO":
                    natureza = _NAO_INFORMADO;
                    break;
            }

            lock (saveLocker)
            {
                Evento evento = LattesDatabase.Evento.FirstOrDefault(ev =>
                    ev.AnoEvento == anoEvento
                    && ev.NomeEvento == nomeEvento
                    && ev.CidadeEvento == cidade);

                if (evento == null)
                {
                    evento = LattesDatabase.Evento.Create();

                    evento.InstituicaoEmpresa = instituicao;
                    evento.AnoEvento = anoEvento;
                    evento.NomeEvento = nomeEvento;
                    evento.CidadeEvento = cidade;
                    evento.PaisEvento = pais;
                    evento.NaturezaEvento = natureza;

                    LattesDatabase.Evento.Add(evento);
                }
                else
                {
                    if (evento.NaturezaEvento == _NAO_INFORMADO
                        || evento.NaturezaEvento == "Outro")
                        evento.NaturezaEvento = natureza;

                    if (evento.InstituicaoEmpresa.NomeInstituicaoEmpresa == _NAO_INFORMADO)
                        evento.InstituicaoEmpresa = instituicao;
                }

                LattesDatabase.SaveChanges();
                return evento;
            }
        }

        private void ProcessarProducoesBibliograficas(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.PRODUCAOBIBLIOGRAFICA == null)
                return;

            ProducaoBibliografica pb = null;
            var pbXml = cvXml.PRODUCAOBIBLIOGRAFICA;

            if (pbXml.TRABALHOSEMEVENTOS != null)
            {
                foreach (var trabalhoEvento in pbXml.TRABALHOSEMEVENTOS)
                {
                    pb = GetProducaoBibliografica(_TP_PB_TRABALHO_EVENTOS,
                                                  trabalhoEvento.DADOSBASICOSDOTRABALHO.TITULODOTRABALHO,
                                                  trabalhoEvento.DADOSBASICOSDOTRABALHO.ANODOTRABALHO);
                    if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                    ComplementarProducaoBibliografica(pb,
                                                      trabalhoEvento.DADOSBASICOSDOTRABALHO.TITULODOTRABALHOINGLES,
                                                      trabalhoEvento.INFORMACOESADICIONAIS,
                                                      null,
                                                      trabalhoEvento.DADOSBASICOSDOTRABALHO.NATUREZA.ToString(),
                                                      TraduzirFlags(trabalhoEvento.DADOSBASICOSDOTRABALHO.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                      trabalhoEvento.DETALHAMENTODOTRABALHO.ISBN,
                                                      trabalhoEvento.DETALHAMENTODOTRABALHO.TITULODOSANAISOUPROCEEDINGS,
                                                      GetIdioma(trabalhoEvento.DADOSBASICOSDOTRABALHO.IDIOMA),
                                                      trabalhoEvento.DADOSBASICOSDOTRABALHO.PAISDOEVENTO,
                                                      trabalhoEvento.DADOSBASICOSDOTRABALHO.MEIODEDIVULGACAO.ToString(),
                                                      trabalhoEvento.DADOSBASICOSDOTRABALHO.HOMEPAGEDOTRABALHO,
                                                      trabalhoEvento.DADOSBASICOSDOTRABALHO.DOI,
                                                      ExtrairAreasConhecimento(trabalhoEvento.AREASDOCONHECIMENTO),
                                                      ExtrairPalavrasChave(trabalhoEvento.PALAVRASCHAVE, trabalhoEvento.SETORESDEATIVIDADE));
                    professor.ProducaoBibliografica.Add(pb);

                    RegistraCacheProducao(trabalhoEvento.SEQUENCIAPRODUCAO, "PB", _TP_PB_TRABALHO_EVENTOS,
                        pb.AreaConhecimento.ToList(),
                        pb.PalavraChave.ToList(),
                        pb);
                }
            }

            if (pbXml.ARTIGOSPUBLICADOS != null)
            {
                foreach (var artigoPublicado in pbXml.ARTIGOSPUBLICADOS)
                {
                    pb = GetProducaoBibliografica(_TP_PB_ARTIGO_PUBLICADO,
                                                  artigoPublicado.DADOSBASICOSDOARTIGO.TITULODOARTIGO,
                                                  artigoPublicado.DADOSBASICOSDOARTIGO.ANODOARTIGO);
                    if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                    ComplementarProducaoBibliografica(pb,
                                                      artigoPublicado.DADOSBASICOSDOARTIGO.TITULODOARTIGOINGLES,
                                                      artigoPublicado.INFORMACOESADICIONAIS,
                                                      null,
                                                      artigoPublicado.DADOSBASICOSDOARTIGO.NATUREZA.ToString(),
                                                      TraduzirFlags(artigoPublicado.DADOSBASICOSDOARTIGO.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                      artigoPublicado.DETALHAMENTODOARTIGO.ISSN,
                                                      artigoPublicado.DETALHAMENTODOARTIGO.TITULODOPERIODICOOUREVISTA,
                                                      GetIdioma(artigoPublicado.DADOSBASICOSDOARTIGO.IDIOMA),
                                                      artigoPublicado.DADOSBASICOSDOARTIGO.PAISDEPUBLICACAO,
                                                      artigoPublicado.DADOSBASICOSDOARTIGO.MEIODEDIVULGACAO.ToString(),
                                                      artigoPublicado.DADOSBASICOSDOARTIGO.HOMEPAGEDOTRABALHO,
                                                      artigoPublicado.DADOSBASICOSDOARTIGO.DOI,
                                                      ExtrairAreasConhecimento(artigoPublicado.AREASDOCONHECIMENTO),
                                                      ExtrairPalavrasChave(artigoPublicado.PALAVRASCHAVE, artigoPublicado.SETORESDEATIVIDADE));
                    professor.ProducaoBibliografica.Add(pb);

                    RegistraCacheProducao(artigoPublicado.SEQUENCIAPRODUCAO, "PB", _TP_PB_ARTIGO_PUBLICADO,
                        pb.AreaConhecimento.ToList(),
                        pb.PalavraChave.ToList(),
                        pb);
                }
            }

            if (pbXml.ARTIGOSACEITOSPARAPUBLICACAO != null)
            {
                foreach (var artigoAceitoPub in pbXml.ARTIGOSACEITOSPARAPUBLICACAO)
                {
                    pb = GetProducaoBibliografica(_TP_PB_ARTIGO_ACEITO_PUBLICACAO,
                                                  artigoAceitoPub.DADOSBASICOSDOARTIGO.TITULODOARTIGO,
                                                  artigoAceitoPub.DADOSBASICOSDOARTIGO.ANODOARTIGO);
                    if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                    ComplementarProducaoBibliografica(pb,
                                                      artigoAceitoPub.DADOSBASICOSDOARTIGO.TITULODOARTIGOINGLES,
                                                      artigoAceitoPub.INFORMACOESADICIONAIS,
                                                      null,
                                                      artigoAceitoPub.DADOSBASICOSDOARTIGO.NATUREZA.ToString(),
                                                      TraduzirFlags(artigoAceitoPub.DADOSBASICOSDOARTIGO.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                      artigoAceitoPub.DETALHAMENTODOARTIGO.ISSN,
                                                      artigoAceitoPub.DETALHAMENTODOARTIGO.TITULODOPERIODICOOUREVISTA,
                                                      GetIdioma(artigoAceitoPub.DADOSBASICOSDOARTIGO.IDIOMA),
                                                      artigoAceitoPub.DADOSBASICOSDOARTIGO.PAISDEPUBLICACAO,
                                                      artigoAceitoPub.DADOSBASICOSDOARTIGO.MEIODEDIVULGACAO.ToString(),
                                                      artigoAceitoPub.DADOSBASICOSDOARTIGO.HOMEPAGEDOTRABALHO,
                                                      artigoAceitoPub.DADOSBASICOSDOARTIGO.DOI,
                                                      ExtrairAreasConhecimento(artigoAceitoPub.AREASDOCONHECIMENTO),
                                                      ExtrairPalavrasChave(artigoAceitoPub.PALAVRASCHAVE, artigoAceitoPub.SETORESDEATIVIDADE));
                    professor.ProducaoBibliografica.Add(pb);

                    RegistraCacheProducao(artigoAceitoPub.SEQUENCIAPRODUCAO, "PB", _TP_PB_ARTIGO_ACEITO_PUBLICACAO,
                        pb.AreaConhecimento.ToList(),
                        pb.PalavraChave.ToList(),
                        pb);
                }
            }

            if (pbXml.LIVROSECAPITULOS != null)
            {
                if (pbXml.LIVROSECAPITULOS.LIVROSPUBLICADOSOUORGANIZADOS != null)
                {
                    foreach (var livro in pbXml.LIVROSECAPITULOS.LIVROSPUBLICADOSOUORGANIZADOS)
                    {
                        pb = GetProducaoBibliografica(_TP_PB_LIVRO_PUBLICADO_ORGANIZADO,
                                                      livro.DADOSBASICOSDOLIVRO.TITULODOLIVRO,
                                                      livro.DADOSBASICOSDOLIVRO.ANO);
                        if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                            professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                        ComplementarProducaoBibliografica(pb,
                                                          livro.DADOSBASICOSDOLIVRO.TITULODOLIVROINGLES,
                                                          livro.INFORMACOESADICIONAIS,
                                                          livro.DADOSBASICOSDOLIVRO.TIPO.ToString(),
                                                          livro.DADOSBASICOSDOLIVRO.NATUREZA.ToString(),
                                                          TraduzirFlags(livro.DADOSBASICOSDOLIVRO.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                          livro.DETALHAMENTODOLIVRO.ISBN,
                                                          livro.DETALHAMENTODOLIVRO.NOMEDAEDITORA,
                                                          GetIdioma(livro.DADOSBASICOSDOLIVRO.IDIOMA),
                                                          livro.DADOSBASICOSDOLIVRO.PAISDEPUBLICACAO,
                                                          livro.DADOSBASICOSDOLIVRO.MEIODEDIVULGACAO.ToString(),
                                                          livro.DADOSBASICOSDOLIVRO.HOMEPAGEDOTRABALHO,
                                                          livro.DADOSBASICOSDOLIVRO.DOI,
                                                          ExtrairAreasConhecimento(livro.AREASDOCONHECIMENTO),
                                                          ExtrairPalavrasChave(livro.PALAVRASCHAVE, livro.SETORESDEATIVIDADE));
                        professor.ProducaoBibliografica.Add(pb);

                        RegistraCacheProducao(livro.SEQUENCIAPRODUCAO, "PB", _TP_PB_LIVRO_PUBLICADO_ORGANIZADO,
                            pb.AreaConhecimento.ToList(),
                            pb.PalavraChave.ToList(),
                            pb);
                    }
                }

                if (pbXml.LIVROSECAPITULOS.CAPITULOSDELIVROSPUBLICADOS != null)
                {
                    foreach (var capitulo in pbXml.LIVROSECAPITULOS.CAPITULOSDELIVROSPUBLICADOS)
                    {
                        pb = GetProducaoBibliografica(_TP_PB_CAPTIULO_PUBLICADO_ORGANIZADO,
                                                      capitulo.DADOSBASICOSDOCAPITULO.TITULODOCAPITULODOLIVRO,
                                                      capitulo.DADOSBASICOSDOCAPITULO.ANO);
                        if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                            professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                        ComplementarProducaoBibliografica(pb,
                                                          capitulo.DADOSBASICOSDOCAPITULO.TITULODOCAPITULODOLIVROINGLES,
                                                          capitulo.INFORMACOESADICIONAIS,
                                                          null,
                                                          capitulo.DADOSBASICOSDOCAPITULO.TIPO,
                                                          TraduzirFlags(capitulo.DADOSBASICOSDOCAPITULO.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                          capitulo.DETALHAMENTODOCAPITULO.ISBN,
                                                          capitulo.DETALHAMENTODOCAPITULO.NOMEDAEDITORA,
                                                          GetIdioma(capitulo.DADOSBASICOSDOCAPITULO.IDIOMA),
                                                          capitulo.DADOSBASICOSDOCAPITULO.PAISDEPUBLICACAO,
                                                          capitulo.DADOSBASICOSDOCAPITULO.MEIODEDIVULGACAO.ToString(),
                                                          capitulo.DADOSBASICOSDOCAPITULO.HOMEPAGEDOTRABALHO,
                                                          capitulo.DADOSBASICOSDOCAPITULO.DOI,
                                                          ExtrairAreasConhecimento(capitulo.AREASDOCONHECIMENTO),
                                                          ExtrairPalavrasChave(capitulo.PALAVRASCHAVE, capitulo.SETORESDEATIVIDADE));
                        professor.ProducaoBibliografica.Add(pb);

                        RegistraCacheProducao(capitulo.SEQUENCIAPRODUCAO, "PB", _TP_PB_CAPTIULO_PUBLICADO_ORGANIZADO,
                            pb.AreaConhecimento.ToList(),
                            pb.PalavraChave.ToList(),
                            pb);
                    }
                }
            }

            if (pbXml.DEMAISTIPOSDEPRODUCAOBIBLIOGRAFICA != null)
            {
                var demais = pbXml.DEMAISTIPOSDEPRODUCAOBIBLIOGRAFICA;
                var issn = "";
                var editora = "";

                if (demais.OUTRAPRODUCAOBIBLIOGRAFICA != null)
                {
                    foreach (var outra in demais.OUTRAPRODUCAOBIBLIOGRAFICA)
                    {
                        pb = GetProducaoBibliografica(_TP_PB_OUTRA,
                                                      outra.DADOSBASICOSDEOUTRAPRODUCAO.TITULO,
                                                      outra.DADOSBASICOSDEOUTRAPRODUCAO.ANO);
                        if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                            professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);

                        if (outra.DETALHAMENTODEOUTRAPRODUCAO != null) // outra produção pode não ter detalhamento
                        {
                            issn = outra.DETALHAMENTODEOUTRAPRODUCAO.ISSNISBN;
                            editora = outra.DETALHAMENTODEOUTRAPRODUCAO.EDITORA;
                        }
                        else
                        {
                            issn = "";
                            editora = _NAO_INFORMADO;
                        }

                        ComplementarProducaoBibliografica(pb,
                                                          outra.DADOSBASICOSDEOUTRAPRODUCAO.TITULOINGLES,
                                                          outra.INFORMACOESADICIONAIS,
                                                          null,
                                                          outra.DADOSBASICOSDEOUTRAPRODUCAO.NATUREZA.ToString(),
                                                          TraduzirFlags(outra.DADOSBASICOSDEOUTRAPRODUCAO.FLAGDIVULGACAOCIENTIFICA),
                                                          issn,
                                                          editora,
                                                          GetIdioma(outra.DADOSBASICOSDEOUTRAPRODUCAO.IDIOMA),
                                                          outra.DADOSBASICOSDEOUTRAPRODUCAO.PAISDEPUBLICACAO,
                                                          outra.DADOSBASICOSDEOUTRAPRODUCAO.MEIODEDIVULGACAO.ToString(),
                                                          outra.DADOSBASICOSDEOUTRAPRODUCAO.HOMEPAGEDOTRABALHO,
                                                          outra.DADOSBASICOSDEOUTRAPRODUCAO.DOI,
                                                          ExtrairAreasConhecimento(outra.AREASDOCONHECIMENTO),
                                                          ExtrairPalavrasChave(outra.PALAVRASCHAVE, outra.SETORESDEATIVIDADE));
                        professor.ProducaoBibliografica.Add(pb);

                        RegistraCacheProducao(outra.SEQUENCIAPRODUCAO, "PB", _TP_PB_OUTRA,
                            pb.AreaConhecimento.ToList(),
                            pb.PalavraChave.ToList(),
                            pb);
                    }
                }

                if (demais.PARTITURAMUSICAL != null)
                {
                    foreach (var partitura in demais.PARTITURAMUSICAL)
                    {
                        pb = GetProducaoBibliografica(_TP_PB_PARTITURA_MUSICAL,
                                                      partitura.DADOSBASICOSDAPARTITURA.TITULO,
                                                      partitura.DADOSBASICOSDAPARTITURA.ANO);
                        if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                            professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                        ComplementarProducaoBibliografica(pb,
                                                          partitura.DADOSBASICOSDAPARTITURA.TITULOINGLES,
                                                          partitura.INFORMACOESADICIONAIS,
                                                          null,
                                                          partitura.DADOSBASICOSDAPARTITURA.NATUREZA.ToString(),
                                                          false,
                                                          _NAO_POSSUI,
                                                          partitura.DETALHAMENTODAPARTITURA.EDITORA,
                                                          GetIdioma(partitura.DADOSBASICOSDAPARTITURA.IDIOMA),
                                                          partitura.DADOSBASICOSDAPARTITURA.PAISDEPUBLICACAO,
                                                          partitura.DADOSBASICOSDAPARTITURA.MEIODEDIVULGACAO.ToString(),
                                                          partitura.DADOSBASICOSDAPARTITURA.HOMEPAGEDOTRABALHO,
                                                          partitura.DADOSBASICOSDAPARTITURA.DOI,
                                                          ExtrairAreasConhecimento(partitura.AREASDOCONHECIMENTO),
                                                          ExtrairPalavrasChave(partitura.PALAVRASCHAVE, partitura.SETORESDEATIVIDADE));
                        professor.ProducaoBibliografica.Add(pb);

                        RegistraCacheProducao(partitura.SEQUENCIAPRODUCAO, "PB", _TP_PB_PARTITURA_MUSICAL,
                            pb.AreaConhecimento.ToList(),
                            pb.PalavraChave.ToList(),
                            pb);
                    }
                }

                if (demais.PREFACIOPOSFACIO != null)
                {
                    foreach (var preposfacio in demais.PREFACIOPOSFACIO)
                    {
                        pb = GetProducaoBibliografica(_TP_PB_PREFACIO_POSFACIO,
                                                      preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.TITULO,
                                                      preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.ANO);
                        if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                            professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                        ComplementarProducaoBibliografica(pb,
                                                          preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.TITULOINGLES,
                                                          preposfacio.INFORMACOESADICIONAIS,
                                                          preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.TIPO.ToString(),
                                                          preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.NATUREZA.ToString(),
                                                          false,
                                                          preposfacio.DETALHAMENTODOPREFACIOPOSFACIO.ISSNISBN,
                                                          preposfacio.DETALHAMENTODOPREFACIOPOSFACIO.EDITORADOPREFACIOPOSFACIO,
                                                          GetIdioma(preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.IDIOMA),
                                                          preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.PAISDEPUBLICACAO,
                                                          preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.MEIODEDIVULGACAO.ToString(),
                                                          preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.HOMEPAGEDOTRABALHO,
                                                          preposfacio.DADOSBASICOSDOPREFACIOPOSFACIO.DOI,
                                                          ExtrairAreasConhecimento(preposfacio.AREASDOCONHECIMENTO),
                                                          ExtrairPalavrasChave(preposfacio.PALAVRASCHAVE, preposfacio.SETORESDEATIVIDADE));
                        professor.ProducaoBibliografica.Add(pb);

                        RegistraCacheProducao(preposfacio.SEQUENCIAPRODUCAO, "PB", _TP_PB_PREFACIO_POSFACIO,
                            pb.AreaConhecimento.ToList(),
                            pb.PalavraChave.ToList(),
                            pb);
                    }
                }

                if (demais.TRADUCAO != null)
                {
                    foreach (var traducao in demais.TRADUCAO)
                    {
                        pb = GetProducaoBibliografica(_TP_PB_TRADUCAO,
                                                      traducao.DADOSBASICOSDATRADUCAO.TITULO,
                                                      traducao.DADOSBASICOSDATRADUCAO.ANO);
                        if (pb.AnoProducaoBibliografica > professor.DataUltimaPublicacaoCurriculo.Year)
                            professor.DataUltimaPublicacaoCurriculo = new DateTime((int)pb.AnoProducaoBibliografica, 01, 01);
                        ComplementarProducaoBibliografica(pb,
                                                          traducao.DADOSBASICOSDATRADUCAO.TITULOINGLES,
                                                          traducao.INFORMACOESADICIONAIS,
                                                          null,
                                                          traducao.DADOSBASICOSDATRADUCAO.NATUREZA.ToString(),
                                                          false,
                                                          traducao.DETALHAMENTODATRADUCAO.ISSNISBN,
                                                          traducao.DETALHAMENTODATRADUCAO.EDITORADATRADUCAO,
                                                          GetIdioma(traducao.DADOSBASICOSDATRADUCAO.IDIOMA),
                                                          traducao.DADOSBASICOSDATRADUCAO.PAISDEPUBLICACAO,
                                                          traducao.DADOSBASICOSDATRADUCAO.MEIODEDIVULGACAO.ToString(),
                                                          traducao.DADOSBASICOSDATRADUCAO.HOMEPAGEDOTRABALHO,
                                                          traducao.DADOSBASICOSDATRADUCAO.DOI,
                                                          ExtrairAreasConhecimento(traducao.AREASDOCONHECIMENTO),
                                                          ExtrairPalavrasChave(traducao.PALAVRASCHAVE, traducao.SETORESDEATIVIDADE));
                        professor.ProducaoBibliografica.Add(pb);

                        RegistraCacheProducao(traducao.SEQUENCIAPRODUCAO, "PB", _TP_PB_TRADUCAO,
                            pb.AreaConhecimento.ToList(),
                            pb.PalavraChave.ToList(),
                            pb);
                    }
                }
            }
        }

        private void ComplementarProducaoBibliografica(ProducaoBibliografica producaoBibliografica, string tituloEmIngles,
            INFORMACOESADICIONAIS informacoesAdicionais, string tipoProdutoNatureza, string natureza,
            bool divulgacaoCeT, string isnbIssn, string nomePeriodico, Idioma idioma, string pais, string meioDivulgacao,
            string homePage, string doi, AreaConhecimento[] areas, PalavraChave[] palavrasChave)
        {
            lock (saveLocker)
            {
                if (producaoBibliografica.TituloEmInglesProducaoBibliografica == null || producaoBibliografica.TituloEmInglesProducaoBibliografica == "")
                    producaoBibliografica.TituloEmInglesProducaoBibliografica = tituloEmIngles;

                if (informacoesAdicionais != null)
                {
                    if (producaoBibliografica.InformacoesAdicionaisProducaoBibliografica == null || producaoBibliografica.InformacoesAdicionaisProducaoBibliografica == "")
                        producaoBibliografica.InformacoesAdicionaisProducaoBibliografica = informacoesAdicionais.DESCRICAOINFORMACOESADICIONAIS;

                    if (producaoBibliografica.InformacoesAdicionaisEmInglesProducaoBibliografica == null || producaoBibliografica.InformacoesAdicionaisEmInglesProducaoBibliografica == "")
                        producaoBibliografica.InformacoesAdicionaisEmInglesProducaoBibliografica = informacoesAdicionais.DESCRICAOINFORMACOESADICIONAISINGLES;
                }

                if (!producaoBibliografica.DivulgacaoCeTProducaoBibliografica)
                    producaoBibliografica.DivulgacaoCeTProducaoBibliografica = divulgacaoCeT;

                if (producaoBibliografica.Idioma == null)
                    producaoBibliografica.Idioma = idioma;

                if (producaoBibliografica.PaisProducaoBibliografica == null || producaoBibliografica.PaisProducaoBibliografica == "")
                    producaoBibliografica.PaisProducaoBibliografica = pais;

                if (producaoBibliografica.HomePageProducaoBibliografica == null || producaoBibliografica.HomePageProducaoBibliografica == _NAO_INFORMADO)
                    producaoBibliografica.HomePageProducaoBibliografica = Utils.SetMaxLength(homePage, 300);

                if (producaoBibliografica.DOIProducaoBibliografica == null || producaoBibliografica.DOIProducaoBibliografica == "")
                    producaoBibliografica.DOIProducaoBibliografica = doi;

                if (producaoBibliografica.ISBNProducaoBibliografica == null || producaoBibliografica.ISBNProducaoBibliografica == "")
                {
                    producaoBibliografica.ISBNProducaoBibliografica = isnbIssn;
                    producaoBibliografica.NomePeriodicoProducaoBibliografica = nomePeriodico;
                }

                if (producaoBibliografica.NaturezaProducaoBibliografica == "" || producaoBibliografica.NaturezaProducaoBibliografica == null
                    || producaoBibliografica.NaturezaProducaoBibliografica == _NAO_POSSUI || producaoBibliografica.NaturezaProducaoBibliografica == _NAO_INFORMADO)
                {
                    switch (natureza)
                    {
                        case "ANAIS":
                            natureza = "Anais";
                            break;
                        case "COLETANIA":
                            natureza = "Coletânia";
                            break;
                        case "TEXTO_INTEGRAL":
                            natureza = "Texto Integral";
                            break;
                        case "ARTIGO":
                            natureza = "Artigo";
                            break;
                        case "LIVRO":
                            natureza = "Livro";
                            break;
                        case "REVISTAS_OU_PERIODICOS":
                            natureza = "Revistas ou Periódicos";
                            break;
                        case "CANTO":
                            natureza = "Canto";
                            break;
                        case "CORAL":
                            natureza = "Coral";
                            break;
                        case "ORQUESTRA":
                            natureza = "Orquestra";
                            break;
                        case "JORNAL_DE_NOTICIAS":
                            natureza = "Jornal de Noticias";
                            break;
                        case "REVISTA_MAGAZINE":
                            natureza = "Revista/Magazine";
                            break;
                        case "COMPLETO":
                            natureza = "Completo";
                            break;
                        case "RESUMO":
                            natureza = "Resumo";
                            break;
                        case "RESUMO_EXPANDIDO":
                            natureza = "Resumo Expandido";
                            break;
                        case "OUTRO":
                        case "OUTRA":
                            natureza = "Outro";
                            break;
                        case "":
                        case "NAO_INFORMADO":
                            natureza = _NAO_INFORMADO;
                            break;
                        default:
                            // mantem a informação informada, pois deve ser campo "livre"
                            if (natureza.Length > 100)
                                natureza = natureza.Substring(0, 70);
                            natureza = natureza.Trim();
                            break;
                    }

                    if (tipoProdutoNatureza != null)
                    {
                        switch (tipoProdutoNatureza)
                        {
                            case "PREFACIO":
                                natureza += " (Préfacio)";
                                break;
                            case "POSFACIO":
                                natureza += " (Pósfacio)";
                                break;
                            case "APRESENTACAO":
                                natureza += " (Apresentação)";
                                break;
                            case "INTRODUCAO":
                                natureza += " (Introdução)";
                                break;
                            case "LIVRO_PUBLICADO":
                                natureza += " (Livro Publicado)";
                                break;
                            case "LIVRO_ORGANIZADO_OU_EDICAO":
                                natureza += " (Livro Organizado ou Edição)";
                                break;
                            case "OUTRO":
                            case "NAO_INFORMADO":
                                // não muda a tipo
                                break;
                        }
                    }

                    producaoBibliografica.NaturezaProducaoBibliografica = natureza;
                }

                if (producaoBibliografica.MeioDivulgacaoProducaoBibliografica == null || producaoBibliografica.MeioDivulgacaoProducaoBibliografica == _NAO_INFORMADO)
                    producaoBibliografica.MeioDivulgacaoProducaoBibliografica = TraduzirMeioDivulgacao(meioDivulgacao);

                if (areas.Length > 0 && areas[0].GrandeAreaConhecimento != _NAO_POSSUI)
                {
                    foreach (var a in areas)
                    {
                        if (!producaoBibliografica.AreaConhecimento.Contains(a))
                        {
                            producaoBibliografica.AreaConhecimento.Add(a);
                        }
                    }
                }

                if (palavrasChave.Length > 0 && palavrasChave[0].TermoPalavraChave != _NAO_POSSUI)
                {
                    foreach (var pc in palavrasChave)
                    {
                        if (!producaoBibliografica.PalavraChave.Contains(pc))
                        {
                            producaoBibliografica.PalavraChave.Add(pc);
                        }
                    }
                }

                if (producaoBibliografica.PeriodicoQualis == null || 
                    producaoBibliografica.PeriodicoQualis.TituloPeriodicoQualis == _NAO_INFORMADO)
                    producaoBibliografica.PeriodicoQualis = GetQualis(isnbIssn, nomePeriodico);

                if (producaoBibliografica.JCR == null ||
                    producaoBibliografica.JCR.NomePeriodicoJCR == _NAO_INFORMADO)
                    producaoBibliografica.JCR = GetJCR(isnbIssn, nomePeriodico);

                LattesDatabase.SaveChanges();
            }
        }

        private PeriodicoQualis GetQualis(string issn, string nomePeriodico)
        {
            lock (saveLocker)
            {
                issn = Utils.CleanISSN(issn);

                if (issn.Length > 8) // se tiver mais de 8 caracteres implica em não ser um ISSN, mas um ISBN
                {
                    issn = "00000000";
                    nomePeriodico = _NAO_INFORMADO;
                }

                PeriodicoQualis cq = QualisDAOService.GetQualis(issn, nomePeriodico);

                if (cq == null)
                    return QualisDAOService.CreateQualis(issn, nomePeriodico, "NI", _NAO_POSSUI);

                return cq;
            }
        }

        private JCR GetJCR(string issn, string nomePeriodico)
        {
            lock (saveLocker)
            {
                issn = Utils.CleanISSN(issn);

                if (issn.Length > 8) // se tiver mais de 8 caracteres implica em não ser um ISSN, mas um ISBN
                {
                    issn = "00000000";
                    nomePeriodico = _NAO_INFORMADO;
                }

                JCR jcr = JCRDAOService.GetJCR(issn, nomePeriodico);

                if (jcr == null)
                    return JCRDAOService.CreateJCR(issn, nomePeriodico,
                        _NAO_INFORMADO, 0, null, null, null, null, null, null, null, null, null, null);

                return jcr;
            }
        }

        private ProducaoBibliografica GetProducaoBibliografica(string tipo, string titulo, string ano)
        {
            int anoTrabalho = int.Parse(ano);

            lock (saveLocker)
            {

                ProducaoBibliografica producaoBibliografica = LattesDatabase.ProducaoBibliografica.FirstOrDefault(pb =>
                    pb.TipoProducaoBibliografica == tipo
                    && pb.TituloProducaoBibliografica == titulo
                    && pb.AnoProducaoBibliografica == anoTrabalho);

                if (producaoBibliografica == null)
                {
                    producaoBibliografica = LattesDatabase.ProducaoBibliografica.Create();

                    producaoBibliografica.TipoProducaoBibliografica = tipo;
                    producaoBibliografica.TituloProducaoBibliografica = titulo;
                    producaoBibliografica.TituloEmInglesProducaoBibliografica = "";
                    producaoBibliografica.AnoProducaoBibliografica = anoTrabalho;
                    producaoBibliografica.NaturezaProducaoBibliografica = "";

                    LattesDatabase.ProducaoBibliografica.Add(producaoBibliografica);
                    LattesDatabase.SaveChanges();
                }

                return producaoBibliografica;
            }
        }

        /// <summary>
        /// Processa as Produções Técnicas do Currículo
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="cvXml"></param>
        private void ProcessarProducoesTecnicasEPatentes(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.PRODUCAOTECNICA == null)
                return;

            ProducaoTecnica producaoTecnica = null;
            Idioma portugues = GetIdioma("Português");

            var ptXml = cvXml.PRODUCAOTECNICA;

            if (ptXml.CULTIVARREGISTRADA != null)
            {
                foreach (var cultivar in ptXml.CULTIVARREGISTRADA)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_CULTIVAR_REGISTRADA,
                                                         cultivar.DADOSBASICOSDACULTIVAR.DENOMINACAO,
                                                         cultivar.DADOSBASICOSDACULTIVAR.ANOSOLICITACAO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                cultivar.DADOSBASICOSDACULTIVAR.DENOMINACAOINGLES,
                                                cultivar.INFORMACOESADICIONAIS,
                                                null,
                                                _NAO_POSSUI,
                                                TraduzirFlags(cultivar.DADOSBASICOSDACULTIVAR.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadora("", cultivar.DETALHAMENTODACULTIVAR.INSTITUICAOFINANCIADORA),
                                                portugues,
                                                cultivar.DADOSBASICOSDACULTIVAR.PAIS,
                                                _NAO_POSSUI,
                                                _NAO_POSSUI,
                                                "",
                                                ExtrairAreasConhecimento(cultivar.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(cultivar.PALAVRASCHAVE, cultivar.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, cultivar.DETALHAMENTODACULTIVAR.REGISTROOUPATENTE);

                    RegistraCacheProducao(cultivar.SEQUENCIAPRODUCAO, "PT", _TP_PT_CULTIVAR_REGISTRADA, 
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.SOFTWARE != null)
            {
                foreach (var software in ptXml.SOFTWARE)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_SOFTWARE,
                                                         software.DADOSBASICOSDOSOFTWARE.TITULODOSOFTWARE,
                                                         software.DADOSBASICOSDOSOFTWARE.ANO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                software.DADOSBASICOSDOSOFTWARE.TITULODOSOFTWAREINGLES,
                                                software.INFORMACOESADICIONAIS,
                                                null,
                                                software.DADOSBASICOSDOSOFTWARE.NATUREZA.ToString(),
                                                TraduzirFlags(software.DADOSBASICOSDOSOFTWARE.FLAGPOTENCIALINOVACAO.ToString()),
                                                TraduzirFlags(software.DADOSBASICOSDOSOFTWARE.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                GetAgenciaFinanciadora("", software.DETALHAMENTODOSOFTWARE.INSTITUICAOFINANCIADORA),
                                                GetIdioma(software.DADOSBASICOSDOSOFTWARE.IDIOMA),
                                                software.DADOSBASICOSDOSOFTWARE.PAIS,
                                                software.DADOSBASICOSDOSOFTWARE.MEIODEDIVULGACAO.ToString(),
                                                software.DADOSBASICOSDOSOFTWARE.HOMEPAGEDOTRABALHO,
                                                software.DADOSBASICOSDOSOFTWARE.DOI,
                                                ExtrairAreasConhecimento(software.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(software.PALAVRASCHAVE, software.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, software.DETALHAMENTODOSOFTWARE.REGISTROOUPATENTE);

                    RegistraCacheProducao(software.SEQUENCIAPRODUCAO, "PT", _TP_PT_SOFTWARE,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.PATENTE != null)
            {
                foreach (var patente in ptXml.PATENTE)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_PATENTE,
                                                         patente.DADOSBASICOSDAPATENTE.TITULO,
                                                         patente.DADOSBASICOSDAPATENTE.ANODESENVOLVIMENTO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                patente.DADOSBASICOSDAPATENTE.TITULOINGLES,
                                                patente.INFORMACOESADICIONAIS,
                                                null,
                                                _NAO_POSSUI,
                                                TraduzirFlags(patente.DADOSBASICOSDAPATENTE.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadora("", patente.DETALHAMENTODAPATENTE.INSTITUICAOFINANCIADORA),
                                                portugues,
                                                patente.DADOSBASICOSDAPATENTE.PAIS,
                                                patente.DADOSBASICOSDAPATENTE.MEIODEDIVULGACAO.ToString(),
                                                _NAO_POSSUI,
                                                "",
                                                ExtrairAreasConhecimento(patente.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(patente.PALAVRASCHAVE, patente.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, patente.DETALHAMENTODAPATENTE.REGISTROOUPATENTE);

                    RegistraCacheProducao(patente.SEQUENCIAPRODUCAO, "PT", _TP_PT_PATENTE,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.CULTIVARPROTEGIDA != null)
            {
                foreach (var cultProt in ptXml.CULTIVARPROTEGIDA)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_CULTIVAR_PROTEGIDA,
                                                         cultProt.DADOSBASICOSDACULTIVAR.DENOMINACAO,
                                                         cultProt.DADOSBASICOSDACULTIVAR.ANOSOLICITACAO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                cultProt.DADOSBASICOSDACULTIVAR.DENOMINACAOINGLES,
                                                cultProt.INFORMACOESADICIONAIS,
                                                null,
                                                _NAO_POSSUI,
                                                TraduzirFlags(cultProt.DADOSBASICOSDACULTIVAR.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadora("", cultProt.DETALHAMENTODACULTIVAR.INSTITUICAOFINANCIADORA),
                                                portugues,
                                                cultProt.DADOSBASICOSDACULTIVAR.PAIS,
                                                _NAO_POSSUI,
                                                _NAO_POSSUI,
                                                "",
                                                ExtrairAreasConhecimento(cultProt.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(cultProt.PALAVRASCHAVE, cultProt.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, cultProt.DETALHAMENTODACULTIVAR.REGISTROOUPATENTE);

                    RegistraCacheProducao(cultProt.SEQUENCIAPRODUCAO, "PT", _TP_PT_CULTIVAR_PROTEGIDA,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.DESENHOINDUSTRIAL != null)
            {
                foreach (var desIndus in ptXml.DESENHOINDUSTRIAL)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_DESENHO_INDUSTRIAL,
                                                         desIndus.DADOSBASICOSDODESENHOINDUSTRIAL.TITULO,
                                                         desIndus.DADOSBASICOSDODESENHOINDUSTRIAL.ANODESENVOLVIMENTO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                desIndus.DADOSBASICOSDODESENHOINDUSTRIAL.TITULOINGLES,
                                                desIndus.INFORMACOESADICIONAIS,
                                                null,
                                                _NAO_POSSUI,
                                                TraduzirFlags(desIndus.DADOSBASICOSDODESENHOINDUSTRIAL.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadora("", desIndus.DETALHAMENTODODESENHOINDUSTRIAL.INSTITUICAOFINANCIADORA),
                                                portugues,
                                                desIndus.DADOSBASICOSDODESENHOINDUSTRIAL.PAIS,
                                                _NAO_POSSUI,
                                                _NAO_POSSUI,
                                                "",
                                                ExtrairAreasConhecimento(desIndus.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(desIndus.PALAVRASCHAVE, desIndus.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, desIndus.DETALHAMENTODODESENHOINDUSTRIAL.REGISTROOUPATENTE);

                    RegistraCacheProducao(desIndus.SEQUENCIAPRODUCAO, "PT", _TP_PT_DESENHO_INDUSTRIAL,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.MARCA != null)
            {
                foreach (var marca in ptXml.MARCA)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_MARCA,
                                                         marca.DADOSBASICOSDAMARCA.TITULO,
                                                         marca.DADOSBASICOSDAMARCA.ANODESENVOLVIMENTO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                marca.DADOSBASICOSDAMARCA.TITULOINGLES,
                                                marca.INFORMACOESADICIONAIS,
                                                null,
                                                _NAO_POSSUI,
                                                TraduzirFlags(marca.DADOSBASICOSDAMARCA.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadoraNaoPossui(),
                                                portugues,
                                                marca.DADOSBASICOSDAMARCA.PAIS,
                                                _NAO_POSSUI,
                                                _NAO_POSSUI,
                                                "",
                                                ExtrairAreasConhecimento(marca.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(marca.PALAVRASCHAVE, marca.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, marca.DETALHAMENTODAMARCA.REGISTROOUPATENTE);

                    RegistraCacheProducao(marca.SEQUENCIAPRODUCAO, "PT", _TP_PT_MARCA,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.TOPOGRAFIADECIRCUITOINTEGRADO != null)
            {
                foreach (var tgci in ptXml.TOPOGRAFIADECIRCUITOINTEGRADO)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_TOPOGRAFIA_CIRCUITO_INTERGRADO,
                                                         tgci.DADOSBASICOSDATOPOGRAFIADECIRCUITOINTEGRADO.TITULO,
                                                         tgci.DADOSBASICOSDATOPOGRAFIADECIRCUITOINTEGRADO.ANODESENVOLVIMENTO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                tgci.DADOSBASICOSDATOPOGRAFIADECIRCUITOINTEGRADO.TITULOINGLES,
                                                tgci.INFORMACOESADICIONAIS,
                                                null,
                                                _NAO_POSSUI,
                                                TraduzirFlags(tgci.DADOSBASICOSDATOPOGRAFIADECIRCUITOINTEGRADO.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadora("", tgci.DETALHAMENTODATOPOGRAFIADECIRCUITOINTEGRADO.INSTITUICAOFINANCIADORA),
                                                portugues,
                                                tgci.DADOSBASICOSDATOPOGRAFIADECIRCUITOINTEGRADO.PAIS,
                                                _NAO_POSSUI,
                                                _NAO_POSSUI,
                                                "",
                                                ExtrairAreasConhecimento(tgci.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(tgci.PALAVRASCHAVE, tgci.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, tgci.DETALHAMENTODATOPOGRAFIADECIRCUITOINTEGRADO.REGISTROOUPATENTE);

                    RegistraCacheProducao(tgci.SEQUENCIAPRODUCAO, "PT", _TP_PT_TOPOGRAFIA_CIRCUITO_INTERGRADO,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.PRODUTOTECNOLOGICO != null)
            {
                foreach (var prodTec in ptXml.PRODUTOTECNOLOGICO)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_PRODUTO_TECNOLOGICO,
                                                         prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.TITULODOPRODUTO,
                                                         prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.ANO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.TITULODOPRODUTOINGLES,
                                                prodTec.INFORMACOESADICIONAIS,
                                                prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.TIPOPRODUTO.ToString(),
                                                prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.NATUREZA.ToString(),
                                                TraduzirFlags(prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadora("", prodTec.DETALHAMENTODOPRODUTOTECNOLOGICO.INSTITUICAOFINANCIADORA),
                                                GetIdioma(prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.IDIOMA),
                                                prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.PAIS,
                                                prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.MEIODEDIVULGACAO.ToString(),
                                                prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.HOMEPAGEDOTRABALHO,
                                                prodTec.DADOSBASICOSDOPRODUTOTECNOLOGICO.DOI,
                                                ExtrairAreasConhecimento(prodTec.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(prodTec.PALAVRASCHAVE, prodTec.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, prodTec.DETALHAMENTODOPRODUTOTECNOLOGICO.REGISTROOUPATENTE);

                    RegistraCacheProducao(prodTec.SEQUENCIAPRODUCAO, "PT", _TP_PT_PRODUTO_TECNOLOGICO,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.PROCESSOSOUTECNICAS != null)
            {
                foreach (var procOuTec in ptXml.PROCESSOSOUTECNICAS)
                {
                    producaoTecnica = GetProducaoTecnica(_TP_PT_PROCESSOS_TECNICAS,
                                                         procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.TITULODOPROCESSO,
                                                         procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.ANO);
                    if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                        professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                    ComplementarProducaoTecnica(producaoTecnica,
                                                procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.TITULODOPROCESSOINGLES,
                                                procOuTec.INFORMACOESADICIONAIS,
                                                null,
                                                procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.NATUREZA.ToString(),
                                                TraduzirFlags(procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.FLAGPOTENCIALINOVACAO.ToString()),
                                                false,
                                                GetAgenciaFinanciadora("", procOuTec.DETALHAMENTODOPROCESSOSOUTECNICAS.INSTITUICAOFINANCIADORA),
                                                GetIdioma(procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.IDIOMA),
                                                procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.PAIS,
                                                procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.MEIODEDIVULGACAO.ToString(),
                                                procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.HOMEPAGEDOTRABALHO,
                                                procOuTec.DADOSBASICOSDOPROCESSOSOUTECNICAS.DOI,
                                                ExtrairAreasConhecimento(procOuTec.AREASDOCONHECIMENTO),
                                                ExtrairPalavrasChave(procOuTec.PALAVRASCHAVE, procOuTec.SETORESDEATIVIDADE));
                    professor.ProducaoTecnica.Add(producaoTecnica);
                    ProcessarPatentes(producaoTecnica, procOuTec.DETALHAMENTODOPROCESSOSOUTECNICAS.REGISTROOUPATENTE);

                    RegistraCacheProducao(procOuTec.SEQUENCIAPRODUCAO, "PT", _TP_PT_PROCESSOS_TECNICAS,
                        producaoTecnica.AreaConhecimento.ToList(),
                        producaoTecnica.PalavraChave.ToList(),
                        producaoTecnica);
                }
            }

            if (ptXml.DEMAISTIPOSDEPRODUCAOTECNICA != null)
            {
                foreach (var demais in ptXml.DEMAISTIPOSDEPRODUCAOTECNICA)
                {
                    if (demais.APRESENTACAODETRABALHO != null)
                    {
                        foreach (var apTrab in demais.APRESENTACAODETRABALHO)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_APRESENTACAO_TRABALHO,
                                                                 apTrab.DADOSBASICOSDAAPRESENTACAODETRABALHO.TITULO,
                                                                 apTrab.DADOSBASICOSDAAPRESENTACAODETRABALHO.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        apTrab.DADOSBASICOSDAAPRESENTACAODETRABALHO.TITULOINGLES,
                                                        apTrab.INFORMACOESADICIONAIS,
                                                        null,
                                                        apTrab.DADOSBASICOSDAAPRESENTACAODETRABALHO.NATUREZA.ToString(),
                                                        false,
                                                        false,
                                                        GetAgenciaFinanciadoraNaoPossui(),
                                                        GetIdioma(apTrab.DADOSBASICOSDAAPRESENTACAODETRABALHO.IDIOMA),
                                                        apTrab.DADOSBASICOSDAAPRESENTACAODETRABALHO.PAIS,
                                                        _NAO_POSSUI,
                                                        _NAO_POSSUI,
                                                        apTrab.DADOSBASICOSDAAPRESENTACAODETRABALHO.DOI,
                                                        ExtrairAreasConhecimento(apTrab.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(apTrab.PALAVRASCHAVE, apTrab.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(apTrab.SEQUENCIAPRODUCAO, "PT", _TP_PT_APRESENTACAO_TRABALHO,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.CARTAMAPAOUSIMILAR != null)
                    {
                        foreach (var carta in demais.CARTAMAPAOUSIMILAR)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_CARTA_MAPA_SIMILAR,
                                                                 carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.TITULO,
                                                                 carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.TITULOINGLES,
                                                        carta.INFORMACOESADICIONAIS,
                                                        null,
                                                        carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.NATUREZA.ToString(),
                                                        false,
                                                        false,
                                                        GetAgenciaFinanciadora("", carta.DETALHAMENTODECARTAMAPAOUSIMILAR.INSTITUICAOFINANCIADORA),
                                                        GetIdioma(carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.IDIOMA),
                                                        carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.PAIS,
                                                        carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.MEIODEDIVULGACAO.ToString(),
                                                        carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.HOMEPAGEDOTRABALHO,
                                                        carta.DADOSBASICOSDECARTAMAPAOUSIMILAR.DOI,
                                                        ExtrairAreasConhecimento(carta.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(carta.PALAVRASCHAVE, carta.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(carta.SEQUENCIAPRODUCAO, "PT", _TP_PT_CARTA_MAPA_SIMILAR,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.CURSODECURTADURACAOMINISTRADO != null)
                    {
                        foreach (var cursoMin in demais.CURSODECURTADURACAOMINISTRADO)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_CURSO_CURTA_DURACAO_MINISTRADO,
                                                                 cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.TITULO,
                                                                 cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.TITULOINGLES,
                                                        cursoMin.INFORMACOESADICIONAIS,
                                                        null,
                                                        cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.NIVELDOCURSO.ToString(),
                                                        false,
                                                        TraduzirFlags(cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                        GetAgenciaFinanciadoraNaoPossui(),
                                                        GetIdioma(cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.IDIOMA),
                                                        cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.PAIS,
                                                        cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.MEIODEDIVULGACAO.ToString(),
                                                        cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.HOMEPAGEDOTRABALHO,
                                                        cursoMin.DADOSBASICOSDECURSOSCURTADURACAOMINISTRADO.DOI,
                                                        ExtrairAreasConhecimento(cursoMin.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(cursoMin.PALAVRASCHAVE, cursoMin.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(cursoMin.SEQUENCIAPRODUCAO, "PT", _TP_PT_CURSO_CURTA_DURACAO_MINISTRADO,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.DESENVOLVIMENTODEMATERIALDIDATICOOUINSTRUCIONAL != null)
                    {
                        foreach (var desMat in demais.DESENVOLVIMENTODEMATERIALDIDATICOOUINSTRUCIONAL)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_DESENV_MATERIAL_DIDATIVO_INSTITUCIONAL,
                                                                 desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.TITULO,
                                                                 desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.TITULOINGLES,
                                                        desMat.INFORMACOESADICIONAIS,
                                                        null,
                                                        desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.NATUREZA,
                                                        false,
                                                        TraduzirFlags(desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                        GetAgenciaFinanciadoraNaoPossui(),
                                                        GetIdioma(desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.IDIOMA),
                                                        desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.PAIS,
                                                        desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.MEIODEDIVULGACAO.ToString(),
                                                        desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.HOMEPAGEDOTRABALHO,
                                                        desMat.DADOSBASICOSDOMATERIALDIDATICOOUINSTRUCIONAL.DOI,
                                                        ExtrairAreasConhecimento(desMat.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(desMat.PALAVRASCHAVE, desMat.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(desMat.SEQUENCIAPRODUCAO, "PT", _TP_PT_DESENV_MATERIAL_DIDATIVO_INSTITUCIONAL,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.EDITORACAO != null)
                    {
                        foreach (var edito in demais.EDITORACAO)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_EDITORACAO,
                                                                 edito.DADOSBASICOSDEEDITORACAO.TITULO,
                                                                 edito.DADOSBASICOSDEEDITORACAO.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        edito.DADOSBASICOSDEEDITORACAO.TITULOINGLES,
                                                        edito.INFORMACOESADICIONAIS,
                                                        null,
                                                        edito.DADOSBASICOSDEEDITORACAO.NATUREZA.ToString(),
                                                        false,
                                                        false,
                                                        GetAgenciaFinanciadoraNaoPossui(),
                                                        GetIdioma(edito.DADOSBASICOSDEEDITORACAO.IDIOMA),
                                                        edito.DADOSBASICOSDEEDITORACAO.PAIS,
                                                        edito.DADOSBASICOSDEEDITORACAO.MEIODEDIVULGACAO.ToString(),
                                                        edito.DADOSBASICOSDEEDITORACAO.HOMEPAGEDOTRABALHO,
                                                        edito.DADOSBASICOSDEEDITORACAO.DOI,
                                                        ExtrairAreasConhecimento(edito.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(edito.PALAVRASCHAVE, edito.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(edito.SEQUENCIAPRODUCAO, "PT", _TP_PT_EDITORACAO,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.MANUTENCAODEOBRAARTISTICA != null)
                    {
                        foreach (var manObraArtistica in demais.MANUTENCAODEOBRAARTISTICA)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_MANUTENCAO_OBRA_ARTISTICA,
                                                                 manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.TITULO,
                                                                 manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.TITULOINGLES,
                                                        manObraArtistica.INFORMACOESADICIONAIS,
                                                        manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.TIPO.ToString(),
                                                        manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.NATUREZA.ToString(),
                                                        false,
                                                        false,
                                                        GetAgenciaFinanciadoraNaoPossui(),
                                                        GetIdioma(manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.IDIOMA),
                                                        manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.PAIS,
                                                        _NAO_POSSUI,
                                                        _NAO_POSSUI,
                                                        manObraArtistica.DADOSBASICOSDEMANUTENCAODEOBRAARTISTICA.DOI,
                                                        ExtrairAreasConhecimento(manObraArtistica.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(manObraArtistica.PALAVRASCHAVE, manObraArtistica.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(manObraArtistica.SEQUENCIAPRODUCAO, "PT", _TP_PT_MANUTENCAO_OBRA_ARTISTICA,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.MAQUETE != null)
                    {
                        foreach (var maquete in demais.MAQUETE)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_MAQUETE,
                                                                 maquete.DADOSBASICOSDAMAQUETE.TITULO,
                                                                 maquete.DADOSBASICOSDAMAQUETE.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        maquete.DADOSBASICOSDAMAQUETE.TITULOINGLES,
                                                        maquete.INFORMACOESADICIONAIS,
                                                        null,
                                                        _NAO_POSSUI,
                                                        false,
                                                        false,
                                                        GetAgenciaFinanciadora("", maquete.DETALHAMENTODAMAQUETE.INSTITUICAOFINANCIADORA),
                                                        GetIdioma(maquete.DADOSBASICOSDAMAQUETE.IDIOMA),
                                                        maquete.DADOSBASICOSDAMAQUETE.PAIS,
                                                        maquete.DADOSBASICOSDAMAQUETE.MEIODEDIVULGACAO.ToString(),
                                                        maquete.DADOSBASICOSDAMAQUETE.HOMEPAGEDOTRABALHO,
                                                        maquete.DADOSBASICOSDAMAQUETE.DOI,
                                                        ExtrairAreasConhecimento(maquete.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(maquete.PALAVRASCHAVE, maquete.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(maquete.SEQUENCIAPRODUCAO, "PT", _TP_PT_MAQUETE,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.PROGRAMADERADIOOUTV != null)
                    {
                        foreach (var radioTv in demais.PROGRAMADERADIOOUTV)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_PROGRAMA_RADIO_TV,
                                                                 radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.TITULO,
                                                                 radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.TITULOINGLES,
                                                        radioTv.INFORMACOESADICIONAIS,
                                                        null,
                                                        radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.NATUREZA.ToString(),
                                                        false,
                                                        TraduzirFlags(radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                        GetAgenciaFinanciadoraNaoPossui(),
                                                        GetIdioma(radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.IDIOMA),
                                                        radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.PAIS,
                                                        radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.MEIODEDIVULGACAO.ToString(),
                                                        _NAO_POSSUI,
                                                        radioTv.DADOSBASICOSDOPROGRAMADERADIOOUTV.DOI,
                                                        ExtrairAreasConhecimento(radioTv.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(radioTv.PALAVRASCHAVE, radioTv.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(radioTv.SEQUENCIAPRODUCAO, "PT", _TP_PT_PROGRAMA_RADIO_TV,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.RELATORIODEPESQUISA != null)
                    {
                        foreach (var relatPesq in demais.RELATORIODEPESQUISA)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_RELATORIO_PESQUISA,
                                                                 relatPesq.DADOSBASICOSDORELATORIODEPESQUISA.TITULO,
                                                                 relatPesq.DADOSBASICOSDORELATORIODEPESQUISA.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        relatPesq.DADOSBASICOSDORELATORIODEPESQUISA.TITULOINGLES,
                                                        relatPesq.INFORMACOESADICIONAIS,
                                                        null,
                                                        _NAO_POSSUI,
                                                        false,
                                                        false,
                                                        GetAgenciaFinanciadora("", relatPesq.DETALHAMENTODORELATORIODEPESQUISA.INSTITUICAOFINANCIADORA),
                                                        GetIdioma(relatPesq.DADOSBASICOSDORELATORIODEPESQUISA.IDIOMA),
                                                        relatPesq.DADOSBASICOSDORELATORIODEPESQUISA.PAIS,
                                                        relatPesq.DADOSBASICOSDORELATORIODEPESQUISA.MEIODEDIVULGACAO.ToString(),
                                                        _NAO_POSSUI,
                                                        relatPesq.DADOSBASICOSDORELATORIODEPESQUISA.DOI,
                                                        ExtrairAreasConhecimento(relatPesq.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(relatPesq.PALAVRASCHAVE, relatPesq.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(relatPesq.SEQUENCIAPRODUCAO, "PT", _TP_PT_RELATORIO_PESQUISA,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }

                    if (demais.OUTRAPRODUCAOTECNICA != null)
                    {
                        foreach (var outra in demais.OUTRAPRODUCAOTECNICA)
                        {
                            producaoTecnica = GetProducaoTecnica(_TP_PT_OUTRA_PRODUCAO_TECNICA,
                                                                 outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.TITULO,
                                                                 outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.ANO);
                            if (producaoTecnica.AnoProducaoTecnica > professor.DataUltimaPublicacaoCurriculo.Year)
                                professor.DataUltimaPublicacaoCurriculo = new DateTime((int)producaoTecnica.AnoProducaoTecnica, 01, 01);
                            ComplementarProducaoTecnica(producaoTecnica,
                                                        outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.TITULOINGLES,
                                                        outra.INFORMACOESADICIONAIS,
                                                        null,
                                                        outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.NATUREZA,
                                                        false,
                                                        TraduzirFlags(outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.FLAGDIVULGACAOCIENTIFICA.ToString()),
                                                        GetAgenciaFinanciadoraNaoPossui(),
                                                        GetIdioma(outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.IDIOMA),
                                                        outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.PAIS,
                                                        outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.MEIODEDIVULGACAO.ToString(),
                                                        outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.HOMEPAGEDOTRABALHO,
                                                        outra.DADOSBASICOSDEOUTRAPRODUCAOTECNICA.DOI,
                                                        ExtrairAreasConhecimento(outra.AREASDOCONHECIMENTO),
                                                        ExtrairPalavrasChave(outra.PALAVRASCHAVE, outra.SETORESDEATIVIDADE));
                            professor.ProducaoTecnica.Add(producaoTecnica);
                            if (outra.REGISTROOUPATENTE != null)
                                ProcessarPatentes(producaoTecnica, new REGISTROOUPATENTE[] { outra.REGISTROOUPATENTE });
                            else
                                ProcessarPatentes(producaoTecnica, null);

                            RegistraCacheProducao(outra.SEQUENCIAPRODUCAO, "PT", _TP_PT_OUTRA_PRODUCAO_TECNICA,
                                producaoTecnica.AreaConhecimento.ToList(),
                                producaoTecnica.PalavraChave.ToList(),
                                producaoTecnica);
                        }
                    }
                }
            }
        }

        private void ComplementarProducaoTecnica(ProducaoTecnica producaoTecnica, string tituloEmIngles,
            INFORMACOESADICIONAIS informacoesAdicionais, string tipoProdutoNatureza, string natureza,
            bool potencialInovacao, bool divulgacaoCeT, AgenciaFinanciadora agenciaFinanciadora,
            Idioma idioma, string pais, string meioDivulgacao, string homePage, string doi,
            AreaConhecimento[] areas, PalavraChave[] palavrasChave)
        {
            lock (saveLocker)
            {
                if (producaoTecnica.TituloEmInglesProducaoTecnica == null || producaoTecnica.TituloEmInglesProducaoTecnica == "")
                    producaoTecnica.TituloEmInglesProducaoTecnica = tituloEmIngles;

                if (informacoesAdicionais != null)
                {
                    if (producaoTecnica.InformacoesAdicionaisProducaoTecnica == null || producaoTecnica.InformacoesAdicionaisProducaoTecnica == "")
                        producaoTecnica.InformacoesAdicionaisProducaoTecnica = informacoesAdicionais.DESCRICAOINFORMACOESADICIONAIS;

                    if (producaoTecnica.InformacoesAdicionaisEmInglesProducaoTecnica == null || producaoTecnica.InformacoesAdicionaisEmInglesProducaoTecnica == "")
                        producaoTecnica.InformacoesAdicionaisEmInglesProducaoTecnica = informacoesAdicionais.DESCRICAOINFORMACOESADICIONAISINGLES;
                }

                if (producaoTecnica.PotencialInovacaoProducaoTecnica == null)
                    producaoTecnica.PotencialInovacaoProducaoTecnica = potencialInovacao;

                if (producaoTecnica.DivulgacaoCeTProducaoTecnica == null)
                    producaoTecnica.DivulgacaoCeTProducaoTecnica = divulgacaoCeT;

                if (producaoTecnica.AgenciaFinanciadora == null || producaoTecnica.AgenciaFinanciadora.NomeAgenciaFinanciadora == _NAO_POSSUI)
                    producaoTecnica.AgenciaFinanciadora = agenciaFinanciadora;

                if (producaoTecnica.Idioma == null)
                    producaoTecnica.Idioma = idioma;

                if (producaoTecnica.PaisProducaoTecnica == null || producaoTecnica.PaisProducaoTecnica == "")
                    producaoTecnica.PaisProducaoTecnica = pais;

                if (producaoTecnica.HomePageProducaoTecnica == null || producaoTecnica.HomePageProducaoTecnica == _NAO_INFORMADO)
                    producaoTecnica.HomePageProducaoTecnica = Utils.SetMaxLength(homePage, 300);

                if (producaoTecnica.DOIProducaoTecnica == null || producaoTecnica.DOIProducaoTecnica == "")
                    producaoTecnica.DOIProducaoTecnica = doi;

                if (producaoTecnica.NaturezaProducaoTecnica == "" || producaoTecnica.NaturezaProducaoTecnica == null
                    || producaoTecnica.NaturezaProducaoTecnica == _NAO_POSSUI || producaoTecnica.NaturezaProducaoTecnica == _NAO_INFORMADO)
                {
                    switch (natureza)
                    {
                        case "FOLDER":
                            natureza = "Folder";
                            break;
                        case "ENTREVISTA":
                            natureza = "Entrevista";
                            break;
                        case "MESA_REDONDA":
                            natureza = "Mesa Redonda";
                            break;
                        case "COMENTARIO":
                            natureza = "Comentário";
                            break;
                        case "PROGRAMA":
                            natureza = "Programa";
                            break;
                        case "CURADORIA":
                            natureza = "Curadoria";
                            break;
                        case "MONTAGEM":
                            natureza = "Montagem";
                            break;
                        case "MUSEOLOGIA":
                            natureza = "Museologia";
                            break;
                        case "ORGANIZACAO":
                            natureza = "Organização";
                            break;
                        case "ARQUITETURA":
                            natureza = "Arquitetura";
                            break;
                        case "DESENHO":
                            natureza = "Desenho";
                            break;
                        case "ESCULTURA":
                            natureza = "Escultura";
                            break;
                        case "FOTOGRAFIA":
                            natureza = "Fotografia";
                            break;
                        case "GRAVURA":
                            natureza = "Gravura";
                            break;
                        case "PINTURA":
                            natureza = "Pintura";
                            break;
                        case "LIVRO":
                            natureza = "Livro";
                            break;
                        case "ANAIS":
                            natureza = "Anais";
                            break;
                        case "CATALOGO":
                            natureza = "Catálogo";
                            break;
                        case "COLETANEA":
                            natureza = "Coletânia";
                            break;
                        case "ENCICLOPEDIA":
                            natureza = "Enciclopédia";
                            break;
                        case "PERIODICO":
                            natureza = "Periódico";
                            break;
                        case "EXTENSAO":
                            natureza = "Extensão";
                            break;
                        case "APERFEICOAMENTO":
                            natureza = "Aperfeicoamento";
                            break;
                        case "ESPECIALIZACAO":
                            natureza = "Especialização";
                            break;
                        case "AEROFOTOGRAMA":
                            natureza = "Aero-Fotograma";
                            break;
                        case "CARTA":
                            natureza = "Carta";
                            break;
                        case "FOTOGRAMA":
                            natureza = "Fotograma";
                            break;
                        case "MAPA":
                            natureza = "Mapa";
                            break;
                        case "COMUNICACAO":
                            natureza = "Comunicação";
                            break;
                        case "CONFERENCIA":
                            natureza = "Conferência";
                            break;
                        case "CONGRESSO":
                            natureza = "Congresso";
                            break;
                        case "SEMINARIO":
                            natureza = "Seminário";
                            break;
                        case "SIMPOSIO":
                            natureza = "Simpósio";
                            break;
                        case "ANALITICA":
                            natureza = "Analítica";
                            break;
                        case "INSTRUMENTAL":
                            natureza = "Instrumental";
                            break;
                        case "PEDAGOGICA":
                            natureza = "Pedagógica";
                            break;
                        case "PROCESSUAL":
                            natureza = "Processual";
                            break;
                        case "TERAPEUTICA":
                            natureza = "Terapeutica";
                            break;
                        case "ASSESSORIA":
                            natureza = "Assessoria";
                            break;
                        case "CONSULTORIA":
                            natureza = "Consultoria";
                            break;
                        case "PARECER":
                            natureza = "Parecer";
                            break;
                        case "ELABORACAO_DE_PROJETO":
                            natureza = "Elaboração de Projeto";
                            break;
                        case "RELATORIO_TECNICO":
                            natureza = "Relatório Técnico";
                            break;
                        case "SERVICOS_NA_AREA_DA_SAUDE":
                            natureza = "Serviços na Área da Saúde";
                            break;
                        case "APARELHO":
                            natureza = "Aparelho";
                            break;
                        case "EQUIPAMENTO":
                            natureza = "Equipamento";
                            break;
                        case "FARMACOS_E_SIMILARES":
                            natureza = "Farmacos e Similares";
                            break;
                        case "INSTRUMENTO":
                            natureza = "Instrumento";
                            break;
                        case "COMPUTACIONAL":
                            natureza = "Computacional";
                            break;
                        case "MULTIMIDIA":
                            natureza = "Multimídia";
                            break;
                        case "OUTRA":
                        case "OUTRO":
                            natureza = "Outro";
                            break;
                        case _NAO_POSSUI:
                            natureza = _NAO_POSSUI;
                            break;
                        case "NAO_INFORMADO":
                            natureza = _NAO_INFORMADO;
                            break;
                        default:
                            // mantem a informação informada, pois deve ser campo "livre"
                            natureza = natureza.Trim();
                            break;
                    }

                    if (tipoProdutoNatureza != null)
                    {
                        switch (tipoProdutoNatureza)
                        {
                            case "CONCERTO":
                                natureza += " (Concerto)";
                                break;
                            case "CONCURSO":
                                natureza += " (Concurso)";
                                break;
                            case "CONGRESSO":
                                natureza += " (Congresso)";
                                break;
                            case "EXPOSICAO":
                                natureza += " (Exposição)";
                                break;
                            case "FESTIVAL":
                                natureza += " (Festival)";
                                break;
                            case "FEIRA":
                                natureza += " (Feira)";
                                break;
                            case "OLIMPÍADA":
                                natureza += " (Olimpíada)";
                                break;
                            case "CONSERVACAO":
                                natureza += " (Convervação)";
                                break;
                            case "RESTAURACAO":
                                natureza += " (Restauração)";
                                break;
                            case "PILOTO":
                                natureza += " (Piloto)";
                                break;
                            case "PROJETO":
                                natureza += " (Projeto)";
                                break;
                            case "PROTOTIPO":
                                natureza += " (Protótipo)";
                                break;
                            case "OUTRO":
                            case "NAO_INFORMADO":
                                // não muda a tipo
                                break;
                        }
                    }

                    producaoTecnica.NaturezaProducaoTecnica = natureza;
                }

                if (producaoTecnica.MeioDivulgacaoProducaoTecnica == null || producaoTecnica.MeioDivulgacaoProducaoTecnica == _NAO_INFORMADO)
                    producaoTecnica.MeioDivulgacaoProducaoTecnica = TraduzirMeioDivulgacao(meioDivulgacao);

                if (areas.Length > 0 && areas[0].GrandeAreaConhecimento != _NAO_POSSUI)
                {
                    foreach (var a in areas)
                    {
                        if (!producaoTecnica.AreaConhecimento.Contains(a))
                        {
                            producaoTecnica.AreaConhecimento.Add(a);
                        }
                    }
                }

                if (palavrasChave.Length > 0 && palavrasChave[0].TermoPalavraChave != _NAO_POSSUI)
                {
                    foreach (var pc in palavrasChave)
                    {
                        if (!producaoTecnica.PalavraChave.Contains(pc))
                        {
                            producaoTecnica.PalavraChave.Add(pc);
                        }
                    }
                }

                LattesDatabase.SaveChanges();
            }
        }

        private ProducaoTecnica GetProducaoTecnica(string tipoProducaoTecnica, string titulo, string ano)
        {
            decimal anoProducao = int.Parse(ano);

            lock (saveLocker)
            {
                ProducaoTecnica pt = LattesDatabase.ProducaoTecnica.FirstOrDefault(
                                p => p.TipoProducaoTecnica == tipoProducaoTecnica
                                && p.TituloProducaoTecnica == titulo
                                && p.AnoProducaoTecnica == anoProducao);

                if (pt == null)
                {
                    pt = LattesDatabase.ProducaoTecnica.Create();

                    pt.TipoProducaoTecnica = tipoProducaoTecnica;
                    pt.TituloProducaoTecnica = titulo;
                    pt.TituloEmInglesProducaoTecnica = "";
                    pt.AnoProducaoTecnica = anoProducao;

                    LattesDatabase.ProducaoTecnica.Add(pt);
                    LattesDatabase.SaveChanges();
                }

                return pt;
            }
        }

        private void ProcessarPatentes(ProducaoTecnica producaoTecnica, REGISTROOUPATENTE[] registrosXml)
        {
            lock (saveLocker)
            {
                if (registrosXml != null)
                {
                    producaoTecnica.PatentiadoOuRegistradoProducaoTecnica = true;
                    
                    PatenteRegistro patente = null;
                    string tipoPatente;
                    foreach (var regPat in registrosXml)
                    {
                        tipoPatente = TraduzirTipoPatente(regPat.TIPOPATENTE.ToString());
                        patente = producaoTecnica.PatenteRegistro.FirstOrDefault(pr =>
                            pr.CodigoPatenteRegistro == regPat.CODIGODOREGISTROOUPATENTE
                            && pr.TituloPatenteRegistro == regPat.TITULOPATENTE
                            && pr.TipoPatenteRegistro == tipoPatente);

                        if (patente == null)
                        {
                            patente = LattesDatabase.PatenteRegistro.Create();

                            patente.TipoPatenteRegistro = tipoPatente;
                            patente.CodigoPatenteRegistro = regPat.CODIGODOREGISTROOUPATENTE;
                            patente.NumeroDepositoPCTPatenteRegistro = regPat.NUMERODEPOSITOPCT;
                            patente.TituloPatenteRegistro = regPat.TITULOPATENTE;
                            patente.NomeTitularPatenteRegistro = regPat.NOMEDOTITULAR;
                            patente.InstituicaoDepositoPatenteRegistro = Utils.SetMaxLength(regPat.INSTITUICAODEPOSITOREGISTRO, 300);

                            patente.DataPedidoPatenteRegistro = Utils.ParseToDateTimeOrNull(regPat.DATAPEDIDODEDEPOSITO);
                            patente.DataPedidoExamePatenteRegistro = Utils.ParseToDateTimeOrNull(regPat.DATADEPEDIDODEEXAME);
                            patente.DataConcessaoPatenteRegistro = Utils.ParseToDateTimeOrNull(regPat.DATADECONCESSAO);
                            patente.DataDepositoPCTPatenteRegistro = Utils.ParseToDateTimeOrNull(regPat.DATADEPOSITOPCT);

                            producaoTecnica.PatenteRegistro.Add(patente);
                        }
                    }
                }
                LattesDatabase.SaveChanges();
            }
        }

        /// <summary>
        /// Processa as Atuações Profissionais e Projetos do Professor
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="cvXml"></param>
        private void ProcessarAtuacoesProfissionaisEProjetos(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.DADOSGERAIS.ATUACOESPROFISSIONAIS == null)
                return;

            AtividadeProfissional ativProf = null;
            VinculoAtuacaoProfissional vinculo = null;
            InstituicaoEmpresa ie = null;
            Projeto projeto = null;
            ParticipacaoEmProjeto part;
            InstituicaoEmpresa ief;

            int sequenciaVinculo = 1;
            int sequenciaAtiv = 1;
            int sequenciaLP = 1;

            String treinamentos;
            String disciplinas;
            String projetos;

            foreach (ATUACAOPROFISSIONAL ap in cvXml.DADOSGERAIS.ATUACOESPROFISSIONAIS)
            {
                ie = GetInstituicaoEmpresa(ap.CODIGOINSTITUICAO,
                                           ap.NOMEINSTITUICAO);

                if (ap.ATIVIDADESDEPARTICIPACAOEMPROJETO != null)
                {
                    foreach (PARTICIPACAOEMPROJETO pp in ap.ATIVIDADESDEPARTICIPACAOEMPROJETO)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_PART_PROJETO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          pp.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      pp.NOMEORGAO);
                        if (pp.MESINICIO != null && pp.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(pp.MESINICIO, pp.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", pp.ANOINICIO);

                        if (pp.MESFIM != null && pp.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(pp.MESFIM, pp.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", pp.ANOFIM);

                        projetos = "";

                        if (pp.PROJETODEPESQUISA != null)
                        {
                            foreach (PROJETODEPESQUISA pdp in pp.PROJETODEPESQUISA)
                            {
                                if (pdp.ANOINICIO == "" || pdp.ANOINICIO == null)
                                {
                                    lock (logLocker)
                                    {
                                        Logger.Error(String.Format("O Projeto \"{0}\" do Professor {1} - {2} não possui Ano de Início, somente serão considerados projetos com Ano de Início",
                                                                                pdp.NOMEDOPROJETO, professor.NumeroCurriculo, professor.NomeProfessor));
                                    }
                                }
                                else
                                {
                                    projetos += pdp.NOMEDOPROJETO + ", ";
                                    projeto = GetProjeto(ie,
                                                         ativProf.OrgaoInstituicaoEmpresa,
                                                         ativProf.UnidadeInstituicaoEmpresa,
                                                         int.Parse(pdp.ANOINICIO),
                                                         pdp.NOMEDOPROJETO);

                                    ComplementarProjeto(projeto,
                                                        Utils.ParseIntegerOrNull(pdp.ANOFIM),
                                                        pdp.SITUACAO.ToString(),
                                                        pdp.NATUREZA.ToString(),
                                                        TraduzirFlags(pdp.FLAGPOTENCIALINOVACAO.ToString()),
                                                        pdp.NOMEDOPROJETOINGLES,
                                                        pdp.DESCRICAODOPROJETO,
                                                        pdp.DESCRICAODOPROJETOINGLES);

                                    part = professor.ParticipacaoEmProjeto.FirstOrDefault(
                                        p => p.Projeto.ProjetoId == projeto.ProjetoId);

                                    if (part == null)
                                    {
                                        // adiciona v partipação do professor em questão
                                        part = LattesDatabase.ParticipacaoEmProjeto.Create();
                                        professor.ParticipacaoEmProjeto.Add(part);
                                        part.Projeto = projeto;
                                    }

                                    // TODO voltar aqui

                                    foreach (var partXml in pdp.EQUIPEDOPROJETO)
                                    {
                                        if (professor.NomeProfessor == partXml.NOMECOMPLETO
                                        || professor.NumeroCurriculo.Trim() == partXml.NROIDCNPQ.Trim())
                                            part.ResponsavelParticipacaoEmProjeto = TraduzirFlags(partXml.FLAGRESPONSAVEL.ToString());
                                    }

                                    if (pdp.FINANCIADORESDOPROJETO != null)
                                    {
                                        foreach (var fp in pdp.FINANCIADORESDOPROJETO)
                                        {
                                            ief = GetInstituicaoEmpresa(fp.CODIGOINSTITUICAO,
                                                                        fp.NOMEINSTITUICAO);
                                            if (!projeto.InstituicaoEmpresaFinanciadora.Contains(ief))
                                                projeto.InstituicaoEmpresaFinanciadora.Add(ief);
                                        }
                                    }

                                    if (pdp.PRODUCOESCTDOPROJETO != null)
                                    {
                                        foreach (var pcet in pdp.PRODUCOESCTDOPROJETO)
                                        {
                                            if (cacheProducoes.ContainsKey(int.Parse(pcet.SEQUENCIAPRODUCAOCT)))
                                                RegistraCacheProducaoProjeto(projeto, cacheProducoes[int.Parse(pcet.SEQUENCIAPRODUCAOCT)]);
                                        }
                                    }

                                    if (pdp.ORIENTACOES != null)
                                    {
                                        foreach (var orien in pdp.ORIENTACOES)
                                        {
                                            if (cacheProducoes.ContainsKey(int.Parse(orien.SEQUENCIAORIENTACAO)))
                                                RegistraCacheProducaoProjeto(projeto, cacheProducoes[int.Parse(orien.SEQUENCIAORIENTACAO)]);
                                        }
                                    }
                                }
                            }
                        }

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Projetos: {0}", projetos);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDECONSELHOCOMISSAOECONSULTORIA != null)
                {
                    foreach (CONSELHOCOMISSAOECONSULTORIA ccc in ap.ATIVIDADESDECONSELHOCOMISSAOECONSULTORIA)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_CONSELHO_COMISSAO_CONSULTORIA;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          ccc.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      ccc.NOMEORGAO);
                        if (ccc.MESINICIO != null && ccc.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(ccc.MESINICIO, ccc.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", ccc.ANOINICIO);

                        if (ccc.MESFIM != null && ccc.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(ccc.MESFIM, ccc.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", ccc.ANOFIM);

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Especificação: {0}", ccc.ESPECIFICACAO);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.OUTRASATIVIDADESTECNICOCIENTIFICA != null)
                {
                    foreach (OUTRAATIVIDADETECNICOCIENTIFICA outra in ap.OUTRASATIVIDADESTECNICOCIENTIFICA)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_OUTRA_TECNICO_CIENTIFICA;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          outra.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      outra.NOMEORGAO);
                        if (outra.MESINICIO != null && outra.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(outra.MESINICIO, outra.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", outra.ANOINICIO);

                        if (outra.MESFIM != null && outra.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(outra.MESFIM, outra.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", outra.ANOFIM);

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Atividade Realizada: {0}", outra.ATIVIDADEREALIZADA);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDETREINAMENTOMINISTRADO != null)
                {
                    foreach (TREINAMENTOMINISTRADO tm in ap.ATIVIDADESDETREINAMENTOMINISTRADO)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_TREINAMENTO_MINISTRADO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          tm.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      tm.NOMEORGAO);
                        if (tm.MESINICIO != null && tm.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(tm.MESINICIO, tm.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", tm.ANOINICIO);

                        if (tm.MESFIM != null && tm.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(tm.MESFIM, tm.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", tm.ANOFIM);

                        treinamentos = "";
                        foreach (TREINAMENTO d in tm.TREINAMENTO)
                            treinamentos += d.Value + ", ";

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Treinamentos Ministrados: {0}", treinamentos);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDEEXTENSAOUNIVERSITARIA != null)
                {
                    foreach (EXTENSAOUNIVERSITARIA eu in ap.ATIVIDADESDEEXTENSAOUNIVERSITARIA)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_SERVICO_TECNICO_ESPECIALIZADO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          eu.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      eu.NOMEORGAO);
                        if (eu.MESINICIO != null && eu.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(eu.MESINICIO, eu.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", eu.ANOINICIO);

                        if (eu.MESFIM != null && eu.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(eu.MESFIM, eu.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", eu.ANOFIM);

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Atividade Realizada: {0}", eu.ATIVIDADEDEEXTENSAOREALIZADA);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDESERVICOTECNICOESPECIALIZADO != null)
                {
                    foreach (SERVICOTECNICOESPECIALIZADO se in ap.ATIVIDADESDESERVICOTECNICOESPECIALIZADO)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_SERVICO_TECNICO_ESPECIALIZADO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          se.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      se.NOMEORGAO);
                        if (se.MESINICIO != null && se.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(se.MESINICIO, se.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", se.ANOINICIO);

                        if (se.MESFIM != null && se.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(se.MESFIM, se.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", se.ANOFIM);

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Serviço Realizado: {0}", se.SERVICOREALIZADO);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDEESTAGIO != null)
                {
                    foreach (ESTAGIO estagio in ap.ATIVIDADESDEESTAGIO)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_ESTAGIO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          estagio.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      estagio.NOMEORGAO);
                        if (estagio.MESINICIO != null && estagio.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(estagio.MESINICIO, estagio.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", estagio.ANOINICIO);

                        if (estagio.MESFIM != null && estagio.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(estagio.MESFIM, estagio.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", estagio.ANOFIM);

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Estágio Realizado: {0}", estagio.ESTAGIOREALIZADO);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDEENSINO != null)
                {
                    foreach (ENSINO ensino in ap.ATIVIDADESDEENSINO)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_ENSINO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresaNaoPossui(ie);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      ensino.NOMEORGAO);
                        if (ensino.MESINICIO != null && ensino.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(ensino.MESINICIO, ensino.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", ensino.ANOINICIO);

                        if (ensino.MESFIM != null && ensino.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(ensino.MESFIM, ensino.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", ensino.ANOFIM);

                        disciplinas = "";
                        foreach (DISCIPLINA d in ensino.DISCIPLINA)
                            disciplinas += d.Value + ", ";

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Curso Ministrado: {0} - {1}; Disciplinas Ministradas: {2}",
                                                                                ensino.CODIGOCURSO,
                                                                                ensino.NOMECURSO,
                                                                                disciplinas);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDEPESQUISAEDESENVOLVIMENTO != null)
                {
                    foreach (PESQUISAEDESENVOLVIMENTO pd in ap.ATIVIDADESDEPESQUISAEDESENVOLVIMENTO)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_PESQUISA_DESENVOLVIMENTO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          pd.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      pd.NOMEORGAO);
                        if (pd.MESINICIO != null && pd.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(pd.MESINICIO, pd.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", pd.ANOINICIO);

                        if (pd.MESFIM != null && pd.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(pd.MESFIM, pd.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", pd.ANOFIM);

                        ativProf.InformacoesAdicionaisAtividadeProfissional = _NAO_POSSUI;

                        sequenciaLP = ProcessarLinhasDePesquisa(professor, sequenciaLP, pd.LINHADEPESQUISA);

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.ATIVIDADESDEDIRECAOEADMINISTRACAO != null)
                {
                    foreach (DIRECAOEADMINISTRACAO dea in ap.ATIVIDADESDEDIRECAOEADMINISTRACAO)
                    {
                        ativProf = LattesDatabase.AtividadeProfissional.Create();

                        ativProf.SequenciaAtividadeProfissional = sequenciaAtiv++;
                        ativProf.TipoAtividadeProfissional = _TP_AP_DIRECAO_ADMINISTRACAO;
                        ativProf.InstituicaoEmpresa = ie;
                        ativProf.UnidadeInstituicaoEmpresa = GetUnidadeInstituicaoEmpresa(ie,
                                                                                          dea.NOMEUNIDADE);
                        ativProf.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(ie,
                                                                                      dea.NOMEORGAO);
                        if (dea.MESINICIO != null && dea.MESINICIO != "")
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear(dea.MESINICIO, dea.ANOINICIO);
                        else
                            ativProf.DataInicioAtividadeProfissional = (DateTime)Utils.ParseMonthAndYear("01", dea.ANOINICIO);

                        if (dea.MESFIM != null && dea.MESFIM != "")
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear(dea.MESFIM, dea.ANOFIM);
                        else
                            ativProf.DataTerminoAtividadeProfissional = Utils.ParseMonthAndYear("12", dea.ANOFIM);

                        ativProf.InformacoesAdicionaisAtividadeProfissional = String.Format("Cargo Ou Função: {0}",
                                                                                TraduzirCargoOuFuncao(dea.FORMATOCARGOOUFUNCAO.ToString(),
                                                                                                      dea.CARGOOUFUNCAO));

                        professor.AtividadeProfissional.Add(ativProf);
                    }
                }

                if (ap.VINCULOS != null)
                {
                    foreach (VINCULOS v in ap.VINCULOS)
                    {

                        if (v.ANOINICIO == "" || v.ANOINICIO == null)
                        {
                            lock (logLocker)
                            {
                                Logger.Error(String.Format("O vínculo profissional do Professor {1} - {2} com a empresa \"{0}\" não possui Ano de Início, somente serão considerados vínculos com Ano de Início",
                                                                        ie.NomeInstituicaoEmpresa, professor.NumeroCurriculo, professor.NomeProfessor));
                            }
                        }
                        else
                        {
                            vinculo = LattesDatabase.VinculoAtuacaoProfissional.Create();
                            vinculo.InstituicaoEmpresa = ie;
                            vinculo.SequenciaVinculoAtuacaoProfissional = sequenciaVinculo++;
                            vinculo.SequenciaImportanciaVinculoAtuacaoProfissional = (int)Utils.ParseIntegerOrNull(ap.SEQUENCIAIMPORTANCIA);

                            if (v.MESINICIO == null || v.MESINICIO == "")
                                vinculo.DataInicioVinculoAtuacaoProfissional = (DateTime)Utils.ParseMonthAndYear("01", v.ANOINICIO);
                            else
                                vinculo.DataInicioVinculoAtuacaoProfissional = (DateTime)Utils.ParseMonthAndYear(v.MESINICIO, v.ANOINICIO);

                            if (v.MESFIM == null || v.MESFIM == "")
                                vinculo.DataTerminoVinculoAtuacaoProfissional = Utils.ParseMonthAndYear("01", v.ANOFIM);
                            else
                                vinculo.DataTerminoVinculoAtuacaoProfissional = Utils.ParseMonthAndYear(v.MESFIM, v.ANOFIM);

                            if (v.ENQUADRAMENTOFUNCIONAL == VINCULOSENQUADRAMENTOFUNCIONAL.OUTRO)
                            {
                                vinculo.EnquadramentoFuncionalVinculoAtuacaoProfissional = v.OUTROENQUADRAMENTOFUNCIONALINFORMADO;
                            }
                            else
                            {
                                if (v.ENQUADRAMENTOFUNCIONAL == VINCULOSENQUADRAMENTOFUNCIONAL.PROFESSOR_TITULAR)
                                    vinculo.EnquadramentoFuncionalVinculoAtuacaoProfissional = "Professor Titular";
                                else
                                    vinculo.EnquadramentoFuncionalVinculoAtuacaoProfissional = "Livre";
                            }

                            if (v.TIPODEVINCULO == VINCULOSTIPODEVINCULO.OUTRO)
                                vinculo.TipoVinculoVinculoAtuacaoProfissional = v.OUTROVINCULOINFORMADO;
                            else
                                vinculo.TipoVinculoVinculoAtuacaoProfissional = TraduzirTipoVinculo(v.TIPODEVINCULO.ToString());

                            vinculo.DescricaoVinculoAtuacaoProfissional = v.OUTRASINFORMACOES;

                            professor.VinculoAtuacaoProfissional.Add(vinculo);
                        }
                    }
                }
            }
        }

        private Projeto GetProjeto(InstituicaoEmpresa instEmp, OrgaoInstituicaoEmpresa orgao, UnidadeInstituicaoEmpresa unid, int anoInicio, String nomeProjeto)
        {
            lock (saveLocker)
            {
                var projeto = LattesDatabase.Projeto.FirstOrDefault(
                               p => p.InstituicaoEmpresa.InstituicaoEmpresaId == instEmp.InstituicaoEmpresaId
                               && p.OrgaoInstituicaoEmpresa.OrgaoInstituicaoEmpresaId == orgao.OrgaoInstituicaoEmpresaId
                               && p.UnidadeInstituicaoEmpresa.UnidadeInstituicaoEmpresaId == unid.UnidadeInstituicaoEmpresaId
                               && p.AnoInicioProjeto == anoInicio
                               && p.NomeProjeto == nomeProjeto);

                if (projeto == null)
                {
                    projeto = LattesDatabase.Projeto.Create();

                    projeto.InstituicaoEmpresa = instEmp;
                    projeto.OrgaoInstituicaoEmpresa = orgao;
                    projeto.UnidadeInstituicaoEmpresa = unid;
                    projeto.NomeProjeto = nomeProjeto;
                    projeto.AnoInicioProjeto = anoInicio;
                    projeto.SituacaoProjeto = "";
                    projeto.NaturezaProjeto = "";

                    LattesDatabase.Projeto.Add(projeto);
                    LattesDatabase.SaveChanges();
                }

                return projeto;
            }
        }

        private void ComplementarProjeto(Projeto projeto, decimal? anoTermino, string situacaoXml, string naturezaXml, bool? potencialInovacao, string nomeIngles, string descricao, string descricaoIngles)
        {
            lock (saveLocker)
            {
                if (projeto.AnoFimProjeto == null)
                    projeto.AnoFimProjeto = anoTermino;

                if (projeto.NomeEmInglesProjeto == null || projeto.NomeEmInglesProjeto == "")
                    projeto.NomeEmInglesProjeto = nomeIngles;

                if (projeto.InformacoesAdicionaisProjeto == null || projeto.InformacoesAdicionaisProjeto == "")
                    projeto.InformacoesAdicionaisProjeto = descricao;

                if (projeto.InformacoesAdicionaisEmInglesProjeto == null || projeto.InformacoesAdicionaisEmInglesProjeto == "")
                    projeto.InformacoesAdicionaisEmInglesProjeto = descricaoIngles;

                if (projeto.PotencialInovacao == null || projeto.PotencialInovacao == false)
                    projeto.PotencialInovacao = potencialInovacao;

                if (projeto.NaturezaProjeto == "" || projeto.NaturezaProjeto == _NAO_INFORMADO)
                {
                    switch (naturezaXml)
                    {
                        case "DESENVOLVIMENTO":
                            projeto.NaturezaProjeto = "Desenvolvimento";
                            break;
                        case "EXTENSAO":
                            projeto.NaturezaProjeto = "Extensão";
                            break;
                        case "PESQUISA":
                            projeto.NaturezaProjeto = "Pesquisa";
                            break;
                        case "OUTRA":
                            projeto.NaturezaProjeto = "Outra";
                            break;
                        default:
                            projeto.NaturezaProjeto = _NAO_INFORMADO;
                            break;
                    }
                }

                String situacao = TraduzirSituacao(situacaoXml);

                if (projeto.SituacaoProjeto == "" || projeto.SituacaoProjeto == _NAO_INFORMADO)
                    projeto.SituacaoProjeto = situacao;
                else
                {
                    if (situacao != _NAO_INFORMADO)
                    {
                        if (projeto.SituacaoProjeto == _SIT_EM_ANDAMENTO
                            && situacao != _SIT_EM_ANDAMENTO)
                            projeto.SituacaoProjeto = situacao;
                        else
                        {
                            if (situacao != _SIT_EM_ANDAMENTO)
                            {
                                if (projeto.SituacaoProjeto != _SIT_DESATIVADO)
                                    projeto.SituacaoProjeto = situacao;
                            }
                        }
                    }
                }
                LattesDatabase.SaveChanges();
            }
        }

        private int ProcessarLinhasDePesquisa(Professor professor, int sequencia, LINHADEPESQUISA[] linhasXml)
        {
            LinhaDePesquisa linhaPesquisa = null;

            if (linhasXml != null)
            {
                foreach (LINHADEPESQUISA lpXml in linhasXml)
                {
                    foreach (PalavraChave pc in ExtrairPalavrasChave(lpXml.PALAVRASCHAVE, lpXml.SETORESDEATIVIDADE))
                    {
                        linhaPesquisa = LattesDatabase.LinhaDePesquisa.Create();

                        linhaPesquisa.AtivaLinhaDePesquisa = TraduzirFlags(lpXml.FLAGLINHADEPESQUISAATIVA.ToString());
                        linhaPesquisa.TituloLinhaDePesquisa = lpXml.TITULODALINHADEPESQUISA;
                        linhaPesquisa.ObjetivosLinhaDePesquisa = lpXml.OBJETIVOSLINHADEPESQUISA;
                        linhaPesquisa.PalavraChave = pc;
                    }

                    foreach (AreaConhecimento ac in ExtrairAreasConhecimento(lpXml.AREASDOCONHECIMENTO))
                    {
                        IncluirAreaAtuacao(ac, professor);
                    }

                    professor.LinhaDePesquisa.Add(linhaPesquisa);
                }
            }

            return sequencia;
        }

        private void IncluirAreaAtuacao(AreaConhecimento ac, Professor professor)
        {
            AreaAtuacao aa = professor.AreaAtuacao.FirstOrDefault(
                area => area.GrandeAreaAtuacao == ac.GrandeAreaConhecimento
                && area.NomeAreaAtuacao == ac.NomeAreaConhecimento
                && area.SubAreaAtuacao == ac.SubAreaConhecimento
                && area.Especialidade == ac.Especialidade);

            if (aa == null)
            {
                aa = LattesDatabase.AreaAtuacao.Create();
                aa.GrandeAreaAtuacao = ac.GrandeAreaConhecimento;
                aa.NomeAreaAtuacao = ac.NomeAreaConhecimento;
                aa.SubAreaAtuacao = ac.SubAreaConhecimento;
                aa.Especialidade = ac.Especialidade;
                aa.TermoCompleto = ac.TermoCompleto;

                professor.AreaAtuacao.Add(aa);
            }

        }

        /// <summary>
        /// Processa as Areas de Conhecimento do Professor
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="cvXml"></param>
        private void ProcessarAreasAtuacaoProfessor(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.DADOSGERAIS.AREASDEATUACAO != null)
            {
                foreach (var area in cvXml.DADOSGERAIS.AREASDEATUACAO)
                {
                    IncluirAreaAtuacao(GetAreaConhecimento(area.NOMEGRANDEAREADOCONHECIMENTO.ToString(),
                                                           area.NOMEDAAREADOCONHECIMENTO,
                                                           area.NOMEDASUBAREADOCONHECIMENTO,
                                                           area.NOMEDAESPECIALIDADE),
                                       professor);
                }
            }
        }

        /// <summary>
        /// Processa as Formações Acadêmicas, Titulações e Complementares do Professor existentes no XML
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="cvXml"></param>
        private void ProcessarFormacaoAcademicaETitulacao(Professor professor, CurriculoVitaeXml cvXml)
        {
            FormacaoAcademicaTitulacao fat = null;
            int sequencia = 1;

            if (cvXml.DADOSGERAIS.FORMACAOACADEMICATITULACAO != null)
            {
                FORMACAOACADEMICATITULACAO fatXml = cvXml.DADOSGERAIS.FORMACAOACADEMICATITULACAO;

                if (fatXml.ENSINOFUNDAMENTALPRIMEIROGRAU != null)
                {
                    foreach (ENSINOFUNDAMENTALPRIMEIROGRAU fundamental in fatXml.ENSINOFUNDAMENTALPRIMEIROGRAU)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_ENSINO_FUNDAMENTAL;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(fundamental.CODIGOINSTITUICAO, fundamental.NOMEINSTITUICAO);
                        fat.Curso = GetCurso(fat.InstituicaoEmpresa, "", _NIVEL_FAT_ENSINO_FUNDAMENTAL, _NIVEL_FAT_ENSINO_FUNDAMENTAL);

                        fat.TituloTrabalhoFinal = _NIVEL_FAT_ENSINO_FUNDAMENTAL;
                        fat.TituloTrabalhoFinalEmIngles = fat.TituloTrabalhoFinal;
                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(fundamental.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(fundamental.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(fundamental.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;

                        // relacionar com não possui
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresaNaoPossui(fat.InstituicaoEmpresa);
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.Orientador = GetOrientadorNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.AgenciaFinanciadora = GetAgenciaFinanciadoraNaoPossui();
                        fat.TemBolsaFormacaoAcademicaTitulacao = false;
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;
                        fat.CodigoAreaCurso = _NAO_POSSUI;
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;

                        fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                        fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.ENSINOMEDIOSEGUNDOGRAU != null)
                {
                    foreach (ENSINOMEDIOSEGUNDOGRAU medio in fatXml.ENSINOMEDIOSEGUNDOGRAU)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_ENSINO_MEDIO;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(medio.CODIGOINSTITUICAO, medio.NOMEINSTITUICAO);
                        fat.Curso = GetCurso(fat.InstituicaoEmpresa, "", _NIVEL_FAT_ENSINO_MEDIO, _NIVEL_FAT_ENSINO_MEDIO);

                        fat.TituloTrabalhoFinal = _NIVEL_FAT_ENSINO_MEDIO;
                        fat.TituloTrabalhoFinalEmIngles = fat.TituloTrabalhoFinal;
                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(medio.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(medio.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(medio.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;

                        // relacionar com não possui
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresaNaoPossui(fat.InstituicaoEmpresa);
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.Orientador = GetOrientadorNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.AgenciaFinanciadora = GetAgenciaFinanciadoraNaoPossui();
                        fat.TemBolsaFormacaoAcademicaTitulacao = false;
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;
                        fat.CodigoAreaCurso = _NAO_POSSUI;
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;

                        fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                        fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.CURSOTECNICOPROFISSIONALIZANTE != null)
                {
                    foreach (CURSOTECNICOPROFISSIONALIZANTE tecnico in fatXml.CURSOTECNICOPROFISSIONALIZANTE)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_TECNICO_PROFISSIONALIZANTE;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(tecnico.CODIGOINSTITUICAO, tecnico.NOMEINSTITUICAO);
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                 tecnico.NOMEORGAO);
                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             tecnico.CODIGOCURSO,
                                             tecnico.NOMECURSO,
                                             _NIVEL_FAT_TECNICO_PROFISSIONALIZANTE);
                        ComplementarCurso(fat.Curso, "", tecnico.NOMECURSOINGLES);

                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(tecnico.CODIGOAGENCIAFINANCIADORA,
                                                                         tecnico.NOMEAGENCIA);

                        fat.TituloTrabalhoFinal = _NIVEL_FAT_TECNICO_PROFISSIONALIZANTE;
                        fat.TituloTrabalhoFinalEmIngles = fat.TituloTrabalhoFinal;
                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(tecnico.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(tecnico.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(tecnico.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(tecnico.FLAGBOLSA);

                        // relacionar com não possui
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.Orientador = GetOrientadorNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;
                        fat.CodigoAreaCurso = _NAO_POSSUI;
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;

                        fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                        fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.APERFEICOAMENTO != null)
                {
                    foreach (APERFEICOAMENTO aperfeicoamento in fatXml.APERFEICOAMENTO)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_APERFEICOAMENTO;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(aperfeicoamento.CODIGOINSTITUICAO, aperfeicoamento.NOMEINSTITUICAO);
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                 aperfeicoamento.NOMEORGAO);
                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             aperfeicoamento.CODIGOCURSO,
                                             aperfeicoamento.NOMECURSO,
                                             _NIVEL_FAT_APERFEICOAMENTO);
                        ComplementarCurso(fat.Curso, "", aperfeicoamento.NOMECURSOINGLES);

                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(aperfeicoamento.CODIGOAGENCIAFINANCIADORA,
                                                                         aperfeicoamento.NOMEAGENCIA);

                        fat.TituloTrabalhoFinal = aperfeicoamento.TITULODAMONOGRAFIA;
                        fat.TituloTrabalhoFinalEmIngles = aperfeicoamento.TITULODAMONOGRAFIAINGLES;
                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);

                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(aperfeicoamento.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(aperfeicoamento.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(aperfeicoamento.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(aperfeicoamento.FLAGBOLSA);
                        fat.CodigoAreaCurso = aperfeicoamento.CODIGOAREACURSO;

                        if (aperfeicoamento.CARGAHORARIA != "")
                            fat.CargaHorariaFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(aperfeicoamento.CARGAHORARIA);
                        else
                            fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        // relacionar com não possui
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.Orientador = GetOrientadorNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;

                        fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                        fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.GRADUACAO != null)
                {
                    foreach (GRADUACAO graduacao in fatXml.GRADUACAO)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_GRADUACAO;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(graduacao.CODIGOINSTITUICAO,
                                                                            graduacao.NOMEINSTITUICAO);

                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                 graduacao.NOMEORGAO);

                        fat.TituloTrabalhoFinal = graduacao.TITULODOTRABALHODECONCLUSAODECURSO;
                        fat.TituloTrabalhoFinalEmIngles = graduacao.TITULODOTRABALHODECONCLUSAODECURSOINGLES;

                        if (fat.TituloTrabalhoFinal == null)
                            fat.TituloTrabalhoFinal = _NAO_INFORMADO;

                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);
                        fat.TipoGraduacaoDoutorado = TraduzirTipoGraduacaoDoutorado(graduacao.TIPOGRADUACAO);

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             graduacao.CODIGOCURSO,
                                             graduacao.NOMECURSO,
                                             _NIVEL_FAT_GRADUACAO);

                        ComplementarCurso(fat.Curso, graduacao.CODIGOCURSOCAPES, graduacao.NOMECURSOINGLES);

                        fat.Orientador = GetOrientador(graduacao.NUMEROIDORIENTADOR,
                                                        graduacao.NOMEDOORIENTADOR);

                        if (fat.TipoGraduacaoDoutorado != _TIPO_GD_NORMAL)
                        {
                            fat.InstituicaoEmpresaSanduiche = this.GetInstituicaoEmpresa(graduacao.CODIGOINSTITUICAOGRAD,
                                                                                         graduacao.NOMEINSTITUICAOGRAD);
                            fat.OrientadorSanduiche = GetOrientador("",
                                                                    graduacao.NOMEORIENTADORGRAD);
                        }

                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(graduacao.CODIGOAGENCIAFINANCIADORA,
                                                                         graduacao.NOMEAGENCIA);

                        fat.CodigoAreaCurso = graduacao.CODIGOAREACURSO;
                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(graduacao.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(graduacao.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(graduacao.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(graduacao.FLAGBOLSA);

                        // relacionar com não possui
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                        fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.ESPECIALIZACAO != null)
                {
                    foreach (ESPECIALIZACAO espec in fatXml.ESPECIALIZACAO)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_ESPECIALIZACAO;

                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(espec.CODIGOINSTITUICAO,
                                                                            espec.NOMEINSTITUICAO);
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                 espec.NOMEORGAO);

                        fat.TituloTrabalhoFinal = espec.TITULODAMONOGRAFIA;
                        fat.TituloTrabalhoFinalEmIngles = espec.TITULODAMONOGRAFIAINGLES;
                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             espec.CODIGOCURSO,
                                             espec.NOMECURSO,
                                             _NIVEL_FAT_ESPECIALIZACAO);
                        ComplementarCurso(fat.Curso, "", espec.NOMECURSOINGLES);

                        fat.Orientador = GetOrientador("",
                                                       espec.NOMEDOORIENTADOR);

                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(espec.CODIGOAGENCIAFINANCIADORA,
                                                                         espec.NOMEAGENCIA);

                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(espec.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(espec.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(espec.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(espec.FLAGBOLSA);

                        if (espec.CARGAHORARIA != "")
                            fat.CargaHorariaFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(espec.CARGAHORARIA);
                        else
                            fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        // relacionar com não possui
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                        fat.CodigoAreaCurso = _NAO_POSSUI;
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();

                        fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                        fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.MESTRADOPROFISSIONALIZANTE != null)
                {
                    foreach (MESTRADOPROFISSIONALIZANTE mestradoProf in fatXml.MESTRADOPROFISSIONALIZANTE)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_MESTRADO;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(mestradoProf.CODIGOINSTITUICAO,
                                                                            mestradoProf.NOMEINSTITUICAO);
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                 mestradoProf.NOMEORGAO);

                        fat.TituloTrabalhoFinal = mestradoProf.TITULODADISSERTACAOTESE;
                        fat.TituloTrabalhoFinalEmIngles = mestradoProf.TITULODADISSERTACAOTESEINGLES;
                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             mestradoProf.CODIGOCURSO,
                                             mestradoProf.NOMECURSO,
                                             _NIVEL_FAT_MESTRADO);

                        ComplementarCurso(fat.Curso, mestradoProf.CODIGOCURSOCAPES, mestradoProf.NOMECURSOINGLES);

                        fat.Orientador = GetOrientador(mestradoProf.NUMEROIDORIENTADOR,
                                                        mestradoProf.NOMECOMPLETODOORIENTADOR);

                        fat.CoOrientador = GetOrientador("",
                                                         mestradoProf.NOMEDOCOORIENTADOR);

                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(mestradoProf.CODIGOAGENCIAFINANCIADORA,
                                                                         mestradoProf.NOMEAGENCIA);

                        fat.CodigoAreaCurso = mestradoProf.CODIGOAREACURSO;
                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(mestradoProf.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(mestradoProf.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(mestradoProf.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(mestradoProf.ANODEOBTENCAODOTITULO);
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(mestradoProf.FLAGBOLSA);

                        foreach (PalavraChave palavraChave in ExtrairPalavrasChave(mestradoProf.PALAVRASCHAVE, mestradoProf.SETORESDEATIVIDADE))
                            fat.PalavraChave.Add(palavraChave);

                        foreach (AreaConhecimento area in ExtrairAreasConhecimento(mestradoProf.AREASDOCONHECIMENTO))
                            fat.AreaConhecimento.Add(area);

                        // relacionar com não possui
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.MESTRADO != null)
                {
                    foreach (MESTRADO mestrado in fatXml.MESTRADO)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_MESTRADO;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(mestrado.CODIGOINSTITUICAO,
                                                                            mestrado.NOMEINSTITUICAO);
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                 mestrado.NOMEORGAO);

                        fat.TituloTrabalhoFinal = mestrado.TITULODADISSERTACAOTESE;
                        fat.TituloTrabalhoFinalEmIngles = mestrado.TITULODADISSERTACAOTESEINGLES;
                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);
                        fat.TipoGraduacaoDoutorado = TraduzirTipoGraduacaoDoutorado(mestrado.TIPOMESTRADO);

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             mestrado.CODIGOCURSO,
                                             mestrado.NOMECURSO,
                                             _NIVEL_FAT_MESTRADO);

                        ComplementarCurso(fat.Curso, mestrado.CODIGOCURSOCAPES, mestrado.NOMECURSOINGLES);

                        fat.Orientador = GetOrientador(mestrado.NUMEROIDORIENTADOR,
                                                        mestrado.NOMECOMPLETODOORIENTADOR);

                        fat.CoOrientador = GetOrientador("",
                                                         mestrado.NOMEDOCOORIENTADOR);

                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(mestrado.CODIGOAGENCIAFINANCIADORA,
                                                                         mestrado.NOMEAGENCIA);

                        if (fat.TipoGraduacaoDoutorado == _TIPO_GD_SANDUICHE)
                        {
                            // na tela de cadastro v informação da "Sanduíche" é gravado no "Doutorado"
                            fat.InstituicaoEmpresaSanduiche = this.GetInstituicaoEmpresa(mestrado.CODIGOINSTITUICAODOUT,
                                                                                            mestrado.NOMEINSTITUICAODOUT);
                            fat.OrientadorSanduiche = GetOrientador("",
                                                                    mestrado.NOMEORIENTADORDOUT);
                            fat.InstituicaoEmpresaOutraSanduiche = this.GetInstituicaoEmpresa(mestrado.CODIGOINSTITUICAOOUTRADOUT,
                                                                                              mestrado.NOMEINSTITUICAOOUTRADOUT);
                        }
                        else
                        {
                            fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        }

                        foreach (PalavraChave palavraChave in ExtrairPalavrasChave(mestrado.PALAVRASCHAVE, mestrado.SETORESDEATIVIDADE))
                            fat.PalavraChave.Add(palavraChave);

                        foreach (AreaConhecimento area in ExtrairAreasConhecimento(mestrado.AREASDOCONHECIMENTO))
                            fat.AreaConhecimento.Add(area);

                        fat.CodigoAreaCurso = mestrado.CODIGOAREACURSO;
                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(mestrado.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(mestrado.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(mestrado.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(mestrado.ANODEOBTENCAODOTITULO);
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(mestrado.FLAGBOLSA);

                        // relacionar com não possui
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.RESIDENCIAMEDICA != null)
                {
                    foreach (RESIDENCIAMEDICA residenciaMedica in fatXml.RESIDENCIAMEDICA)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_RESIDENCIA_MEDICA;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(residenciaMedica.CODIGOINSTITUICAO,
                                                                            residenciaMedica.NOMEINSTITUICAO);

                        fat.TituloTrabalhoFinal = residenciaMedica.TITULODARESIDENCIAMEDICA;
                        fat.TituloTrabalhoFinalEmIngles = residenciaMedica.TITULODARESIDENCIAMEDICAINGLES;
                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             "",
                                             _NIVEL_FAT_RESIDENCIA_MEDICA,
                                             _NIVEL_FAT_RESIDENCIA_MEDICA);
                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(residenciaMedica.CODIGOAGENCIAFINANCIADORA,
                                                                         residenciaMedica.NOMEAGENCIA);

                        fat.SituacaoFormacaoAcademicaTitulacao = _SIT_CONCLUIDO;
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(residenciaMedica.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(residenciaMedica.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;

                        foreach (PalavraChave palavraChave in ExtrairPalavrasChave(residenciaMedica.PALAVRASCHAVE, residenciaMedica.SETORESDEATIVIDADE))
                            fat.PalavraChave.Add(palavraChave);

                        foreach (AreaConhecimento area in ExtrairAreasConhecimento(residenciaMedica.AREASDOCONHECIMENTO))
                            fat.AreaConhecimento.Add(area);

                        // relacionar com não possui
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                        fat.CodigoAreaCurso = _NAO_POSSUI;
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.Orientador = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresaNaoPossui(fat.InstituicaoEmpresa);
                        fat.TemBolsaFormacaoAcademicaTitulacao = false;
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.DOUTORADO != null)
                {
                    foreach (DOUTORADO doutorado in fatXml.DOUTORADO)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_DOUTORADO;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(doutorado.CODIGOINSTITUICAO,
                                                                            doutorado.NOMEINSTITUICAO);
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                 doutorado.NOMEORGAO);

                        fat.TituloTrabalhoFinal = doutorado.TITULODADISSERTACAOTESE;
                        fat.TituloTrabalhoFinalEmIngles = doutorado.TITULODADISSERTACAOTESEINGLES;
                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);
                        fat.TipoGraduacaoDoutorado = TraduzirTipoGraduacaoDoutorado(doutorado.TIPODOUTORADO);

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             doutorado.CODIGOCURSO,
                                             doutorado.NOMECURSO,
                                             _NIVEL_FAT_DOUTORADO);

                        ComplementarCurso(fat.Curso, doutorado.CODIGOCURSOCAPES, doutorado.NOMECURSOINGLES);

                        fat.Orientador = GetOrientador(doutorado.NUMEROIDORIENTADOR,
                                                        doutorado.NOMECOMPLETODOORIENTADOR);
                        fat.CoOrientador = GetOrientador("",
                                                         doutorado.NOMEDOCOORIENTADOR);

                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(doutorado.CODIGOAGENCIAFINANCIADORA,
                                                                         doutorado.NOMEAGENCIA);

                        if (fat.TipoGraduacaoDoutorado != _TIPO_GD_NORMAL)
                        {
                            switch (fat.TipoGraduacaoDoutorado)
                            {
                                case _TIPO_GD_COTUTELA:
                                    // na tela de cadastro v informação da "Co-Tutela" é gravado no "Doutorado"
                                    fat.InstituicaoEmpresaCoTutela = this.GetInstituicaoEmpresa(doutorado.CODIGOINSTITUICAODOUT,
                                                                                                doutorado.NOMEINSTITUICAODOUT);
                                    fat.OrientadorCoTutela = GetOrientador("",
                                                                           doutorado.NOMEORIENTADORDOUT);
                                    fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                                    fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                                    fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                                    break;
                                case _TIPO_GD_SANDUICHE:
                                    // na tela de cadastro v informação da "Sanduíche" é gravado no "Doutorado"
                                    fat.InstituicaoEmpresaSanduiche = this.GetInstituicaoEmpresa(doutorado.CODIGOINSTITUICAODOUT,
                                                                                                 doutorado.NOMEINSTITUICAODOUT);
                                    fat.OrientadorSanduiche = GetOrientador("",
                                                                            doutorado.NOMEORIENTADORDOUT);
                                    fat.InstituicaoEmpresaOutraSanduiche = this.GetInstituicaoEmpresa(doutorado.CODIGOINSTITUICAOOUTRADOUT,
                                                                                                      doutorado.NOMEINSTITUICAOOUTRADOUT);
                                    fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                                    fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                                    break;
                                default:
                                    // co tutela
                                    fat.InstituicaoEmpresaCoTutela = this.GetInstituicaoEmpresa(doutorado.CODIGOINSTITUICAOCOTUTELA,
                                                                                                "");
                                    fat.OrientadorCoTutela = GetOrientador("",
                                                                           doutorado.NOMEDOORIENTADORCOTUTELA);
                                    // sanduiche
                                    fat.InstituicaoEmpresaSanduiche = this.GetInstituicaoEmpresa(doutorado.CODIGOINSTITUICAOSANDUICHE,
                                                                                                 "");
                                    fat.OrientadorSanduiche = GetOrientador("",
                                                                            doutorado.NOMEDOORIENTADORSANDUICHE);
                                    fat.InstituicaoEmpresaOutraSanduiche = this.GetInstituicaoEmpresa(doutorado.CODIGOINSTITUICAOOUTRADOUT,
                                                                                                      doutorado.NOMEINSTITUICAOOUTRADOUT);
                                    break;
                            }
                        }

                        fat.CodigoAreaCurso = doutorado.CODIGOAREACURSO;
                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(doutorado.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(doutorado.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(doutorado.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(doutorado.ANODEOBTENCAODOTITULO);
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(doutorado.FLAGBOLSA);

                        foreach (PalavraChave palavraChave in ExtrairPalavrasChave(doutorado.PALAVRASCHAVE, doutorado.SETORESDEATIVIDADE))
                            fat.PalavraChave.Add(palavraChave);

                        foreach (AreaConhecimento area in ExtrairAreasConhecimento(doutorado.AREASDOCONHECIMENTO))
                            fat.AreaConhecimento.Add(area);

                        // relacionar com não possui
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.POSDOUTORADO != null)
                {
                    foreach (POSDOUTORADO posDoutorado in fatXml.POSDOUTORADO)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_POS_DOUTORADO;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(posDoutorado.CODIGOINSTITUICAO,
                                                                            posDoutorado.NOMEINSTITUICAO);


                        fat.TituloTrabalhoFinal = _NIVEL_FAT_POS_DOUTORADO;
                        fat.TituloTrabalhoFinalEmIngles = _NIVEL_FAT_POS_DOUTORADO;

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             "",
                                             _NIVEL_FAT_POS_DOUTORADO,
                                             _NIVEL_FAT_POS_DOUTORADO);

                        fat.Orientador = GetOrientador(posDoutorado.NUMEROIDORIENTADOR,
                                                       "");


                        fat.AgenciaFinanciadora = GetAgenciaFinanciadora(posDoutorado.CODIGOAGENCIAFINANCIADORA,
                                                                         posDoutorado.NOMEAGENCIA);

                        fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(posDoutorado.STATUSDOCURSO.ToString());
                        fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(posDoutorado.ANODEINICIO);
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(posDoutorado.ANODECONCLUSAO);
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(posDoutorado.ANODEOBTENCAODOTITULO);
                        fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(posDoutorado.FLAGBOLSA);

                        foreach (PalavraChave palavraChave in ExtrairPalavrasChave(posDoutorado.PALAVRASCHAVE, posDoutorado.SETORESDEATIVIDADE))
                            fat.PalavraChave.Add(palavraChave);

                        foreach (AreaConhecimento area in ExtrairAreasConhecimento(posDoutorado.AREASDOCONHECIMENTO))
                            fat.AreaConhecimento.Add(area);

                        // relacionar com não possui
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                        fat.CodigoAreaCurso = _NAO_POSSUI;
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresaNaoPossui(fat.InstituicaoEmpresa);
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }

                if (fatXml.LIVREDOCENCIA != null)
                {
                    foreach (LIVREDOCENCIA livreDocencia in fatXml.LIVREDOCENCIA)
                    {
                        fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                        fat.Professor = professor;
                        fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                        fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_LIVRE_DOCENCIA;
                        fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(livreDocencia.CODIGOINSTITUICAO,
                                                                            livreDocencia.NOMEINSTITUICAO);

                        fat.TituloTrabalhoFinal = livreDocencia.TITULODOTRABALHO;
                        fat.TituloTrabalhoFinalEmIngles = livreDocencia.TITULODOTRABALHOINGLES;
                        fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);

                        fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                             "",
                                             _NIVEL_FAT_LIVRE_DOCENCIA,
                                             _NIVEL_FAT_LIVRE_DOCENCIA);

                        fat.SituacaoFormacaoAcademicaTitulacao = _SIT_CONCLUIDO;
                        fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(livreDocencia.ANODEOBTENCAODOTITULO);
                        fat.AnoInicioFormacaoAcademicaTitulacao = (decimal)fat.AnoObtencaoTituloFormacaoAcademicaTitulacao;
                        fat.AnoConclusaoFormacaoAcademicaTitulacao = fat.AnoObtencaoTituloFormacaoAcademicaTitulacao;

                        foreach (PalavraChave palavraChave in ExtrairPalavrasChave(livreDocencia.PALAVRASCHAVE, livreDocencia.SETORESDEATIVIDADE))
                            fat.PalavraChave.Add(palavraChave);

                        foreach (AreaConhecimento area in ExtrairAreasConhecimento(livreDocencia.AREASDOCONHECIMENTO))
                            fat.AreaConhecimento.Add(area);

                        // relacionar com não possui
                        fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                        fat.CodigoAreaCurso = _NAO_POSSUI;
                        fat.AgenciaFinanciadora = GetAgenciaFinanciadoraNaoPossui();
                        fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                        fat.Orientador = GetOrientadorNaoPossui();
                        fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                        fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                        fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                        fat.CoOrientador = GetOrientadorNaoPossui();
                        fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresaNaoPossui(fat.InstituicaoEmpresa);
                        fat.TemBolsaFormacaoAcademicaTitulacao = false;
                        fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                        professor.FormacaoAcademicaTitulacao.Add(fat);
                    }
                }
            }

            if (cvXml.DADOSCOMPLEMENTARES.FORMACAOCOMPLEMENTAR != null)
            {
                // na definição esta como vetor, por tal motivo ie foreach
                foreach (FORMACAOCOMPLEMENTAR fc in cvXml.DADOSCOMPLEMENTARES.FORMACAOCOMPLEMENTAR)
                {
                    if (fc.MBA != null)
                    {
                        foreach (MBA mba in fc.MBA)
                        {
                            fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                            fat.Professor = professor;
                            fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                            fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_MBA;
                            fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(mba.CODIGOINSTITUICAO,
                                                                                mba.NOMEINSTITUICAO);
                            fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                     mba.NOMEORGAO);

                            fat.TituloTrabalhoFinal = mba.TITULODAMONOGRAFIA;
                            fat.TituloTrabalhoFinalEmIngles = mba.TITULODAMONOGRAFIA;
                            fat.TituloTrabalhoFinalEmIngles =
                            (fat.TituloTrabalhoFinalEmIngles == null || fat.TituloTrabalhoFinalEmIngles == "" ?
                                fat.TituloTrabalhoFinal : fat.TituloTrabalhoFinalEmIngles);

                            fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                                 mba.CODIGOCURSO,
                                                 mba.NOMECURSO,
                                                 _NIVEL_FAT_MBA);
                            ComplementarCurso(fat.Curso, "", mba.NOMECURSOINGLES);

                            fat.Orientador = GetOrientador("", mba.NOMECOMPLETODOORIENTADOR);

                            fat.AgenciaFinanciadora = GetAgenciaFinanciadora(mba.CODIGOAGENCIAFINANCIADORA,
                                                                             mba.NOMEAGENCIA);

                            fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(mba.STATUSDOCURSO.ToString());
                            fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(mba.ANODEINICIO);
                            fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(mba.ANODECONCLUSAO);
                            fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(mba.ANODEOBTENCAODOTITULO);
                            fat.TemBolsaFormacaoAcademicaTitulacao = TraduzirFlags(mba.FLAGBOLSA);

                            if (mba.CARGAHORARIA != "")
                                fat.CargaHorariaFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(mba.CARGAHORARIA);
                            else
                                fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                            foreach (PalavraChave palavraChave in ExtrairPalavrasChave(mba.PALAVRASCHAVE, mba.SETORESDEATIVIDADE))
                                fat.PalavraChave.Add(palavraChave);

                            foreach (AreaConhecimento area in ExtrairAreasConhecimento(mba.AREASDOCONHECIMENTO))
                                fat.AreaConhecimento.Add(area);

                            // relacionar com não possui
                            fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                            fat.CodigoAreaCurso = _NAO_POSSUI;
                            fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                            fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                            fat.CoOrientador = GetOrientadorNaoPossui();

                            professor.FormacaoAcademicaTitulacao.Add(fat);
                        }
                    }

                    if (fc.FORMACAOCOMPLEMENTARDEEXTENSAOUNIVERSITARIA != null)
                    {
                        foreach (FORMACAOCOMPLEMENTARDEEXTENSAOUNIVERSITARIA fceu in fc.FORMACAOCOMPLEMENTARDEEXTENSAOUNIVERSITARIA)
                        {
                            fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                            fat.Professor = professor;
                            fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                            fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_FCEU;
                            fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(fceu.CODIGOINSTITUICAO,
                                                                                fceu.NOMEINSTITUICAO);
                            fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                     fceu.NOMEORGAO);

                            fat.TituloTrabalhoFinal = _NIVEL_FAT_FCEU;
                            fat.TituloTrabalhoFinalEmIngles = _NIVEL_FAT_FCEU;

                            fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                                 fceu.CODIGOCURSO,
                                                 fceu.NOMECURSO,
                                                 _NIVEL_FAT_FCEU);
                            ComplementarCurso(fat.Curso, "", fceu.NOMECURSOINGLES);

                            fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(fceu.STATUSDOCURSO.ToString());
                            fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(fceu.ANODEINICIO);
                            fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(fceu.ANODECONCLUSAO);
                            fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;

                            if (fceu.CARGAHORARIA != "")
                                fat.CargaHorariaFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(fceu.CARGAHORARIA);
                            else
                                fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                            // relacionar com não possui
                            fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                            fat.CodigoAreaCurso = _NAO_POSSUI;
                            fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                            fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                            fat.Orientador = GetOrientadorNaoPossui();
                            fat.CoOrientador = GetOrientadorNaoPossui();
                            fat.AgenciaFinanciadora = GetAgenciaFinanciadoraNaoPossui();
                            fat.TemBolsaFormacaoAcademicaTitulacao = false;

                            fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                            fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                            professor.FormacaoAcademicaTitulacao.Add(fat);
                        }
                    }

                    if (fc.FORMACAOCOMPLEMENTARCURSODECURTADURACAO != null)
                    {
                        foreach (FORMACAOCOMPLEMENTARCURSODECURTADURACAO fcccd in fc.FORMACAOCOMPLEMENTARCURSODECURTADURACAO)
                        {
                            fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                            fat.Professor = professor;
                            fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                            fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_FCCCD;
                            fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(fcccd.CODIGOINSTITUICAO,
                                                                                fcccd.NOMEINSTITUICAO);
                            fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                     fcccd.NOMEORGAO);

                            fat.TituloTrabalhoFinal = _NIVEL_FAT_FCCCD;
                            fat.TituloTrabalhoFinalEmIngles = _NIVEL_FAT_FCCCD;

                            fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                                 fcccd.CODIGOCURSO,
                                                 fcccd.NOMECURSO,
                                                 _NIVEL_FAT_FCCCD);
                            ComplementarCurso(fat.Curso, "", fcccd.NOMECURSOINGLES);

                            fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(fcccd.STATUSDOCURSO.ToString());
                            fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(fcccd.ANODEINICIO);
                            fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(fcccd.ANODECONCLUSAO);
                            fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;

                            if (fcccd.CARGAHORARIA != "")
                                fat.CargaHorariaFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(fcccd.CARGAHORARIA);
                            else
                                fat.CargaHorariaFormacaoAcademicaTitulacao = 0;

                            // relacionar com não possui
                            fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                            fat.CodigoAreaCurso = _NAO_POSSUI;
                            fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                            fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                            fat.Orientador = GetOrientadorNaoPossui();
                            fat.CoOrientador = GetOrientadorNaoPossui();
                            fat.AgenciaFinanciadora = GetAgenciaFinanciadoraNaoPossui();
                            fat.TemBolsaFormacaoAcademicaTitulacao = false;

                            fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                            fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                            professor.FormacaoAcademicaTitulacao.Add(fat);
                        }
                    }

                    if (fc.OUTROS != null)
                    {
                        foreach (OUTROS outro in fc.OUTROS)
                        {
                            fat = LattesDatabase.FormacaoAcademicaTitulacao.Create();

                            fat.Professor = professor;
                            fat.SequenciaFormacaoAcademicaTitulacao = sequencia++;

                            fat.NivelFormacaoAcademicaTitulacao = _NIVEL_FAT_OUTROS;
                            fat.InstituicaoEmpresa = this.GetInstituicaoEmpresa(outro.CODIGOINSTITUICAO,
                                                                                outro.NOMEINSTITUICAO);
                            fat.OrgaoInstituicaoEmpresa = GetOrgaoInstituicaoEmpresa(fat.InstituicaoEmpresa,
                                                                                     outro.NOMEORGAO);

                            fat.TituloTrabalhoFinal = _NIVEL_FAT_OUTROS;
                            fat.TituloTrabalhoFinalEmIngles = _NIVEL_FAT_OUTROS;

                            fat.Curso = GetCurso(fat.InstituicaoEmpresa,
                                                 outro.CODIGOCURSO,
                                                 outro.NOMECURSO,
                                                 _NIVEL_FAT_OUTROS);
                            ComplementarCurso(fat.Curso, "", outro.NOMECURSOINGLES);

                            fat.SituacaoFormacaoAcademicaTitulacao = TraduzirSituacao(outro.STATUSDOCURSO.ToString());
                            fat.AnoInicioFormacaoAcademicaTitulacao = (int)Utils.ParseIntegerOrNull(outro.ANODEINICIO);
                            fat.AnoConclusaoFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(outro.ANODECONCLUSAO);
                            fat.AnoObtencaoTituloFormacaoAcademicaTitulacao = fat.AnoConclusaoFormacaoAcademicaTitulacao;

                            if (outro.CARGAHORARIA != "")
                                fat.CargaHorariaFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(outro.CARGAHORARIA);
                            else
                                fat.CargaHorariaFormacaoAcademicaTitulacao = Utils.ParseIntegerOrNull(outro.CARGAHORARIA);

                            // relacionar com não possui
                            fat.TipoGraduacaoDoutorado = _NAO_POSSUI;
                            fat.CodigoAreaCurso = _NAO_POSSUI;
                            fat.InstituicaoEmpresaSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.InstituicaoEmpresaOutraSanduiche = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorSanduiche = GetOrientadorNaoPossui();
                            fat.InstituicaoEmpresaCoTutela = GetInstituicaoEmpresaNaoPossui();
                            fat.OrientadorCoTutela = GetOrientadorNaoPossui();
                            fat.Orientador = GetOrientadorNaoPossui();
                            fat.CoOrientador = GetOrientadorNaoPossui();
                            fat.AgenciaFinanciadora = GetAgenciaFinanciadoraNaoPossui();
                            fat.TemBolsaFormacaoAcademicaTitulacao = false;

                            fat.PalavraChave.Add(GetPalavraChaveNaoPossui());
                            fat.AreaConhecimento.Add(GetAreaConhecimentoNaoPossui());

                            professor.FormacaoAcademicaTitulacao.Add(fat);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Complementa as informações do Curso
        /// </summary>
        /// <param name="curso"></param>
        /// <param name="codigoCapes"></param>
        /// <param name="nomeIngles"></param>
        private void ComplementarCurso(Curso curso, string codigoCapes, string nomeIngles)
        {
            if (codigoCapes != null && codigoCapes != "")
                curso.CodigoCapesCurso = codigoCapes;

            if (nomeIngles != null && nomeIngles != "")
                curso.NomeCursoEmIngles = nomeIngles;
        }

        /// <summary>
        /// Adiciona os Títulos e Prêmio do Professor existentes no XML
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="cvXml"></param>
        private void ProcessarPremiosETitulos(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.DADOSGERAIS.PREMIOSTITULOS == null)
                return;

            PremioOuTitulo premioTitulo = null;
            int sequencia = 1;
            foreach (PREMIOTITULO premio in cvXml.DADOSGERAIS.PREMIOSTITULOS)
            {
                premioTitulo = LattesDatabase.PremioOuTitulo.Create();

                //premioTitulo.Professor = professor;
                //premioTitulo.ProfessorId = professor.ProfessorId;
                premioTitulo.SequenciaPremioOuTitulo = sequencia++;
                premioTitulo.EntidadePromotoraPremioOuTitulo = premio.NOMEDAENTIDADEPROMOTORA;
                premioTitulo.NomePremioOuTitulo = premio.NOMEDOPREMIOOUTITULO;
                premioTitulo.NomePremioOuTituloEmIngles = premio.NOMEDOPREMIOOUTITULOINGLES;
                premioTitulo.AnoPremioOuTitulo = (int)Utils.ParseIntegerOrNull(premio.ANODAPREMIACAO);
                professor.PremioOuTitulo.Add(premioTitulo);
                //LattesDatabase.PremioOuTitulo.Add(premioTitulo);
            }
        }

        /// <summary>
        /// Carrega as informações básicas no professor apartir do XML
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="cvXml"></param>
        private void ProcessarDadosGerais(Professor professor, CurriculoVitaeXml cvXml)
        {
            // dados básicos do professor
            professor.NomeProfessor = cvXml.DADOSGERAIS.NOMECOMPLETO;
            professor.NomeEmCitacoesProfessor = Utils.SetMaxLength(cvXml.DADOSGERAIS.NOMEEMCITACOESBIBLIOGRAFICAS, 300);
            professor.NacionalidadeProfessor = cvXml.DADOSGERAIS.NACIONALIDADE;
            professor.PaisNascimentoProfessor = cvXml.DADOSGERAIS.PAISDENACIONALIDADE;
            professor.UFNascimentoProfessor = cvXml.DADOSGERAIS.UFNASCIMENTO;
            professor.CidadeNascimentoProfessor = cvXml.DADOSGERAIS.CIDADENASCIMENTO;
            professor.PaisNascionalidadeProfessor = cvXml.DADOSGERAIS.SIGLAPAISNACIONALIDADE;
        }

        private void ProcessarIdiomas(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.DADOSGERAIS.IDIOMAS == null)
                return;

            IdiomasProfessor idiomasProfessor = null;
            foreach (IDIOMA idiomaXml in cvXml.DADOSGERAIS.IDIOMAS)
            {
                idiomasProfessor = LattesDatabase.IdiomasProfessor.Create();
                idiomasProfessor.Idioma = GetIdioma(idiomaXml.DESCRICAODOIDIOMA);
                idiomasProfessor.Professor = professor;

                idiomasProfessor.NomeIdioma = idiomasProfessor.Idioma.NomeIdioma;
                idiomasProfessor.ProeficienciaCompreensaoProfessor = TranduzirProeficiencia(idiomaXml.PROFICIENCIADECOMPREENSAO.ToString());
                idiomasProfessor.ProeficienciaEscritaProfessor = TranduzirProeficiencia(idiomaXml.PROFICIENCIADEESCRITA.ToString());
                idiomasProfessor.ProeficienciaLeituraProfessor = TranduzirProeficiencia(idiomaXml.PROFICIENCIADELEITURA.ToString());
                idiomasProfessor.ProeficienciaFalaProfessor = TranduzirProeficiencia(idiomaXml.PROFICIENCIADEFALA.ToString());

                professor.IdiomasProfessor.Add(idiomasProfessor);
            }
        }

        /// <summary>
        /// Adiciona os endereços e contatos do XML para ie professor do parâmetro
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="cvXml"></param>
        private void ProcessarEnderecosEContatos(Professor professor, CurriculoVitaeXml cvXml)
        {
            if (cvXml.DADOSGERAIS.ENDERECO == null)
                return;

            if (cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL != null)
            {
                professor.EnderecoProfissional = this.GetEndereco(cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.PAIS,
                                                                  cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.UF,
                                                                  cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.CIDADE,
                                                                  cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.BAIRRO,
                                                                  cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.CEP);

                professor.InstituicaoEmpresa = this.GetInstituicaoEmpresa(cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.CODIGOINSTITUICAOEMPRESA,
                                                                          cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.NOMEINSTITUICAOEMPRESA);

                professor.OrgaoInstituicaoEmpresa = this.GetOrgaoInstituicaoEmpresa(professor.InstituicaoEmpresa,
                                                                                    cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.NOMEORGAO);

                professor.UnidadeInstituicaoEmpresa = this.GetUnidadeInstituicaoEmpresa(professor.InstituicaoEmpresa,
                                                                                        cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.NOMEUNIDADE);
                professor.UnidadeInstituicaoEmpresa.LogradouroCompletoUnidadeInstituicaoEmpresa = cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.LOGRADOUROCOMPLEMENTO;
                professor.LogradouroProfissional = cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.LOGRADOUROCOMPLEMENTO;

                ContatoProfessor cp = LattesDatabase.ContatoProfessor.Create();
                cp.TipoContato = "Profissional";
                cp.TelefoneContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.DDD + cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.TELEFONE;
                cp.RamalContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.RAMAL;
                cp.FaxContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.FAX;
                cp.EMailContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.EMAIL;
                cp.SiteContato = Utils.SetMaxLength(cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.HOMEPAGE, 300);
                cp.CaixaPostalContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECOPROFISSIONAL.CAIXAPOSTAL;
                professor.ContatoProfessor.Add(cp);
            }
            else
            {
                professor.EnderecoProfissional = GetEnderecoNaoPossui();
                professor.LogradouroProfissional = _NAO_INFORMADO;
            }

            if (cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL != null)
            {
                professor.EnderecoResidencial = this.GetEndereco(cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.PAIS,
                                                                 cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.UF,
                                                                 cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.CIDADE,
                                                                 cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.BAIRRO,
                                                                 cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.CEP);

                ContatoProfessor cp = LattesDatabase.ContatoProfessor.Create();
                cp.TipoContato = "Residencial";
                cp.TelefoneContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.DDD + cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.TELEFONE;
                cp.RamalContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.RAMAL;
                cp.FaxContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.FAX;
                cp.EMailContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.EMAIL;
                cp.SiteContato = Utils.SetMaxLength(cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.HOMEPAGE, 300);
                cp.CaixaPostalContato = cvXml.DADOSGERAIS.ENDERECO.ENDERECORESIDENCIAL.CAIXAPOSTAL;
                professor.ContatoProfessor.Add(cp);
            }
            else
            {
                professor.EnderecoResidencial = GetEnderecoNaoPossui();
                professor.LogradouroResidencial = _NAO_INFORMADO;
            }
        }

        /// <summary>
        /// Lista as áreas de conhecimento existentes para ie bloco "AREASDOCONHECIMENTO" passado do XML
        /// </summary>
        /// <param name="areasXml"></param>
        /// <returns></returns>
        private AreaConhecimento[] ExtrairAreasConhecimento(AREASDOCONHECIMENTO areasXml)
        {
            List<AreaConhecimento> areas = new List<AreaConhecimento>();

            if (areasXml != null)
            {
                if (areasXml.AREADOCONHECIMENTO1 != null)
                    areas.Add(GetAreaConhecimento(areasXml.AREADOCONHECIMENTO1.NOMEGRANDEAREADOCONHECIMENTO.ToString(),
                                                  areasXml.AREADOCONHECIMENTO1.NOMEDAAREADOCONHECIMENTO,
                                                  areasXml.AREADOCONHECIMENTO1.NOMEDASUBAREADOCONHECIMENTO,
                                                  areasXml.AREADOCONHECIMENTO1.NOMEDAESPECIALIDADE));

                if (areasXml.AREADOCONHECIMENTO2 != null)
                    areas.Add(GetAreaConhecimento(areasXml.AREADOCONHECIMENTO2.NOMEGRANDEAREADOCONHECIMENTO.ToString(),
                                                  areasXml.AREADOCONHECIMENTO2.NOMEDAAREADOCONHECIMENTO,
                                                  areasXml.AREADOCONHECIMENTO2.NOMEDASUBAREADOCONHECIMENTO,
                                                  areasXml.AREADOCONHECIMENTO2.NOMEDAESPECIALIDADE));

                if (areasXml.AREADOCONHECIMENTO3 != null)
                    areas.Add(GetAreaConhecimento(areasXml.AREADOCONHECIMENTO3.NOMEGRANDEAREADOCONHECIMENTO.ToString(),
                                                  areasXml.AREADOCONHECIMENTO3.NOMEDAAREADOCONHECIMENTO,
                                                  areasXml.AREADOCONHECIMENTO3.NOMEDASUBAREADOCONHECIMENTO,
                                                  areasXml.AREADOCONHECIMENTO3.NOMEDAESPECIALIDADE));
            }

            if (areas.Count == 0)
                areas.Add(GetAreaConhecimentoNaoPossui());

            return areas.ToArray();
        }

        /// <summary>
        /// Processa as "PALAVRASCHAVE" e "SETORESDEATIVIDADE" do XML para ie banco de dados
        /// </summary>
        /// <param name="palavrasChaveXml"></param>
        /// <param name="setoresDeAtividadeXml"></param>
        /// <returns></returns>
        private PalavraChave[] ExtrairPalavrasChave(PALAVRASCHAVE palavrasChaveXml, SETORESDEATIVIDADE setoresDeAtividadeXml)
        {
            List<PalavraChave> palavrasChave = new List<PalavraChave>();

            if (palavrasChaveXml != null)
            {
                if (palavrasChaveXml.PALAVRACHAVE1 != null
                    && palavrasChaveXml.PALAVRACHAVE1.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(palavrasChaveXml.PALAVRACHAVE1, false));

                if (palavrasChaveXml.PALAVRACHAVE2 != null
                    && palavrasChaveXml.PALAVRACHAVE2.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(palavrasChaveXml.PALAVRACHAVE2, false));

                if (palavrasChaveXml.PALAVRACHAVE3 != null
                    && palavrasChaveXml.PALAVRACHAVE3.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(palavrasChaveXml.PALAVRACHAVE3, false));

                if (palavrasChaveXml.PALAVRACHAVE4 != null
                    && palavrasChaveXml.PALAVRACHAVE4.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(palavrasChaveXml.PALAVRACHAVE4, false));

                if (palavrasChaveXml.PALAVRACHAVE5 != null
                    && palavrasChaveXml.PALAVRACHAVE5.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(palavrasChaveXml.PALAVRACHAVE5, false));
            }

            if (setoresDeAtividadeXml != null)
            {
                if (setoresDeAtividadeXml.SETORDEATIVIDADE1 != null
                    && setoresDeAtividadeXml.SETORDEATIVIDADE1.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(setoresDeAtividadeXml.SETORDEATIVIDADE1, true));

                if (setoresDeAtividadeXml.SETORDEATIVIDADE2 != null
                    && setoresDeAtividadeXml.SETORDEATIVIDADE2.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(setoresDeAtividadeXml.SETORDEATIVIDADE2, true));

                if (setoresDeAtividadeXml.SETORDEATIVIDADE3 != null
                    && setoresDeAtividadeXml.SETORDEATIVIDADE3.Trim() != "")
                    palavrasChave.Add(GetPalavraChave(setoresDeAtividadeXml.SETORDEATIVIDADE3, true));
            }

            if (palavrasChave.Count == 0)
                palavrasChave.Add(GetPalavraChaveNaoPossui());

            return palavrasChave.ToArray();
        }

        /// <summary>
        /// Retorna v AreaConhecimento com v chave informada
        /// </summary>
        /// <param name="grandeAreaConhecimento"></param>
        /// <param name="areaConhecimento"></param>
        /// <param name="subAreaConhecimento"></param>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        public AreaConhecimento GetAreaConhecimento(string grandeAreaConhecimento, string areaConhecimento, string subAreaConhecimento, string especialidade)
        {
            grandeAreaConhecimento = grandeAreaConhecimento == null ? "" : grandeAreaConhecimento;
            areaConhecimento = areaConhecimento == null ? "" : areaConhecimento.Trim();
            subAreaConhecimento = subAreaConhecimento == null ? "" : subAreaConhecimento.Trim();
            especialidade = especialidade == null ? "" : especialidade.Trim();

            if (grandeAreaConhecimento == ""
                && areaConhecimento == ""
                && subAreaConhecimento == ""
                && especialidade == "")
                return GetAreaConhecimentoNaoPossui();

            if (subAreaConhecimento == "")
            {
                subAreaConhecimento = especialidade;
                especialidade = "";
            }

            if (areaConhecimento == "")
            {
                areaConhecimento = subAreaConhecimento;
                subAreaConhecimento = especialidade;
                especialidade = "";
            }

            grandeAreaConhecimento = TraduzirGrandeAreaConhecimento(grandeAreaConhecimento);

            lock (saveLocker)
            {
                var ac = LattesDatabase.AreaConhecimento.FirstOrDefault(a =>
                               a.GrandeAreaConhecimento == grandeAreaConhecimento
                            && a.NomeAreaConhecimento == areaConhecimento
                            && a.SubAreaConhecimento == subAreaConhecimento
                            && a.Especialidade == especialidade);

                if (ac == null)
                {
                    ac = LattesDatabase.AreaConhecimento.Create();

                    ac.GrandeAreaConhecimento = grandeAreaConhecimento;
                    ac.NomeAreaConhecimento = areaConhecimento;
                    ac.SubAreaConhecimento = subAreaConhecimento;
                    ac.Especialidade = especialidade;

                    ac.TermoCompleto = areaConhecimento;

                    if (subAreaConhecimento != "")
                    {
                        ac.TermoCompleto += "; " + subAreaConhecimento;

                        if (especialidade != "")
                            ac.TermoCompleto += "; " + especialidade;
                    }

                    LattesDatabase.AreaConhecimento.Add(ac);
                    LattesDatabase.SaveChanges();
                }

                return ac;
            }
        }

        /// <summary>
        /// Retorna uma AreaConhecimento genérica que representa que ie registro em questão não possui um relacionamento
        /// </summary>
        /// <returns></returns>
        private AreaConhecimento GetAreaConhecimentoNaoPossui()
        {
            return GetAreaConhecimento(_NAO_POSSUI, _NAO_POSSUI, _NAO_POSSUI, _NAO_POSSUI);
        }

        /// <summary>
        /// Retorna uma PalavraChave de acordo com os termos da pesquisa
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="eSetorAtividade"></param>
        /// <returns></returns>
        private PalavraChave GetPalavraChave(string texto, bool eSetorAtividade)
        {
            if (texto == null || texto.Trim() == "")
                return GetPalavraChaveNaoPossui();

            lock (saveLocker)
            {
                var pc = LattesDatabase.PalavraChave.FirstOrDefault(
                            p => p.TermoPalavraChave == texto
                            && p.ESetorAtividade == eSetorAtividade);

                if (pc == null)
                {
                    pc = LattesDatabase.PalavraChave.Create();
                    pc.TermoPalavraChave = texto;
                    pc.ESetorAtividade = eSetorAtividade;

                    LattesDatabase.PalavraChave.Add(pc);
                    LattesDatabase.SaveChanges();
                }

                return pc;
            }
        }

        /// <summary>
        /// Retorna uma PalavraChave que representa um relacionamento não existente ou não informado
        /// </summary>
        /// <returns></returns>
        private PalavraChave GetPalavraChaveNaoPossui()
        {
            return GetPalavraChave(_NAO_POSSUI, false);
        }

        private AgenciaFinanciadora GetAgenciaFinanciadora(string codigo, string nome)
        {
            if ((codigo != null && codigo == "") && nome == "")
                return GetAgenciaFinanciadoraNaoPossui();

            lock (saveLocker)
            {
                var agencia = LattesDatabase.AgenciaFinanciadora.FirstOrDefault(
                           ag => ag.NomeAgenciaFinanciadora == nome);

                if (agencia == null)
                {
                    agencia = LattesDatabase.AgenciaFinanciadora.Create();
                    agencia.NomeAgenciaFinanciadora = nome;

                    LattesDatabase.AgenciaFinanciadora.Add(agencia);
                    LattesDatabase.SaveChanges();
                }
                return agencia;
            }
        }

        private AgenciaFinanciadora GetAgenciaFinanciadoraNaoPossui()
        {
            return GetAgenciaFinanciadora(_NAO_POSSUI, _NAO_POSSUI);
        }

        private Orientador GetOrientador(string numeroCurriculo, string nome)
        {
            numeroCurriculo = (numeroCurriculo == null ? "" : numeroCurriculo).Trim();
            nome = nome == null ? "" : nome;

            if (numeroCurriculo == "" && nome == "")
            {
                return GetOrientadorNaoPossui();
            }
            lock (saveLocker)
            {
                Orientador orien = null;
                if (numeroCurriculo == _NAO_POSSUI && nome == _NAO_POSSUI) // procura pelo não possui
                    orien = LattesDatabase.Orientador.FirstOrDefault(
                             o => o.NumeroCurriculoOrientador == _NAO_POSSUI);
                else
                {
                    if (numeroCurriculo != "") // eu tem numero do curriculo, procura por ele
                    {
                        orien = LattesDatabase.Orientador.FirstOrDefault(
                                 o => o.NumeroCurriculoOrientador == numeroCurriculo);

                        if (orien != null)
                        {
                            if (orien.NomeOrientador == "")
                            {
                                orien.NomeOrientador = nome;
                                LattesDatabase.SaveChanges();
                            }
                        }
                    }

                    orien = LattesDatabase.Orientador.FirstOrDefault(
                             o => o.NomeOrientador == nome);
                    if (orien != null)
                    {
                        if (orien.NumeroCurriculoOrientador.Trim() == "")
                        {
                            orien.NumeroCurriculoOrientador = numeroCurriculo;
                            LattesDatabase.SaveChanges();
                        }
                    }
                }

                if (orien == null)
                {
                    orien = LattesDatabase.Orientador.Create(); // eu não encontrar criar um novo

                    orien.NumeroCurriculoOrientador = numeroCurriculo;
                    orien.NomeOrientador = nome;

                    LattesDatabase.Orientador.Add(orien);
                    LattesDatabase.SaveChanges();
                }

                return orien;
            }
        }

        private Orientador GetOrientadorNaoPossui()
        {
            return GetOrientador(_NAO_POSSUI, _NAO_POSSUI);
        }

        private Idioma GetIdioma(string nome)
        {
            if (nome == "" || nome == null)
            {
                nome = _NAO_INFORMADO;
            }

            lock (saveLocker)
            {
                Idioma idioma = null;

                idioma = LattesDatabase.Idioma.FirstOrDefault(
                              i => i.NomeIdioma == nome);

                if (idioma == null)
                {
                    idioma = LattesDatabase.Idioma.Create();

                    idioma.NomeIdioma = nome;

                    LattesDatabase.Idioma.Add(idioma);
                    LattesDatabase.SaveChanges(); // salva idioma no banco de dados
                }

                return idioma;
            }
        }

        private UnidadeInstituicaoEmpresa GetUnidadeInstituicaoEmpresa(InstituicaoEmpresa instituicaoEmpresa, string nome)
        {
            if (instituicaoEmpresa == null)
                throw new ArgumentNullException("instituicaoEmpresa");

            lock (saveLocker)
            {
                var uni = LattesDatabase.UnidadeInstituicaoEmpresa.FirstOrDefault(
                       u => u.InstituicaoEmpresa.InstituicaoEmpresaId == instituicaoEmpresa.InstituicaoEmpresaId
                       && u.NomeUnidadeInstituicaoEmpresa == nome);

                if (uni == null)
                {
                    uni = LattesDatabase.UnidadeInstituicaoEmpresa.Create();

                    uni.InstituicaoEmpresa = instituicaoEmpresa;
                    uni.NomeUnidadeInstituicaoEmpresa = nome;

                    LattesDatabase.UnidadeInstituicaoEmpresa.Add(uni);
                    LattesDatabase.SaveChanges();
                }
                return uni;
            }
        }

        private UnidadeInstituicaoEmpresa GetUnidadeInstituicaoEmpresaNaoPossui(InstituicaoEmpresa instituicaoEmpresa)
        {
            return GetUnidadeInstituicaoEmpresa(instituicaoEmpresa, _NAO_POSSUI);
        }

        private OrgaoInstituicaoEmpresa GetOrgaoInstituicaoEmpresa(InstituicaoEmpresa instituicaoEmpresa, string nome)
        {

            if (instituicaoEmpresa == null)
                throw new ArgumentNullException("instituicaoEmpresa");

            lock (saveLocker)
            {
                var orgao = LattesDatabase.OrgaoInstituicaoEmpresa.FirstOrDefault(
                        o => o.InstituicaoEmpresa.InstituicaoEmpresaId == instituicaoEmpresa.InstituicaoEmpresaId
                          && o.NomeOrgaoInstituicaoEmpresa == nome);

                if (orgao == null)
                {
                    orgao = LattesDatabase.OrgaoInstituicaoEmpresa.Create();

                    orgao.InstituicaoEmpresa = instituicaoEmpresa;
                    orgao.NomeOrgaoInstituicaoEmpresa = nome;

                    LattesDatabase.OrgaoInstituicaoEmpresa.Add(orgao);
                    LattesDatabase.SaveChanges();
                }

                return orgao;
            }
        }

        private OrgaoInstituicaoEmpresa GetOrgaoInstituicaoEmpresaNaoPossui(InstituicaoEmpresa instituicaoEmpresa)
        {
            return GetOrgaoInstituicaoEmpresa(instituicaoEmpresa, _NAO_POSSUI);
        }

        private Curso GetCurso(InstituicaoEmpresa instituicaoEmpresa, string codigo, string nome, string tipoFormacao)
        {
            if (instituicaoEmpresa == null)
                throw new ArgumentNullException("instituicaoEmpresa");

            if (tipoFormacao == "")
                tipoFormacao = _NAO_INFORMADO;

            if (nome == "")
                nome = _NAO_INFORMADO;

            lock (saveLocker)
            {
                var c = LattesDatabase.Curso.FirstOrDefault(
                         cur => cur.InstituicaoEmpresa.InstituicaoEmpresaId == instituicaoEmpresa.InstituicaoEmpresaId
                         && cur.TipoFormacaoCurso == tipoFormacao
                         && cur.NomeCurso == nome);

                if (c == null)
                {
                    c = LattesDatabase.Curso.Create();

                    c.InstituicaoEmpresa = instituicaoEmpresa;
                    c.TipoFormacaoCurso = tipoFormacao;
                    c.NomeCurso = nome;

                    if (codigo != null
                        && cacheCursos.ContainsKey(codigo))
                    {
                        CacheCurso ci = cacheCursos[codigo];
                        c.GrandeAreaConhecimento = ci.area.GrandeAreaConhecimento;
                        c.AreaConhecimento = ci.area.NomeAreaConhecimento;
                        c.SubAreaConhecimento = ci.area.SubAreaConhecimento;
                        c.Especialidade = ci.area.Especialidade;
                        c.TermoCompleto = ci.area.TermoCompleto;
                    }
                    else
                    {
                        var ac = GetAreaConhecimentoNaoPossui();
                        c.GrandeAreaConhecimento = ac.GrandeAreaConhecimento;
                        c.AreaConhecimento = ac.NomeAreaConhecimento;
                        c.SubAreaConhecimento = ac.SubAreaConhecimento;
                        c.Especialidade = ac.Especialidade;
                        c.TermoCompleto = ac.TermoCompleto;
                    }

                    LattesDatabase.Curso.Add(c);
                    LattesDatabase.SaveChanges();
                }

                return c;
            }
        }

        private InstituicaoEmpresa GetInstituicaoEmpresa(string codigo, string nome)
        {
            if (nome == "")
                nome = _NAO_INFORMADO;

            lock (saveLocker)
            {
                var instEmp = LattesDatabase.InstituicaoEmpresa.FirstOrDefault(
                           ie => ie.NomeInstituicaoEmpresa == nome);

                if (instEmp == null)
                {
                    instEmp = LattesDatabase.InstituicaoEmpresa.Create();

                    instEmp.NomeInstituicaoEmpresa = nome;

                    if (codigo != null
                        && cacheInstituicoes.ContainsKey(codigo))
                    {
                        CacheInstituicao ci = cacheInstituicoes[codigo];
                        instEmp.SiglaInstituicaoEmpresa = ci.sigla;
                        instEmp.PaisInstituicaoEmpresa = ci.pais;
                        instEmp.EnsinoInstituicaoEmpresa = ci.instituicaoEnsino;
                    }
                    else
                    {
                        instEmp.SiglaInstituicaoEmpresa = _NAO_POSSUI;
                        instEmp.PaisInstituicaoEmpresa = _NAO_INFORMADO;
                        instEmp.EnsinoInstituicaoEmpresa = false;
                    }

                    LattesDatabase.InstituicaoEmpresa.Add(instEmp);
                    LattesDatabase.SaveChanges(); // save v instituicao no banco para que possa ser usada por outros professores
                }

                return instEmp;
            }
        }

        private InstituicaoEmpresa GetInstituicaoEmpresaNaoPossui()
        {
            return GetInstituicaoEmpresa("", _NAO_POSSUI);
        }

        private Endereco GetEndereco(string pais, string uf, string cidade, string bairro, string cep)
        {
            cep = cep.Replace("-", "");

            if (pais == "" && uf == "" && cidade == "" && bairro == "" && cep == "")
                return GetEnderecoNaoPossui();

            lock (saveLocker)
            {
                var ender = LattesDatabase.Endereco.FirstOrDefault(
                             e => e.Pais == pais
                             && e.UF == uf
                             && e.Cidade == cidade
                             && e.Bairro == bairro
                             && e.CEP == cep);


                if (ender == null)
                {
                    ender = LattesDatabase.Endereco.Create();

                    ender.Pais = pais;
                    ender.UF = uf;
                    ender.Cidade = cidade;
                    ender.Bairro = bairro;
                    ender.CEP = cep;

                    LattesDatabase.Endereco.Add(ender);
                    LattesDatabase.SaveChanges();
                }
                return ender;
            }
        }

        private Endereco GetEnderecoNaoPossui()
        {
            return GetEndereco(_NAO_INFORMADO, "NI", _NAO_INFORMADO, _NAO_INFORMADO, "00000000");
        }

        private void RemoverDadosProfessor(Professor professor)
        {
            lock (saveLocker)
            {
                var basesDeConsulta = professor.BaseDeConsulta.ToArray();
                foreach (var bc in basesDeConsulta)
                    LattesDatabase.BaseDeConsulta.Remove(bc);

                var vinculos = professor.VinculoAtuacaoProfissional.ToArray();
                foreach (var v in vinculos)
                    LattesDatabase.VinculoAtuacaoProfissional.Remove(v); // remove registro da base

                var atividadesP = professor.AtividadeProfissional.ToArray();
                foreach (var ap in atividadesP)
                    LattesDatabase.AtividadeProfissional.Remove(ap); // remove registro da base

                var areasAtuacao = professor.AreaAtuacao.ToArray();
                foreach (var ac in areasAtuacao)
                {
                    LattesDatabase.AreaAtuacao.Remove(ac);
                }

                var contatos = professor.ContatoProfessor.ToArray();
                foreach (var contato in contatos)
                    LattesDatabase.ContatoProfessor.Remove(contato); // remove registro da base

                // remove ie relacionamento do professor com os endereços
                var enderecoP = professor.EnderecoProfissional;
                if (enderecoP != null)
                {
                    enderecoP.ProfessorProfissional.Remove(professor);
                    if (enderecoP.ProfessorResidencial.Count == 0
                        && enderecoP.ProfessorProfissional.Count == 0)
                        LattesDatabase.Endereco.Remove(enderecoP); // eu não estiver relacionado v nenhum professor, então elimina
                }

                var enderecoR = professor.EnderecoResidencial;
                if (enderecoR != null)
                {
                    enderecoR.ProfessorResidencial.Remove(professor);
                    if (enderecoR.ProfessorResidencial.Count == 0
                        && enderecoR.ProfessorProfissional.Count == 0)
                        LattesDatabase.Endereco.Remove(enderecoR); // eu não estiver relacionado v nenhum professor, então elimina
                }

                var formacoes = professor.FormacaoAcademicaTitulacao.ToArray();
                foreach (var formacao in formacoes)
                {
                    var areas = formacao.AreaConhecimento.ToArray();
                    foreach (var area in areas)
                        formacao.AreaConhecimento.Remove(area);
                    var palavras = formacao.PalavraChave.ToArray();
                    foreach (var p in palavras)
                        formacao.PalavraChave.Remove(p);
                    LattesDatabase.FormacaoAcademicaTitulacao.Remove(formacao); // remove as formações
                }

                var linhas = professor.LinhaDePesquisa.ToArray();
                foreach (var linha in linhas)
                    LattesDatabase.LinhaDePesquisa.Remove(linha); // remove as formações

                var idiomas = professor.IdiomasProfessor.ToArray();
                foreach (var idioma in idiomas)
                    LattesDatabase.IdiomasProfessor.Remove(idioma); // remove os idiomas do professor

                var premiosTitulacoes = professor.PremioOuTitulo.ToArray();
                foreach (var premio in premiosTitulacoes)
                    LattesDatabase.PremioOuTitulo.Remove(premio);

                AreaConhecimento[] areasConhecimento;
                var partEventos = professor.ParticipacaoEvento.ToArray();
                Evento e;
                foreach (var part in partEventos)
                {
                    e = part.Evento;

                    areasConhecimento = part.AreaConhecimento.ToArray();
                    foreach (var area in areasConhecimento)
                        part.AreaConhecimento.Remove(area);

                    var palavras = part.PalavraChave.ToArray();
                    foreach (var pl in palavras)
                        part.PalavraChave.Remove(pl);

                    LattesDatabase.ParticipacaoEvento.Remove(part); // remove participação
                    if (e.ParticipacaoEvento.Count == 0)
                        LattesDatabase.Evento.Remove(e); // eu não houverem participantes, eliminar evento
                }

                var bancasTrabalho = professor.BancaDeTrabalho.ToArray();
                foreach (var bt in bancasTrabalho)
                {
                    professor.BancaDeTrabalho.Remove(bt); // remove as participações
                    lock (saveLocker)
                    {
                        if (bt.Professor.Count == 0)
                        {
                            areasConhecimento = bt.AreaConhecimento.ToArray();
                            foreach (var area in areasConhecimento)
                                bt.AreaConhecimento.Remove(area);

                            var palavras = bt.PalavraChave.ToArray();
                            foreach (var pl in palavras)
                                bt.PalavraChave.Remove(pl);

                            LattesDatabase.BancaDeTrabalho.Remove(bt); // eu não houverem participantes, eliminar evento
                        }
                    }
                }

                var bancasJulg = professor.BancaJulgadora.ToArray();
                foreach (var bj in bancasJulg)
                {
                    professor.BancaJulgadora.Remove(bj); // remove as participações

                    if (bj.Professor.Count == 0)
                    {
                        areasConhecimento = bj.AreaConhecimento.ToArray();
                        foreach (var area in areasConhecimento)
                            bj.AreaConhecimento.Remove(area);

                        var palavras = bj.PalavraChave.ToArray();
                        foreach (var pl in palavras)
                            bj.PalavraChave.Remove(pl);

                        LattesDatabase.BancaJulgadora.Remove(bj); // eu não houverem participantes, eliminar evento
                    }
                }

                var partProjetos = professor.ParticipacaoEmProjeto.ToArray();
                Projeto proj;
                foreach (var part in partProjetos)
                {
                    proj = part.Projeto;
                    LattesDatabase.ParticipacaoEmProjeto.Remove(part); // remove participação do professor

                    if (proj.ParticipacaoEmProjeto.Count == 0)
                    {
                        var financs = proj.InstituicaoEmpresaFinanciadora.ToArray();
                        foreach (var f in financs)
                            proj.InstituicaoEmpresaFinanciadora.Remove(f);

                        LattesDatabase.Projeto.Remove(proj); // eu não houverem participantes, eliminar evento
                    }
                }

                var producoesBibliograficas = professor.ProducaoBibliografica.ToArray();
                foreach (var pb in producoesBibliograficas)
                {
                    professor.ProducaoBibliografica.Remove(pb); // remove relacionamento

                    if (pb.Professor.Count == 0)
                    {
                        areasConhecimento = pb.AreaConhecimento.ToArray();
                        foreach (var area in areasConhecimento)
                            pb.AreaConhecimento.Remove(area);

                        var palavras = pb.PalavraChave.ToArray();
                        foreach (var pl in palavras)
                            pb.PalavraChave.Remove(pl);

                        LattesDatabase.ProducaoBibliografica.Remove(pb); // eu não houverem participantes, eliminar evento
                    }
                }

                var producoesTecnicas = professor.ProducaoTecnica.ToArray();
                foreach (var pt in producoesTecnicas)
                {
                    professor.ProducaoTecnica.Remove(pt);

                    if (pt.Professor.Count == 0)
                    {
                        areasConhecimento = pt.AreaConhecimento.ToArray();
                        foreach (var area in areasConhecimento)
                            pt.AreaConhecimento.Remove(area);

                        var palavras = pt.PalavraChave.ToArray();
                        foreach (var pl in palavras)
                            pt.PalavraChave.Remove(pl);

                        LattesDatabase.ProducaoTecnica.Remove(pt); // eu não houverem participantes, eliminar evento
                    }
                }

                var oriens = professor.OrientacaoSupervisao.ToArray();
                foreach (var o in oriens)
                {
                    var areas = o.AreaConhecimento.ToArray();
                    foreach (var area in areas)
                        o.AreaConhecimento.Remove(area);
                    var palavras = o.PalavraChave.ToArray();
                    foreach (var p in palavras)
                        o.PalavraChave.Remove(p);
                    LattesDatabase.OrientacaoSupervisao.Remove(o); // remove as formações
                }

                //LattesDatabase.Professor.Remove(professor);
                LattesDatabase.SaveChanges(); // elimina os negocios
            }
        }

        public void ProcessarCache(CurriculoVitaeXml cvXml)
        {
            CacheInstituicao ci = null;
            CacheCurso cc = null;

            // limpar cache de producões e orientações
            cacheProducoes.Clear();
            cacheProducoesProjetos.Clear();

            // limpar o cache v cada professor, pois essa informação não é confiável entre currículos
            cacheInstituicoes.Clear();

            foreach (INFORMACAOADICIONALINSTITUICAO iai in cvXml.DADOSCOMPLEMENTARES.INFORMACOESADICIONAISINSTITUICOES)
            {
                if (!cacheInstituicoes.ContainsKey(iai.CODIGOINSTITUICAO))
                {
                    ci = new CacheInstituicao();
                    ci.codigo = iai.CODIGOINSTITUICAO;
                    ci.sigla = iai.SIGLAINSTITUICAO;
                    ci.pais = iai.NOMEPAISINSTITUICAO;
                    ci.instituicaoEnsino = (bool)TraduzirFlags(iai.FLAGINSTITUICAODEENSINO.ToString());
                    cacheInstituicoes.Add(ci.codigo, ci);
                }
            }

            cacheCursos.Clear();

            foreach (var ic in cvXml.DADOSCOMPLEMENTARES.INFORMACOESADICIONAISCURSOS)
            {
                if (!cacheCursos.ContainsKey(ic.CODIGOCURSO))
                {
                    cc = new CacheCurso();
                    cc.codigo = ic.CODIGOCURSO;
                    cc.area = GetAreaConhecimento(ic.NOMEGRANDEAREADOCONHECIMENTO.ToString(),
                                                  ic.NOMEDAAREADOCONHECIMENTO,
                                                  ic.NOMEDASUBAREADOCONHECIMENTO,
                                                  ic.NOMEDAESPECIALIDADE);
                    cacheCursos.Add(cc.codigo, cc);
                }
            }
        }

        /// <summary>
        /// Traduz os códigos de "Tipo de Gradução ou Doutorado" do XML para algo mais compreensível
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static string TraduzirTipoGraduacaoDoutorado(string tipo)
        {
            switch (tipo)
            {
                case "N":
                    return _TIPO_GD_NORMAL;
                case "C":
                    return _TIPO_GD_COTUTELA;
                case "S":
                    return _TIPO_GD_SANDUICHE;
                case "CS":
                    return _TIPO_GD_COTUTELA_SANDUICHE;
            }

            return _TIPO_GD_NORMAL;
        }

        /// <summary>
        /// Converte as strings "SIM" e "NAO" para TRUE e FALSE respectivamente
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static bool TraduzirFlags(string flag)
        {
            if (flag == "SIM")
                return true;

            return false;
        }

        /// <summary>
        /// Traduz as situações do XML para um texto mais amigável
        /// </summary>
        /// <param name="situacao"></param>
        /// <returns></returns>
        public static String TraduzirSituacao(string situacao)
        {
            switch (situacao)
            {
                case "EM_ANDAMENTO":
                    return _SIT_EM_ANDAMENTO;
                case "CONCLUIDO":
                    return _SIT_CONCLUIDO;
                case "INCOMPLETO":
                    return _SIT_INCOMPLETO;
                case "DESATIVADO":
                    return _SIT_DESATIVADO;
            }

            return _NAO_INFORMADO;
        }

        /// <summary>
        /// Traduz os tipos de proeficiencia em algo mais amigável
        /// </summary>
        /// <param name="proefXml"></param>
        /// <returns></returns>
        public static String TranduzirProeficiencia(string proefXml)
        {
            switch (proefXml)
            {
                case "POUCO":
                    return "Pouco";
                case "RAZOAVELMENTE":
                    return "Razoavelmente";
                case "BEM":
                    return "Bem";
            }

            return _NAO_INFORMADO;
        }

        public static string TraduzirGrandeAreaConhecimento(string grandeAreaConhecimento)
        {
            switch (grandeAreaConhecimento)
            {
                case "OUTROS":
                    return "Outros";
                case "LINGUISTICA_LETRAS_E_ARTES":
                    return "Linguística, Letras e Artes";
                case "CIENCIAS_HUMANAS":
                    return "Ciências Humanas";
                case "CIENCIAS_SOCIAIS_APLICADAS":
                    return "Ciências Sociais Aplicadas";
                case "CIENCIAS_AGRARIAS":
                    return "Ciências Agrárias";
                case "CIENCIAS_DA_SAUDE":
                    return "Ciências da Saúde";
                case "ENGENHARIAS":
                    return "Engenharias";
                case "CIENCIAS_BIOLOGICAS":
                    return "Ciências Biológicas";
                case "CIENCIAS_EXATAS_E_DA_TERRA":
                    return "Ciências Exatas e da Terra";
            }

            return grandeAreaConhecimento;
        }

        public static string TraduzirTipoVinculo(string tipoVinculo)
        {
            switch (tipoVinculo)
            {
                case "SERVIDOR_PUBLICO_OU_CELETISTA":
                    return "Servidor Público ou Celetista";
                case "SERVIDOR_PUBLICO":
                    return "Servidor Público";
                case "CELETIST":
                    return "Celetista";
                case "PROFESSOR_VISITANTE":
                    return "Professor Visitante";
                case "COLABORADOR":
                    return "Colaborador";
                case "BOLSISTA_RECEM_DOUTOR":
                    return "Bolsista / Recem Doutor";
                case "OUTRO":
                    return "Outro";
                case "LIVRE":
                    return "Livre";
            }

            return _NAO_INFORMADO;
        }

        public static string TraduzirCargoOuFuncao(string selecionado, string informado)
        {
            switch (selecionado)
            {
                case "CHEFE_DE_DEPARTMENTO":
                    return "Chefe de Departamento";
                case "COORDENADOR_DE_CURSO":
                    return "Coordenador de Curso";
                case "COORDENADOR_DE_PROGRAMA":
                    return "Coordenador de Programa";
                case "DECANO_DE_CENTRO":
                    return "Decano de Centro";
                case "DIRETOR_DE_UNIDADE":
                    return "Diretor de Unidade";
                case "MEMBRO_DE_COLEGIADO_SUPERIOR":
                    return "Membro de Colegiado Superior";
                case "MEMBRO_DE_COMISSAO_PERMANENTE":
                    return "Membro de Colegiado Permanente";
                case "MEMBRO_DE_COMISSAO_TEMPORARIA":
                    return "Membro de Comissão Temporária";
                case "MEMBRO_DE_CONSELHO_DE_CENTRO":
                    return "Membro de Conselho de Centro";
                case "MEMBRO_DE_CONSELHO_DE_UNIDADE":
                    return "Membro de Conselho de Unidade";
                case "REITOR":
                    return "Reitor";
                case "VICE_REITOR_OU_PRO_REITOR":
                    return "Vice Reitor ou Pró-Reitor";
                case "LIVRE":
                    return "Livre";
                case "OUTRO":
                    return informado;
            }

            return _NAO_INFORMADO;
        }

        public static string TraduzirTipoPatente(string tipo)
        {
            switch (tipo)
            {
                case "PRIVILEGIO_DE_INOVACAO_PI":
                    return "Privilégio de Inovação (PI)";
                case "MODELO_DE_UTILIDADE_MU":
                    return "Modelo de Utilidade (MU)";
                case "DESENHO_INDUSTRIAL_DI":
                    return "Desenho Industrial (DI)";
                case "MODELO_INDUSTRIAL_MI":
                    return "Modelo Industrial (MI)";
                case "PATENTE_NO_EXTERIOR_PE":
                    return "Patente no Exterior (PE)";
                case "PROGRAMA_DE_COMPUTADOR_PC":
                    return "Programa de Computador (PC)";
                case "OUTRO_OU":
                case "OUTRO_Ou":
                    return "Outro (OU)";
                case "CERTIFICADO_DE_ADICAO_CA":
                    return "Certificação de Adição (CA)";
                case "CULTIVAR_PROTEGIDA_CTV":
                    return "Cultivar Protegida (CTV)";
                case "MARCA_REGISTRADA_DE_PRODUTO_MPD":
                    return "Marca Registrada de Produto (MPD)";
                case "MARCA_REGISTRADA_DE_SERVICO_MSV":
                    return "Marca Registrada de Serviço (MPS)";
                case "MARCA_REGISTRADA_COLETIVA_MCL":
                    return "Marca Registrada Coletiva (MCL)";
                case "MARCA_REGISTRADA_DE_CERTIFICACAO_MCT":
                    return "Marca Registrada de Certificação (MCT)";
                case "TOPOGRAFIA_DE_CIRCUITO_INTEGRADO_REGISTRADA_TCI":
                    return "Topografia de Circuito Integrado Registrada (TCI)";
                case "MARCA_REGISTRADA_FIGURATIVA_MRF":
                    return "Marca Registrada Figurativa (MRF)";
                case "MARCA_REGISTRADA_NOMINATIVA_MRN":
                    return "Marca Registrada Nominativa (MRN)";
                case "MARCA_REGISTRADA_MISTA_MRM":
                    return "Marca Registrada Mista (MRM)";
                case "MARCA_REGISTRADA_TRIDIMENSIONAL_MRT":
                    return "Marca Registrada Tridimensional (MRT)";
                default:
                    return _NAO_INFORMADO;
            }
        }
    }
}
