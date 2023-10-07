﻿using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aguacongas.IdentityServer.Admin.Configuration;

/// <summary>
/// Api route attribute
/// </summary>
public class ApiRouteAttribute : Attribute, IRouteTemplateProvider
{
    private int? _order;
    /// <summary>
    /// Creates a new <see cref="ApiRouteAttribute"/> with the given route template.
    /// </summary>
    /// <param name="template">The route template. May not be null.</param>
    public ApiRouteAttribute([StringSyntax("Route")] string template)
    {
        Template = $"{ApiBasePath.Value}{template ?? throw new ArgumentNullException(nameof(template))}";
    }

    /// <inheritdoc />
    [StringSyntax("Route")]
    public string Template { get; }

    /// <summary>
    /// Gets the route order. The order determines the order of route execution. Routes with a lower order
    /// value are tried first. If an action defines a route by providing an <see cref="IRouteTemplateProvider"/>
    /// with a non <c>null</c> order, that order is used instead of this value. If neither the action nor the
    /// controller defines an order, a default value of 0 is used.
    /// </summary>
    public int Order
    {
        get { return _order ?? 0; }
        set { _order = value; }
    }

    /// <inheritdoc />
    int? IRouteTemplateProvider.Order => _order;

    /// <inheritdoc />
    public string? Name { get; set; }
}
