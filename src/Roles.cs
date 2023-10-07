using System;
namespace Samples{
public class Roles{
//roles de Windows
string[,] roles = {
	{"0x224",@"BUILTIN\Account Operators"},
	{"0x220",@"BUILTIN\Administrators"},
	{"0x227",@"BUILTIN\Backup Operators"},
	{"0x222",@"BUILTIN\Guests"},
	{"0x223",@"BUILTIN\Power Users"},
	{"0x226",@"BUILTIN\Print Operators"},
	{"0x228",@"BUILTIN\Replicators"},
	{"0x225",@"BUILTIN\Server Operators"},
	{"0x221",@"BUILTIN\Users"}
};
public string this[string rid]{
get{
	for(int i = 0;i < (roles.Length/2);i++)
	{
	if(roles[i,0].Equals(rid))
	return 	roles[i,1];
	}
	return "Sin rol";
}
}
}
}
