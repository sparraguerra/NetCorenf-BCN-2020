namespace NetCoreConf.BCN.API.API.Avengers.v3
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreConf.BCN.API.Domain;
    using NetCoreConf.BCN.API.Model;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("3.0")]
    //[ApiVersion("3.1")]
    //[ODataRoutePrefix("Avenger")]
    [Route("api/[controller]")]
    //[Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AvengersController : ODataController
    {
        private readonly IAvengerDomain avengerDomain;

        public AvengersController(IAvengerDomain avengerDomain)
        {
            this.avengerDomain = avengerDomain;
        }

        /// <summary>
        /// Get Avengers
        /// </summary>
        [SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<Avenger>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        [EnableQuery()]
        [HttpGet(Name = "Get All Avengers")]
        public async Task<IActionResult> Get()
        {
            var result = await avengerDomain.GetAllAsync();

            return Ok(result);
        }

        ///// <summary>
        ///// Get Avengers
        ///// </summary>
        //[SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        //[SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<Avenger>))]
        //[SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        //[SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        //[HttpGet(Name = "Get All Avengers"), MapToApiVersion("3.1")]

        //public IActionResult Getv31(ODataQueryOptions<Avenger> filter)
        //{
      
        //    var result = avengerDomain.GetAllAsync(filter);
        //    return Ok(result);
        //}

    }
}