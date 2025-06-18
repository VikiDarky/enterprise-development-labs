/// <summary>  
/// Заявка работодателя на поиск сотрудника.  
/// Содержит требования, предлагаемую зарплату и дату подачи.  
/// </summary>  
public class EmployerRequest
{
    public int Id { get; set; }
    public int EmployerId { get; set; }
    public Employer Employer { get; set; }
    public int JobPositionId { get; set; }
    public JobPosition JobPosition { get; set; }
    public string Requirements { get; set; }
    public decimal OfferedSalary { get; set; }
    public DateTime ApplicationDate { get; set; }
}