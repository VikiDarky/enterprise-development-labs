/// <summary>  
/// Модель работодателя.  
/// Содержит название компании, контактное лицо и телефон.  
/// </summary>  
public class Employer
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string ContactPerson { get; set; }
    public string Phone { get; set; }
    public List<EmployerRequest> Requests { get; set; } = new();
}