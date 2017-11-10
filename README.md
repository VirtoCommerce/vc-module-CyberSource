# CyberSource Simple Order API integration module
CyberSource Simple Order API payment gateway integration module provides integration with CyberSource <a href="https://www.cybersource.com/developers/getting_started/integration_methods/simple_order_api/" target="_blank">Simple Order</a> API.

# Installation
Installing the module:
* Automatically: in VC Manager go to Configuration -> Modules -> CyberSource Simple Order payment gateway -> Install
* Manually: download module zip package from https://github.com/VirtoCommerce/vc-module-CyberSource/releases. In VC Manager go to Configuration -> Modules -> Advanced -> upload module package -> Install.

# Module management and settings UI
![image](https://cloud.githubusercontent.com/assets/5801549/16554443/9565ae46-41d7-11e6-9b8a-1836d8ef760c.png)

# Settings
* **Merchant ID** - CyberSource Merchant ID
* **Transaction Security Keys Directory** - Directory containing file {Merchant ID}.p12. This file should be generated in CyberSource Enterprise Business Center.
* **Work mode** - Type of working mode (test or live)
* **Payment action type** - CyberSource payment method (Sale - authorization and capture in one, Authorization/Capture - operations separated in these 2 steps)


# License
Copyright (c) Virto Solutions LTD.  All rights reserved.

Licensed under the Virto Commerce Open Software License (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

http://virtocommerce.com/opensourcelicense

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied.
