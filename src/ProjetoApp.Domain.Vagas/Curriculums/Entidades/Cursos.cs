using ProjetoApp.Domain.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoApp.Domain.Curriculums.Entidades
{
    public class Cursos : EntidadeBase
    {
        protected Cursos()
        {

        }

        public Cursos(int id, int idcur, DateTime dtinicio, DateTime dtfim, string nomecurso, string instituicao)
        {
            Id = id;
            IdCur = idcur;
            DtInicio = dtinicio;
            DtFim = dtfim;
            NomeCurso = nomecurso;
            Instituicao = instituicao;
            Consistente = EstaConsistente();

        }

        public int IdCur { get; private set; }
        public DateTime DtInicio { get; private set; }
        public DateTime DtFim { get; private set; }
        public string NomeCurso { get; private set; }
        public string Instituicao { get; private set; }

        public override bool EstaConsistente()
        {
            IdDoCurriculumDeveSerInformado();
            DataDeInicioNaoPodeSerSuperiorADataFinal();
            NomeDoCursoDeveSerInformado();
            NomeDoCursoDeveTerUmTamanhoLimite();
            InstituicaoDeveSerInformado();
            InsituicaoDeveTerUmTamanhoLimite();
            return !ListaErros.Any();
        }

        private void IdDoCurriculumDeveSerInformado()
        {
            if (IdCur <= 0) ListaErros.Add("Curriculum deve ser informado.");
        }

        private void DataDeInicioNaoPodeSerSuperiorADataFinal()
        {
            if (DtFim < DtInicio) ListaErros.Add("Data Final não pode ser inferior a data inicial.");
        }

        private void NomeDoCursoDeveSerInformado()
        {
            if (string.IsNullOrEmpty(NomeCurso)) ListaErros.Add("Nome do curso deve ser informado.");
        }

        private void NomeDoCursoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(NomeCurso) && NomeCurso.Length > 200) ListaErros.Add("Nome do Curso deve ter um tamanho máximo de 200 caracteres.");
        }

        private void InstituicaoDeveSerInformado()
        {
            if (string.IsNullOrEmpty(Instituicao)) ListaErros.Add("Insitituicao deve ser informada.");
        }

        private void InsituicaoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(Instituicao) && Instituicao.Length > 200) ListaErros.Add("Instituição deve ter um tamanho máximo de 200 caracteres.");
        }


    }
}
