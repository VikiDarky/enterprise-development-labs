/// <summary>  
/// Заявка соискателя на должность.  
/// Связывает соискателя с должностью и содержит дату подачи.  
/// </summary>  
public class ApplicantRequest
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public Applicant Applicant { get; set; }
    public int JobPositionId { get; set; }
    public JobPosition JobPosition { get; set; }
    public DateTime ApplicationDate { get; set; }
}