using MongoCrudTest.Models;
using MongoCrudTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace SecondModelStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecondController : ControllerBase
{
    private readonly SecondService _SecondService;

    public SecondController(SecondService SecondService) =>
        _SecondService = SecondService;

    [HttpGet]
    public async Task<List<SecondModel>> Get()
    {
        return await _SecondService.GetAsync();
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<SecondModel>> Get(string id)
    {
        var SecondModel = await _SecondService.GetAsync(id);

        if (SecondModel is null)
        {
            return NotFound();
        }

        return SecondModel;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SecondModel newSecondModel)
    {
        await _SecondService.CreateAsync(newSecondModel);

        return CreatedAtAction(nameof(Get), new { id = newSecondModel.Id }, newSecondModel);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, SecondModel updatedSecondModel)
    {
        var SecondModel = await _SecondService.GetAsync(id);

        if (SecondModel is null)
        {
            return NotFound();
        }

        updatedSecondModel.Id = SecondModel.Id;

        await _SecondService.UpdateAsync(id, updatedSecondModel);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var SecondModel = await _SecondService.GetAsync(id);

        if (SecondModel is null)
        {
            return NotFound();
        }

        await _SecondService.RemoveAsync(id);

        return NoContent();
    }
}