using System;
using Foundation.Clients.Core.FoundationModels;

namespace XXXXX.Template.Core.Kernel.ViewModels
{
    public class BookDeviceInfosViewModel : LanguageInfosFoundationModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
    }
}