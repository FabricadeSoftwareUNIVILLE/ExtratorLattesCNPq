USE [dblattes]
GO

/****** Object:  Table [dbo].[AgenciaFinanciadora]    Script Date: 09/06/2016 12:06:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AgenciaFinanciadora](
	[AgenciaFinanciadoraId] [int] IDENTITY(1,1) NOT NULL,
	[NomeAgenciaFinanciadora] [varchar](200) NULL,
 CONSTRAINT [PK_AgenciaFinanciadora] PRIMARY KEY CLUSTERED 
(
	[AgenciaFinanciadoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[AreaAtuacao]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AreaAtuacao](
	[ProfessorId] [int] NOT NULL,
	[SequenciaAreaAtuacao] [int] NOT NULL,
	[GrandeAreaAtuacao] [varchar](50) NULL,
	[AreaAtuacao] [varchar](100) NULL,
	[SubAreaAtuacao] [varchar](100) NULL,
	[Especialidade] [varchar](100) NULL,
	[TermoCompleto] [varchar](350) NULL,
 CONSTRAINT [PK_AreaAtuacao] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaAreaAtuacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[AreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AreaConhecimento](
	[AreaConhecimentoId] [int] IDENTITY(1,1) NOT NULL,
	[GrandeAreaConhecimento] [varchar](50) NULL,
	[AreaConhecimento] [varchar](100) NULL,
	[SubAreaConhecimento] [varchar](100) NULL,
	[Especialidade] [varchar](100) NULL,
	[TermoCompleto] [varchar](350) NULL,
 CONSTRAINT [PK_AreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[AreaConhecimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[AtividadeProfissional]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AtividadeProfissional](
	[ProfessorId] [int] NOT NULL,
	[SequenciaAtividadeProfissional] [int] NOT NULL,
	[InstituicaoEmpresaId] [int] NOT NULL,
	[UnidadeInstituicaoEmpresaId] [int] NULL,
	[OrgaoInstituicaoEmpresaId] [int] NULL,
	[DataInicioAtividadeProfissional] [date] NOT NULL,
	[DataTerminoAtividadeProfissional] [date] NULL,
	[InformacoesAdicionaisAtividadeProfissional] [varchar](2000) NULL,
	[TipoAtividadeProfissional] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AtividadeProfissional] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaAtividadeProfissional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[AutorProducaoBibliografica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AutorProducaoBibliografica](
	[ProducaoBibliograficaId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_AutorProducaoBibliografica] PRIMARY KEY CLUSTERED 
(
	[ProducaoBibliograficaId] ASC,
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[AutorProducaoTecnica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AutorProducaoTecnica](
	[ProducaoTecnicaId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_AutorProducaoTecnica_1] PRIMARY KEY CLUSTERED 
(
	[ProducaoTecnicaId] ASC,
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BancaDeTrabalho]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BancaDeTrabalho](
	[BancaDeTrabalhoId] [int] IDENTITY(1,1) NOT NULL,
	[NaturezaBancaDeTrabalho] [varchar](25) NULL,
	[TipoBancaDeTrabalho] [varchar](50) NOT NULL,
	[TituloBancaDeTrabalho] [varchar](350) NOT NULL,
	[AnoBancaDeTrabalho] [numeric](4, 0) NOT NULL,
	[PaisBancaDeTrabalho] [varchar](50) NULL,
	[IdiomaId] [int] NULL,
	[HomePageBancaDeTrabalho] [varchar](300) NULL,
	[DOIBancaDeTrabalho] [char](55) NULL,
	[TituloEmInglesBancaDeTrabalho] [varchar](350) NULL,
	[NomeDoCandidatoBancaDeTrabalho] [varchar](200) NOT NULL,
	[InstituicaoEmpresaId] [int] NULL,
	[CursoId] [int] NULL,
	[InformacoesAdicionaisBancaDeTrabalho] [varchar](2000) NULL,
	[InformacoesAdicionaisEmInglesBancaDeTrabalho] [varchar](2000) NULL,
	[OrgaoInstituicaoEmpresaId] [int] NULL,
 CONSTRAINT [PK_BancaDeTrabalho] PRIMARY KEY CLUSTERED 
(
	[BancaDeTrabalhoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[BancaDeTrabalhoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BancaDeTrabalhoAreaConhecimento](
	[BancaDeTrabalhoId] [int] NOT NULL,
	[AreaConhecimentoId] [int] NOT NULL,
 CONSTRAINT [PK_BancaDeTrabalhoAreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[BancaDeTrabalhoId] ASC,
	[AreaConhecimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BancaDeTrabalhoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BancaDeTrabalhoPalavraChave](
	[BancaDeTrabalhoId] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
 CONSTRAINT [PK_BancaDeTrabalhoPalavraChave] PRIMARY KEY CLUSTERED 
(
	[BancaDeTrabalhoId] ASC,
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BancaJulgadora]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BancaJulgadora](
	[BancaJulgadoraId] [int] IDENTITY(1,1) NOT NULL,
	[TipoBancaJulgadora] [varchar](50) NOT NULL,
	[NaturezaBancaJulgadora] [varchar](50) NULL,
	[TituloBancaJulgadora] [varchar](350) NOT NULL,
	[AnoBancaJulgadora] [numeric](4, 0) NOT NULL,
	[PaisBancaJulgadora] [varchar](50) NULL,
	[IdiomaId] [int] NULL,
	[HomePageBancaJulgadora] [varchar](300) NULL,
	[DOIBancaJulgadora] [char](55) NULL,
	[TituloEmInglesBancaJulgadora] [varchar](350) NULL,
	[InstituicaoEmpresaId] [int] NULL,
	[InformacoesAdicionaisBancaJulgadora] [varchar](2000) NULL,
	[InformacoesAdicionaisEmInglesBancaJulgadora] [varchar](2000) NULL,
 CONSTRAINT [PK_BancaJulgadora] PRIMARY KEY CLUSTERED 
(
	[BancaJulgadoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[BancaJulgadoraAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BancaJulgadoraAreaConhecimento](
	[BancaJulgadoraId] [int] NOT NULL,
	[AreaConhecimentoId] [int] NOT NULL,
 CONSTRAINT [PK_BancaJulgadoraAreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[BancaJulgadoraId] ASC,
	[AreaConhecimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BancaJulgadoraPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BancaJulgadoraPalavraChave](
	[BancaJulgadoraId] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
 CONSTRAINT [PK_BancaJulgadoraPalavraChave] PRIMARY KEY CLUSTERED 
(
	[BancaJulgadoraId] ASC,
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BaseDeConsulta]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BaseDeConsulta](
	[ProfessorId] [int] NOT NULL,
	[AnoBaseDeConsulta] [numeric](4, 0) NOT NULL,
	[SequenciaBaseDeConsulta] [int] NOT NULL,
	[InstituicaoEmpresaId] [int] NULL,
	[UnidadeInstituicaoEmpresaId] [int] NULL,
	[OrgaoInstituicaoEmpresaId] [int] NULL,
	[AreaConhecimentoId] [int] NULL,
	[PalavraChaveId] [int] NULL,
	[IdiomaId] [int] NULL,
	[CursoId] [int] NULL,
	[AgenciaFinanciadoraId] [int] NULL,
	[SequenciaAtividadeProfissional] [int] NULL,
	[ProducaoBibliograficaId] [int] NULL,
	[ProducaoTecnicaId] [int] NULL,
	[BancaDeTrabalhoId] [int] NULL,
	[BancaJulgadoraId] [int] NULL,
	[EventoId] [int] NULL,
	[SequenciaParticipacaoEvento] [int] NULL,
	[SequenciaFormacaoAcademicaTitulacao] [int] NULL,
	[SequenciaOrientacaoSupervicao] [int] NULL,
	[ProjetoId] [int] NULL,
	[SequenciaPremioOuTitulo] [int] NULL,
	[SequenciaVinculoAtuacaoProfissional] [int] NULL,
	[AtividadeProfissionalId] [char](23) NULL,
	[ParticipacaoEventoId] [char](23) NULL,
	[FormacaoAcademicaTitulacaoId] [char](23) NULL,
	[OrientacaoSupervicaoId] [char](23) NULL,
	[PremioOuTituloId] [char](23) NULL,
	[VinculoAtuacaoProfissionalId] [char](23) NULL,
 CONSTRAINT [PK_BaseDeConsulta] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[AnoBaseDeConsulta] ASC,
	[SequenciaBaseDeConsulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ContatoProfessor]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContatoProfessor](
	[ProfessorId] [int] NOT NULL,
	[TipoContato] [varchar](30) NOT NULL,
	[TelefoneContato] [varchar](20) NULL,
	[RamalContato] [char](5) NULL,
	[FaxContato] [varchar](20) NULL,
	[EMailContato] [varchar](70) NULL,
	[SiteContato] [varchar](250) NULL,
	[CaixaPostalContato] [char](10) NULL,
 CONSTRAINT [PK_ContatoProfessor] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[TipoContato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Curso]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Curso](
	[InstituicaoEmpresaId] [int] NOT NULL,
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[NomeCurso] [varchar](150) NULL,
	[TipoFormacaoCurso] [varchar](50) NOT NULL,
	[CodigoCapesCurso] [char](20) NULL,
	[NomeCursoEmIngles] [varchar](150) NULL,
	[GrandeAreaConhecimento] [varchar](50) NULL,
	[AreaConhecimento] [varchar](100) NULL,
	[SubAreaConhecimento] [varchar](100) NULL,
	[Especialidade] [varchar](100) NULL,
	[TermoCompleto] [varchar](350) NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Endereco](
	[EnderecoId] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [varchar](50) NULL,
	[UF] [char](2) NULL,
	[Cidade] [varchar](60) NULL,
	[Bairro] [varchar](50) NULL,
	[CEP] [char](9) NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[EnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Evento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Evento](
	[EventoId] [int] IDENTITY(1,1) NOT NULL,
	[AnoEvento] [numeric](4, 0) NOT NULL,
	[PaisEvento] [varchar](50) NULL,
	[NomeEvento] [varchar](300) NULL,
	[InstituicaoEmpresaId] [int] NULL,
	[CidadeEvento] [varchar](100) NULL,
	[NaturezaEvento] [char](15) NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[EventoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ExtratoQualis]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ExtratoQualis](
	[AreaAvaliacaoPeriodicoQualis] [varchar](50) NOT NULL,
	[ExtratoPeriodicoQualis] [char](2) NOT NULL,
	[PeriodicoQualisId] [int] NOT NULL,
 CONSTRAINT [PK_ExtratoQualis] PRIMARY KEY CLUSTERED 
(
	[AreaAvaliacaoPeriodicoQualis] ASC,
	[PeriodicoQualisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FinanciamentoProjeto]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FinanciamentoProjeto](
	[ProjetoId] [int] NOT NULL,
	[InstituicaoEmpresaId] [int] NOT NULL,
 CONSTRAINT [PK_FinanciamentoProjeto] PRIMARY KEY CLUSTERED 
(
	[ProjetoId] ASC,
	[InstituicaoEmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[FormacaoAcademicaTitulacao]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormacaoAcademicaTitulacao](
	[ProfessorId] [int] NOT NULL,
	[SequenciaFormacaoAcademicaTitulacao] [int] NOT NULL,
	[NivelFormacaoAcademicaTitulacao] [varchar](50) NOT NULL,
	[TituloTrabalhoFinal] [varchar](260) NOT NULL,
	[TituloTrabalhoFinalEmIngles] [varchar](260) NOT NULL,
	[OrientadorId] [int] NULL,
	[InstituicaoEmpresaId] [int] NOT NULL,
	[CursoId] [int] NULL,
	[CodigoAreaCurso] [varchar](30) NULL,
	[SituacaoFormacaoAcademicaTitulacao] [char](12) NOT NULL,
	[AnoInicioFormacaoAcademicaTitulacao] [numeric](4, 0) NOT NULL,
	[AnoConclusaoFormacaoAcademicaTitulacao] [numeric](4, 0) NULL,
	[TemBolsaFormacaoAcademicaTitulacao] [bit] NULL,
	[AgenciaFinanciadoraId] [int] NULL,
	[TipoGraduacaoDoutorado] [varchar](50) NULL,
	[CargaHorariaFormacaoAcademicaTitulacao] [numeric](4, 0) NULL,
	[AnoObtencaoTituloFormacaoAcademicaTitulacao] [numeric](4, 0) NULL,
	[OrientadorCoTutelaId] [int] NULL,
	[InstituicaoEmpresaCoTutelaId] [int] NULL,
	[OrientadorSanduicheId] [int] NULL,
	[InstituicaoEmpresaSanduicheId] [int] NULL,
	[InstituicaoEmpresaOutraSanduicheId] [int] NULL,
	[OrgaoInstituicaoEmpresaId] [int] NULL,
	[CoOrientadorId] [int] NULL,
 CONSTRAINT [PK_FormacaoAcademicaTitulacao] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaFormacaoAcademicaTitulacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento](
	[ProfessorId] [int] NOT NULL,
	[SequenciaFormacaoAcademicaTitulacao] [int] NOT NULL,
	[AreaConhecimentoId] [int] NOT NULL,
 CONSTRAINT [PK_FormacaoAcademicaAreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaFormacaoAcademicaTitulacao] ASC,
	[AreaConhecimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[FormacaoAcademicaTitulacaoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave](
	[ProfessorId] [int] NOT NULL,
	[SequenciaFormacaoAcademicaTitulacao] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
 CONSTRAINT [PK_PalavraChaveFormacaoAcademicaTitulacao] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaFormacaoAcademicaTitulacao] ASC,
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Idioma]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Idioma](
	[Idioma] [varchar](50) NOT NULL,
	[IdiomaId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Idioma_1] PRIMARY KEY CLUSTERED 
(
	[IdiomaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[IdiomasProfessor]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[IdiomasProfessor](
	[ProfessorId] [int] NOT NULL,
	[IdiomaId] [int] NOT NULL,
	[ProeficienciaLeituraProfessor] [varchar](15) NULL,
	[ProeficienciaFalaProfessor] [varchar](15) NULL,
	[ProeficienciaEscritaProfessor] [varchar](15) NULL,
	[ProeficienciaCompreensaoProfessor] [varchar](15) NULL,
	[Idioma] [varchar](50) NULL,
 CONSTRAINT [PK_IdiomasProfessor] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[IdiomaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[InstituicaoEmpresa]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[InstituicaoEmpresa](
	[InstituicaoEmpresaId] [int] IDENTITY(1,1) NOT NULL,
	[NomeInstituicaoEmpresa] [varchar](300) NULL,
	[SiglaInstituicaoEmpresa] [varchar](25) NULL,
	[EnsinoInstituicaoEmpresa] [bit] NULL,
	[PaisInstituicaoEmpresa] [varchar](50) NULL,
 CONSTRAINT [PK_InstituicaoEmpresa] PRIMARY KEY CLUSTERED 
(
	[InstituicaoEmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[LinhaDePesquisa]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LinhaDePesquisa](
	[ProfessorId] [int] NOT NULL,
	[SequenciaLinhaDePesquisa] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
	[TituloLinhaDePesquisa] [varchar](250) NOT NULL,
	[ObjetivosLinhaDePesquisa] [varchar](2000) NOT NULL,
	[AtivaLinhaDePesquisa] [bit] NOT NULL,
 CONSTRAINT [PK_LinhaDePesquisa] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaLinhaDePesquisa] ASC,
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[OrgaoInstituicaoEmpresa]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrgaoInstituicaoEmpresa](
	[InstituicaoEmpresaId] [int] NOT NULL,
	[OrgaoInstituicaoEmpresaId] [int] IDENTITY(1,1) NOT NULL,
	[NomeOrgaoInstituicaoEmpresa] [varchar](200) NULL,
 CONSTRAINT [PK_OrgaoInstituicaoEmpresa] PRIMARY KEY CLUSTERED 
(
	[OrgaoInstituicaoEmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[OrientacaoSupervisao]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrientacaoSupervisao](
	[ProfessorId] [int] NOT NULL,
	[SequenciaOrientacaoSupervicao] [int] NOT NULL,
	[TipoOrientacaoSupervicao] [varchar](25) NOT NULL,
	[NaturezaOrientacaoSupervicao] [varchar](100) NULL,
	[TituloOrientacaoSupervicao] [varchar](350) NOT NULL,
	[AnoOrientacaoSupervicao] [numeric](4, 0) NOT NULL,
	[PaisOrientacaoSupervicao] [varchar](50) NULL,
	[IdiomaId] [int] NULL,
	[HomePageOrientacaoSupervicao] [varchar](300) NULL,
	[DOIOrientacaoSupervicao] [char](55) NULL,
	[TituloEmInglesOrientacaoSupervicao] [varchar](350) NULL,
	[NomeOrientandoOrientacaoSupervicao] [varchar](200) NULL,
	[InstituicaoEmpresaId] [int] NULL,
	[TemBolsaOrientacaoSupervicao] [bit] NULL,
	[AgenciaFinanciadoraId] [int] NULL,
	[PapelOrientacaoSupervicao] [varchar](25) NULL,
	[InformacoesAdicionaisOrientacaoSupervicao] [varchar](2000) NULL,
	[InformacoesAdicionaisEmInglesOrientacaoSupervicao] [varchar](2000) NULL,
	[CursoId] [int] NULL,
	[OrgaoInstituicaoEmpresaId] [int] NULL,
 CONSTRAINT [PK_OrientacaoSupervisao] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaOrientacaoSupervicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[OrientacaoSupervisaoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento](
	[ProfessorId] [int] NOT NULL,
	[SequenciaOrientacaoSupervicao] [int] NOT NULL,
	[AreaConhecimentoId] [int] NOT NULL,
 CONSTRAINT [PK_OrientacaoSupervisaoAreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaOrientacaoSupervicao] ASC,
	[AreaConhecimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[OrientacaoSupervisaoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrientacaoSupervisaoPalavraChave](
	[ProfessorId] [int] NOT NULL,
	[SequenciaOrientacaoSupervicao] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
 CONSTRAINT [PK_OrientacaoSupervisaoPalavraChave] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaOrientacaoSupervicao] ASC,
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orientador]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Orientador](
	[OrientadorId] [int] IDENTITY(1,1) NOT NULL,
	[NomeOrientador] [varchar](200) NOT NULL,
	[NumeroCurriculoOrientador] [char](20) NOT NULL,
	[ProfessorId] [int] NULL,
 CONSTRAINT [PK_Orientador] PRIMARY KEY CLUSTERED 
(
	[OrientadorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[PalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PalavraChave](
	[PalavraChaveId] [int] IDENTITY(1,1) NOT NULL,
	[PalavraChave] [varchar](200) NOT NULL,
	[ESetorAtividade] [bit] NULL,
 CONSTRAINT [PK_PalavraChave] PRIMARY KEY CLUSTERED 
(
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ParticipacaoBancaDeTrabalho]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParticipacaoBancaDeTrabalho](
	[BancaDeTrabalhoId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_ParticipacaoBancaDeTrabalho_1] PRIMARY KEY CLUSTERED 
(
	[BancaDeTrabalhoId] ASC,
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ParticipacaoBancaJulgadora]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParticipacaoBancaJulgadora](
	[BancaJulgadoraId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_ParticipacaoBancaJulgadora_1] PRIMARY KEY CLUSTERED 
(
	[BancaJulgadoraId] ASC,
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ParticipacaoEmProjeto]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParticipacaoEmProjeto](
	[ProjetoId] [int] NOT NULL,
	[ResponsavelParticipacaoEmProjeto] [bit] NULL,
	[ProfessorId] [int] NOT NULL,
 CONSTRAINT [PK_ParticipacaoEmProjeto] PRIMARY KEY CLUSTERED 
(
	[ProjetoId] ASC,
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ParticipacaoEvento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ParticipacaoEvento](
	[ProfessorId] [int] NOT NULL,
	[EventoId] [int] NOT NULL,
	[TipoParticipacaoEvento] [varchar](25) NULL,
	[FormaParticipacaoEvento] [varchar](25) NULL,
	[IdiomaId] [int] NULL,
	[TituloParticipacaoEvento] [varchar](400) NULL,
	[TituloEmInglesParticipacaoEvento] [varchar](400) NULL,
	[InformacoesAdicionaisParticipacaoEvento] [varchar](2000) NULL,
	[InformacoesAdicionaisEmInglesParticipacaoEvento] [varchar](2000) NULL,
	[MeioDivulgacaoParticipacaoEvento] [varchar](50) NULL,
	[HomePageParticipacaoEvento] [varchar](300) NULL,
	[DOIParticipacaoEvento] [char](55) NULL,
	[DivulgacaoCeTParticipacaoEvento] [bit] NULL,
	[SequenciaParticipacaoEvento] [int] NOT NULL,
 CONSTRAINT [PK_ParticipacaoEvento] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[EventoId] ASC,
	[SequenciaParticipacaoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ParticipacaoEventoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParticipacaoEventoAreaConhecimento](
	[EventoId] [int] NOT NULL,
	[AreaConhecimentoId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
	[SequenciaParticipacaoEvento] [int] NOT NULL,
 CONSTRAINT [PK_EventoAreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[EventoId] ASC,
	[AreaConhecimentoId] ASC,
	[ProfessorId] ASC,
	[SequenciaParticipacaoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ParticipacaoEventoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParticipacaoEventoPalavraChave](
	[EventoId] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
	[SequenciaParticipacaoEvento] [int] NOT NULL,
 CONSTRAINT [PK_EventoPalavraChave] PRIMARY KEY CLUSTERED 
(
	[EventoId] ASC,
	[PalavraChaveId] ASC,
	[ProfessorId] ASC,
	[SequenciaParticipacaoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PatenteRegistro]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PatenteRegistro](
	[ProducaoTecnicaId] [int] NOT NULL,
	[SequenciaPatenteRegistro] [int] NOT NULL,
	[TipoPatenteRegistro] [varchar](50) NOT NULL,
	[CodigoPatenteRegistro] [char](20) NOT NULL,
	[TituloPatenteRegistro] [varchar](300) NOT NULL,
	[DataPedidoPatenteRegistro] [date] NULL,
	[DataPedidoExamePatenteRegistro] [date] NULL,
	[DataConcessaoPatenteRegistro] [date] NULL,
	[NumeroDepositoPCTPatenteRegistro] [char](20) NULL,
	[DataDepositoPCTPatenteRegistro] [date] NULL,
	[NomeTitularPatenteRegistro] [varchar](200) NULL,
	[InstituicaoDepositoPatenteRegistro] [varchar](300) NULL,
 CONSTRAINT [PK_PatenteRegistro] PRIMARY KEY CLUSTERED 
(
	[ProducaoTecnicaId] ASC,
	[SequenciaPatenteRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[PeriodicoQualis]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PeriodicoQualis](
	[ISSNPeriodicoQualis] [char](8) NOT NULL,
	[TituloPeriodicoQualis] [varchar](200) NOT NULL,
	[PeriodicoQualisId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ClassificacaoQualis] PRIMARY KEY CLUSTERED 
(
	[PeriodicoQualisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[PremioOuTitulo]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PremioOuTitulo](
	[ProfessorId] [int] NOT NULL,
	[SequenciaPremioOuTitulo] [int] NOT NULL,
	[NomePremioOuTitulo] [varchar](250) NOT NULL,
	[EntidadePromotoraPremioOuTitulo] [varchar](150) NULL,
	[AnoPremioOuTitulo] [numeric](4, 0) NOT NULL,
	[NomePremioOuTituloEmIngles] [varchar](150) NULL,
 CONSTRAINT [PK_PremioOuTitulo] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaPremioOuTitulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ProducaoBibligraficaPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProducaoBibligraficaPalavraChave](
	[ProducaoBibliograficaId] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
 CONSTRAINT [PK_ProducaoBibligraficaPalavraChave] PRIMARY KEY CLUSTERED 
(
	[ProducaoBibliograficaId] ASC,
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProducaoBibliografica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProducaoBibliografica](
	[ProducaoBibliograficaId] [int] IDENTITY(1,1) NOT NULL,
	[NaturezaProducaoBibligrafica] [varchar](100) NOT NULL,
	[TipoProducaoBibligrafica] [varchar](50) NOT NULL,
	[TituloProducaoBibligrafica] [varchar](350) NOT NULL,
	[AnoProducaoBibligrafica] [numeric](4, 0) NOT NULL,
	[PaisProducaoBibligrafica] [varchar](20) NULL,
	[IdiomaId] [int] NULL,
	[MeioDivulgacaoProducaoBibligrafica] [char](15) NULL,
	[HomePageProducaoBibligrafica] [varchar](300) NULL,
	[DOIProducaoBibligrafica] [char](55) NULL,
	[ISBNProducaoBibligrafica] [char](20) NULL,
	[InformacoesAdicionaisProducaoBibligrafica] [varchar](2000) NULL,
	[DivulgacaoCeTProducaoBibligrafica] [bit] NOT NULL,
	[InformacoesAdicionaisEmInglesProducaoBibligrafica] [varchar](2000) NULL,
	[TituloEmInglesProducaoBibligrafica] [varchar](350) NULL,
	[PeriodicoQualisId] [int] NULL,
 CONSTRAINT [PK_ProducaoBibliografica] PRIMARY KEY CLUSTERED 
(
	[ProducaoBibliograficaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ProducaoBibliograficaAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProducaoBibliograficaAreaConhecimento](
	[ProducaoBibliograficaId] [int] NOT NULL,
	[AreaConhecimentoId] [int] NOT NULL,
 CONSTRAINT [PK_ProducaoBibliograficaAreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[ProducaoBibliograficaId] ASC,
	[AreaConhecimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProducaoTecnica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProducaoTecnica](
	[ProducaoTecnicaId] [int] IDENTITY(1,1) NOT NULL,
	[TituloProducaoTecnica] [varchar](350) NOT NULL,
	[TipoProducaoTecnica] [varchar](50) NOT NULL,
	[AnoProducaoTecnica] [numeric](4, 0) NOT NULL,
	[PaisProducaoTecnica] [varchar](50) NULL,
	[IdiomaId] [int] NULL,
	[MeioDivulgacaoProducaoTecnica] [varchar](50) NULL,
	[HomePageProducaoTecnica] [varchar](300) NULL,
	[DOIProducaoTecnica] [char](55) NULL,
	[DivulgacaoCeTProducaoTecnica] [bit] NULL,
	[PotencialInovacaoProducaoTecnica] [bit] NULL,
	[InformacoesAdicionaisProducaoTecnica] [varchar](2000) NULL,
	[PatentiadoOuRegistradoProducaoTecnica] [bit] NULL,
	[NaturezaProducaoTecnica] [varchar](100) NULL,
	[AgenciaFinanciadoraId] [int] NULL,
	[InformacoesAdicionaisEmInglesProducaoTecnica] [varchar](2000) NULL,
	[TituloEmInglesProducaoTecnica] [varchar](350) NULL,
 CONSTRAINT [PK_ProducaoTecnica] PRIMARY KEY CLUSTERED 
(
	[ProducaoTecnicaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ProducaoTecnicaAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProducaoTecnicaAreaConhecimento](
	[ProducaoTecnicaId] [int] NOT NULL,
	[AreaConhecimentoId] [int] NOT NULL,
 CONSTRAINT [PK_ProducaoTecnicaAreaConhecimento] PRIMARY KEY CLUSTERED 
(
	[ProducaoTecnicaId] ASC,
	[AreaConhecimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProducaoTecnicaPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProducaoTecnicaPalavraChave](
	[ProducaoTecnicaId] [int] NOT NULL,
	[PalavraChaveId] [int] NOT NULL,
 CONSTRAINT [PK_ProducaoTecnicaPalavraChave] PRIMARY KEY CLUSTERED 
(
	[ProducaoTecnicaId] ASC,
	[PalavraChaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Professor]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Professor](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCurriculo] [char](20) NOT NULL,
	[NomeProfessor] [varchar](200) NOT NULL,
	[NomeEmCitacoesProfessor] [varchar](300) NULL,
	[EnderecoResidencialId] [int] NULL,
	[LogradouroResidencial] [varchar](250) NULL,
	[EnderecoProfissionalId] [int] NULL,
	[LogradouroProfissional] [varchar](250) NULL,
	[InstituicaoEmpresaId] [int] NULL,
	[DataUltimaAtualizacaoCurriculo] [datetime] NOT NULL,
	[DataUltimaPublicacaoCurriculo] [date] NOT NULL,
	[LinkParaCurriculo] [varchar](150) NOT NULL,
	[UnidadeInstituicaoEmpresaId] [int] NULL,
	[OrgaoInstituicaoEmpresaId] [int] NULL,
	[NacionalidadeProfessor] [varchar](50) NULL,
	[PaisNascimentoProfessor] [varchar](50) NULL,
	[UFNascimentoProfessor] [char](2) NULL,
	[CidadeNascimentoProfessor] [varchar](50) NULL,
	[PaisNascionalidadeProfessor] [varchar](50) NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Projeto]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Projeto](
	[ProjetoId] [int] IDENTITY(1,1) NOT NULL,
	[InstituicaoEmpresaId] [int] NOT NULL,
	[AnoInicioProjeto] [numeric](4, 0) NOT NULL,
	[AnoFimProjeto] [numeric](4, 0) NULL,
	[NomeProjeto] [varchar](300) NOT NULL,
	[SituacaoProjeto] [char](12) NOT NULL,
	[NaturezaProjeto] [char](15) NOT NULL,
	[PotencialInovacao] [bit] NULL,
	[OrgaoInstituicaoEmpresaId] [int] NOT NULL,
	[UnidadeInstituicaoEmpresaId] [int] NOT NULL,
	[InformacoesAdicionaisProjeto] [varchar](4000) NULL,
	[InformacoesAdicionaisEmInglesProjeto] [varchar](4000) NULL,
	[NomeEmInglesProjeto] [varchar](300) NULL,
 CONSTRAINT [PK_Projeto] PRIMARY KEY CLUSTERED 
(
	[ProjetoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[UnidadeInstituicaoEmpresa]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UnidadeInstituicaoEmpresa](
	[InstituicaoEmpresaId] [int] NOT NULL,
	[NomeUnidadeInstituicaoEmpresa] [varchar](200) NULL,
	[LogradouroCompletoUnidadeInstituicaoEmpresa] [varchar](250) NULL,
	[UnidadeInstituicaoEmpresaId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_UnidadeInstituicaoEmpresa] PRIMARY KEY CLUSTERED 
(
	[UnidadeInstituicaoEmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[VinculoAtuacaoProfissional]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VinculoAtuacaoProfissional](
	[ProfessorId] [int] NOT NULL,
	[SequenciaVinculoAtuacaoProfissional] [int] NOT NULL,
	[InstituicaoEmpresaId] [int] NOT NULL,
	[SequenciaImportanciaVinculoAtuacaoProfissional] [int] NULL,
	[DataInicioVinculoAtuacaoProfissional] [date] NOT NULL,
	[DataTerminoVinculoAtuacaoProfissional] [date] NULL,
	[EnquadramentoFuncionalVinculoAtuacaoProfissional] [varchar](100) NULL,
	[TipoVinculoVinculoAtuacaoProfissional] [varchar](20) NULL,
	[DescricaoVinculoAtuacaoProfissional] [varchar](2000) NULL,
	[VinculoEmpregaticioVinculoAtuacaoProfissional] [bit] NULL,
 CONSTRAINT [PK_AtuacaoProfissional] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SequenciaVinculoAtuacaoProfissional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AreaAtuacao]  WITH CHECK ADD  CONSTRAINT [FK_AreaAtuacao_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[AreaAtuacao] CHECK CONSTRAINT [FK_AreaAtuacao_Professor]
GO

ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_OrgaoInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_Professor]
GO

ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_UnidadeInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[AutorProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoBibligrafica_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

ALTER TABLE [dbo].[AutorProducaoBibliografica] CHECK CONSTRAINT [FK_AutorProducaoBibligrafica_ProducaoBibliografica]
GO

ALTER TABLE [dbo].[AutorProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoBibligrafica_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[AutorProducaoBibliografica] CHECK CONSTRAINT [FK_AutorProducaoBibligrafica_Professor]
GO

ALTER TABLE [dbo].[AutorProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoTecnica_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

ALTER TABLE [dbo].[AutorProducaoTecnica] CHECK CONSTRAINT [FK_AutorProducaoTecnica_ProducaoTecnica]
GO

ALTER TABLE [dbo].[AutorProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoTecnica_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[AutorProducaoTecnica] CHECK CONSTRAINT [FK_AutorProducaoTecnica_Professor]
GO

ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_Curso] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
GO

ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_Curso]
GO

ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_Idioma1] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_Idioma1]
GO

ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_OrgaoInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento] CHECK CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_AreaConhecimento]
GO

ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento] CHECK CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_BancaDeTrabalho]
GO

ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave] CHECK CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_BancaDeTrabalho]
GO

ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave] CHECK CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_PalavraChave]
GO

ALTER TABLE [dbo].[BancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadora_Idioma1] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[BancaJulgadora] CHECK CONSTRAINT [FK_BancaJulgadora_Idioma1]
GO

ALTER TABLE [dbo].[BancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadora_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[BancaJulgadora] CHECK CONSTRAINT [FK_BancaJulgadora_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento] CHECK CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_AreaConhecimento]
GO

ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento] CHECK CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_BancaJulgadora]
GO

ALTER TABLE [dbo].[BancaJulgadoraPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraPalavraChave_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

ALTER TABLE [dbo].[BancaJulgadoraPalavraChave] CHECK CONSTRAINT [FK_BancaJulgadoraPalavraChave_BancaJulgadora]
GO

ALTER TABLE [dbo].[BancaJulgadoraPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[BancaJulgadoraPalavraChave] CHECK CONSTRAINT [FK_BancaJulgadoraPalavraChave_PalavraChave]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_AgenciaFinanciadora]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_AreaConhecimento]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_AtividadeProfissional] FOREIGN KEY([ProfessorId], [SequenciaAtividadeProfissional])
REFERENCES [dbo].[AtividadeProfissional] ([ProfessorId], [SequenciaAtividadeProfissional])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_AtividadeProfissional]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_BancaDeTrabalho]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_BancaJulgadora]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_Curso] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_Curso]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_FormacaoAcademicaTitulacao] FOREIGN KEY([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
REFERENCES [dbo].[FormacaoAcademicaTitulacao] ([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_FormacaoAcademicaTitulacao]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_Idioma] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_Idioma]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_OrgaoInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_OrientacaoSupervisao] FOREIGN KEY([ProfessorId], [SequenciaOrientacaoSupervicao])
REFERENCES [dbo].[OrientacaoSupervisao] ([ProfessorId], [SequenciaOrientacaoSupervicao])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_OrientacaoSupervisao]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_PalavraChave]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEmProjeto] FOREIGN KEY([ProjetoId], [ProfessorId])
REFERENCES [dbo].[ParticipacaoEmProjeto] ([ProjetoId], [ProfessorId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEmProjeto]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEvento] FOREIGN KEY([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
REFERENCES [dbo].[ParticipacaoEvento] ([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEvento]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_PremioOuTitulo] FOREIGN KEY([ProfessorId], [SequenciaPremioOuTitulo])
REFERENCES [dbo].[PremioOuTitulo] ([ProfessorId], [SequenciaPremioOuTitulo])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_PremioOuTitulo]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ProducaoBibliografica]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ProducaoTecnica]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_Professor]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_UnidadeInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_VinculoAtuacaoProfissional] FOREIGN KEY([ProfessorId], [SequenciaVinculoAtuacaoProfissional])
REFERENCES [dbo].[VinculoAtuacaoProfissional] ([ProfessorId], [SequenciaVinculoAtuacaoProfissional])
GO

ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_VinculoAtuacaoProfissional]
GO

ALTER TABLE [dbo].[ContatoProfessor]  WITH CHECK ADD  CONSTRAINT [FK_ContatoProfessor_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[ContatoProfessor] CHECK CONSTRAINT [FK_ContatoProfessor_Professor]
GO

ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [FK_Evento_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [FK_Evento_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[ExtratoQualis]  WITH CHECK ADD  CONSTRAINT [FK_ExtratoQualis_ClassificacaoQualis] FOREIGN KEY([PeriodicoQualisId])
REFERENCES [dbo].[PeriodicoQualis] ([PeriodicoQualisId])
GO

ALTER TABLE [dbo].[ExtratoQualis] CHECK CONSTRAINT [FK_ExtratoQualis_ClassificacaoQualis]
GO

ALTER TABLE [dbo].[FinanciamentoProjeto]  WITH CHECK ADD  CONSTRAINT [FK_FinanciamentoProjeto_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[FinanciamentoProjeto] CHECK CONSTRAINT [FK_FinanciamentoProjeto_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[FinanciamentoProjeto]  WITH CHECK ADD  CONSTRAINT [FK_FinanciamentoProjeto_Projeto] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projeto] ([ProjetoId])
GO

ALTER TABLE [dbo].[FinanciamentoProjeto] CHECK CONSTRAINT [FK_FinanciamentoProjeto_Projeto]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_AgenciaFinanciadora]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_CoOrientador] FOREIGN KEY([CoOrientadorId])
REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_CoOrientador]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_Curso] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_Curso]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaCoTutela] FOREIGN KEY([InstituicaoEmpresaCoTutelaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaCoTutela]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaOutraSanduiche] FOREIGN KEY([InstituicaoEmpresaOutraSanduicheId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaOutraSanduiche]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaSanduiche] FOREIGN KEY([InstituicaoEmpresaSanduicheId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaSanduiche]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrgaoInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_Orientador] FOREIGN KEY([OrientadorId])
REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_Orientador]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorCoTutela] FOREIGN KEY([OrientadorCoTutelaId])
REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorCoTutela]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorSanduiche] FOREIGN KEY([OrientadorSanduicheId])
REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorSanduiche]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_Professor]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento] CHECK CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_AreaConhecimento]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_FormacaoAcademicaTitulacao] FOREIGN KEY([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
REFERENCES [dbo].[FormacaoAcademicaTitulacao] ([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento] CHECK CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_FormacaoAcademicaTitulacao]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_FormacaoAcademicaTitulacao] FOREIGN KEY([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
REFERENCES [dbo].[FormacaoAcademicaTitulacao] ([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave] CHECK CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_FormacaoAcademicaTitulacao]
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave] CHECK CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_PalavraChave]
GO

ALTER TABLE [dbo].[IdiomasProfessor]  WITH CHECK ADD  CONSTRAINT [FK_IdiomasProfessor_Idioma1] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[IdiomasProfessor] CHECK CONSTRAINT [FK_IdiomasProfessor_Idioma1]
GO

ALTER TABLE [dbo].[IdiomasProfessor]  WITH CHECK ADD  CONSTRAINT [FK_IdiomasProfessor_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[IdiomasProfessor] CHECK CONSTRAINT [FK_IdiomasProfessor_Professor]
GO

ALTER TABLE [dbo].[LinhaDePesquisa]  WITH CHECK ADD  CONSTRAINT [FK_LinhaDePesquisa_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[LinhaDePesquisa] CHECK CONSTRAINT [FK_LinhaDePesquisa_PalavraChave]
GO

ALTER TABLE [dbo].[LinhaDePesquisa]  WITH CHECK ADD  CONSTRAINT [FK_LinhaDePesquisa_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[LinhaDePesquisa] CHECK CONSTRAINT [FK_LinhaDePesquisa_Professor]
GO

ALTER TABLE [dbo].[OrgaoInstituicaoEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_OrgaoInstituicaoEmpresaId_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[OrgaoInstituicaoEmpresa] CHECK CONSTRAINT [FK_OrgaoInstituicaoEmpresaId_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_AgenciaFinanciadora]
GO

ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_Curso] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_Curso]
GO

ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_Idioma1] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_Idioma1]
GO

ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_OrgaoInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_Professor]
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento] CHECK CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_AreaConhecimento]
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_OrientacaoSupervisao] FOREIGN KEY([ProfessorId], [SequenciaOrientacaoSupervicao])
REFERENCES [dbo].[OrientacaoSupervisao] ([ProfessorId], [SequenciaOrientacaoSupervicao])
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento] CHECK CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_OrientacaoSupervisao]
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_OrientacaoSupervisao] FOREIGN KEY([ProfessorId], [SequenciaOrientacaoSupervicao])
REFERENCES [dbo].[OrientacaoSupervisao] ([ProfessorId], [SequenciaOrientacaoSupervicao])
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave] CHECK CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_OrientacaoSupervisao]
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave] CHECK CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_PalavraChave]
GO

ALTER TABLE [dbo].[Orientador]  WITH CHECK ADD  CONSTRAINT [FK_Orientador_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[Orientador] CHECK CONSTRAINT [FK_Orientador_Professor]
GO

ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho] CHECK CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_BancaDeTrabalho]
GO

ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho] CHECK CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_Professor]
GO

ALTER TABLE [dbo].[ParticipacaoBancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaJulgadora_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

ALTER TABLE [dbo].[ParticipacaoBancaJulgadora] CHECK CONSTRAINT [FK_ParticipacaoBancaJulgadora_BancaJulgadora]
GO

ALTER TABLE [dbo].[ParticipacaoBancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaJulgadora_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[ParticipacaoBancaJulgadora] CHECK CONSTRAINT [FK_ParticipacaoBancaJulgadora_Professor]
GO

ALTER TABLE [dbo].[ParticipacaoEmProjeto]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEmProjeto_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[ParticipacaoEmProjeto] CHECK CONSTRAINT [FK_ParticipacaoEmProjeto_Professor]
GO

ALTER TABLE [dbo].[ParticipacaoEmProjeto]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEmProjeto_Projeto] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projeto] ([ProjetoId])
GO

ALTER TABLE [dbo].[ParticipacaoEmProjeto] CHECK CONSTRAINT [FK_ParticipacaoEmProjeto_Projeto]
GO

ALTER TABLE [dbo].[ParticipacaoEvento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEvento_Evento] FOREIGN KEY([EventoId])
REFERENCES [dbo].[Evento] ([EventoId])
GO

ALTER TABLE [dbo].[ParticipacaoEvento] CHECK CONSTRAINT [FK_ParticipacaoEvento_Evento]
GO

ALTER TABLE [dbo].[ParticipacaoEvento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEvento_Idioma1] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[ParticipacaoEvento] CHECK CONSTRAINT [FK_ParticipacaoEvento_Idioma1]
GO

ALTER TABLE [dbo].[ParticipacaoEvento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEvento_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[ParticipacaoEvento] CHECK CONSTRAINT [FK_ParticipacaoEvento_Professor]
GO

ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_EventoAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento] CHECK CONSTRAINT [FK_EventoAreaConhecimento_AreaConhecimento]
GO

ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEventoAreaConhecimento_ParticipacaoEvento1] FOREIGN KEY([EventoId], [ProfessorId], [SequenciaParticipacaoEvento])
REFERENCES [dbo].[ParticipacaoEvento] ([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
GO

ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento] CHECK CONSTRAINT [FK_ParticipacaoEventoAreaConhecimento_ParticipacaoEvento1]
GO

ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_EventoPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave] CHECK CONSTRAINT [FK_EventoPalavraChave_PalavraChave]
GO

ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEventoPalavraChave_ParticipacaoEvento1] FOREIGN KEY([EventoId], [ProfessorId], [SequenciaParticipacaoEvento])
REFERENCES [dbo].[ParticipacaoEvento] ([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
GO

ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave] CHECK CONSTRAINT [FK_ParticipacaoEventoPalavraChave_ParticipacaoEvento1]
GO

ALTER TABLE [dbo].[PatenteRegistro]  WITH CHECK ADD  CONSTRAINT [FK_PatenteRegistro_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

ALTER TABLE [dbo].[PatenteRegistro] CHECK CONSTRAINT [FK_PatenteRegistro_ProducaoTecnica]
GO

ALTER TABLE [dbo].[PremioOuTitulo]  WITH CHECK ADD  CONSTRAINT [FK_PremioOuTitulo_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[PremioOuTitulo] CHECK CONSTRAINT [FK_PremioOuTitulo_Professor]
GO

ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave] CHECK CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_PalavraChave]
GO

ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave] CHECK CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_ProducaoBibliografica]
GO

ALTER TABLE [dbo].[ProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliografica_Idioma1] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[ProducaoBibliografica] CHECK CONSTRAINT [FK_ProducaoBibliografica_Idioma1]
GO

ALTER TABLE [dbo].[ProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliografica_PeriodicoQualis] FOREIGN KEY([PeriodicoQualisId])
REFERENCES [dbo].[PeriodicoQualis] ([PeriodicoQualisId])
GO

ALTER TABLE [dbo].[ProducaoBibliografica] CHECK CONSTRAINT [FK_ProducaoBibliografica_PeriodicoQualis]
GO

ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_AreaConhecimento]
GO

ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_ProducaoBibliografica]
GO

ALTER TABLE [dbo].[ProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnica_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

ALTER TABLE [dbo].[ProducaoTecnica] CHECK CONSTRAINT [FK_ProducaoTecnica_AgenciaFinanciadora]
GO

ALTER TABLE [dbo].[ProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnica_Idioma1] FOREIGN KEY([IdiomaId])
REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

ALTER TABLE [dbo].[ProducaoTecnica] CHECK CONSTRAINT [FK_ProducaoTecnica_Idioma1]
GO

ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_AreaConhecimento]
GO

ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_ProducaoTecnica]
GO

ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave] CHECK CONSTRAINT [FK_ProducaoTecnicaPalavraChave_PalavraChave]
GO

ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaPalavraChave_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave] CHECK CONSTRAINT [FK_ProducaoTecnicaPalavraChave_ProducaoTecnica]
GO

ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_EnderecoProfissional] FOREIGN KEY([EnderecoProfissionalId])
REFERENCES [dbo].[Endereco] ([EnderecoId])
GO

ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_EnderecoProfissional]
GO

ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_EnderecoResidencial] FOREIGN KEY([EnderecoResidencialId])
REFERENCES [dbo].[Endereco] ([EnderecoId])
GO

ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_EnderecoResidencial]
GO

ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_OrgaoInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_UnidadeInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Projeto_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Projeto_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Projeto_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Projeto_OrgaoInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Projeto_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Projeto_UnidadeInstituicaoEmpresa]
GO

ALTER TABLE [dbo].[UnidadeInstituicaoEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeInstituicaoEmpresaId_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[UnidadeInstituicaoEmpresa] CHECK CONSTRAINT [FK_UnidadeInstituicaoEmpresaId_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[VinculoAtuacaoProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtuacaoProfissional_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

ALTER TABLE [dbo].[VinculoAtuacaoProfissional] CHECK CONSTRAINT [FK_AtuacaoProfissional_InstituicaoEmpresa]
GO

ALTER TABLE [dbo].[VinculoAtuacaoProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtuacaoProfissional_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO

ALTER TABLE [dbo].[VinculoAtuacaoProfissional] CHECK CONSTRAINT [FK_AtuacaoProfissional_Professor]
GO


