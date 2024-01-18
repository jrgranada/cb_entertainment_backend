using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Enums;
using FluentValidation;
using System;

namespace cb_entertainment_backend.Validators
{
    public class SearchRequestValidator : AbstractValidator<SearchRequestDto>
    {
        public SearchRequestValidator()
        {
            RuleFor(searchRequest => searchRequest.Token)
                .NotEmpty()
                .WithMessage("El token es obligatorio");

            RuleFor(searchRequest => searchRequest.Query)
                .NotEmpty()
                .WithMessage("El query es obligatorio");

            RuleFor(searchRequest => searchRequest.Types)
                .NotEmpty()
                .WithMessage("El type es obligatorio");

            RuleFor(searchRequest => searchRequest.Types)
                .Must(OnlyEnumValues)
                .WithMessage("Uno o mas types no son validos");
        }

        private bool OnlyEnumValues(List<TypesSpotify> types)
        {
            return types.All(valor => Enum.IsDefined(typeof(TypesSpotify), valor));
        }
    }
}
