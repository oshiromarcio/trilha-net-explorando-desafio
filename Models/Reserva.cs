using System.Diagnostics;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // VALIDA
            if (Suite == null)
            {
                throw new Exception("Suíte não definida, operação cancelada.");
            }
            else if (hospedes == null || hospedes.Count == 0)
            {
                throw new Exception("Não há hóspedes para a reserva, operação cancelada.");
            }
            else if (this.Suite.Capacidade < hospedes.Count)
            {
                throw new Exception("Quantidade de hóspedes ultrapassa a capacidade da suíte, operação cancelada.");
            }

            // CADASTRA
            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = Suite.ValorDiaria * DiasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= .9M;
            }

            return valor;
        }
    }
}