/// <summary>  
/// Модель должности.  
/// Включает раздел (IT/финансы/реклама) и название (программист, дизайнер и т.д.).  
/// </summary>  
public class JobPosition
{
    public int Id { get; set; }
    public JobCategory Category { get; set; }  // Из перечисления Enums.cs  
    public string Title { get; set; }
}