﻿using System;
using Microsoft.Practices.Unity;
using VirtoCommerce.Domain.Payment.Services;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Settings;
using Cyber.Source.Managers;

namespace Cyber.Source
{
    public class Module : ModuleBase
    {
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        #region IModule Members

        public override void PostInitialize()
        {
            var settings = _container.Resolve<ISettingsManager>().GetModuleSettings("CyberSource.SimpleOrder");

            Func<CyberSourceMethod> authorizeNetPaymentMethodFactory = () => new CyberSourceMethod
            {
                Name = "CyberSource payment gateway",
                Description = "CyberSource payment gateway integration",
                LogoUrl = "https://raw.githubusercontent.com/VirtoCommerce/vc-module-CyberSource/master/Cyber.Source/Content/cybersource.jpg",
                Settings = settings,
                IsActive = false
            };

            _container.Resolve<IPaymentMethodsService>().RegisterPaymentMethod(authorizeNetPaymentMethodFactory);
        }

        #endregion
    }
}
