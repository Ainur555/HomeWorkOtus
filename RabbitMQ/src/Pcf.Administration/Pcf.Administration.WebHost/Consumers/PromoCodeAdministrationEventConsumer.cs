using MassTransit;
using Pcf.Administration.Core.Abstractions.Repositories;
using Pcf.Administration.Core.Domain.Administration;
using Pcf.Administration.WebHost.Settings.Exceptions;
using Pcf.ReceivingFromPartner.Message;
using System.Threading.Tasks;

namespace Pcf.Administration.WebHost.Consumers
{
    public class PromoCodeAdministrationEventConsumer(IRepository<Employee> repository) : IConsumer<PromoCodeMessage>
    {
        public async Task Consume(ConsumeContext<PromoCodeMessage> context)
        {
            var promoCode = context.Message;
            var employee = await repository.GetByIdAsync((System.Guid)promoCode.PartnerManagerId) ??
                 throw new NotFoundException(Comment.FormatNotFoundErrorMessage((System.Guid)promoCode.PartnerManagerId, "PartnerManager"));

            employee.AppliedPromocodesCount++;
            await repository.UpdateAsync(employee);
        }
    }
}
