using System.ComponentModel.DataAnnotations;

namespace Sadin.Cms.Presentation.ViewModels.ContactUs;

public sealed class CreateContactMessageViewModel
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Subject { get; set; }
    [Required]
    public string Content { get; set; }
}