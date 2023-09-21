using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;

namespace BlogApi.Extentions;

public static class ModelStateExtensions
{
    public static string GetErrors(this ModelStateDictionary model, IStringLocalizer? sLocalizer = null, string separator = ", ") {
        var errors = model.SelectMany(x => x.Value?.Errors.Select(e => e.ErrorMessage) ?? Array.Empty<string>());

        if (sLocalizer != null) {
            errors = errors.Select(x => sLocalizer[x].Value);
        }

        return string.Join(separator, errors);
    }
}