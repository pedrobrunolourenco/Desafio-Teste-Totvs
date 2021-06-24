using ProjetoApp.Domain.Shared.Entidades;
using System;
using System.Linq;

namespace ProjetoApp.Domain.Curriculums.Entidades
{
    public class HistoricoProfisional : EntidadeBase
    {
        protected HistoricoProfisional()
        {

        }

        public HistoricoProfisional(int id, int idcur, DateTime dtinicio, DateTime dtfim, string atividadeexercida)
        {
            Id = id;
            IdCur = idcur;
            DtInicio = dtinicio;
            DtFim = dtfim;
            AtividadeExercida = atividadeexercida;
            Consistente = EstaConsistente();
        }


        public override bool EstaConsistente()
        {
            IdDoCurriculumDeveSerInformado();
            DataDeInicioNaoPodeSerSuperiorADataFinal();
            AtividadeExercidaDeveSerInformada();
            AtividadeExercidaDeveTerUmTamanhoLimite();
            return !ListaErros.Any();
        }

        public int IdCur { get; private set; }
        public DateTime DtInicio { get; private set; }
        public DateTime DtFim { get; private set; }
        public string AtividadeExercida { get; private set; }

        private void IdDoCurriculumDeveSerInformado()
        {
            if (IdCur <= 0) ListaErros.Add("Curriculum deve ser informado.");
        }

        private void DataDeInicioNaoPodeSerSuperiorADataFinal()
        {
            if (DtFim<DtInicio) ListaErros.Add("Data Final não pode ser inferior a data inicial.");
        }

        private void AtividadeExercidaDeveSerInformada()
        {
            if (string.IsNullOrEmpty(AtividadeExercida)) ListaErros.Add("Atividade Exercida deve ser informada.");
        }

        private void AtividadeExercidaDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(AtividadeExercida) && AtividadeExercida.Length > 8000) ListaErros.Add("Atividade Exercida deve ter um tamanho máximo de 8000 caracteres.");
        }






    }
}
