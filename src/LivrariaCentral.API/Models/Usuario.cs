namespace LivrariaCentral.API.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty; 
    public string Nome { get; set; } = string.Empty;
}

// Classe auxiliar para receber os dados do Login/Registro (DTO)
public class UsuarioDTO
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}