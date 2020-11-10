﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace Invoice.Web.App_Start
{
    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly CompositionContainer _compositionContainer;

        public MefControllerFactory(CompositionContainer compositionContainer) => _compositionContainer = compositionContainer;

        protected override IController GetControllerInstance(
            RequestContext requestContext,
            Type controllerType)
        {
            var controllerInstance = base.GetControllerInstance(requestContext, controllerType);
            _compositionContainer.ComposeParts((object)controllerInstance);
            return controllerInstance;
        }
    }
}