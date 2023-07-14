using MongoCrudTest.Models;
using MongoCrudTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestModelStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestModelsController : ControllerBase
{
    private readonly TestService _TestService;

    public TestModelsController(TestService TestService) =>
        _TestService = TestService;

    [HttpGet]
    public async Task<List<TestModel>> Get() =>
        await _TestService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<TestModel>> Get(string id)
    {
        var TestModel = await _TestService.GetAsync(id);

        if (TestModel is null)
        {
            return NotFound();
        }

        return TestModel;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TestModel newTestModel)
    {
        await _TestService.CreateAsync(newTestModel);

        return CreatedAtAction(nameof(Get), new { id = newTestModel.Id }, newTestModel);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, TestModel updatedTestModel)
    {
        var TestModel = await _TestService.GetAsync(id);

        if (TestModel is null)
        {
            return NotFound();
        }

        updatedTestModel.Id = TestModel.Id;

        await _TestService.UpdateAsync(id, updatedTestModel);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var TestModel = await _TestService.GetAsync(id);

        if (TestModel is null)
        {
            return NotFound();
        }

        await _TestService.RemoveAsync(id);

        return NoContent();
    }
}