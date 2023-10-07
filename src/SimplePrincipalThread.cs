using System;
using System.Security.Principal;
using System.Security;
using System.Threading;

namespace Samples{
public class SimplePrincipalThread{
public static int Main(string[] args)
{
Console.WriteLine("\n");
Console.WriteLine("===================");
if(args.Length > 0 && args.Length < 3){
try{
if(args[0].ToLower().Equals("true"))
AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
WindowsPrincipal wp = (WindowsPrincipal)Thread.CurrentPrincipal;
Console.WriteLine("Login: {0}",wp.Identity.Name);
Console.WriteLine("Esta autentificado: {0}",wp.Identity.IsAuthenticated);
Console.WriteLine("Tipo de autentificación: {0}",wp.Identity.AuthenticationType);	
Roles roles = new Roles();
string rid = args[1];
if(wp.IsInRole(rid))
Console.WriteLine("Es miembro de {0}",roles[rid]);
else
Console.WriteLine("No es miembro de {0}",roles[rid]);
}
catch(FormatException fe)
{
Console.WriteLine("Error al asignar el rid.");
Console.WriteLine("Mensaje: {0}",fe.Message);
}
catch(SecurityException se)
{
Console.WriteLine("No tiene permisos para establecer el principal.");
Console.WriteLine("Mensaje: {0}",se.Message);
}
catch(InvalidCastException ie){
Console.WriteLine("Error al obtener el principal.");
Console.WriteLine("Mensaje: {0}",ie.Message);
}
}else
Usage();
return 0;
} //fin de main

static void Usage(){
Console.WriteLine("Usar:");
Console.WriteLine("SimplePrincipalThread [true|false] [rid(hex)]");
Console.WriteLine("ejemplo: SimplePrincipalThread true 0x222");
}
}
}
