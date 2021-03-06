// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
            new ApiResource("resource_photo_stock"){Scopes={"photo_stock_fullpermission"}},
            new ApiResource("resource_basket"){Scopes={"basket_fullpermission"}},
            new ApiResource("resource_discount"){Scopes={"discount_fullpermission"}},
            new ApiResource("resource_order"){Scopes={"order_fullpermission"}},
            new ApiResource("resource_fake_payment"){Scopes={"fake_payment_fullpermission"}},
            new ApiResource("resource_gateway"){Scopes={"gateway_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){Name="roles",DisplayName="Roles",Description="Kullanıcı Rolleri",UserClaims=new[]{ "role"} } // role isimli claime maple
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Catalog Api için full erişim"),
                new ApiScope("photo_stock_fullpermission","Photo Stock Api için full erişim"),
                new ApiScope("basket_fullpermission","Basket Api için full erişim"),
                new ApiScope("discount_fullpermission","Discount Api için full erişim"),
                new ApiScope("order_fullpermission","Order Api için full erişim"),
                new ApiScope("fake_payment_fullpermission","FakePayment Api için full erişim"),
                new ApiScope("gateway_fullpermission","Gateway Api için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)// kendisi
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId="WebMvcClient",
                    ClientName="AspNet Core MVC",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "gateway_fullpermission","catalog_fullpermission", "photo_stock_fullpermission",IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client
                {
                    ClientId="WebMvcClientForUser",
                    ClientName="AspNet Core MVC",
                    AllowOfflineAccess=true,//refresh token aktif et
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "gateway_fullpermission",  "order_fullpermission","basket_fullpermission",IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName, "roles" },
                    AccessTokenLifetime=1*60*60,//1 saat
                    RefreshTokenExpiration=TokenExpiration.Absolute,// 61.gün refresh token ömrü biter
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,// 60 gün
                    RefreshTokenUsage=TokenUsage.ReUse, // tekrar kullan
                },
                new Client
                {
                    ClientId="TokenExchangeClient",
                    ClientName="Token Exchange",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=new[]{ "urn:ietf:params:oauth:grant-type:token-exchange" },
                    AllowedScopes={"discount_fullpermission","fake_payment_fullpermission",IdentityServerConstants.StandardScopes.OpenId }
                }
            };
    }
}