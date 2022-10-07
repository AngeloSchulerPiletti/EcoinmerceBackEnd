namespace Ecoinmerce.Domain.Objects.VOs.Responses;
public interface IMessageBaseVO
{
    public string Title { get; set; }
    public bool IsError { get; }
    public string ErrorCode { get; }
    public List<string> Messages { get; }
}