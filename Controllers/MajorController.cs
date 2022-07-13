using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.ServiceInterfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace OJTManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService, IMapper mapper)
        {
            _majorService = majorService;
            _mapper = mapper;
        }


    }
}
