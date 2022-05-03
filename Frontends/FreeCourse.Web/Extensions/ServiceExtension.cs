using FreeCourse.Web.Handlers;
using FreeCourse.Web.Models;
using FreeCourse.Web.Services;
using FreeCourse.Web.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FreeCourse.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();//benim için ilgili sınıflar için http client nesnesi oluştursun
            services.AddHttpClient<IIdentityService, IdentityService>();//benim için uygulama http client nesnesi oluştursun

            services.AddHttpClient<ICatalogService, CatalogService>(opts =>
            {
                opts.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();//CatalogService içeriğine her istek atıldığında clientCredentialTokenHandler delegesi çalışacak
            services.AddHttpClient<IPhotoStockService, PhotoStockService>(opts =>
            {
                opts.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.PhotoStock.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();//PhotoStockService içeriğine her istek atıldığında clientCredentialTokenHandler delegesi çalışacak
            services.AddHttpClient<IUserService, UserService>(opts =>
            {
                opts.BaseAddress = new Uri(serviceApiSettings.IdentityBaseUri);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();// user servisine delege olarak resourceownerpasswordtokenhandler sınıfını verdiğimizden dolayı userservice kullanılan yerlere her istekte çalışacak
            services.AddHttpClient<IBasketService, BasketService>(opts =>
            {
                opts.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Basket.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            services.AddHttpClient<IDiscountService, DiscountService>(opts =>
            {
                opts.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Discount.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            services.AddHttpClient<IPaymentService, PaymentService>(opts =>
            {
                opts.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Payment.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            services.AddHttpClient<IOrderService, OrderService>(opts =>
            {
                opts.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Order.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
        }
    }
}
