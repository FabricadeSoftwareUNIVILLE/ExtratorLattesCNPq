IF (NOT EXISTS(SELECT 1 FROM sysobjects WHERE xtype = 'U' and name = 'ControleVersaoBanco')) 
BEGIN
	CREATE TABLE [dbo].[ControleVersaoBanco](
		[VersaoBanco] [char](6) NOT NULL,
		[DataAtualizacao] [datetime] NOT NULL,
	 CONSTRAINT [PK_ControleVersaoBanco] PRIMARY KEY CLUSTERED 
	(
		[VersaoBanco] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END

/****** Object:  Table [dbo].[AgenciaFinanciadora]    Script Date: 09/06/2016 12:06:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[AgenciaFinanciadora](
		[AgenciaFinanciadoraId] [int] IDENTITY(1,1) NOT NULL,
		[NomeAgenciaFinanciadora] [varchar](500) NULL,
	 CONSTRAINT [PK_AgenciaFinanciadora] PRIMARY KEY CLUSTERED 
	(
		[AgenciaFinanciadoraId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[AutorProducaoBibliografica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[AutorProducaoBibliografica](
		[ProducaoBibliograficaId] [int] NOT NULL,
		[ProfessorId] [int] NOT NULL,
	 CONSTRAINT [PK_AutorProducaoBibliografica] PRIMARY KEY CLUSTERED 
	(
		[ProducaoBibliograficaId] ASC,
		[ProfessorId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[AutorProducaoTecnica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[AutorProducaoTecnica](
		[ProducaoTecnicaId] [int] NOT NULL,
		[ProfessorId] [int] NOT NULL,
	 CONSTRAINT [PK_AutorProducaoTecnica_1] PRIMARY KEY CLUSTERED 
	(
		[ProducaoTecnicaId] ASC,
		[ProfessorId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[BancaDeTrabalho]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[BancaDeTrabalhoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[BancaDeTrabalhoAreaConhecimento](
		[BancaDeTrabalhoId] [int] NOT NULL,
		[AreaConhecimentoId] [int] NOT NULL,
	 CONSTRAINT [PK_BancaDeTrabalhoAreaConhecimento] PRIMARY KEY CLUSTERED 
	(
		[BancaDeTrabalhoId] ASC,
		[AreaConhecimentoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[BancaDeTrabalhoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[BancaDeTrabalhoPalavraChave](
		[BancaDeTrabalhoId] [int] NOT NULL,
		[PalavraChaveId] [int] NOT NULL,
	 CONSTRAINT [PK_BancaDeTrabalhoPalavraChave] PRIMARY KEY CLUSTERED 
	(
		[BancaDeTrabalhoId] ASC,
		[PalavraChaveId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[BancaJulgadora]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[BancaJulgadoraAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[BancaJulgadoraAreaConhecimento](
		[BancaJulgadoraId] [int] NOT NULL,
		[AreaConhecimentoId] [int] NOT NULL,
	 CONSTRAINT [PK_BancaJulgadoraAreaConhecimento] PRIMARY KEY CLUSTERED 
	(
		[BancaJulgadoraId] ASC,
		[AreaConhecimentoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[BancaJulgadoraPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[BancaJulgadoraPalavraChave](
		[BancaJulgadoraId] [int] NOT NULL,
		[PalavraChaveId] [int] NOT NULL,
	 CONSTRAINT [PK_BancaJulgadoraPalavraChave] PRIMARY KEY CLUSTERED 
	(
		[BancaJulgadoraId] ASC,
		[PalavraChaveId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[BaseDeConsulta]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
		[OrientacaoSupervisaoId] [char](23) NULL,
		[PremioOuTituloId] [char](23) NULL,
		[VinculoAtuacaoProfissionalId] [char](23) NULL,
	 CONSTRAINT [PK_BaseDeConsulta] PRIMARY KEY CLUSTERED 
	(
		[ProfessorId] ASC,
		[AnoBaseDeConsulta] ASC,
		[SequenciaBaseDeConsulta] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[Evento](
		[EventoId] [int] IDENTITY(1,1) NOT NULL,
		[AnoEvento] [numeric](4, 0) NOT NULL,
		[PaisEvento] [varchar](50) NULL,
		[NomeEvento] [varchar](300) NULL,
		[InstituicaoEmpresaId] [int] NULL,
		[CidadeEvento] [varchar](500) NULL,
		[NaturezaEvento] [char](15) NULL,
	 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
	(
		[EventoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FinanciamentoProjeto]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[FinanciamentoProjeto](
		[ProjetoId] [int] NOT NULL,
		[InstituicaoEmpresaId] [int] NOT NULL,
	 CONSTRAINT [PK_FinanciamentoProjeto] PRIMARY KEY CLUSTERED 
	(
		[ProjetoId] ASC,
		[InstituicaoEmpresaId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[FormacaoAcademicaTitulacao]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

/****** Object:  Table [dbo].[FormacaoAcademicaTitulacaoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

/****** Object:  Table [dbo].[Idioma]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[Idioma](
		[Idioma] [varchar](50) NOT NULL,
		[IdiomaId] [int] IDENTITY(1,1) NOT NULL,
	 CONSTRAINT [PK_Idioma_1] PRIMARY KEY CLUSTERED 
	(
		[IdiomaId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[InstituicaoEmpresa](
		[InstituicaoEmpresaId] [int] IDENTITY(1,1) NOT NULL,
		[NomeInstituicaoEmpresa] [varchar](300) NULL,
		[SiglaInstituicaoEmpresa] [varchar](100) NULL,
		[EnsinoInstituicaoEmpresa] [bit] NULL,
		[PaisInstituicaoEmpresa] [varchar](50) NULL,
	 CONSTRAINT [PK_InstituicaoEmpresa] PRIMARY KEY CLUSTERED 
	(
		[InstituicaoEmpresaId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[LinhaDePesquisa](
		[ProfessorId] [int] NOT NULL,
		[SequenciaLinhaDePesquisa] [int] NOT NULL,
		[PalavraChaveId] [int] NOT NULL,
		[TituloLinhaDePesquisa] [varchar](1000) NOT NULL,
		[ObjetivosLinhaDePesquisa] [varchar](5000) NOT NULL,
		[AtivaLinhaDePesquisa] [bit] NOT NULL,
	 CONSTRAINT [PK_LinhaDePesquisa] PRIMARY KEY CLUSTERED 
	(
		[ProfessorId] ASC,
		[SequenciaLinhaDePesquisa] ASC,
		[PalavraChaveId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[OrgaoInstituicaoEmpresa](
		[InstituicaoEmpresaId] [int] NOT NULL,
		[OrgaoInstituicaoEmpresaId] [int] IDENTITY(1,1) NOT NULL,
		[NomeOrgaoInstituicaoEmpresa] [varchar](200) NULL,
	 CONSTRAINT [PK_OrgaoInstituicaoEmpresa] PRIMARY KEY CLUSTERED 
	(
		[OrgaoInstituicaoEmpresaId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[OrientacaoSupervisao](
		[ProfessorId] [int] NOT NULL,
		[SequenciaOrientacaoSupervicao] [int] NOT NULL,
		[TipoOrientacaoSupervicao] [varchar](25) NOT NULL,
		[NaturezaOrientacaoSupervicao] [varchar](500) NULL,
		[TituloOrientacaoSupervicao] [varchar](350) NOT NULL,
		[AnoOrientacaoSupervicao] [numeric](4, 0) NOT NULL,
		[PaisOrientacaoSupervicao] [varchar](50) NULL,
		[IdiomaId] [int] NULL,
		[HomePageOrientacaoSupervicao] [varchar](300) NULL,
		[DOIOrientacaoSupervicao] [char](55) NULL,
		[TituloEmInglesOrientacaoSupervicao] [varchar](1750) NULL,
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[OrientacaoSupervisaoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

/****** Object:  Table [dbo].[OrientacaoSupervisaoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

/****** Object:  Table [dbo].[Orientador]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[PalavraChave](
		[PalavraChaveId] [int] IDENTITY(1,1) NOT NULL,
		[PalavraChave] [varchar](200) NOT NULL,
		[ESetorAtividade] [bit] NULL,
	 CONSTRAINT [PK_PalavraChave] PRIMARY KEY CLUSTERED 
	(
		[PalavraChaveId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ParticipacaoBancaDeTrabalho]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[ParticipacaoBancaDeTrabalho](
		[BancaDeTrabalhoId] [int] NOT NULL,
		[ProfessorId] [int] NOT NULL,
	 CONSTRAINT [PK_ParticipacaoBancaDeTrabalho_1] PRIMARY KEY CLUSTERED 
	(
		[BancaDeTrabalhoId] ASC,
		[ProfessorId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[ParticipacaoBancaJulgadora]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[ParticipacaoBancaJulgadora](
		[BancaJulgadoraId] [int] NOT NULL,
		[ProfessorId] [int] NOT NULL,
	 CONSTRAINT [PK_ParticipacaoBancaJulgadora_1] PRIMARY KEY CLUSTERED 
	(
		[BancaJulgadoraId] ASC,
		[ProfessorId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[ParticipacaoEmProjeto]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

/****** Object:  Table [dbo].[ParticipacaoEvento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[ParticipacaoEvento](
		[ProfessorId] [int] NOT NULL,
		[EventoId] [int] NOT NULL,
		[TipoParticipacaoEvento] [varchar](25) NULL,
		[FormaParticipacaoEvento] [varchar](25) NULL,
		[IdiomaId] [int] NULL,
		[TituloParticipacaoEvento] [varchar](400) NULL,
		[TituloEmInglesParticipacaoEvento] [varchar](400) NULL,
		[InformacoesAdicionaisParticipacaoEvento] [varchar](5000) NULL,
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ParticipacaoEventoAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

/****** Object:  Table [dbo].[ParticipacaoEventoPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

/****** Object:  Table [dbo].[PatenteRegistro]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[PeriodicoQualis](
		[ISSNPeriodicoQualis] [char](8) NOT NULL,
		[TituloPeriodicoQualis] [varchar](200) NOT NULL,
		[PeriodicoQualisId] [int] IDENTITY(1,1) NOT NULL,
	 CONSTRAINT [PK_ClassificacaoQualis] PRIMARY KEY CLUSTERED 
	(
		[PeriodicoQualisId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ProducaoBibligraficaPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[ProducaoBibligraficaPalavraChave](
		[ProducaoBibliograficaId] [int] NOT NULL,
		[PalavraChaveId] [int] NOT NULL,
	 CONSTRAINT [PK_ProducaoBibligraficaPalavraChave] PRIMARY KEY CLUSTERED 
	(
		[ProducaoBibliograficaId] ASC,
		[PalavraChaveId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[ProducaoBibliografica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ProducaoBibliograficaAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[ProducaoBibliograficaAreaConhecimento](
		[ProducaoBibliograficaId] [int] NOT NULL,
		[AreaConhecimentoId] [int] NOT NULL,
	 CONSTRAINT [PK_ProducaoBibliograficaAreaConhecimento] PRIMARY KEY CLUSTERED 
	(
		[ProducaoBibliograficaId] ASC,
		[AreaConhecimentoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[ProducaoTecnica]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
		[NaturezaProducaoTecnica] [varchar](500) NULL,
		[AgenciaFinanciadoraId] [int] NULL,
		[InformacoesAdicionaisEmInglesProducaoTecnica] [varchar](2000) NULL,
		[TituloEmInglesProducaoTecnica] [varchar](350) NULL,
	 CONSTRAINT [PK_ProducaoTecnica] PRIMARY KEY CLUSTERED 
	(
		[ProducaoTecnicaId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ProducaoTecnicaAreaConhecimento]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[ProducaoTecnicaAreaConhecimento](
		[ProducaoTecnicaId] [int] NOT NULL,
		[AreaConhecimentoId] [int] NOT NULL,
	 CONSTRAINT [PK_ProducaoTecnicaAreaConhecimento] PRIMARY KEY CLUSTERED 
	(
		[ProducaoTecnicaId] ASC,
		[AreaConhecimentoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[ProducaoTecnicaPalavraChave]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
	CREATE TABLE [dbo].[ProducaoTecnicaPalavraChave](
		[ProducaoTecnicaId] [int] NOT NULL,
		[PalavraChaveId] [int] NOT NULL,
	 CONSTRAINT [PK_ProducaoTecnicaPalavraChave] PRIMARY KEY CLUSTERED 
	(
		[ProducaoTecnicaId] ASC,
		[PalavraChaveId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[Professor]    Script Date: 09/06/2016 12:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
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

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000')) BEGIN 
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
END
GO

SET ANSI_PADDING OFF
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AreaAtuacao]  WITH CHECK ADD  CONSTRAINT [FK_AreaAtuacao_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AreaAtuacao] CHECK CONSTRAINT [FK_AreaAtuacao_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
	REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_OrgaoInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProfissional_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
	REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AtividadeProfissional] CHECK CONSTRAINT [FK_AtividadeProfissional_UnidadeInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoBibligrafica_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
	REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoBibliografica] CHECK CONSTRAINT [FK_AutorProducaoBibligrafica_ProducaoBibliografica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoBibligrafica_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoBibliografica] CHECK CONSTRAINT [FK_AutorProducaoBibligrafica_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoTecnica_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
	REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoTecnica] CHECK CONSTRAINT [FK_AutorProducaoTecnica_ProducaoTecnica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_AutorProducaoTecnica_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[AutorProducaoTecnica] CHECK CONSTRAINT [FK_AutorProducaoTecnica_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_Curso] FOREIGN KEY([CursoId])
	REFERENCES [dbo].[Curso] ([CursoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_Curso]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_Idioma1] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_Idioma1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalho_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
	REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalho] CHECK CONSTRAINT [FK_BancaDeTrabalho_OrgaoInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento] CHECK CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
	REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoAreaConhecimento] CHECK CONSTRAINT [FK_BancaDeTrabalhoAreaConhecimento_BancaDeTrabalho]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
	REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave] CHECK CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_BancaDeTrabalho]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaDeTrabalhoPalavraChave] CHECK CONSTRAINT [FK_BancaDeTrabalhoPalavraChave_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadora_Idioma1] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadora] CHECK CONSTRAINT [FK_BancaJulgadora_Idioma1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadora_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadora] CHECK CONSTRAINT [FK_BancaJulgadora_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento] CHECK CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
	REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraAreaConhecimento] CHECK CONSTRAINT [FK_BancaJulgadoraAreaConhecimento_BancaJulgadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraPalavraChave_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
	REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraPalavraChave] CHECK CONSTRAINT [FK_BancaJulgadoraPalavraChave_BancaJulgadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_BancaJulgadoraPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BancaJulgadoraPalavraChave] CHECK CONSTRAINT [FK_BancaJulgadoraPalavraChave_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
	REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_AgenciaFinanciadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_AtividadeProfissional] FOREIGN KEY([ProfessorId], [SequenciaAtividadeProfissional])
	REFERENCES [dbo].[AtividadeProfissional] ([ProfessorId], [SequenciaAtividadeProfissional])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_AtividadeProfissional]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
	REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_BancaDeTrabalho]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
	REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_BancaJulgadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_Curso] FOREIGN KEY([CursoId])
	REFERENCES [dbo].[Curso] ([CursoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_Curso]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_FormacaoAcademicaTitulacao] FOREIGN KEY([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
	REFERENCES [dbo].[FormacaoAcademicaTitulacao] ([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_FormacaoAcademicaTitulacao]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_Idioma] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_Idioma]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
	REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_OrgaoInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_OrientacaoSupervisao] FOREIGN KEY([ProfessorId], [SequenciaOrientacaoSupervicao])
	REFERENCES [dbo].[OrientacaoSupervisao] ([ProfessorId], [SequenciaOrientacaoSupervicao])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_OrientacaoSupervisao]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEmProjeto] FOREIGN KEY([ProjetoId], [ProfessorId])
	REFERENCES [dbo].[ParticipacaoEmProjeto] ([ProjetoId], [ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEmProjeto]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEvento] FOREIGN KEY([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
	REFERENCES [dbo].[ParticipacaoEvento] ([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ParticipacaoEvento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_PremioOuTitulo] FOREIGN KEY([ProfessorId], [SequenciaPremioOuTitulo])
	REFERENCES [dbo].[PremioOuTitulo] ([ProfessorId], [SequenciaPremioOuTitulo])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_PremioOuTitulo]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
	REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ProducaoBibliografica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
	REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_ProducaoTecnica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
	REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_UnidadeInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta]  WITH CHECK ADD  CONSTRAINT [FK_BaseDeConsulta_VinculoAtuacaoProfissional] FOREIGN KEY([ProfessorId], [SequenciaVinculoAtuacaoProfissional])
	REFERENCES [dbo].[VinculoAtuacaoProfissional] ([ProfessorId], [SequenciaVinculoAtuacaoProfissional])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[BaseDeConsulta] CHECK CONSTRAINT [FK_BaseDeConsulta_VinculoAtuacaoProfissional]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ContatoProfessor]  WITH CHECK ADD  CONSTRAINT [FK_ContatoProfessor_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ContatoProfessor] CHECK CONSTRAINT [FK_ContatoProfessor_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [FK_Evento_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [FK_Evento_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ExtratoQualis]  WITH CHECK ADD  CONSTRAINT [FK_ExtratoQualis_ClassificacaoQualis] FOREIGN KEY([PeriodicoQualisId])
	REFERENCES [dbo].[PeriodicoQualis] ([PeriodicoQualisId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ExtratoQualis] CHECK CONSTRAINT [FK_ExtratoQualis_ClassificacaoQualis]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FinanciamentoProjeto]  WITH CHECK ADD  CONSTRAINT [FK_FinanciamentoProjeto_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FinanciamentoProjeto] CHECK CONSTRAINT [FK_FinanciamentoProjeto_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FinanciamentoProjeto]  WITH CHECK ADD  CONSTRAINT [FK_FinanciamentoProjeto_Projeto] FOREIGN KEY([ProjetoId])
	REFERENCES [dbo].[Projeto] ([ProjetoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FinanciamentoProjeto] CHECK CONSTRAINT [FK_FinanciamentoProjeto_Projeto]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
	REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_AgenciaFinanciadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_CoOrientador] FOREIGN KEY([CoOrientadorId])
	REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_CoOrientador]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_Curso] FOREIGN KEY([CursoId])
	REFERENCES [dbo].[Curso] ([CursoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_Curso]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaCoTutela] FOREIGN KEY([InstituicaoEmpresaCoTutelaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaCoTutela]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaOutraSanduiche] FOREIGN KEY([InstituicaoEmpresaOutraSanduicheId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaOutraSanduiche]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaSanduiche] FOREIGN KEY([InstituicaoEmpresaSanduicheId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaSanduiche]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
	REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrgaoInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_Orientador] FOREIGN KEY([OrientadorId])
	REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_Orientador]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorCoTutela] FOREIGN KEY([OrientadorCoTutelaId])
	REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorCoTutela]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorSanduiche] FOREIGN KEY([OrientadorSanduicheId])
	REFERENCES [dbo].[Orientador] ([OrientadorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_OrientadorSanduiche]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaTitulacao_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacao] CHECK CONSTRAINT [FK_FormacaoAcademicaTitulacao_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento] CHECK CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_FormacaoAcademicaTitulacao] FOREIGN KEY([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
	REFERENCES [dbo].[FormacaoAcademicaTitulacao] ([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoAreaConhecimento] CHECK CONSTRAINT [FK_FormacaoAcademicaAreaConhecimento_FormacaoAcademicaTitulacao]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_FormacaoAcademicaTitulacao] FOREIGN KEY([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
	REFERENCES [dbo].[FormacaoAcademicaTitulacao] ([ProfessorId], [SequenciaFormacaoAcademicaTitulacao])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave] CHECK CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_FormacaoAcademicaTitulacao]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[FormacaoAcademicaTitulacaoPalavraChave] CHECK CONSTRAINT [FK_PalavraChaveFormacaoAcademicaTitulacao_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[IdiomasProfessor]  WITH CHECK ADD  CONSTRAINT [FK_IdiomasProfessor_Idioma1] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[IdiomasProfessor] CHECK CONSTRAINT [FK_IdiomasProfessor_Idioma1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[IdiomasProfessor]  WITH CHECK ADD  CONSTRAINT [FK_IdiomasProfessor_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[IdiomasProfessor] CHECK CONSTRAINT [FK_IdiomasProfessor_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[LinhaDePesquisa]  WITH CHECK ADD  CONSTRAINT [FK_LinhaDePesquisa_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[LinhaDePesquisa] CHECK CONSTRAINT [FK_LinhaDePesquisa_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[LinhaDePesquisa]  WITH CHECK ADD  CONSTRAINT [FK_LinhaDePesquisa_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[LinhaDePesquisa] CHECK CONSTRAINT [FK_LinhaDePesquisa_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrgaoInstituicaoEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_OrgaoInstituicaoEmpresaId_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrgaoInstituicaoEmpresa] CHECK CONSTRAINT [FK_OrgaoInstituicaoEmpresaId_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
	REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_AgenciaFinanciadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_Curso] FOREIGN KEY([CursoId])
	REFERENCES [dbo].[Curso] ([CursoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_Curso]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_Idioma1] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_Idioma1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
	REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_OrgaoInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisao_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisao] CHECK CONSTRAINT [FK_OrientacaoSupervisao_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento] CHECK CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_OrientacaoSupervisao] FOREIGN KEY([ProfessorId], [SequenciaOrientacaoSupervicao])
	REFERENCES [dbo].[OrientacaoSupervisao] ([ProfessorId], [SequenciaOrientacaoSupervicao])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoAreaConhecimento] CHECK CONSTRAINT [FK_OrientacaoSupervisaoAreaConhecimento_OrientacaoSupervisao]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_OrientacaoSupervisao] FOREIGN KEY([ProfessorId], [SequenciaOrientacaoSupervicao])
	REFERENCES [dbo].[OrientacaoSupervisao] ([ProfessorId], [SequenciaOrientacaoSupervicao])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave] CHECK CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_OrientacaoSupervisao]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[OrientacaoSupervisaoPalavraChave] CHECK CONSTRAINT [FK_OrientacaoSupervisaoPalavraChave_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Orientador]  WITH CHECK ADD  CONSTRAINT [FK_Orientador_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Orientador] CHECK CONSTRAINT [FK_Orientador_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_BancaDeTrabalho] FOREIGN KEY([BancaDeTrabalhoId])
	REFERENCES [dbo].[BancaDeTrabalho] ([BancaDeTrabalhoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho] CHECK CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_BancaDeTrabalho]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaDeTrabalho] CHECK CONSTRAINT [FK_ParticipacaoBancaDeTrabalho_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaJulgadora_BancaJulgadora] FOREIGN KEY([BancaJulgadoraId])
	REFERENCES [dbo].[BancaJulgadora] ([BancaJulgadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaJulgadora] CHECK CONSTRAINT [FK_ParticipacaoBancaJulgadora_BancaJulgadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaJulgadora]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoBancaJulgadora_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoBancaJulgadora] CHECK CONSTRAINT [FK_ParticipacaoBancaJulgadora_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEmProjeto]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEmProjeto_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEmProjeto] CHECK CONSTRAINT [FK_ParticipacaoEmProjeto_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEmProjeto]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEmProjeto_Projeto] FOREIGN KEY([ProjetoId])
	REFERENCES [dbo].[Projeto] ([ProjetoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEmProjeto] CHECK CONSTRAINT [FK_ParticipacaoEmProjeto_Projeto]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEvento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEvento_Evento] FOREIGN KEY([EventoId])
	REFERENCES [dbo].[Evento] ([EventoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEvento] CHECK CONSTRAINT [FK_ParticipacaoEvento_Evento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEvento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEvento_Idioma1] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEvento] CHECK CONSTRAINT [FK_ParticipacaoEvento_Idioma1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEvento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEvento_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEvento] CHECK CONSTRAINT [FK_ParticipacaoEvento_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_EventoAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento] CHECK CONSTRAINT [FK_EventoAreaConhecimento_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEventoAreaConhecimento_ParticipacaoEvento1] FOREIGN KEY([EventoId], [ProfessorId], [SequenciaParticipacaoEvento])
	REFERENCES [dbo].[ParticipacaoEvento] ([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoAreaConhecimento] CHECK CONSTRAINT [FK_ParticipacaoEventoAreaConhecimento_ParticipacaoEvento1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_EventoPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave] CHECK CONSTRAINT [FK_EventoPalavraChave_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ParticipacaoEventoPalavraChave_ParticipacaoEvento1] FOREIGN KEY([EventoId], [ProfessorId], [SequenciaParticipacaoEvento])
	REFERENCES [dbo].[ParticipacaoEvento] ([ProfessorId], [EventoId], [SequenciaParticipacaoEvento])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ParticipacaoEventoPalavraChave] CHECK CONSTRAINT [FK_ParticipacaoEventoPalavraChave_ParticipacaoEvento1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[PatenteRegistro]  WITH CHECK ADD  CONSTRAINT [FK_PatenteRegistro_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
	REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[PatenteRegistro] CHECK CONSTRAINT [FK_PatenteRegistro_ProducaoTecnica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[PremioOuTitulo]  WITH CHECK ADD  CONSTRAINT [FK_PremioOuTitulo_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[PremioOuTitulo] CHECK CONSTRAINT [FK_PremioOuTitulo_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave] CHECK CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
	REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibligraficaPalavraChave] CHECK CONSTRAINT [FK_ProducaoBibligraficaPalavraChave_ProducaoBibliografica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliografica_Idioma1] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliografica] CHECK CONSTRAINT [FK_ProducaoBibliografica_Idioma1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliografica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliografica_PeriodicoQualis] FOREIGN KEY([PeriodicoQualisId])
	REFERENCES [dbo].[PeriodicoQualis] ([PeriodicoQualisId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliografica] CHECK CONSTRAINT [FK_ProducaoBibliografica_PeriodicoQualis]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_ProducaoBibliografica] FOREIGN KEY([ProducaoBibliograficaId])
	REFERENCES [dbo].[ProducaoBibliografica] ([ProducaoBibliograficaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoBibliograficaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoBibliograficaAreaConhecimento_ProducaoBibliografica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnica_AgenciaFinanciadora] FOREIGN KEY([AgenciaFinanciadoraId])
	REFERENCES [dbo].[AgenciaFinanciadora] ([AgenciaFinanciadoraId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnica] CHECK CONSTRAINT [FK_ProducaoTecnica_AgenciaFinanciadora]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnica]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnica_Idioma1] FOREIGN KEY([IdiomaId])
	REFERENCES [dbo].[Idioma] ([IdiomaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnica] CHECK CONSTRAINT [FK_ProducaoTecnica_Idioma1]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_AreaConhecimento] FOREIGN KEY([AreaConhecimentoId])
	REFERENCES [dbo].[AreaConhecimento] ([AreaConhecimentoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_AreaConhecimento]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
	REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaAreaConhecimento] CHECK CONSTRAINT [FK_ProducaoTecnicaAreaConhecimento_ProducaoTecnica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaPalavraChave_PalavraChave] FOREIGN KEY([PalavraChaveId])
	REFERENCES [dbo].[PalavraChave] ([PalavraChaveId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave] CHECK CONSTRAINT [FK_ProducaoTecnicaPalavraChave_PalavraChave]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave]  WITH CHECK ADD  CONSTRAINT [FK_ProducaoTecnicaPalavraChave_ProducaoTecnica] FOREIGN KEY([ProducaoTecnicaId])
	REFERENCES [dbo].[ProducaoTecnica] ([ProducaoTecnicaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[ProducaoTecnicaPalavraChave] CHECK CONSTRAINT [FK_ProducaoTecnicaPalavraChave_ProducaoTecnica]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_EnderecoProfissional] FOREIGN KEY([EnderecoProfissionalId])
	REFERENCES [dbo].[Endereco] ([EnderecoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_EnderecoProfissional]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_EnderecoResidencial] FOREIGN KEY([EnderecoResidencialId])
	REFERENCES [dbo].[Endereco] ([EnderecoId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_EnderecoResidencial]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
	REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_OrgaoInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
	REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_UnidadeInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Projeto_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Projeto_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Projeto_OrgaoInstituicaoEmpresa] FOREIGN KEY([OrgaoInstituicaoEmpresaId])
	REFERENCES [dbo].[OrgaoInstituicaoEmpresa] ([OrgaoInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Projeto_OrgaoInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Projeto_UnidadeInstituicaoEmpresa] FOREIGN KEY([UnidadeInstituicaoEmpresaId])
	REFERENCES [dbo].[UnidadeInstituicaoEmpresa] ([UnidadeInstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Projeto_UnidadeInstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[UnidadeInstituicaoEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeInstituicaoEmpresaId_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[UnidadeInstituicaoEmpresa] CHECK CONSTRAINT [FK_UnidadeInstituicaoEmpresaId_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[VinculoAtuacaoProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtuacaoProfissional_InstituicaoEmpresa] FOREIGN KEY([InstituicaoEmpresaId])
	REFERENCES [dbo].[InstituicaoEmpresa] ([InstituicaoEmpresaId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[VinculoAtuacaoProfissional] CHECK CONSTRAINT [FK_AtuacaoProfissional_InstituicaoEmpresa]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[VinculoAtuacaoProfissional]  WITH CHECK ADD  CONSTRAINT [FK_AtuacaoProfissional_Professor] FOREIGN KEY([ProfessorId])
	REFERENCES [dbo].[Professor] ([ProfessorId])
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	ALTER TABLE [dbo].[VinculoAtuacaoProfissional] CHECK CONSTRAINT [FK_AtuacaoProfissional_Professor]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.000'))
	INSERT INTO ControleVersaoBanco (VersaoBanco, DataAtualizacao) VALUES('01.000', GETDATE())

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.001')) 
	/* Melhoria para contemplar JCR */
	CREATE TABLE [dbo].[JCR](
		[JCRId] [int] IDENTITY(1,1) NOT NULL,
		[Rank] [int] NOT NULL,
		[NomePeriodicoJCR] [varchar](1500) NOT NULL,
		[NomeAbreviadoPeriodioJCR] [varchar](100) NOT NULL,
		[ISSNJCR] [char](8) NOT NULL,
		[NumeroCitacoesJCR] [int] NULL,
		[FatorImpactoJCR] [numeric](15, 4) NULL,
		[FatorImpactoSemCitacoesPropriasJCR] [numeric](15, 4) NULL,
		[FatorImpactoCincoAnosJCR] [numeric](15, 4) NULL,
		[IndiceInfluenciaJCR] [numeric](15, 4) NULL,
		[ItensCitaveisJCR] [int] NULL,
		[PontuacaoEigenfactorJCR] [numeric](15, 6) NULL,
		[PontuacaoInfluenciaArtigoJCR] [numeric](15, 4) NULL,
		[PercentualMedioJCR] [numeric](15, 4) NULL,
		[EigenfactorNormalizadoJCR] [numeric](15, 6) NULL,
	 CONSTRAINT [PK_JCR] PRIMARY KEY CLUSTERED 
	(
		[JCRId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.001'))
	ALTER TABLE [dbo].JCR SET (LOCK_ESCALATION = TABLE)
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.001'))
	ALTER TABLE [dbo].ProducaoBibliografica ADD
		JCRId int NULL,
		NomePeriodicoProducaoBibliografica varchar(500) NULL
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.001'))
	ALTER TABLE [dbo].ProducaoBibliografica ADD CONSTRAINT
		FK_ProducaoBibliografica_JCR FOREIGN KEY
		(
		JCRId
		) REFERENCES dbo.JCR
		(
		JCRId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.001'))
	ALTER TABLE [dbo].ProducaoBibliografica SET (LOCK_ESCALATION = TABLE)
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.001'))
	INSERT INTO ControleVersaoBanco (VersaoBanco, DataAtualizacao) VALUES('01.001', GETDATE())
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.AreaAtuacao
		DROP CONSTRAINT FK_AreaAtuacao_Professor
	
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	
	COMMIT
	BEGIN TRANSACTION
	
	CREATE TABLE dbo.Tmp_AreaAtuacao
		(
		AreaAtuacaoId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		GrandeAreaAtuacao varchar(50) NOT NULL,
		AreaAtuacao varchar(100) NOT NULL,
		SubAreaAtuacao varchar(100) NOT NULL,
		Especialidade varchar(100) NOT NULL,
		TermoCompleto varchar(350) NOT NULL
		)  ON [PRIMARY]
	
	ALTER TABLE dbo.Tmp_AreaAtuacao SET (LOCK_ESCALATION = TABLE)
	
	SET IDENTITY_INSERT dbo.Tmp_AreaAtuacao OFF
	
	IF EXISTS(SELECT * FROM dbo.AreaAtuacao)
		 EXEC('INSERT INTO dbo.Tmp_AreaAtuacao (ProfessorId, GrandeAreaAtuacao, AreaAtuacao, SubAreaAtuacao, Especialidade, TermoCompleto)
			SELECT ProfessorId, ISNULL(GrandeAreaAtuacao, ''''), ISNULL(AreaAtuacao, ''''), ISNULL(SubAreaAtuacao, ''''), ISNULL(Especialidade, ''''), ISNULL(TermoCompleto, '''') FROM dbo.AreaAtuacao WITH (HOLDLOCK TABLOCKX)')
	
	DROP TABLE dbo.AreaAtuacao
	
	EXECUTE sp_rename N'dbo.Tmp_AreaAtuacao', N'AreaAtuacao', 'OBJECT' 
	
	ALTER TABLE dbo.AreaAtuacao ADD CONSTRAINT
		PK_AreaAtuacao PRIMARY KEY CLUSTERED 
		(
		AreaAtuacaoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	CREATE NONCLUSTERED INDEX IX_AreaAtuacao ON dbo.AreaAtuacao
		(
		ProfessorId,
		GrandeAreaAtuacao,
		AreaAtuacao,
		SubAreaAtuacao,
		Especialidade,
		TermoCompleto
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	
	ALTER TABLE dbo.AreaAtuacao ADD CONSTRAINT
		FK_AreaAtuacao_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.AtividadeProfissional
		DROP CONSTRAINT FK_AtividadeProfissional_UnidadeInstituicaoEmpresa
	ALTER TABLE dbo.UnidadeInstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.AtividadeProfissional
		DROP CONSTRAINT FK_AtividadeProfissional_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.AtividadeProfissional
		DROP CONSTRAINT FK_AtividadeProfissional_OrgaoInstituicaoEmpresa
	ALTER TABLE dbo.OrgaoInstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.AtividadeProfissional
		DROP CONSTRAINT FK_AtividadeProfissional_InstituicaoEmpresa
	ALTER TABLE dbo.InstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_AtividadeProfissional
		(
		AtividadeProfissionalId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		SequenciaAtividadeProfissional int NOT NULL,
		InstituicaoEmpresaId int NOT NULL,
		UnidadeInstituicaoEmpresaId int NULL,
		OrgaoInstituicaoEmpresaId int NULL,
		DataInicioAtividadeProfissional date NOT NULL,
		DataTerminoAtividadeProfissional date NULL,
		InformacoesAdicionaisAtividadeProfissional varchar(2000) NULL,
		TipoAtividadeProfissional varchar(50) NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_AtividadeProfissional SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_AtividadeProfissional OFF
	IF EXISTS(SELECT * FROM dbo.AtividadeProfissional)
		 EXEC('INSERT INTO dbo.Tmp_AtividadeProfissional (ProfessorId, SequenciaAtividadeProfissional, InstituicaoEmpresaId, UnidadeInstituicaoEmpresaId, OrgaoInstituicaoEmpresaId, DataInicioAtividadeProfissional, DataTerminoAtividadeProfissional, InformacoesAdicionaisAtividadeProfissional, TipoAtividadeProfissional)
			SELECT ProfessorId, SequenciaAtividadeProfissional, InstituicaoEmpresaId, UnidadeInstituicaoEmpresaId, OrgaoInstituicaoEmpresaId, DataInicioAtividadeProfissional, DataTerminoAtividadeProfissional, InformacoesAdicionaisAtividadeProfissional, TipoAtividadeProfissional FROM dbo.AtividadeProfissional WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_AtividadeProfissional
	DROP TABLE dbo.AtividadeProfissional
	EXECUTE sp_rename N'dbo.Tmp_AtividadeProfissional', N'AtividadeProfissional', 'OBJECT' 
	ALTER TABLE dbo.AtividadeProfissional ADD CONSTRAINT
		PK_AtividadeProfissional PRIMARY KEY CLUSTERED 
		(
		AtividadeProfissionalId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	CREATE NONCLUSTERED INDEX IX_AtividadeProfissional ON dbo.AtividadeProfissional
		(
		ProfessorId,
		SequenciaAtividadeProfissional
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.AtividadeProfissional ADD CONSTRAINT
		FK_AtividadeProfissional_InstituicaoEmpresa FOREIGN KEY
		(
		InstituicaoEmpresaId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.AtividadeProfissional ADD CONSTRAINT
		FK_AtividadeProfissional_OrgaoInstituicaoEmpresa FOREIGN KEY
		(
		OrgaoInstituicaoEmpresaId
		) REFERENCES dbo.OrgaoInstituicaoEmpresa
		(
		OrgaoInstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.AtividadeProfissional ADD CONSTRAINT
		FK_AtividadeProfissional_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.AtividadeProfissional ADD CONSTRAINT
		FK_AtividadeProfissional_UnidadeInstituicaoEmpresa FOREIGN KEY
		(
		UnidadeInstituicaoEmpresaId
		) REFERENCES dbo.UnidadeInstituicaoEmpresa
		(
		UnidadeInstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_OrgaoInstituicaoEmpresa
	ALTER TABLE dbo.OrgaoInstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_InstituicaoEmpresa
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaCoTutela
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaOutraSanduiche
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaSanduiche
	ALTER TABLE dbo.InstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_Curso
	ALTER TABLE dbo.Curso SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_CoOrientador
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_Orientador
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_OrientadorCoTutela
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_OrientadorSanduiche
	ALTER TABLE dbo.Orientador SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao
		DROP CONSTRAINT FK_FormacaoAcademicaTitulacao_AgenciaFinanciadora
	ALTER TABLE dbo.AgenciaFinanciadora SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_FormacaoAcademicaTitulacao
		(
		FormacaoAcademicaTitulacaoId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		SequenciaFormacaoAcademicaTitulacao int NOT NULL,
		NivelFormacaoAcademicaTitulacao varchar(50) NOT NULL,
		TituloTrabalhoFinal varchar(260) NOT NULL,
		TituloTrabalhoFinalEmIngles varchar(260) NOT NULL,
		OrientadorId int NULL,
		InstituicaoEmpresaId int NOT NULL,
		CursoId int NULL,
		CodigoAreaCurso varchar(30) NULL,
		SituacaoFormacaoAcademicaTitulacao char(12) NOT NULL,
		AnoInicioFormacaoAcademicaTitulacao numeric(4, 0) NOT NULL,
		AnoConclusaoFormacaoAcademicaTitulacao numeric(4, 0) NULL,
		TemBolsaFormacaoAcademicaTitulacao bit NULL,
		AgenciaFinanciadoraId int NULL,
		TipoGraduacaoDoutorado varchar(50) NULL,
		CargaHorariaFormacaoAcademicaTitulacao numeric(4, 0) NULL,
		AnoObtencaoTituloFormacaoAcademicaTitulacao numeric(4, 0) NULL,
		OrientadorCoTutelaId int NULL,
		InstituicaoEmpresaCoTutelaId int NULL,
		OrientadorSanduicheId int NULL,
		InstituicaoEmpresaSanduicheId int NULL,
		InstituicaoEmpresaOutraSanduicheId int NULL,
		OrgaoInstituicaoEmpresaId int NULL,
		CoOrientadorId int NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_FormacaoAcademicaTitulacao SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_FormacaoAcademicaTitulacao OFF
	IF EXISTS(SELECT * FROM dbo.FormacaoAcademicaTitulacao)
		 EXEC('INSERT INTO dbo.Tmp_FormacaoAcademicaTitulacao (ProfessorId, SequenciaFormacaoAcademicaTitulacao, NivelFormacaoAcademicaTitulacao, TituloTrabalhoFinal, TituloTrabalhoFinalEmIngles, OrientadorId, InstituicaoEmpresaId, CursoId, CodigoAreaCurso, SituacaoFormacaoAcademicaTitulacao, AnoInicioFormacaoAcademicaTitulacao, AnoConclusaoFormacaoAcademicaTitulacao, TemBolsaFormacaoAcademicaTitulacao, AgenciaFinanciadoraId, TipoGraduacaoDoutorado, CargaHorariaFormacaoAcademicaTitulacao, AnoObtencaoTituloFormacaoAcademicaTitulacao, OrientadorCoTutelaId, InstituicaoEmpresaCoTutelaId, OrientadorSanduicheId, InstituicaoEmpresaSanduicheId, InstituicaoEmpresaOutraSanduicheId, OrgaoInstituicaoEmpresaId, CoOrientadorId)
			SELECT ProfessorId, SequenciaFormacaoAcademicaTitulacao, NivelFormacaoAcademicaTitulacao, TituloTrabalhoFinal, TituloTrabalhoFinalEmIngles, OrientadorId, InstituicaoEmpresaId, CursoId, CodigoAreaCurso, SituacaoFormacaoAcademicaTitulacao, AnoInicioFormacaoAcademicaTitulacao, AnoConclusaoFormacaoAcademicaTitulacao, TemBolsaFormacaoAcademicaTitulacao, AgenciaFinanciadoraId, TipoGraduacaoDoutorado, CargaHorariaFormacaoAcademicaTitulacao, AnoObtencaoTituloFormacaoAcademicaTitulacao, OrientadorCoTutelaId, InstituicaoEmpresaCoTutelaId, OrientadorSanduicheId, InstituicaoEmpresaSanduicheId, InstituicaoEmpresaOutraSanduicheId, OrgaoInstituicaoEmpresaId, CoOrientadorId FROM dbo.FormacaoAcademicaTitulacao WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoAreaConhecimento
		DROP CONSTRAINT FK_FormacaoAcademicaAreaConhecimento_FormacaoAcademicaTitulacao
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoPalavraChave
		DROP CONSTRAINT FK_PalavraChaveFormacaoAcademicaTitulacao_FormacaoAcademicaTitulacao
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_FormacaoAcademicaTitulacao
	DROP TABLE dbo.FormacaoAcademicaTitulacao
	EXECUTE sp_rename N'dbo.Tmp_FormacaoAcademicaTitulacao', N'FormacaoAcademicaTitulacao', 'OBJECT' 
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		PK_FormacaoAcademicaTitulacao PRIMARY KEY CLUSTERED 
		(
		FormacaoAcademicaTitulacaoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_AgenciaFinanciadora FOREIGN KEY
		(
		AgenciaFinanciadoraId
		) REFERENCES dbo.AgenciaFinanciadora
		(
		AgenciaFinanciadoraId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_CoOrientador FOREIGN KEY
		(
		CoOrientadorId
		) REFERENCES dbo.Orientador
		(
		OrientadorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_Curso FOREIGN KEY
		(
		CursoId
		) REFERENCES dbo.Curso
		(
		CursoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_InstituicaoEmpresa FOREIGN KEY
		(
		InstituicaoEmpresaId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaCoTutela FOREIGN KEY
		(
		InstituicaoEmpresaCoTutelaId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaOutraSanduiche FOREIGN KEY
		(
		InstituicaoEmpresaOutraSanduicheId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_InstituicaoEmpresaSanduiche FOREIGN KEY
		(
		InstituicaoEmpresaSanduicheId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_OrgaoInstituicaoEmpresa FOREIGN KEY
		(
		OrgaoInstituicaoEmpresaId
		) REFERENCES dbo.OrgaoInstituicaoEmpresa
		(
		OrgaoInstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_Orientador FOREIGN KEY
		(
		OrientadorId
		) REFERENCES dbo.Orientador
		(
		OrientadorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_OrientadorCoTutela FOREIGN KEY
		(
		OrientadorCoTutelaId
		) REFERENCES dbo.Orientador
		(
		OrientadorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_OrientadorSanduiche FOREIGN KEY
		(
		OrientadorSanduicheId
		) REFERENCES dbo.Orientador
		(
		OrientadorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacao ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacao_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoPalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoAreaConhecimento SET (LOCK_ESCALATION = TABLE)
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoAreaConhecimento
		DROP CONSTRAINT FK_FormacaoAcademicaAreaConhecimento_AreaConhecimento
	ALTER TABLE dbo.AreaConhecimento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_FormacaoAcademicaTitulacaoAreaConhecimento
		(
		AreaConhecimentoId int NOT NULL,
		FormacaoAcademicaTitulacaoId int NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_FormacaoAcademicaTitulacaoAreaConhecimento SET (LOCK_ESCALATION = TABLE)
	IF EXISTS(SELECT * FROM dbo.FormacaoAcademicaTitulacaoAreaConhecimento)
		 EXEC('INSERT INTO dbo.Tmp_FormacaoAcademicaTitulacaoAreaConhecimento (AreaConhecimentoId, FormacaoAcademicaTitulacaoId)
				SELECT AreaConhecimentoId, FormacaoAcademicaTitulacaoId FROM dbo.FormacaoAcademicaTitulacaoAreaConhecimento FATAC WITH (HOLDLOCK TABLOCKX)
					INNER JOIN FormacaoAcademicaTitulacao FAT ON FAT.ProfessorId = FATAC.ProfessorId AND FAT.SequenciaFormacaoAcademicaTitulacao = FATAC.SequenciaFormacaoAcademicaTitulacao')
	DROP TABLE dbo.FormacaoAcademicaTitulacaoAreaConhecimento
	EXECUTE sp_rename N'dbo.Tmp_FormacaoAcademicaTitulacaoAreaConhecimento', N'FormacaoAcademicaTitulacaoAreaConhecimento', 'OBJECT' 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoAreaConhecimento ADD CONSTRAINT
		PK_FormacaoAcademicaTitulacaoAreaConhecimento PRIMARY KEY CLUSTERED 
		(
		AreaConhecimentoId,
		FormacaoAcademicaTitulacaoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoAreaConhecimento ADD CONSTRAINT
		FK_FormacaoAcademicaAreaConhecimento_AreaConhecimento FOREIGN KEY
		(
		AreaConhecimentoId
		) REFERENCES dbo.AreaConhecimento
		(
		AreaConhecimentoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoAreaConhecimento ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacaoAreaConhecimento_FormacaoAcademicaTitulacao FOREIGN KEY
		(
		FormacaoAcademicaTitulacaoId
		) REFERENCES dbo.FormacaoAcademicaTitulacao
		(
		FormacaoAcademicaTitulacaoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoPalavraChave
		DROP CONSTRAINT FK_PalavraChaveFormacaoAcademicaTitulacao_PalavraChave
	ALTER TABLE dbo.PalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_FormacaoAcademicaTitulacaoPalavraChave
		(
		PalavraChaveId int NOT NULL,
		FormacaoAcademicaTitulacaoId int NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_FormacaoAcademicaTitulacaoPalavraChave SET (LOCK_ESCALATION = TABLE)
	IF EXISTS(SELECT * FROM dbo.FormacaoAcademicaTitulacaoPalavraChave)
		 EXEC('INSERT INTO dbo.Tmp_FormacaoAcademicaTitulacaoPalavraChave (PalavraChaveId, FormacaoAcademicaTitulacaoId)
				SELECT PalavraChaveId, FormacaoAcademicaTitulacaoId FROM dbo.FormacaoAcademicaTitulacaoPalavraChave FATPC WITH (HOLDLOCK TABLOCKX)
					INNER JOIN FormacaoAcademicaTitulacao FAT 
						ON  FAT.ProfessorId = FATPC.ProfessorId
						AND FAT.SequenciaFormacaoAcademicaTitulacao = FATPC.SequenciaFormacaoAcademicaTitulacao')
	DROP TABLE dbo.FormacaoAcademicaTitulacaoPalavraChave
	EXECUTE sp_rename N'dbo.Tmp_FormacaoAcademicaTitulacaoPalavraChave', N'FormacaoAcademicaTitulacaoPalavraChave', 'OBJECT' 
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoPalavraChave ADD CONSTRAINT
		PK_FormacaoAcademicaTitulacaoPalavraChave PRIMARY KEY CLUSTERED 
		(
		PalavraChaveId,
		FormacaoAcademicaTitulacaoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.FormacaoAcademicaTitulacaoPalavraChave ADD CONSTRAINT
		FK_PalavraChaveFormacaoAcademicaTitulacao_PalavraChave FOREIGN KEY
		(
		PalavraChaveId
		) REFERENCES dbo.PalavraChave
		(
		PalavraChaveId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.FormacaoAcademicaTitulacaoPalavraChave ADD CONSTRAINT
		FK_FormacaoAcademicaTitulacaoPalavraChave_FormacaoAcademicaTitulacao FOREIGN KEY
		(
		FormacaoAcademicaTitulacaoId
		) REFERENCES dbo.FormacaoAcademicaTitulacao
		(
		FormacaoAcademicaTitulacaoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.LinhaDePesquisa
		DROP CONSTRAINT FK_LinhaDePesquisa_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.LinhaDePesquisa
		DROP CONSTRAINT FK_LinhaDePesquisa_PalavraChave
	ALTER TABLE dbo.PalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_LinhaDePesquisa
		(
		LinhaDePesquisaId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		PalavraChaveId int NOT NULL,
		TituloLinhaDePesquisa varchar(1000) NOT NULL,
		ObjetivosLinhaDePesquisa varchar(5000) NOT NULL,
		AtivaLinhaDePesquisa bit NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_LinhaDePesquisa SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_LinhaDePesquisa OFF
	IF EXISTS(SELECT * FROM dbo.LinhaDePesquisa)
		 EXEC('INSERT INTO dbo.Tmp_LinhaDePesquisa (ProfessorId, PalavraChaveId, TituloLinhaDePesquisa, ObjetivosLinhaDePesquisa, AtivaLinhaDePesquisa)
			SELECT ProfessorId, PalavraChaveId, TituloLinhaDePesquisa, ObjetivosLinhaDePesquisa, AtivaLinhaDePesquisa FROM dbo.LinhaDePesquisa WITH (HOLDLOCK TABLOCKX)')
	DROP TABLE dbo.LinhaDePesquisa
	EXECUTE sp_rename N'dbo.Tmp_LinhaDePesquisa', N'LinhaDePesquisa', 'OBJECT' 
	ALTER TABLE dbo.LinhaDePesquisa ADD CONSTRAINT
		PK_LinhaDePesquisa_1 PRIMARY KEY CLUSTERED 
		(
		LinhaDePesquisaId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	
	ALTER TABLE dbo.LinhaDePesquisa ADD CONSTRAINT
		FK_LinhaDePesquisa_PalavraChave FOREIGN KEY
		(
		PalavraChaveId
		) REFERENCES dbo.PalavraChave
		(
		PalavraChaveId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.LinhaDePesquisa ADD CONSTRAINT
		FK_LinhaDePesquisa_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao
		DROP CONSTRAINT FK_OrientacaoSupervisao_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao
		DROP CONSTRAINT FK_OrientacaoSupervisao_OrgaoInstituicaoEmpresa
	ALTER TABLE dbo.OrgaoInstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao
		DROP CONSTRAINT FK_OrientacaoSupervisao_InstituicaoEmpresa
	ALTER TABLE dbo.InstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao
		DROP CONSTRAINT FK_OrientacaoSupervisao_Idioma1
	ALTER TABLE dbo.Idioma SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao
		DROP CONSTRAINT FK_OrientacaoSupervisao_Curso
	ALTER TABLE dbo.Curso SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao
		DROP CONSTRAINT FK_OrientacaoSupervisao_AgenciaFinanciadora
	ALTER TABLE dbo.AgenciaFinanciadora SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_OrientacaoSupervisao
		(
		OrientacaoSupervisaoId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		SequenciaOrientacaoSupervicao int NOT NULL,
		TipoOrientacaoSupervicao varchar(25) NOT NULL,
		NaturezaOrientacaoSupervicao varchar(500) NULL,
		TituloOrientacaoSupervicao varchar(350) NOT NULL,
		AnoOrientacaoSupervicao numeric(4, 0) NOT NULL,
		PaisOrientacaoSupervicao varchar(50) NULL,
		IdiomaId int NULL,
		HomePageOrientacaoSupervicao varchar(300) NULL,
		DOIOrientacaoSupervicao char(55) NULL,
		TituloEmInglesOrientacaoSupervicao varchar(1750) NULL,
		NomeOrientandoOrientacaoSupervicao varchar(200) NULL,
		InstituicaoEmpresaId int NULL,
		TemBolsaOrientacaoSupervicao bit NULL,
		AgenciaFinanciadoraId int NULL,
		PapelOrientacaoSupervicao varchar(25) NULL,
		InformacoesAdicionaisOrientacaoSupervicao varchar(2000) NULL,
		InformacoesAdicionaisEmInglesOrientacaoSupervicao varchar(2000) NULL,
		CursoId int NULL,
		OrgaoInstituicaoEmpresaId int NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_OrientacaoSupervisao SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_OrientacaoSupervisao OFF
	IF EXISTS(SELECT * FROM dbo.OrientacaoSupervisao)
		 EXEC('INSERT INTO dbo.Tmp_OrientacaoSupervisao (ProfessorId, SequenciaOrientacaoSupervicao, TipoOrientacaoSupervicao, NaturezaOrientacaoSupervicao, TituloOrientacaoSupervicao, AnoOrientacaoSupervicao, PaisOrientacaoSupervicao, IdiomaId, HomePageOrientacaoSupervicao, DOIOrientacaoSupervicao, TituloEmInglesOrientacaoSupervicao, NomeOrientandoOrientacaoSupervicao, InstituicaoEmpresaId, TemBolsaOrientacaoSupervicao, AgenciaFinanciadoraId, PapelOrientacaoSupervicao, InformacoesAdicionaisOrientacaoSupervicao, InformacoesAdicionaisEmInglesOrientacaoSupervicao, CursoId, OrgaoInstituicaoEmpresaId)
			SELECT ProfessorId, SequenciaOrientacaoSupervicao, TipoOrientacaoSupervicao, NaturezaOrientacaoSupervicao, TituloOrientacaoSupervicao, AnoOrientacaoSupervicao, PaisOrientacaoSupervicao, IdiomaId, HomePageOrientacaoSupervicao, DOIOrientacaoSupervicao, TituloEmInglesOrientacaoSupervicao, NomeOrientandoOrientacaoSupervicao, InstituicaoEmpresaId, TemBolsaOrientacaoSupervicao, AgenciaFinanciadoraId, PapelOrientacaoSupervicao, InformacoesAdicionaisOrientacaoSupervicao, InformacoesAdicionaisEmInglesOrientacaoSupervicao, CursoId, OrgaoInstituicaoEmpresaId FROM dbo.OrientacaoSupervisao WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.OrientacaoSupervisaoAreaConhecimento
		DROP CONSTRAINT FK_OrientacaoSupervisaoAreaConhecimento_OrientacaoSupervisao
	ALTER TABLE dbo.OrientacaoSupervisaoPalavraChave
		DROP CONSTRAINT FK_OrientacaoSupervisaoPalavraChave_OrientacaoSupervisao
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_OrientacaoSupervisao
	DROP TABLE dbo.OrientacaoSupervisao
	EXECUTE sp_rename N'dbo.Tmp_OrientacaoSupervisao', N'OrientacaoSupervisao', 'OBJECT' 
	ALTER TABLE dbo.OrientacaoSupervisao ADD CONSTRAINT
		PK_OrientacaoSupervisao PRIMARY KEY CLUSTERED 
		(
		OrientacaoSupervisaoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.OrientacaoSupervisao ADD CONSTRAINT
		FK_OrientacaoSupervisao_AgenciaFinanciadora FOREIGN KEY
		(
		AgenciaFinanciadoraId
		) REFERENCES dbo.AgenciaFinanciadora
		(
		AgenciaFinanciadoraId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.OrientacaoSupervisao ADD CONSTRAINT
		FK_OrientacaoSupervisao_Curso FOREIGN KEY
		(
		CursoId
		) REFERENCES dbo.Curso
		(
		CursoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.OrientacaoSupervisao ADD CONSTRAINT
		FK_OrientacaoSupervisao_Idioma1 FOREIGN KEY
		(
		IdiomaId
		) REFERENCES dbo.Idioma
		(
		IdiomaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.OrientacaoSupervisao ADD CONSTRAINT
		FK_OrientacaoSupervisao_InstituicaoEmpresa FOREIGN KEY
		(
		InstituicaoEmpresaId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.OrientacaoSupervisao ADD CONSTRAINT
		FK_OrientacaoSupervisao_OrgaoInstituicaoEmpresa FOREIGN KEY
		(
		OrgaoInstituicaoEmpresaId
		) REFERENCES dbo.OrgaoInstituicaoEmpresa
		(
		OrgaoInstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.OrientacaoSupervisao ADD CONSTRAINT
		FK_OrientacaoSupervisao_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT

	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisaoPalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisaoAreaConhecimento SET (LOCK_ESCALATION = TABLE)
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisaoAreaConhecimento
		DROP CONSTRAINT FK_OrientacaoSupervisaoAreaConhecimento_AreaConhecimento
	ALTER TABLE dbo.AreaConhecimento SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_OrientacaoSupervisaoAreaConhecimento
		(
		AreaConhecimentoId int NOT NULL,
		OrientacaoSupervisaoId int NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_OrientacaoSupervisaoAreaConhecimento SET (LOCK_ESCALATION = TABLE)
	IF EXISTS(SELECT * FROM dbo.OrientacaoSupervisaoAreaConhecimento)
		 EXEC('INSERT INTO dbo.Tmp_OrientacaoSupervisaoAreaConhecimento (AreaConhecimentoId, OrientacaoSupervisaoId)
				SELECT AreaConhecimentoId, OrientacaoSupervisaoId FROM dbo.OrientacaoSupervisaoAreaConhecimento OSAC WITH (HOLDLOCK TABLOCKX)
					INNER JOIN OrientacaoSupervisao OS ON OS.ProfessorId = OSAC.ProfessorId AND OS.SequenciaOrientacaoSupervicao = OSAC.SequenciaOrientacaoSupervicao')
	DROP TABLE dbo.OrientacaoSupervisaoAreaConhecimento
	EXECUTE sp_rename N'dbo.Tmp_OrientacaoSupervisaoAreaConhecimento', N'OrientacaoSupervisaoAreaConhecimento', 'OBJECT' 
	ALTER TABLE dbo.OrientacaoSupervisaoAreaConhecimento ADD CONSTRAINT
		PK_OrientacaoSupervisaoAreaConhecimento_1 PRIMARY KEY CLUSTERED 
		(
		AreaConhecimentoId,
		OrientacaoSupervisaoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.OrientacaoSupervisaoAreaConhecimento ADD CONSTRAINT
		FK_OrientacaoSupervisaoAreaConhecimento_AreaConhecimento FOREIGN KEY
		(
		AreaConhecimentoId
		) REFERENCES dbo.AreaConhecimento
		(
		AreaConhecimentoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.OrientacaoSupervisaoAreaConhecimento ADD CONSTRAINT
		FK_OrientacaoSupervisaoAreaConhecimento_OrientacaoSupervisao FOREIGN KEY
		(
		OrientacaoSupervisaoId
		) REFERENCES dbo.OrientacaoSupervisao
		(
		OrientacaoSupervisaoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisaoPalavraChave
		DROP CONSTRAINT FK_OrientacaoSupervisaoPalavraChave_PalavraChave
	ALTER TABLE dbo.PalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_OrientacaoSupervisaoPalavraChave
		(
		PalavraChaveId int NOT NULL,
		OrientacaoSupervisaoId int NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_OrientacaoSupervisaoPalavraChave SET (LOCK_ESCALATION = TABLE)
	IF EXISTS(SELECT * FROM dbo.OrientacaoSupervisaoPalavraChave)
		 EXEC('INSERT INTO dbo.Tmp_OrientacaoSupervisaoPalavraChave (PalavraChaveId, OrientacaoSupervisaoId)
				SELECT PalavraChaveId, OrientacaoSupervisaoId FROM dbo.OrientacaoSupervisaoPalavraChave OSPC WITH (HOLDLOCK TABLOCKX)
					INNER JOIN OrientacaoSupervisao OS ON OS.ProfessorId = OSPC.ProfessorId AND OS.SequenciaOrientacaoSupervicao = OSPC.SequenciaOrientacaoSupervicao')
	DROP TABLE dbo.OrientacaoSupervisaoPalavraChave
	EXECUTE sp_rename N'dbo.Tmp_OrientacaoSupervisaoPalavraChave', N'OrientacaoSupervisaoPalavraChave', 'OBJECT' 
	ALTER TABLE dbo.OrientacaoSupervisaoPalavraChave ADD CONSTRAINT
		PK_OrientacaoSupervisaoPalavraChave_1 PRIMARY KEY CLUSTERED 
		(
		PalavraChaveId,
		OrientacaoSupervisaoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.OrientacaoSupervisaoPalavraChave ADD CONSTRAINT
		FK_OrientacaoSupervisaoPalavraChave_PalavraChave FOREIGN KEY
		(
		PalavraChaveId
		) REFERENCES dbo.PalavraChave
		(
		PalavraChaveId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.OrientacaoSupervisaoPalavraChave ADD CONSTRAINT
		FK_OrientacaoSupervisaoPalavraChave_OrientacaoSupervisao FOREIGN KEY
		(
		OrientacaoSupervisaoId
		) REFERENCES dbo.OrientacaoSupervisao
		(
		OrientacaoSupervisaoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEmProjeto
		DROP CONSTRAINT FK_ParticipacaoEmProjeto_Projeto
	ALTER TABLE dbo.Projeto SET (LOCK_ESCALATION = TABLE)
	COMMIT
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEmProjeto
		DROP CONSTRAINT FK_ParticipacaoEmProjeto_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_ParticipacaoEmProjeto
		(
		ParticipacaoEmProjetoId int NOT NULL IDENTITY (1, 1),
		ProjetoId int NOT NULL,
		ProfessorId int NOT NULL,
		ResponsavelParticipacaoEmProjeto bit NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_ParticipacaoEmProjeto SET (LOCK_ESCALATION = TABLE)
	ALTER TABLE dbo.Tmp_ParticipacaoEmProjeto ADD CONSTRAINT
		DF_ParticipacaoEmProjeto_ResponsavelParticipacaoEmProjeto DEFAULT 0 FOR ResponsavelParticipacaoEmProjeto
	SET IDENTITY_INSERT dbo.Tmp_ParticipacaoEmProjeto OFF
	IF EXISTS(SELECT * FROM dbo.ParticipacaoEmProjeto)
		 EXEC('INSERT INTO dbo.Tmp_ParticipacaoEmProjeto (ProjetoId, ProfessorId, ResponsavelParticipacaoEmProjeto)
			SELECT ProjetoId, ProfessorId, ISNULL(ResponsavelParticipacaoEmProjeto, 0) FROM dbo.ParticipacaoEmProjeto WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_ParticipacaoEmProjeto
	DROP TABLE dbo.ParticipacaoEmProjeto
	EXECUTE sp_rename N'dbo.Tmp_ParticipacaoEmProjeto', N'ParticipacaoEmProjeto', 'OBJECT' 
	ALTER TABLE dbo.ParticipacaoEmProjeto ADD CONSTRAINT
		PK_ParticipacaoEmProjeto PRIMARY KEY CLUSTERED 
		(
		ParticipacaoEmProjetoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.ParticipacaoEmProjeto ADD CONSTRAINT
		FK_ParticipacaoEmProjeto_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.ParticipacaoEmProjeto ADD CONSTRAINT
		FK_ParticipacaoEmProjeto_Projeto FOREIGN KEY
		(
		ProjetoId
		) REFERENCES dbo.Projeto
		(
		ProjetoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	COMMIT
END
GO


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEvento
		DROP CONSTRAINT FK_ParticipacaoEvento_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEvento
		DROP CONSTRAINT FK_ParticipacaoEvento_Idioma1
	ALTER TABLE dbo.Idioma SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEvento
		DROP CONSTRAINT FK_ParticipacaoEvento_Evento
	ALTER TABLE dbo.Evento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_ParticipacaoEvento
		(
		ParticipacaoEventoId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		EventoId int NOT NULL,
		SequenciaParticipacaoEvento int NOT NULL,
		TipoParticipacaoEvento varchar(25) NULL,
		FormaParticipacaoEvento varchar(25) NULL,
		IdiomaId int NULL,
		TituloParticipacaoEvento varchar(400) NULL,
		TituloEmInglesParticipacaoEvento varchar(400) NULL,
		InformacoesAdicionaisParticipacaoEvento varchar(5000) NULL,
		InformacoesAdicionaisEmInglesParticipacaoEvento varchar(2000) NULL,
		MeioDivulgacaoParticipacaoEvento varchar(50) NULL,
		HomePageParticipacaoEvento varchar(300) NULL,
		DOIParticipacaoEvento char(55) NULL,
		DivulgacaoCeTParticipacaoEvento bit NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_ParticipacaoEvento SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_ParticipacaoEvento OFF
	IF EXISTS(SELECT * FROM dbo.ParticipacaoEvento)
		 EXEC('INSERT INTO dbo.Tmp_ParticipacaoEvento (ProfessorId, EventoId, SequenciaParticipacaoEvento, TipoParticipacaoEvento, FormaParticipacaoEvento, IdiomaId, TituloParticipacaoEvento, TituloEmInglesParticipacaoEvento, InformacoesAdicionaisParticipacaoEvento, InformacoesAdicionaisEmInglesParticipacaoEvento, MeioDivulgacaoParticipacaoEvento, HomePageParticipacaoEvento, DOIParticipacaoEvento, DivulgacaoCeTParticipacaoEvento)
			SELECT ProfessorId, EventoId, SequenciaParticipacaoEvento, TipoParticipacaoEvento, FormaParticipacaoEvento, IdiomaId, TituloParticipacaoEvento, TituloEmInglesParticipacaoEvento, InformacoesAdicionaisParticipacaoEvento, InformacoesAdicionaisEmInglesParticipacaoEvento, MeioDivulgacaoParticipacaoEvento, HomePageParticipacaoEvento, DOIParticipacaoEvento, DivulgacaoCeTParticipacaoEvento FROM dbo.ParticipacaoEvento WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.ParticipacaoEventoAreaConhecimento
		DROP CONSTRAINT FK_ParticipacaoEventoAreaConhecimento_ParticipacaoEvento1
	ALTER TABLE dbo.ParticipacaoEventoPalavraChave
		DROP CONSTRAINT FK_ParticipacaoEventoPalavraChave_ParticipacaoEvento1
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_ParticipacaoEvento
	DROP TABLE dbo.ParticipacaoEvento
	EXECUTE sp_rename N'dbo.Tmp_ParticipacaoEvento', N'ParticipacaoEvento', 'OBJECT' 
	ALTER TABLE dbo.ParticipacaoEvento ADD CONSTRAINT
		PK_ParticipacaoEvento PRIMARY KEY CLUSTERED 
		(
		ParticipacaoEventoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.ParticipacaoEvento ADD CONSTRAINT
		FK_ParticipacaoEvento_Evento FOREIGN KEY
		(
		EventoId
		) REFERENCES dbo.Evento
		(
		EventoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.ParticipacaoEvento ADD CONSTRAINT
		FK_ParticipacaoEvento_Idioma1 FOREIGN KEY
		(
		IdiomaId
		) REFERENCES dbo.Idioma
		(
		IdiomaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.ParticipacaoEvento ADD CONSTRAINT
		FK_ParticipacaoEvento_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEventoPalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEventoAreaConhecimento SET (LOCK_ESCALATION = TABLE)
	COMMIT
END

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEvento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEventoAreaConhecimento
		DROP CONSTRAINT FK_EventoAreaConhecimento_AreaConhecimento
	ALTER TABLE dbo.AreaConhecimento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_ParticipacaoEventoAreaConhecimento
		(
		AreaConhecimentoId int NOT NULL,
		ParticipacaoEventoId int NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_ParticipacaoEventoAreaConhecimento SET (LOCK_ESCALATION = TABLE)
	IF EXISTS(SELECT * FROM dbo.ParticipacaoEventoAreaConhecimento)
		 EXEC('INSERT INTO dbo.Tmp_ParticipacaoEventoAreaConhecimento (AreaConhecimentoId, ParticipacaoEventoId)
				SELECT AreaConhecimentoId, ParticipacaoEventoId FROM dbo.ParticipacaoEventoAreaConhecimento PEFilho WITH (HOLDLOCK TABLOCKX)
					INNER JOIN ParticipacaoEvento PE ON PE.EventoId = PEFilho.EventoId AND PE.ProfessorId = PEFilho.ProfessorId AND PE.EventoId = PEFilho.EventoId')
	DROP TABLE dbo.ParticipacaoEventoAreaConhecimento
	EXECUTE sp_rename N'dbo.Tmp_ParticipacaoEventoAreaConhecimento', N'ParticipacaoEventoAreaConhecimento', 'OBJECT' 
	ALTER TABLE dbo.ParticipacaoEventoAreaConhecimento ADD CONSTRAINT
		PK_ParticipacaoEventoAreaConhecimento PRIMARY KEY CLUSTERED 
		(
		AreaConhecimentoId,
		ParticipacaoEventoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.ParticipacaoEventoAreaConhecimento ADD CONSTRAINT
		FK_EventoAreaConhecimento_AreaConhecimento FOREIGN KEY
		(
		AreaConhecimentoId
		) REFERENCES dbo.AreaConhecimento
		(
		AreaConhecimentoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.ParticipacaoEventoAreaConhecimento ADD CONSTRAINT
		FK_ParticipacaoEventoAreaConhecimento_ParticipacaoEvento FOREIGN KEY
		(
		ParticipacaoEventoId
		) REFERENCES dbo.ParticipacaoEvento
		(
		ParticipacaoEventoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEvento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEventoPalavraChave
		DROP CONSTRAINT FK_EventoPalavraChave_PalavraChave
	ALTER TABLE dbo.PalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_ParticipacaoEventoPalavraChave
		(
		PalavraChaveId int NOT NULL,
		ParticipacaoEventoId int NOT NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_ParticipacaoEventoPalavraChave SET (LOCK_ESCALATION = TABLE)
	IF EXISTS(SELECT * FROM dbo.ParticipacaoEventoPalavraChave)
		 EXEC('INSERT INTO dbo.Tmp_ParticipacaoEventoPalavraChave (PalavraChaveId, ParticipacaoEventoId)
				SELECT PalavraChaveId, ParticipacaoEventoId FROM dbo.ParticipacaoEventoPalavraChave PEFilho WITH (HOLDLOCK TABLOCKX)
					INNER JOIN ParticipacaoEvento PE ON PE.EventoId = PEFilho.EventoId AND PE.ProfessorId = PEFilho.ProfessorId AND PE.EventoId = PEFilho.EventoId')
	DROP TABLE dbo.ParticipacaoEventoPalavraChave
	EXECUTE sp_rename N'dbo.Tmp_ParticipacaoEventoPalavraChave', N'ParticipacaoEventoPalavraChave', 'OBJECT' 
	ALTER TABLE dbo.ParticipacaoEventoPalavraChave ADD CONSTRAINT
		PK_ParticipacaoEventoPalavraChave PRIMARY KEY CLUSTERED 
		(
		PalavraChaveId,
		ParticipacaoEventoId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.ParticipacaoEventoPalavraChave ADD CONSTRAINT
		FK_EventoPalavraChave_PalavraChave FOREIGN KEY
		(
		PalavraChaveId
		) REFERENCES dbo.PalavraChave
		(
		PalavraChaveId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.ParticipacaoEventoPalavraChave ADD CONSTRAINT
		FK_ParticipacaoEventoPalavraChave_ParticipacaoEvento FOREIGN KEY
		(
		ParticipacaoEventoId
		) REFERENCES dbo.ParticipacaoEvento
		(
		ParticipacaoEventoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.PatenteRegistro
		DROP CONSTRAINT FK_PatenteRegistro_ProducaoTecnica
	ALTER TABLE dbo.ProducaoTecnica SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_PatenteRegistro
		(
		PatenteRegistroId int NOT NULL IDENTITY (1, 1),
		ProducaoTecnicaId int NOT NULL,
		TipoPatenteRegistro varchar(50) NOT NULL,
		CodigoPatenteRegistro char(20) NOT NULL,
		TituloPatenteRegistro varchar(300) NOT NULL,
		DataPedidoPatenteRegistro date NULL,
		DataPedidoExamePatenteRegistro date NULL,
		DataConcessaoPatenteRegistro date NULL,
		NumeroDepositoPCTPatenteRegistro char(20) NULL,
		DataDepositoPCTPatenteRegistro date NULL,
		NomeTitularPatenteRegistro varchar(200) NULL,
		InstituicaoDepositoPatenteRegistro varchar(300) NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_PatenteRegistro SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_PatenteRegistro OFF
	IF EXISTS(SELECT * FROM dbo.PatenteRegistro)
		 EXEC('INSERT INTO dbo.Tmp_PatenteRegistro (ProducaoTecnicaId, TipoPatenteRegistro, CodigoPatenteRegistro, TituloPatenteRegistro, DataPedidoPatenteRegistro, DataPedidoExamePatenteRegistro, DataConcessaoPatenteRegistro, NumeroDepositoPCTPatenteRegistro, DataDepositoPCTPatenteRegistro, NomeTitularPatenteRegistro, InstituicaoDepositoPatenteRegistro)
			SELECT ProducaoTecnicaId, TipoPatenteRegistro, CodigoPatenteRegistro, TituloPatenteRegistro, DataPedidoPatenteRegistro, DataPedidoExamePatenteRegistro, DataConcessaoPatenteRegistro, NumeroDepositoPCTPatenteRegistro, DataDepositoPCTPatenteRegistro, NomeTitularPatenteRegistro, InstituicaoDepositoPatenteRegistro FROM dbo.PatenteRegistro WITH (HOLDLOCK TABLOCKX)')
	DROP TABLE dbo.PatenteRegistro
	EXECUTE sp_rename N'dbo.Tmp_PatenteRegistro', N'PatenteRegistro', 'OBJECT' 
	ALTER TABLE dbo.PatenteRegistro ADD CONSTRAINT
		PK_PatenteRegistro_1 PRIMARY KEY CLUSTERED 
		(
		PatenteRegistroId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.PatenteRegistro ADD CONSTRAINT
		FK_PatenteRegistro_ProducaoTecnica FOREIGN KEY
		(
		ProducaoTecnicaId
		) REFERENCES dbo.ProducaoTecnica
		(
		ProducaoTecnicaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.PremioOuTitulo
		DROP CONSTRAINT FK_PremioOuTitulo_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_PremioOuTitulo
		(
		PremioOuTituloId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		SequenciaPremioOuTitulo int NOT NULL,
		NomePremioOuTitulo varchar(250) NOT NULL,
		EntidadePromotoraPremioOuTitulo varchar(150) NULL,
		AnoPremioOuTitulo numeric(4, 0) NOT NULL,
		NomePremioOuTituloEmIngles varchar(150) NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_PremioOuTitulo SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_PremioOuTitulo OFF
	IF EXISTS(SELECT * FROM dbo.PremioOuTitulo)
		 EXEC('INSERT INTO dbo.Tmp_PremioOuTitulo (ProfessorId, SequenciaPremioOuTitulo, NomePremioOuTitulo, EntidadePromotoraPremioOuTitulo, AnoPremioOuTitulo, NomePremioOuTituloEmIngles)
			SELECT ProfessorId, SequenciaPremioOuTitulo, NomePremioOuTitulo, EntidadePromotoraPremioOuTitulo, AnoPremioOuTitulo, NomePremioOuTituloEmIngles FROM dbo.PremioOuTitulo WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_PremioOuTitulo
	DROP TABLE dbo.PremioOuTitulo
	EXECUTE sp_rename N'dbo.Tmp_PremioOuTitulo', N'PremioOuTitulo', 'OBJECT' 
	ALTER TABLE dbo.PremioOuTitulo ADD CONSTRAINT
		PK_PremioOuTitulo_1 PRIMARY KEY CLUSTERED 
		(
		PremioOuTituloId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.PremioOuTitulo ADD CONSTRAINT
		FK_PremioOuTitulo_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.NaturezaProducaoBibligrafica', N'Tmp_NaturezaProducaoBibliografica_2', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.TipoProducaoBibligrafica', N'Tmp_TipoProducaoBibliografica_3', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.TituloProducaoBibligrafica', N'Tmp_TituloProducaoBibliografica_4', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.AnoProducaoBibligrafica', N'Tmp_AnoProducaoBibliografica_5', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.PaisProducaoBibligrafica', N'Tmp_PaisProducaoBibliografica_6', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.MeioDivulgacaoProducaoBibligrafica', N'Tmp_MeioDivulgacaoProducaoBibliografica_7', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.HomePageProducaoBibligrafica', N'Tmp_HomePageProducaoBibliografica_8', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.DOIProducaoBibligrafica', N'Tmp_DOIProducaoBibliografica_9', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.ISBNProducaoBibligrafica', N'Tmp_ISBNProducaoBibliografica_10', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.InformacoesAdicionaisProducaoBibligrafica', N'Tmp_InformacoesAdicionaisProducaoBibliografica_11', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.DivulgacaoCeTProducaoBibligrafica', N'Tmp_DivulgacaoCeTProducaoBibliografica_12', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.InformacoesAdicionaisEmInglesProducaoBibligrafica', N'Tmp_InformacoesAdicionaisEmInglesProducaoBibliografica_13', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.TituloEmInglesProducaoBibligrafica', N'Tmp_TituloEmInglesProducaoBibliografica_14', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_NaturezaProducaoBibliografica_2', N'NaturezaProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_TipoProducaoBibliografica_3', N'TipoProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_TituloProducaoBibliografica_4', N'TituloProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_AnoProducaoBibliografica_5', N'AnoProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_PaisProducaoBibliografica_6', N'PaisProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_MeioDivulgacaoProducaoBibliografica_7', N'MeioDivulgacaoProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_HomePageProducaoBibliografica_8', N'HomePageProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_DOIProducaoBibliografica_9', N'DOIProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_ISBNProducaoBibliografica_10', N'ISBNProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_InformacoesAdicionaisProducaoBibliografica_11', N'InformacoesAdicionaisProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_DivulgacaoCeTProducaoBibliografica_12', N'DivulgacaoCeTProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_InformacoesAdicionaisEmInglesProducaoBibliografica_13', N'InformacoesAdicionaisEmInglesProducaoBibliografica', 'COLUMN' 
	EXECUTE sp_rename N'dbo.ProducaoBibliografica.Tmp_TituloEmInglesProducaoBibliografica_14', N'TituloEmInglesProducaoBibliografica', 'COLUMN' 
	ALTER TABLE dbo.ProducaoBibliografica SET (LOCK_ESCALATION = TABLE)
	COMMIT

	EXECUTE sp_rename N'dbo.ProducaoBibligraficaPalavraChave', N'ProducaoBibliograficaPalavraChave', 'OBJECT' 
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.VinculoAtuacaoProfissional
		DROP CONSTRAINT FK_AtuacaoProfissional_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.VinculoAtuacaoProfissional
		DROP CONSTRAINT FK_AtuacaoProfissional_InstituicaoEmpresa
	ALTER TABLE dbo.InstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_VinculoAtuacaoProfissional
		(
		VinculoAtuacaoProfissionalId int NOT NULL IDENTITY (1, 1),
		ProfessorId int NOT NULL,
		SequenciaVinculoAtuacaoProfissional int NOT NULL,
		InstituicaoEmpresaId int NOT NULL,
		SequenciaImportanciaVinculoAtuacaoProfissional int NULL,
		DataInicioVinculoAtuacaoProfissional date NOT NULL,
		DataTerminoVinculoAtuacaoProfissional date NULL,
		EnquadramentoFuncionalVinculoAtuacaoProfissional varchar(100) NULL,
		TipoVinculoVinculoAtuacaoProfissional varchar(20) NULL,
		DescricaoVinculoAtuacaoProfissional varchar(2000) NULL,
		VinculoEmpregaticioVinculoAtuacaoProfissional bit NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_VinculoAtuacaoProfissional SET (LOCK_ESCALATION = TABLE)
	SET IDENTITY_INSERT dbo.Tmp_VinculoAtuacaoProfissional OFF
	IF EXISTS(SELECT * FROM dbo.VinculoAtuacaoProfissional)
		 EXEC('INSERT INTO dbo.Tmp_VinculoAtuacaoProfissional (ProfessorId, SequenciaVinculoAtuacaoProfissional, InstituicaoEmpresaId, SequenciaImportanciaVinculoAtuacaoProfissional, DataInicioVinculoAtuacaoProfissional, DataTerminoVinculoAtuacaoProfissional, EnquadramentoFuncionalVinculoAtuacaoProfissional, TipoVinculoVinculoAtuacaoProfissional, DescricaoVinculoAtuacaoProfissional, VinculoEmpregaticioVinculoAtuacaoProfissional)
			SELECT ProfessorId, SequenciaVinculoAtuacaoProfissional, InstituicaoEmpresaId, SequenciaImportanciaVinculoAtuacaoProfissional, DataInicioVinculoAtuacaoProfissional, DataTerminoVinculoAtuacaoProfissional, EnquadramentoFuncionalVinculoAtuacaoProfissional, TipoVinculoVinculoAtuacaoProfissional, DescricaoVinculoAtuacaoProfissional, VinculoEmpregaticioVinculoAtuacaoProfissional FROM dbo.VinculoAtuacaoProfissional WITH (HOLDLOCK TABLOCKX)')
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_VinculoAtuacaoProfissional
	DROP TABLE dbo.VinculoAtuacaoProfissional
	EXECUTE sp_rename N'dbo.Tmp_VinculoAtuacaoProfissional', N'VinculoAtuacaoProfissional', 'OBJECT' 
	ALTER TABLE dbo.VinculoAtuacaoProfissional ADD CONSTRAINT
		PK_AtuacaoProfissional PRIMARY KEY CLUSTERED 
		(
		VinculoAtuacaoProfissionalId
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.VinculoAtuacaoProfissional ADD CONSTRAINT
		FK_AtuacaoProfissional_InstituicaoEmpresa FOREIGN KEY
		(
		InstituicaoEmpresaId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.VinculoAtuacaoProfissional ADD CONSTRAINT
		FK_AtuacaoProfissional_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	COMMIT
END
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002')) BEGIN
	BEGIN TRANSACTION
	ALTER TABLE dbo.VinculoAtuacaoProfissional SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.PremioOuTitulo SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.OrientacaoSupervisao SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.FormacaoAcademicaTitulacao SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEvento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.Evento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.ParticipacaoEmProjeto SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.AtividadeProfissional SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_UnidadeInstituicaoEmpresa
	ALTER TABLE dbo.UnidadeInstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_Professor
	ALTER TABLE dbo.Professor SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_ProducaoTecnica
	ALTER TABLE dbo.ProducaoTecnica SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_ProducaoBibliografica
	ALTER TABLE dbo.ProducaoBibliografica SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_PalavraChave
	ALTER TABLE dbo.PalavraChave SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_OrgaoInstituicaoEmpresa
	ALTER TABLE dbo.OrgaoInstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_InstituicaoEmpresa
	ALTER TABLE dbo.InstituicaoEmpresa SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_Idioma
	ALTER TABLE dbo.Idioma SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_Curso
	ALTER TABLE dbo.Curso SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_BancaJulgadora
	ALTER TABLE dbo.BancaJulgadora SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_BancaDeTrabalho
	ALTER TABLE dbo.BancaDeTrabalho SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_AreaConhecimento
	ALTER TABLE dbo.AreaConhecimento SET (LOCK_ESCALATION = TABLE)
	COMMIT
	
	BEGIN TRANSACTION
	ALTER TABLE dbo.BaseDeConsulta
		DROP CONSTRAINT FK_BaseDeConsulta_AgenciaFinanciadora
	ALTER TABLE dbo.AgenciaFinanciadora SET (LOCK_ESCALATION = TABLE)
	COMMIT

	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_BaseDeConsulta
		(
		ProfessorId int NOT NULL,
		AnoBaseDeConsulta numeric(4, 0) NOT NULL,
		SequenciaBaseDeConsulta int NOT NULL,
		InstituicaoEmpresaId int NULL,
		UnidadeInstituicaoEmpresaId int NULL,
		OrgaoInstituicaoEmpresaId int NULL,
		AreaConhecimentoId int NULL,
		PalavraChaveId int NULL,
		IdiomaId int NULL,
		CursoId int NULL,
		ProjetoId int NULL,
		EventoId int NULL,
		AgenciaFinanciadoraId int NULL,
		ProducaoBibliograficaId int NULL,
		ProducaoTecnicaId int NULL,
		BancaDeTrabalhoId int NULL,
		BancaJulgadoraId int NULL,
		AtividadeProfissionalId int NULL,
		ParticipacaoEventoId int NULL,
		FormacaoAcademicaTitulacaoId int NULL,
		OrientacaoSupervisaoId int NULL,
		PremioOuTituloId int NULL,
		VinculoAtuacaoProfissionalId int NULL,
		ParticipacaoEmProjetoId int NULL
		)  ON [PRIMARY]
	ALTER TABLE dbo.Tmp_BaseDeConsulta SET (LOCK_ESCALATION = TABLE)
	IF EXISTS(SELECT * FROM dbo.BaseDeConsulta)
		 EXEC('INSERT INTO dbo.Tmp_BaseDeConsulta (ProfessorId, AnoBaseDeConsulta, SequenciaBaseDeConsulta, InstituicaoEmpresaId, UnidadeInstituicaoEmpresaId, OrgaoInstituicaoEmpresaId, AreaConhecimentoId, PalavraChaveId, IdiomaId, CursoId, ProjetoId, AgenciaFinanciadoraId, ProducaoBibliograficaId, ProducaoTecnicaId, BancaDeTrabalhoId, BancaJulgadoraId, AtividadeProfissionalId, ParticipacaoEventoId, FormacaoAcademicaTitulacaoId, OrientacaoSupervisaoId, PremioOuTituloId, VinculoAtuacaoProfissionalId, ParticipacaoEmProjetoId)
				SELECT BC.ProfessorId, BC.AnoBaseDeConsulta, BC.SequenciaBaseDeConsulta, BC.InstituicaoEmpresaId, BC.UnidadeInstituicaoEmpresaId, BC.OrgaoInstituicaoEmpresaId, BC.AreaConhecimentoId, BC.PalavraChaveId, BC.IdiomaId, BC.CursoId, BC.ProjetoId, BC.AgenciaFinanciadoraId, BC.ProducaoBibliograficaId, BC.ProducaoTecnicaId, BC.BancaDeTrabalhoId, BC.BancaJulgadoraId, 
					AT.AtividadeProfissionalId, 
					PE.ParticipacaoEventoId, 
					FAT.FormacaoAcademicaTitulacaoId, 
					OS.OrientacaoSupervisaoId, 
					PT.PremioOuTituloId, 
					VAP.VinculoAtuacaoProfissionalId,
					PP.ParticipacaoEmProjetoId
				FROM dbo.BaseDeConsulta BC WITH (HOLDLOCK TABLOCKX)
					LEFT OUTER JOIN AtividadeProfissional AT ON AT.ProfessorId = BC.ProfessorId AND AT.SequenciaAtividadeProfissional = BC.SequenciaAtividadeProfissional
					LEFT OUTER JOIN FormacaoAcademicaTitulacao FAT ON FAT.ProfessorId = BC.ProfessorId AND FAT.SequenciaFormacaoAcademicaTitulacao = BC.SequenciaFormacaoAcademicaTitulacao
					LEFT OUTER JOIN OrientacaoSupervisao OS ON OS.ProfessorId = BC.ProfessorId AND OS.SequenciaOrientacaoSupervicao = BC.SequenciaOrientacaoSupervicao
					LEFT OUTER JOIN ParticipacaoEmProjeto PP ON PP.ProfessorId = BC.ProfessorId AND PP.ProjetoId = BC.ProjetoId
					LEFT OUTER JOIN ParticipacaoEvento PE ON PE.ProfessorId = BC.ProfessorId AND PE.EventoId = BC.EventoId AND PE.SequenciaParticipacaoEvento = BC.SequenciaAtividadeProfissional
					LEFT OUTER JOIN PremioOuTitulo PT ON PT.ProfessorId = BC.ProfessorId AND PT.SequenciaPremioOuTitulo = BC.SequenciaPremioOuTitulo
					LEFT OUTER JOIN VinculoAtuacaoProfissional VAP ON VAP.ProfessorId = BC.ProfessorId AND VAP.SequenciaVinculoAtuacaoProfissional = BC.SequenciaVinculoAtuacaoProfissional')
	DROP TABLE dbo.BaseDeConsulta
	EXECUTE sp_rename N'dbo.Tmp_BaseDeConsulta', N'BaseDeConsulta', 'OBJECT' 
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		PK_BaseDeConsulta PRIMARY KEY CLUSTERED 
		(
		ProfessorId,
		AnoBaseDeConsulta,
		SequenciaBaseDeConsulta
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_AgenciaFinanciadora FOREIGN KEY
		(
		AgenciaFinanciadoraId
		) REFERENCES dbo.AgenciaFinanciadora
		(
		AgenciaFinanciadoraId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_AreaConhecimento FOREIGN KEY
		(
		AreaConhecimentoId
		) REFERENCES dbo.AreaConhecimento
		(
		AreaConhecimentoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_BancaDeTrabalho FOREIGN KEY
		(
		BancaDeTrabalhoId
		) REFERENCES dbo.BancaDeTrabalho
		(
		BancaDeTrabalhoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_BancaJulgadora FOREIGN KEY
		(
		BancaJulgadoraId
		) REFERENCES dbo.BancaJulgadora
		(
		BancaJulgadoraId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_Curso FOREIGN KEY
		(
		CursoId
		) REFERENCES dbo.Curso
		(
		CursoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_Idioma FOREIGN KEY
		(
		IdiomaId
		) REFERENCES dbo.Idioma
		(
		IdiomaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_InstituicaoEmpresa FOREIGN KEY
		(
		InstituicaoEmpresaId
		) REFERENCES dbo.InstituicaoEmpresa
		(
		InstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_OrgaoInstituicaoEmpresa FOREIGN KEY
		(
		OrgaoInstituicaoEmpresaId
		) REFERENCES dbo.OrgaoInstituicaoEmpresa
		(
		OrgaoInstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_PalavraChave FOREIGN KEY
		(
		PalavraChaveId
		) REFERENCES dbo.PalavraChave
		(
		PalavraChaveId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_ProducaoBibliografica FOREIGN KEY
		(
		ProducaoBibliograficaId
		) REFERENCES dbo.ProducaoBibliografica
		(
		ProducaoBibliograficaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_ProducaoTecnica FOREIGN KEY
		(
		ProducaoTecnicaId
		) REFERENCES dbo.ProducaoTecnica
		(
		ProducaoTecnicaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_Professor FOREIGN KEY
		(
		ProfessorId
		) REFERENCES dbo.Professor
		(
		ProfessorId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_UnidadeInstituicaoEmpresa FOREIGN KEY
		(
		UnidadeInstituicaoEmpresaId
		) REFERENCES dbo.UnidadeInstituicaoEmpresa
		(
		UnidadeInstituicaoEmpresaId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_AtividadeProfissional FOREIGN KEY
		(
		AtividadeProfissionalId
		) REFERENCES dbo.AtividadeProfissional
		(
		AtividadeProfissionalId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_ParticipacaoEmProjeto FOREIGN KEY
		(
		ParticipacaoEmProjetoId
		) REFERENCES dbo.ParticipacaoEmProjeto
		(
		ParticipacaoEmProjetoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_BaseDeConsulta FOREIGN KEY
		(
		ProfessorId,
		AnoBaseDeConsulta,
		SequenciaBaseDeConsulta
		) REFERENCES dbo.BaseDeConsulta
		(
		ProfessorId,
		AnoBaseDeConsulta,
		SequenciaBaseDeConsulta
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_Evento FOREIGN KEY
		(
		EventoId
		) REFERENCES dbo.Evento
		(
		EventoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_Projeto FOREIGN KEY
		(
		ProjetoId
		) REFERENCES dbo.Projeto
		(
		ProjetoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_ParticipacaoEvento FOREIGN KEY
		(
		ParticipacaoEventoId
		) REFERENCES dbo.ParticipacaoEvento
		(
		ParticipacaoEventoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_FormacaoAcademicaTitulacao FOREIGN KEY
		(
		FormacaoAcademicaTitulacaoId
		) REFERENCES dbo.FormacaoAcademicaTitulacao
		(
		FormacaoAcademicaTitulacaoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_OrientacaoSupervisao FOREIGN KEY
		(
		OrientacaoSupervisaoId
		) REFERENCES dbo.OrientacaoSupervisao
		(
		OrientacaoSupervisaoId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_PremioOuTitulo FOREIGN KEY
		(
		PremioOuTituloId
		) REFERENCES dbo.PremioOuTitulo
		(
		PremioOuTituloId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	ALTER TABLE dbo.BaseDeConsulta ADD CONSTRAINT
		FK_BaseDeConsulta_VinculoAtuacaoProfissional FOREIGN KEY
		(
		VinculoAtuacaoProfissionalId
		) REFERENCES dbo.VinculoAtuacaoProfissional
		(
		VinculoAtuacaoProfissionalId
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
	
	COMMIT
END
GO

IF (NOT EXISTS(SELECT VersaoBanco FROM ControleVersaoBanco WHERE VersaoBanco = '01.002'))
	INSERT INTO ControleVersaoBanco (VersaoBanco, DataAtualizacao) VALUES('01.002', GETDATE())
GO
