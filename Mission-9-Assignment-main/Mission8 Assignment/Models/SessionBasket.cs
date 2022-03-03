using System;
using System.Text.Json.Serialization;
using BookProject.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BookProject.Models
{
    public class SessionBasket : Basket
    {


    public static Basket Getbasket (IServiceProvider services)
    {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;


            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
    }

    [JsonIgnore]
    public ISession Session { get; set; }







    public override void AddItem(Book Boo, int qty)
    {
        base.AddItem(Boo, qty);
        Session.SetJson("Basket", this);
    }

    public override void RemoveItem(Book Boo)
    {
        base.RemoveItem(Boo);
        Session.SetJson("Basket", this);
    }

    public override void ClearBasket()
    {
        base.ClearBasket();
        Session.Remove("Basket");
    }
    }
}
