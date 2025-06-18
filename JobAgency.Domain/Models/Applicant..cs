/// <summary>  
/// Модель соискателя работы.  
/// Хранит ФИО, контактные данные, опыт, образование и желаемую зарплату.  
/// </summary>  
public class Applicant
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public int WorkExperienceYears { get; set; }
    public string Education { get; set; }
    public decimal DesiredSalary { get; set; }
    public List<ApplicantRequest> Requests { get; set; } = new();
}