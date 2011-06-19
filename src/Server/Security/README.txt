This folder contains an example on how the authorization system can be customized.

The CustomAuthorizationPolicy can be enabled by specifying the "Custom" principal
permission mode in the serviceAuthorization element in the service's behavior.

In the Evaluate method, the Sid of the caller can be verified. Moreover, a custom
principal can be supplied, allowing the implementation of IsInRole to be fully
customized.