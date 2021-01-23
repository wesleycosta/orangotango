using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Services
{
    public interface IEmailService
    {
        Task<bool> Send(string to, string subject, string body);
    }
}
