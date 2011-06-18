This folder is just an example on how an application service component could
be implemented.

Application services should probably be contained in another assembly, so that
the WCF bits don't get mixed up with domain bits.

If an application service needs to invoke something from the WCF framework,
use proper IoC to obtain this.