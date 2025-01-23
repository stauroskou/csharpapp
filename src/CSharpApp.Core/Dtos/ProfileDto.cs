namespace CSharpApp.Core.Dtos;

public sealed class Profile
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("role")]
    public string? Role { get; set; }
    [JsonPropertyName("password")]
    public string? Password { get; set; }
    [JsonPropertyName("image")]
    public string? Image { get; set; }
    [JsonPropertyName("creationAt")]
    public DateTime? CreationAt { get; set; }
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
}
