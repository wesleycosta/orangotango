using Orangotango.Business.ViewModels.SendEmail;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Services
{
    public interface IEmailService
    {
        Task<bool> Send(EmailContentViewModel emailContent);
    }
}
