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
         
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Quantidade de hospedes ultrapassa capacidade da suite");
            }
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
            
            decimal discount = 0;

            // Para reservas maiores que 9 dias, há desconto de 10%
            if (DiasReservados >= 10)
            {
                discount = .1M;
            }

            decimal precoReservaPorDia = (1 - discount) * Suite.ValorDiaria;
            return precoReservaPorDia * DiasReservados;
        }
    }
}