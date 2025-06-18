namespace CVGenerate.Core.DTOs.PersonalInfo;

public class PersonalInfoDto
{
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string MaritalStatus { get; set; } = null!;
    public string MilitaryStatus { get; set; } = null!;
    public DateTime? MilitaryPostponeDate { get; set; }
    public string DriverLicense { get; set; } = null!;
}