namespace PhysicalPersonDirectory.Api.Middlewares;

public class AcceptLanguageMiddleware
{
    private readonly RequestDelegate _next;

    public AcceptLanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userLangs = context.Request.Headers["Accept-Language"].ToString();
        var firstLang = userLangs.Split('-').FirstOrDefault();
        var lang = "en";
        switch (firstLang)
        {
            case "ka":
                lang = firstLang;
                break;
            default:
                lang = "en";
                break;
        }

        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

        context.Items["ClientLang"] = lang;
        context.Items["ClientCulture"] = Thread.CurrentThread.CurrentUICulture.Name;
        await _next.Invoke(context);
    }
}