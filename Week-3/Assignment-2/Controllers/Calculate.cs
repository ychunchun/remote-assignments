using Microsoft.AspNetCore.Mvc;


[ApiController]//自動應用一些預設行為
[Route("[controller]")]//自訂 API 的路由規則
public class DataController : ControllerBase
//繼承 ControllerBase 類別能夠使用各種用於處理請求、回傳回應和控制流程的方法，例如 Ok、BadRequest、NotFound 等。此外，也提供各種用於處理模型繫結、驗證、路由和其他 Web API 相關功能的屬性和方法。
{
    [HttpGet]
public IActionResult Get(string? number)
//string?，以允許接受可空的字串值，即使未提供 number 參數，該值仍然可以為 null
{
    if (string.IsNullOrEmpty(number))
    {
        return Content("Lack of Parameter");
    }

    if (!int.TryParse(number, out int parsedNumber) || parsedNumber <= 0)
    //parsedNumber用於存儲轉換後的數字值
    {
        return Content("Wrong Parameter");
    }

    int sum = Calculate(parsedNumber);
    return Ok($"從 1 到 {parsedNumber} 的數字總和為 {sum}");
}

private int Calculate(int number)
{
    int sum = 0;
    for (int i = 1; i <= number; i++)
    {
        sum += i;
    }
    return sum;
}


}