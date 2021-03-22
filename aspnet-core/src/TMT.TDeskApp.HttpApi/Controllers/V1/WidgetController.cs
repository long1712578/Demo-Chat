using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.Objects;
using TMT.TDeskApp.Services;
using TMT.TDeskApp.Widgets;
using Volo.Abp.AspNetCore.Mvc;

namespace TMT.TDeskApp.Controllers.V1
{
    [Route("api/v1/widgets")]
    public class WidgetController : AbpController
    {
        private readonly IWidgetService _widgetService;

        public WidgetController(IWidgetService service)
        {
            _widgetService = service;
        }

        [HttpGet]
        public async Task<List<WidgetDto>> GetListWidget()
        {
            return await _widgetService.GetAllWidget();
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateWidget([FromBody] CreateWidgetDto input)
        {
            ObjectResponse response = new ObjectResponse();

            response = await _widgetService.CreateWidgetAsync(input);
            response.data = null;

            if (response.error.Count < 1 || response.error == null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateWidget(string id, [FromBody]UpdateWidgetDto input)
        {
            ObjectResponse response = new ObjectResponse();
            response = await _widgetService.UpdateWidgetAsync(id, input);
            response.data = null;
            if(response.error.Count < 1 || response.error == null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task DeleteWidget(string id)
        {
            await _widgetService.DeleteWidgetAsync(id);
        }
    }
}
