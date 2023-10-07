using System;
using System.Security.Principal;

namespace Samples{
	public class SimplePrincipal{
	public static int Main(string[] args){
	//roles de Windows
	string[] roles = {
	@"BUILTIN\Account Operators",
	@"BUILTIN\Administrators",
	@"BUILTIN\Backup Operators",
	@"BUILTIN\Guests",
	@"BUILTIN\Power Users",
	@"BUILTIN\Print Operators",
	@"BUILTIN\Replicators",
	@"BUILTIN\Server Operators",
	@"BUILTIN\Users"
	};
	WindowsIdentity wi = WindowsIdentity.GetCurrent();
	//usamos el objeto como parámetro
	WindowsPrincipal wp = new WindowsPrincipal(wi);
	//podemos acceder a todas las propiedades del objeto Identity
	//mediante Principal
	Console.WriteLine("\n Información  ");
	Console.WriteLine("=====================\n");
	Console.WriteLine(" Login: {0}",wp.Identity.Name);
	Console.WriteLine(" Esta autentificado: {0}",wp.Identity.IsAuthenticated);
	Console.WriteLine(" Tipo de autentificación: {0}",wp.Identity.AuthenticationType);	
	for(int i = 0;i < roles.Length;i++){
		if(wp.IsInRole(roles[i]))
			Console.WriteLine(" Es miembro de {0}",roles[i]);	
	}
	Console.Write("\nPresione una tecla para continuar...");
	Console.Read();
	return 0;
		}
	}
}
