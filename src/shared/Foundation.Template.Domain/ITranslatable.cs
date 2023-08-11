using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Models
{
    public interface ITranslatable<TTranslation> where TTranslation : ITranslation
    {
        List<TTranslation> Translations { get; }
    }

    public interface ITranslation
    {
        string LanguageCode { get; }
    }
}