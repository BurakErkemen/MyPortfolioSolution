using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Services.ContactForms;

namespace Portfolio.API.Controllers
{
    [Route("api/ContactForm")]
    [ApiController]
    public class ContactFormController(IContactFormService contactFormService) : CustomBaseController
    {

    }
}
