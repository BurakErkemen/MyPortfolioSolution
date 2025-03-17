using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Services.ContactForms;
using Portfolio.Services.Services.ContactForms.Create;

namespace Portfolio.API.Controllers
{
    [Route("api/ContactForm")]
    [ApiController]
    public class ContactFormController(IContactFormService contactFormService) : CustomBaseController
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return CreateActionResult(await contactFormService.GetAllAsync());
        }


        [HttpGet("getByName/{name:string}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            return CreateActionResult(await contactFormService.GetByNameAsync(name));
        }


        [HttpGet("getByEmail/{email:string}")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            return CreateActionResult(await contactFormService.GetByEmailAsync(email));
        }


        [HttpGet("getByCompanyName/{companyName:string}")]
        public async Task<IActionResult> GetByCompanyName(string companyName)
        {
            return CreateActionResult(await contactFormService.GetByCompanyNameAsync(companyName));
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateContactFormRequest request)
        {
            return CreateActionResult(await contactFormService.CreateAsync(request));
        }


        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return CreateActionResult(await contactFormService.DeleteAsync(id));
        }
    }
}
