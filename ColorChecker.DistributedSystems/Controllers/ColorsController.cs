using ColorChecker.Domain;
using ColorChecker.Domain.Services;
using ColorChecker.Domain.Services.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ColorChecker.DistributedSystems.Controllers
{
    public class ColorsController : ApiController
    {
        private readonly IPixelsServices _pixelsServices;

        public ColorsController(IPixelsServices pxServices)
        {
            _pixelsServices = pxServices;
        }

        // POST: api/Colors

        /// <summary>
        /// Endpoint to register new pixels in the system
        /// </summary>
        /// <param name="values">list of values to create a new pixel</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] List<string> values)
        {

            try
            {
                PixelDTO pxDTO = new PixelDTO().MappingPayloadToDTO(values);
                _pixelsServices.RegisterNewColor(pxDTO);

                return Ok(pxDTO);
            }
            catch (ParsingReqPayloadException ex)
            {
                return BadRequest($"Error when parsing values: {ex.Message}");
            }
            catch (SavingDataException ex)
            {
                return BadRequest($"Error when saving data in database: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
