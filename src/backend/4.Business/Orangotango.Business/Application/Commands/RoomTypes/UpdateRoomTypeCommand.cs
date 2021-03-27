using FluentValidation;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Business.Helpers;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.RoomTypes
{
    public class UpdateRoomTypeCommand : Command
    {
        public UpdateRoomTypeInputModel InputModel { get; private set; }

        public UpdateRoomTypeCommand(UpdateRoomTypeInputModel inputModel)
        {
            AggregateId = inputModel.Id;
            InputModel = inputModel;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRoomTypeValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateRoomTypeValidation : AbstractValidator<UpdateRoomTypeCommand>
        {
            public UpdateRoomTypeValidation()
            {
                RuleFor(updateRoomTypeCommand => updateRoomTypeCommand.AggregateId)
                    .NotEqual(Guid.Empty)
                    .WithMessage(ValidationMessageHelper.IdentifierIsInvalid());

                RuleFor(updateRoomTypeCommand => updateRoomTypeCommand.InputModel.Name)
                    .NotEmpty()
                    .WithMessage(ValidationMessageHelper.NotInformed("nome da categoria"));
            }
        }
    }
}
