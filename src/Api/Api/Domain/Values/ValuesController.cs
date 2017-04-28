using Api.Domain.Values.Create;
using Api.Domain.Values.Detail;
using Api.Domain.Values.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Domain.Values
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        internal const string GetListRouteName = "Values_GetList";
        internal const string GetByIdRouteName = "Values_GetById";
        internal const string PostRouteName = "Values_Post";
        internal const string PutRouteName = "Values_Put";
        internal const string DeleteRouteName = "Values_Delete";

        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet(Name = GetListRouteName)]
        public IActionResult Get([FromQuery] ListValuesRequest listValuesRequest)
        {
            var result = _mediator.Send(listValuesRequest ?? new ListValuesRequest()).Result;
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id:int:min(1)}", Name = GetByIdRouteName)]
        public IActionResult Get([FromRoute] DetailValuesRequest detailValuesRequest)
        {
            var result = _mediator.Send(detailValuesRequest).Result;
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/values
        [HttpPost(Name = PostRouteName)]
        public IActionResult Post([FromBody] CreateValuesRequest createValuesRequest)
        {
            var result = _mediator.Send(createValuesRequest).Result;

            return CreatedAtRoute(GetByIdRouteName, new DetailValuesRequest {Id = result.Id}, result);
        }

        // PUT api/values/5
        [HttpPut("{id}", Name = PutRouteName)]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}", Name = DeleteRouteName)]
        public void Delete(int id)
        {
        }
    }
}
