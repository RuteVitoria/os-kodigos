namespace OrdemServicoApi.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool EquipamentoLimpo { get; set; }
        public bool PecasSubstituidas { get; set; }
        public bool TesteFuncionamento { get; set; }
        public bool AreaOrganizada { get; set; }
        public string? ImagemBase64 { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}