using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;
        private readonly IMapper _mapper;

        public MajorController(IMajorService majorService, IMapper mapper)
        {
            _majorService = majorService;
            _mapper = mapper;
        }
    }
}