namespace Staff.WebAPI.Dto;

public class EmploymentArchiveRecordDto
{
    public int RecordId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required PositionDto Position { get; set; }
}